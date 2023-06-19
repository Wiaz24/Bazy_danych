using Bazy_danych.Models;

namespace Bazy_danych.Services.Interfaces
{
    public interface IUserService
    {
        float GetBalanceById(string id);
        int GetAccountTypeById(string id);
    }
}
