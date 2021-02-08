using DataAccessLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib
{
    public interface IRoomData
    {
        Task<List<Room>> GetRooms();

        Task CreateRoom();

        Task JoinRoom(User user, Room room);

        Task LeaveRoom(User user, Room room);
    }


    public class RoomData : IRoomData
    {
        private readonly ISqlDataAccess _db;

        public RoomData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<Room>> GetRooms()
        {
            var userData = new UserData(_db);
            string sql = "select * from dbo.Rooms;";

            var rooms = await _db.LoadData<Room, dynamic>(sql, new { });

            foreach (var r in rooms)
            {
                r.Users = await userData.GetUsersInRoom(r);
            }

            return rooms;
        }

        public Task CreateRoom()
        {
            string sql = "insert into dbo.Rooms default values;";

            return _db.SaveData(sql, new Room());
        }

        public Task JoinRoom(User user, Room room)
        {
            string sql = string.Format(
                "insert into dbo.RoomsUsers (RoomID, UserID) values ('{0}', '{1}');",
                room.Id, user.Id);

            return _db.SaveData(sql, user);
        }

        public Task LeaveRoom(User user, Room room)
        {
            string sql = string.Format(
                "delete from dbo.RoomsUsers where RoomID = '{0}' and UserID = '{1}';",
                room.Id, user.Id);

            return _db.SaveData(sql, user);
        }
    }
}
