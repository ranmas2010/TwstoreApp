namespace TodoAzure
{
    public static class Constants
    {
        // Replace string with your mobile service URL.
        public static string ApplicationURL = @"Endpoint=sb://fcmnotificationhubsnamespace.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=nr3nRUi5aj2jFH2xX0l7q/BBODf47shYpDA+EHgkG6g=";
        public const string ListenConnectionString = @"Endpoint=sb://fcmnotificationhubsnamespace.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=nr3nRUi5aj2jFH2xX0l7q/BBODf47shYpDA+EHgkG6g=";
        public const string NotificationHubName = "FcmNotificationHubsNamespace";
    }
}
