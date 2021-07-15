using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker
{
    public interface IUsersRepo
    {
        public IEnumerable<Users> GetAllUsers();
        public void InsertUser(Users userToInsert);
        public Users GetUserByFirstAndLastName(String firstName, string lastName);
        public Users GetUser(int id);
        public void UpdateUser(Users user);
        public void DeleteUser(Users user);

    }
}
