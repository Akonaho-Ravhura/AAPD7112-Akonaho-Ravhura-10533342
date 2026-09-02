namespace Municipal_Application.Models
{
    public class Resident : User
    {
        /// <summary>
        /// South African ID number. This is the unique identifier for a resident.
        /// </summary>
        public string IdNumber { get; set; } = string.Empty;

        public string ContactNumber { get; set; } = string.Empty;
    }
}
