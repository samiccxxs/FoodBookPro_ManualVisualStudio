
public record RestaurantDto(int Id, string Name, string Description, string Address, string Phone);
public record CreateRestaurantDto(string Name, string Description, string Address, string Phone);
public record UpdateRestaurantDto(string Name, string Description, string Address, string Phone);