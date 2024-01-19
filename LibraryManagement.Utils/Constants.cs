namespace LibraryManagement.Utils
{
    public static class Constants
    {
        public const string UserWasNotFound = "The user was not found.";
        public const string InvalidEmail = "The email address is not valid.";
        public const string InvalidPassword = "The password is not valid.";
        public const string InvalidBase64String = "The string sent to AzureStorage was in the wrong format.";
        public const string FileNameInUse = "A file with this name already exists.";
        public const string FileNotExistent = "A file with this name doesn't exists.";
        public const string ErrorWhileStoringImage = "An error occured when uploading the file to AzureStorage";
    }
}
