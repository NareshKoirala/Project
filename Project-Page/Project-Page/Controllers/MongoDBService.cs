using MongoDB.Bson;
using MongoDB.Driver;
using Project_Page.Models;

namespace Project_Page.Controllers
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Users> _usersCollection;

        public MongoDBService(string DB, string CL)
        {
            try
            {
                // Connection string - replace with your MongoDB connection details
                var connectionString = "mongodb+srv://chelseanaresh10:Ivo8RG6aWWyX9bhl@nareshdb.7svphii.mongodb.net/?retryWrites=true&w=majority&appName=NareshDB";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(DB);
                _usersCollection = database.GetCollection<Users>(CL);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initialize MongoDB connection: {ex.Message}");
                throw;
            }
        }

        // Search users by name (case-insensitive)
        public async Task<List<Users>> SearchUsersByEmailAsync(string name)
        {
            try
            {
                var filter = Builders<Users>.Filter.Regex(
                    u => u.Email,
                    new BsonRegularExpression(name, "i")
                );

                var users = await _usersCollection
                    .Find(filter)
                    .ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching users: {ex.Message}");
                throw;
            }
        }

        // Example: Insert a user (for testing)
        public async Task InsertUserAsync(Users user)
        {
            try
            {
                await _usersCollection.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting user: {ex.Message}");
                throw;
            }
        }
    }
}
