using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLib
{
    public interface ISqlDataAccess
    {
        string ConnectionStringDefault { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);

        Task SaveData<T>(string sql, T parameters);
    }
}