﻿using ProductAPI.Entities;

namespace Dapper_Sample_Project.IRepository
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsers();
        Task<User> GetUser(int id);
    }
}
