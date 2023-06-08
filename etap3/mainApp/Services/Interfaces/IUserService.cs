using Platformy_Programowania_1.Models;

namespace Platformy_Programowania_1.Services.Interfaces
{
    public interface IUserService
    {
        //Saves new user to database during registration
        int Save(User newUser);
    }
}
