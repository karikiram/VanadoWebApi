using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Vanado.Models
{
    public class FailureRepository
    {

        private string connectionString;

        public FailureRepository()
        {
            connectionString = @"Host=localhost;Username=postgres;Password=user;Database=db_vanado";
            
        }

        public void AddFailure(Failure fail)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = "Insert into failure (failure_name, failure_description,failure_datetime,failure_machineid,failure_status,failure_documentation,failure_priority) values (@Failure_name, @Failure_description,@Failure_datetime,@Failure_machineid,@Failure_status,@Failure_documentation,@Failure_priority);";
                connection.Execute(sQuery, new
                {
                        fail.Failure_name,
                        fail.Failure_description,
                        fail.Failure_datetime,
                        fail.Failure_machineid,
                        fail.Failure_status,
                        fail.Failure_documentation,
                        fail.Failure_priority
                    });
            }
        }


        public IEnumerable<Failure> GetAllFailures()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"Select * FROM failure Where failure_status=false";
                connection.Execute(sQuery);
                return connection.Query<Failure>(sQuery);
            }
        }


        public Failure GetFailureById(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"Select * FROM failure Where failure_id=@Id";
                return connection.Query<Failure>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public List<Failure> GetFailuresByMachineId(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"Select * FROM failure Where failure_machineid=@Id";
                return connection.Query<Failure>(sQuery, new { Id = id }).ToList();
            }
        }

        public void UpdateFailure(Failure fail)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"UPDATE failure SET failure_name=@Failure_name,failure_description=@Failure_description,
                                failure_status=@Failure_status,failure_documentation=@Failure_documentation,failure_priority=@Failure_priority Where failure_id=@Failure_id";
                connection.Query(sQuery, fail);
            }
        }

        public void UpdateFailureStatus(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"UPDATE failure SET failure_status = NOT failure_status Where failure_id=@id";
                connection.Query(sQuery, new { Id = id });
            }
        }
        public void DeleteFailure(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sQuery = @"DELETE FROM failure Where failure_id=@id";
                connection.Execute(sQuery, new { Id = id });
            }
        }

    }
}
