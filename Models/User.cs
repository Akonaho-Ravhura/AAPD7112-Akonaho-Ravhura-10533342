namespace Municipal_Application.Models
{
    public abstract class User
    {
        public string Username { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
    }
}
