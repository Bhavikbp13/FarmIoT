using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;
using Azure.Storage.Blobs;
using Farmiot.Azure;
using Microsoft.Azure.Devices;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text;

namespace Farmiot.Repos
{
    public class ReadingDataRepo
    {
        private EventProcessorClient processor;
        private BlobContainerClient blobContainerClient;
        public List<string> list { get; set; }=  new List<string>();

        private ConcurrentDictionary<string, int> partitionEventCount;

        public ReadingDataRepo()
        {
            //creates a connection to the storage container
            blobContainerClient = new BlobContainerClient(AzureConfig.STORAGE_CONNECTION_STRING, AzureConfig.BLOB_CONTAINER_NAME);
            //creates a connection to the iot hub
            processor = new EventProcessorClient(blobContainerClient, AzureConfig.CONSUMER_GROUP, AzureConfig.EVENT_HUBS_CONNECTION_STRING);           
            partitionEventCount = new ConcurrentDictionary<string, int>();
            
        }

        /// <summary>
        /// process the data from azure and allows checkpoints to be made
        /// so the app knows on where to start reading data
        /// </summary>
        /// <param name="args">Process events</param>
        /// <returns></returns>
        public async Task processEventHandler(ProcessEventArgs args)
        {
            try
            {
                await ProcessEventAsync(
                    args.Data,
                    args.Partition,
                    args.CancellationToken);

                // If the number of events that have been processed
                // since the last checkpoint was created exceeds the
                // checkpointing threshold, a new checkpoint will be
                // created and the count reset.

                string partition = args.Partition.PartitionId;

                int eventsSinceLastCheckpoint = partitionEventCount.AddOrUpdate(
                    key: partition,
                    addValue: 1,
                    updateValueFactory: (_, currentCount) => currentCount + 1);

                if (eventsSinceLastCheckpoint >= AzureConfig.EVENTS_BEFORE_CHECKPOINT)
                {
                    await args.UpdateCheckpointAsync();
                    partitionEventCount[partition] = 0;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error: {e}");
            }
        }
        /// <summary>
        /// Gets the data from azure and parses it accordingly. It gets one payload and it splits it up
        /// based on the special characters included in the payload.
        /// </summary>
        /// <param name="data">Data recieved from the azure </param>
        /// <param name="partition">The partition number from azure</param>
        /// <param name="cancellationToken">the token to cancel the operation</param>
        /// <returns></returns>
        public Task ProcessEventAsync(EventData data, PartitionContext partition, CancellationToken cancellationToken)
        {
            //Clears the previous pay load so that new payloads can be added.

            list.Clear();
            //converts the payload read from the clound into a string 
            string dataAsString = Encoding.UTF8.GetString(data.Body.ToArray());

            //since there is al ot of extra characters in that payload, we remove them from it
            dataAsString = dataAsString.Trim(new char[] { '"', '{', '}' });

            //we replace the extra in the string with empty spaces as we werent able to trim it for some reason 
            dataAsString = dataAsString.Replace("\"", "");
            dataAsString = dataAsString.Replace("]", "");
            dataAsString = dataAsString.Replace("}", "");
            dataAsString = dataAsString.Replace("{", "");
            dataAsString = dataAsString.Replace("[", "");

            //the string was still has commas so we had to split it by commas
            // to get in a key value pair format so we can use the data
            var keyValuePair = dataAsString.Split(',');

            foreach (string keyValue in keyValuePair)
            {
                foreach (string keyValuesPairs in keyValue.Split(':'))
                {
                    list.Add(keyValuesPairs);
                }

            }

            App.MainViewModel.RefreshView();

            return Task.CompletedTask;
        }

        /// <summary>
        /// If the process goes wrong it calls this method and throws the error
        /// </summary>
        /// <param name="args">An error in the process</param>
        /// <returns></returns>
        public Task processErrorHandler(ProcessErrorEventArgs args)
        {
            try
            {
                Debug.WriteLine("Error in the EventProcessorClient");
                Debug.WriteLine($"\tOperation: { args.Operation }");
                Debug.WriteLine($"\tException: { args.Exception }");
                Debug.WriteLine("");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error: {e}");
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets the data from azure and process it accordingly. Will throw an exception if 
        /// the tasks gets cancelled and will display a pop up message
        /// </summary>
        public async Task ReadDataFromCloud()
        {
            try
            {
                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

                processor.ProcessEventAsync += processEventHandler;
                processor.ProcessErrorAsync += processErrorHandler;

                try
                {
                    await processor.StartProcessingAsync(cancellationSource.Token);
                    await Task.Delay(Timeout.Infinite, cancellationSource.Token);
                }
                catch (TaskCanceledException e)
                {
                    Debug.WriteLine($"Error: {e}");
                    await Application.Current.MainPage.DisplayAlert("ERROR", "Error Occured on Server Side. Please Try Again!", "Cancel");
                }
                finally
                {
                    await processor.StopProcessingAsync();
                }
            }
            catch (Exception e)
            {
                string s = e.Message;
            }
            finally
            {
                processor.ProcessEventAsync -= processEventHandler;
                processor.ProcessErrorAsync -= processErrorHandler;
            }
        }

        public static async void ReportConnectivity(string property,string state,bool isThreshold,double threshold)
        {
            try
            {

                var manager = RegistryManager.CreateFromConnectionString(AzureConfig.IOT_HUB_CONNECTION_STRING);
                
                var twin = await manager.GetTwinAsync(AzureConfig.DEVICE_ID);
                
                //if its a threshold value then it will set the desired properties as a double but 
                //if its  string the it sets the properties as a string
                if(isThreshold)
                    twin.Properties.Desired[property] = threshold;
                else
                    twin.Properties.Desired[property] = state;
                await manager.UpdateTwinAsync(twin.DeviceId, twin, twin.ETag);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

    }
}
