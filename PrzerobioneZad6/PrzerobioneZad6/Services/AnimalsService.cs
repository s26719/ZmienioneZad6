using System.Data.SqlClient;
using PrzerobioneZad6.Models;
using PrzerobioneZad6.Repositories;

namespace PrzerobioneZad6.Services;

public class AnimalsService
{
    private readonly IAnimalRepository _repository;

    public AnimalsService(IAnimalRepository repository)
    {
        _repository = repository;
    }

    public List<Animal> GetAnimals(string orderBy = "name")
        {
            return _repository.GetAnimals(orderBy);
        }

        public void AddAnimal(Animal animal)
        {
            _repository.AddAnimal(animal);
        }

        public void UpdateAnimal(Animal animal)
        {
            _repository.UpdateAnimal(animal);
        }

        public void DeleteAnimal(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid animal Id");
            }
            _repository.DeleteAnimal(id);
        }
        
        
    
}