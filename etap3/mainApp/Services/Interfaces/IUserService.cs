using Platformy_Programowania_1.Models;

namespace Platformy_Programowania_1.Services.Interfaces
{
    public interface IUserService
    {
        float GetBalanceById(string id);
        int GetAccountTypeById(string id);
    }
}
