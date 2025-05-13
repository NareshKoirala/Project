using MongoDB.Bson;

namespace Project_Page.Models
{
    public class Users
    {
        public ObjectId Id { get; set; }
        public required string Name {  get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
