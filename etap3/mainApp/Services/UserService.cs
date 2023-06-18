using Org.BouncyCastle.Crypto.Digests;
using Platformy_Programowania_1.Models;
using Platformy_Programowania_1.Services.Interfaces;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Platformy_Programowania_1.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public float GetBalanceById(string id)
        {
            return _dbContext.Users.Find(id).Balance;
        }
        public int GetAccountTypeById(string id)
        {
            return _dbContext.Users.Find(id).AccountType;
        }
    }
}
