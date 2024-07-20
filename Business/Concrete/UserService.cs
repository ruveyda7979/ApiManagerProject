using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {

        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task AddUserAsync(User user)
        {
            await _userDal.AddAsync(user);
        }

        public void DeleteUser(User user)
        {
            user.IsDeleted = true;
            _userDal.Update(user);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userDal.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userDal.GetAsync(u => u.Id == id && u.IsDeleted == false);
        }

        public void UpdateUser(User user)
        {
            _userDal.Update(user);
        }
    }
}
