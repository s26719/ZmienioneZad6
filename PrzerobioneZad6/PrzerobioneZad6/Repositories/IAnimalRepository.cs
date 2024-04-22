namespace PrzerobioneZad6.Repositories;
using PrzerobioneZad6.Models;
public interface IAnimalRepository
{
    List<Animal> GetAnimals(string orderBy);
    void AddAnimal(Animal animal);
    void UpdateAnimal(Animal animal);
    void DeleteAnimal(int id);
}