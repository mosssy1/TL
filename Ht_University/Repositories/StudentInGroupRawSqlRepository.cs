using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ht_university.Models;
using System.Data.SqlClient;
using System.Data;

namespace Ht_university.Repositories
{
    public class StudentInGroupRawSqlRepository : IStudentInGroupRepository
    {
        private readonly string _connectionString;

        public StudentInGroupRawSqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(StudentInGroup studentInGroup)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO [StudentInGroups]([GroupId], [StudentId]) VALUES (@groupsId, @studentId)";
                    command.Parameters.Add("@groupsId", SqlDbType.Int).Value = studentInGroup.GroupsId;
                    command.Parameters.Add("@studentId", SqlDbType.Int).Value = studentInGroup.StudentId;
                    studentInGroup.GroupsId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        public List<StudentInGroup> Get(int groupId)
        {
            var result = new List<StudentInGroup>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText =
                        @"select [StudentId]
                        from [StudentInGroups]
                        where [GroupId] = @groupId";
                    command.Parameters.Add("@groupId", SqlDbType.Int).Value = groupId;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new StudentInGroup
                            {
                                StudentId = Convert.ToInt32(reader["StudentId"])
                            });
                        }
                    }
                }
            }

            return result;
        }
        
    }
}
