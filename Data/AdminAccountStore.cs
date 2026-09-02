namespace Municipal_Application.Data
{
    
    /// Hardcoded admin credentials for the initial prototype.
    /// Replace with a real authentication mechanism when one is required.
    
    public static class AdminAccountStore
    {
        private const string AdminUsername = "admin";
        private const string AdminPassword = "Admin123";

        public static bool Validate(string username, string password)
        {
            return username == AdminUsername && password == AdminPassword;
        }
    }
}
