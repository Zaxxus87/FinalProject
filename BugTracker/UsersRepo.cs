using BugTracker.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker
{
    public class UsersRepo : IUsersRepo
    {
        private readonly IDbConnection _conn;

        public UsersRepo(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Users> GetAllUsers()
        {
            return _conn.Query<Users>("Select * from user;");
        }

        public void InsertUser(Users userToInsert)
        {
            _conn.Execute("INSERT INTO user (FirstName, LastName, Password, email, Title) VALUES (@FirstName, @LastName, @Password, @email, @Title);",
                        new {FirstName = userToInsert.FirstName, Lastname = userToInsert.LastName, Password = userToInsert.Password, 
                            email = $"{userToInsert.FirstName}.{userToInsert.LastName}@email.com", Title = "User"});
        }
    }
}
