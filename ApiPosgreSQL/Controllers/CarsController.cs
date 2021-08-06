using ApiPosgreSQL.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPosgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class CarsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CarsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {   
            string query = @"select * from cars";

            DataTable table = new DataTable();
            List<Cars> data = new List<Cars>(); 
            string sqlDataSource = _configuration.GetConnectionString("PostgresSQLConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    myReader = command.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult(table);


        }
        [HttpPost]
        public JsonResult Post(Cars car)
        {
            string query = @"
            insert into cars (
                make, model, color, year) VALUES (
                @carMake, @carModel, @carColor, @carYear)";

            string sqlDataSource = _configuration.GetConnectionString("PostgresSQLConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@carMake", car.Make);
                    command.Parameters.AddWithValue("@carModel", car.Model);
                    command.Parameters.AddWithValue("@carColor", car.Color);
                    command.Parameters.AddWithValue("@carYear", car.Year);
                    myReader = command.ExecuteReader();
                    myReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Added Successfully");


        }

        [HttpPut]
        public JsonResult Put(Cars car)
        {
            string query = @"
            update cars 
            set make = @carMake, model = @carModel, color = @carColor, year = @carYear
            where id = @carId";

            string sqlDataSource = _configuration.GetConnectionString("PostgresSQLConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@carMake", car.Make);
                    command.Parameters.AddWithValue("@carModel", car.Model);
                    command.Parameters.AddWithValue("@carColor", car.Color);
                    command.Parameters.AddWithValue("@carYear", car.Year);
                    command.Parameters.AddWithValue("@carId", car.Id);
                    myReader = command.ExecuteReader();
                    myReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult("Update Successfully");


        }

        [HttpDelete("{id}")]
        public JsonResult Deletet(int id)
        {
            string query = @"
            delete from cars
            where id = @carId";

            string sqlDataSource = _configuration.GetConnectionString("PostgresSQLConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection connetion = new NpgsqlConnection(sqlDataSource))
            {
                connetion.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connetion))
                {
                    command.Parameters.AddWithValue("@carId", id);
                    myReader = command.ExecuteReader();
                    myReader.Close();
                    connetion.Close();
                }
            }

            return new JsonResult("Delete Successfully");


        }
        [HttpGet("{id}")]
        public JsonResult get(int id)
        {
            string query = @"
            select * from cars
            where id = @carId";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PostgresSQLConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection connetion = new NpgsqlConnection(sqlDataSource))
            {
                connetion.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connetion))
                {
                    command.Parameters.AddWithValue("@carId", id);
                    myReader = command.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    connetion.Close();
                }
            }

            return new JsonResult(table);


        }
    }
}
