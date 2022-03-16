using Ht_university.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Ht_university.Repositories
{
    class StudentRawSqlRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRawSqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Student> GetAll()
        {
            var result = new List<Student>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "select [Id], [Name], [Age] from [Student]";


                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Student
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"]),
                                Age = Convert.ToInt32(reader["Age"])
                            });
                        }
                    }
                }
            }

            return result;
        }

        public void Add(Student student)
        {
            using (var connection = new SqlConnection(_connectionString))
            {


                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO [dbo].[Student]([Name], [Age]) VALUES (@Name, @Age)";
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = student.Name;
                    command.Parameters.Add("@Age", SqlDbType.NVarChar).Value = student.Age;

                    student.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }

        }
        public Student GetStudent(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"select [Id], [Name]
                        from [Student]
                        where [Id] = @id";

                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Student
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"])
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

    }
}