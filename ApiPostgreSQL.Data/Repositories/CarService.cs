using ApiPostgreSQL.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPostgreSQL.Data.Repositories
{
    public class CarService : ICarService
    {
        private PostgreSQLConfig _connectionString;
        public CarService(PostgreSQLConfig connectionString) => _connectionString = connectionString;

        protected NpgsqlConnection DBConnectino()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }


        public Task<bool> AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCar(Car car)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetCar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
