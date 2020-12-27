namespace Users.API.Model.Requests
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PhotoUrl { get; set; }
    }
}
