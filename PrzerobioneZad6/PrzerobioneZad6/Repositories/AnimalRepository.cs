using System.Data.SqlClient;
using PrzerobioneZad6.Models;

namespace PrzerobioneZad6.Repositories;


public class AnimalRepository : IAnimalRepository
{

    private readonly string connectionString;

    public AnimalRepository(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public List<Animal> GetAnimals(string orderBy = "name")
    {
        var query = $"SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY {orderBy}";


        var animals = new List<Animal>();
        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(query, connection);
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    animals.Add(new Animal
                    {
                        IdAnimal = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Category = reader.GetString(3),
                        Area = reader.GetString(4)
                    });
                }
                connection.Close();
            }
        }
        


        return animals;
    }

    public void AddAnimal(Animal animal)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query =
                "INSERT INTO Animal (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("Name", animal.Name);
            command.Parameters.AddWithValue("Description", animal.Description);
            command.Parameters.AddWithValue("Category", animal.Category);
            command.Parameters.AddWithValue("Area", animal.Area);
            
            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void UpdateAnimal(Animal animal)
    {
        using (SqlConnection conenction = new SqlConnection(connectionString))
        {
            string query =
                "UPDATE Animal SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @IdAnimal";
            SqlCommand command = new SqlCommand(query, conenction);

            command.Parameters.AddWithValue("IdAnimal", animal.IdAnimal);
            command.Parameters.AddWithValue("Name", animal.Name);
            command.Parameters.AddWithValue("Description", animal.Description);
            command.Parameters.AddWithValue("Category", animal.Category);
            command.Parameters.AddWithValue("Area", animal.Area);
            conenction.Open();
            command.ExecuteNonQuery();
        }
    }

    public void DeleteAnimal(int id)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("IdAnimal", id);
            connection.Open();
            command.ExecuteNonQuery();
        }
        
    }

}