using MongoDB.Bson;

namespace Project_Page.Models
{
    public class Users
    {
        public ObjectId _id { get; set; }
        public required string name {  get; set; }
        public required string email { get; set; }
        public required string username { get; set; }
        public required string password { get; set; }
        public required string role { get; set; }
    }
}
