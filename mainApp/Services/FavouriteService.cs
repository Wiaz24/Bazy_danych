//using Microsoft.EntityFrameworkCore;
//using Platformy_Programowania_1.Models;
//using Platformy_Programowania_1.Services.Interfaces;

//namespace Platformy_Programowania_1.Services
//{
//    public class FavouriteService : IFavouritesService
//    {
//        private readonly AppDbContext _dbContext;
//        public FavouriteService(AppDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<string> CreateFavourite(Favourite favourite)
//        {
//            _dbContext.Favourites.Add(favourite);
//            await _dbContext.SaveChangesAsync();
//            return favourite.UserID;
//        }
//        public async Task<int> UpdateFavourite(Favourite favourite)
//        {
//            _dbContext.Favourites.Update(favourite);
//            return await _dbContext.SaveChangesAsync();
//        }
//        public async Task<int> DeleteFavourite(string? user_id, int? comp_id)
//        {
//            if (comp_id == null)
//                return 0;
//            if (user_id == null)
//                return 0;

//            var favourite = await _dbContext.Favourites.FindAsync(user_id, comp_id);
//            if (favourite == null)
//                return 0;

//            _dbContext.Favourites.Remove(favourite);
//            return await _dbContext.SaveChangesAsync();
//        }
//        public Favourite GetFavouriteByUserId(string user_id)
//        {
//            return _dbContext.Favourites.Find(user_id);
//        }
//        public async Task<IEnumerable<Favourite>> GetFavourites()
//        {
//            return await _dbContext.Favourites.ToListAsync();
//        }
//    }
//}
