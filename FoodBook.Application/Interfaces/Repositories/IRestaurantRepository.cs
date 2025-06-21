// IRestaurantRepository.cs
public interface IRestaurantRepository
{
    Task<Restaurant> GetByIdAsync(int id);
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<IEnumerable<Restaurant>> SearchByNameAsync(string name);
    Task<Restaurant> AddAsync(Restaurant restaurant);
    Task UpdateAsync(Restaurant restaurant);
    Task DeleteAsync(int id);
}