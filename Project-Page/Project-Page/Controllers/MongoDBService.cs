using Microsoft.CodeAnalysis;
using MongoDB.Bson;
using MongoDB.Driver;
using Org.BouncyCastle.Crypto.Generators;
using Project_Page.Models;

namespace Project_Page.Controllers
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Users> _usersCollection;
        private readonly IMongoCollection<Projects> _projectCollection;

        public MongoDBService()
        {
            try
            {
                // Connection string - replace with your MongoDB connection details
                var connectionString = "mongodb+srv://chelseanaresh10:Ivo8RG6aWWyX9bhl@nareshdb.7svphii.mongodb.net/?retryWrites=true&w=majority&appName=NareshDB";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("Project_Page");
                _projectCollection = database.GetCollection<Projects>("Project");
                _usersCollection = database.GetCollection<Users>("User");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initialize MongoDB connection: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Get all the Project from the collection
        /// </summary>
        /// <returns></returns>
        public List<Projects> ProjectLS() => _projectCollection.Find(Builders<Projects>.Filter.Empty).ToList();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Users> UserLS() => _usersCollection.Find(Builders<Users>.Filter.Empty).ToList();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string RoleCheck(string email)
        {
            var filter = Builders<Users>.Filter.Eq(u => u.email, email);
            var user = _usersCollection.Find(filter).FirstOrDefault();
            if (user != null)
            {
                return user.role;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User not found");
                Console.ResetColor();
                return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> LogInCred(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            try
            {
                // Normalize email (e.g., convert to lowercase) if needed
                email = email.Trim().ToLowerInvariant();

                // Use equality filter instead of regex
                var filter = Builders<Users>.Filter.Eq(u => u.email, email);

                // Fetch a single user
                var user = await _usersCollection
                    .Find(filter)
                    .FirstOrDefaultAsync();

                // If no user found, return false
                if (user == null)
                {
                    // Log safely, avoiding sensitive data

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"User not found for email: {email}");
                    Console.ResetColor();

                    return false;
                }

                // Verify hashed password (assuming Password is a hashed password)
                return user.password == password;
            }
            catch (Exception ex)
            {
                // Log safely, avoiding sensitive data
                Console.WriteLine($"Error during login attempt: {ex.Message}");
                throw; // Consider a more specific exception for the caller
            }
        }
        
        public async Task UserInsertCheck(Users _user) 
        {
            var filter = Builders<Users>.Filter.Eq(u => u.email, _user.email);
            var user = await _usersCollection.FindAsync(filter);

            if (user != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Email Already Exist");
                Console.ResetColor();
                return;
            }
            
            filter = Builders<Users>.Filter.Eq(u => u.username, _user.username);

            await InsertUserAsync(_user);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task InsertUserAsync(Users user) => await _usersCollection.InsertOneAsync(user);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        private async Task InsertProjectAsync(Projects project) => await _projectCollection.InsertOneAsync(project);


    }
}



/*
 * 
 * 
                var filter = Builders<Users>.Filter.Regex(
                    u => u.Name,
                    new BsonRegularExpression(name, "i")
                );

                var users = await _usersCollection
                    .Find(filter)
                    .ToListAsync();

                return users;
*/