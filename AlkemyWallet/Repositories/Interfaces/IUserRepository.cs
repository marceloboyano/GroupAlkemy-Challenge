﻿using AlkemyWallet.Entities;

namespace AlkemyWallet.Repositories.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<User> GetUserByEmail(string email, string password);
}