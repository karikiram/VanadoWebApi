using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vanado.Models
{
    public class MachineRepository
    {
        private string connectionString;
        public MachineRepository()
        {
            connectionString = @"Host=localhost;Username=postgres;Password=user;Database=db_vanado";
        }
        public void AddMachine(Machine mach)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = "Insert into machine (machine_name) values (@Machine_name);";
                connection.Execute(sQuery, new
                {
                    mach.Machine_name
                });
            }
        }
        public IEnumerable<Machine> GetAllMachines()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"Select * FROM machine";
                connection.Execute(sQuery);
                return connection.Query<Machine>(sQuery);
            }
        }
        public Machine GetMachineById(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"Select * FROM machine Where machine_id=@Id";
                return connection.Query<Machine>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }
        public void UpdateMachine(Machine mach)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"UPDATE machine SET machine_name=@Machine_name";
                connection.Query(sQuery, mach);
            }
        }
        public void DeleteMachine(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"DELETE FROM machine Where machine_id=@id";
                connection.Execute(sQuery, new { Id = id });
            }
        }

    }
}
