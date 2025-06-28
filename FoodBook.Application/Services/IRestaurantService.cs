public interface IRestaurantService
{
    Task<RestaurantDto> CreateRestaurantAsync(CreateRestaurantDto createRestaurantDto);
    Task<RestaurantDto> GetRestaurantByIdAsync(int id);
    Task<IEnumerable<RestaurantDto>> GetAllRestaurantsAsync();
    Task<IEnumerable<RestaurantDto>> SearchRestaurantsAsync(string searchTerm);
    Task UpdateRestaurantAsync(int id, UpdateRestaurantDto updateRestaurantDto);
    Task DeleteRestaurantAsync(int id);
}