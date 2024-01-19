namespace LibraryManagement.Application.Settings
{
    public class AzureStorageSettings
    {
        public string BlobConnectionString { get; set; }
        public string BlobContainerName { get; set; }
        public string SharedAccessSignature { get; set; }
    }
}
