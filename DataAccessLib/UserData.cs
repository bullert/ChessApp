using DataAccessLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib
{
    public interface IUserData
    {
        Task<List<User>> GetUsers();

        Task<List<User>> GetOnlineUsers();

        Task<List<User>> GetUsersInRoom(Room room);

        Task<List<User>> GetUserByName(string name);

        Task InsertUser(User user);

        Task<List<User>> ValidateUser(User user);

        Task SetUserStatus(User user, bool status);
    }

    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<User>> GetUsers()
        {
            string sql = "select * from dbo.Users;";

            return _db.LoadData<User, dynamic>(sql, new { });
        }

        public Task<List<User>> GetUsersInRoom(Room room)
        {
            string sql = string.Format(
                "select * from RoomsUsers inner join Users on (UserID = Users.ID) where RoomID = '{0}';",
                room.Id);

            return _db.LoadData<User, dynamic>(sql, new { });
        }

        public Task InsertUser(User user)
        {
            string sql = string.Format(
                "insert into dbo.Users (Username, Password, IsOnline) values ('{0}', '{1}', 0);",
                user.Username, user.Password);

            return _db.SaveData(sql, user);
        }

        public Task<List<User>> GetUserByName(string name)
        {
            string sql = string.Format(
                "select * from dbo.Users where Username = '{0}';",
                name);

            return _db.LoadData<User, dynamic>(sql, new { });
        }

        public Task<List<User>> GetOnlineUsers()
        {
            string sql = "select * from dbo.Users where IsOnline = 1;";

            return _db.LoadData<User, dynamic>(sql, new { });
        }

        public Task SetUserStatus(User user, bool status)
        {
            string sql = string.Format(
                "update dbo.Users set IsOnline = '{0}' where Id = '{1}';",
                status, user.Id);

            return _db.SaveData(sql, new User());
        }

        public Task<List<User>> ValidateUser(User user)
        {
            string sql = string.Format(
                "select * from dbo.Users where Username = '{0}' and Password = '{1}';",
                user.Username, user.Password);

            return _db.LoadData<User, dynamic>(sql, new { });
        }
    }
}
