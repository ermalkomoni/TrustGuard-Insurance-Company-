﻿using PropertyService.Models;

namespace PropertyService.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

        public IQueryable<User> GetAllUsers()
        {
            return _dbContext.Set<User>();
        }

        public User GetUserById(int id)
        {
            
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            return user is null ? throw new NullReferenceException(nameof(user)) : user;
        
        }

        public bool CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _dbContext.Set<User>().Add(user);
            return true;
        }
    }
}
