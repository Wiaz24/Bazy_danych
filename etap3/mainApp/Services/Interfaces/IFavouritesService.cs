﻿using Platformy_Programowania_1.Models;

namespace Platformy_Programowania_1.Services.Interfaces
{
    public interface IFavouritesService
    {
        Task<string> CreateFavourite(Favourite daily);
        Task<int> UpdateFavourite(Favourite daily);
        Task<int> DeleteFavourite(int? id);
        Favourite GetFavouriteByUserId(string user_id);
        Task<IEnumerable<Favourite>> GetFavourites();
    }
}
