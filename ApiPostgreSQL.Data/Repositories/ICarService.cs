using ApiPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPostgreSQL.Data.Repositories
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetCar(int id);
        Task<bool> AddCar(Car car);
        Task<bool> UpdateCar(Car car);
        Task<bool> DeleteCar(Car car);
    }
}
