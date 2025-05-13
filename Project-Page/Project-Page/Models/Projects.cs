using MongoDB.Bson;

namespace Project_Page.Models
{
    public class Projects
    {
        public ObjectId Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public required string MoreDetail { get; set; }
    }
}
