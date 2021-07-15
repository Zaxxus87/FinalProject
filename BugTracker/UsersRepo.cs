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

        public Users GetUserByFirstAndLastName(String firstName, string lastName)
        {
            var title =  _conn.QuerySingle<Users>("Select * from user where FirstName = @FirstName AND LastName = @LastName;",
                new { FirstName = firstName, LastName = lastName });
            return title;
        }

        public Users GetUser(int id)
        {
            return _conn.QuerySingle<Users>("SELECT * FROM User WHERE UserID = @id",
                new { id = id });
        }

        public void UpdateUser(Users user)
        {
            _conn.Execute("UPDATE User SET Title = @title WHERE UserID = @id",
             new {title = user.Title, id = user.UserID});
        }

        public void DeleteUser(Users user)
        {
            _conn.Execute("DELETE FROM User WHERE UserID = @id;",
                                       new { id = user.UserID });
        }

        
    }
}
