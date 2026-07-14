using System;
using System.Collections.Generic;
using System.Text;

namespace Farmiot.Azure
{
    /// <summary>
    /// All configuration made in order to connect to the azure hub and container. 
    /// </summary>
    public static class AzureConfig
    {
        public const string EVENT_HUBS_CONNECTION_STRING = "Endpoint=sb://ihsuprodytres005dednamespace.servicebus.windows.net/;SharedAccessKeyName=iothubowner;SharedAccessKey=Xkx7JsVFdbAvC7wwOmR42zOkaxYVE3MSjjrBpipX68c=;EntityPath=iothub-ehub-co-w22-mb1-18100960-5ec4aa9947";
        public const string CONSUMER_GROUP = "$Default";
        public const string STORAGE_CONNECTION_STRING = "DefaultEndpointsProtocol=https;AccountName=co1866168;AccountKey=rIfheuILiYN39AxUfzK4Q/+FqwoTZW4d2/T8eRwTSAIZd/IGMow4DeWw0F/jb4SP1turbpuv/+u8+ASta6jZ9w==;EndpointSuffix=core.windows.net";
        public const string BLOB_CONTAINER_NAME = "lab8container";
        public const int EVENTS_BEFORE_CHECKPOINT = 25;
        public const string IOT_HUB_CONNECTION_STRING = "HostName=CO-W22-MB1866168-HUB.azure-devices.net;DeviceId=Test-Device;SharedAccessKey=JUbv+mbOFuo2HBpV+6FvNYL+QT9j07CqKz+MBDlWd+w=";
        public const string DEVICE_ID = "Test-Device";
    }
}
