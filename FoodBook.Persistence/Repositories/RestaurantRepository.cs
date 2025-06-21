// RestaurantRepository.cs
using Microsoft.EntityFrameworkCore;
using FoodBook.Application.Interfaces.Repositories;
using FoodBook.Domain.Entities;
using FoodBook.Persistence.Context;

namespace FoodBook.Persistence.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly FoodBookDbContext _context;

        public RestaurantRepository(FoodBookDbContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await _context.Restaurants
                .Include(r => r.MenuItems)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            return await _context.Restaurants
                .Include(r => r.MenuItems)
                .ToListAsync();
        }

        public async Task<IEnumerable<Restaurant>> SearchByNameAsync(string name)
        {
            return await _context.Restaurants
                .Where(r => r.Name.Contains(name))
                .Include(r => r.MenuItems)
                .ToListAsync();
        }

        public async Task<Restaurant> AddAsync(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();
            }
        }
    }
}
