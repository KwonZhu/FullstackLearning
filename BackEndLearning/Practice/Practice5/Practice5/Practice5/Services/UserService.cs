using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Practice5.Config;
using Practice5.IServices;
using Practice5.Models;

namespace Practice5.Services
{
    public class UserService : IUserService
    {
        private DBConnectionConfig dBConnectionConfig;
        public UserService(IOptions<DBConnectionConfig> options)
        {
            this.dBConnectionConfig = options.Value;
        }
        public bool AddUser(User user)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBConnectionConfig.DBConnection))
            {
                mySqlConnection.Open();
                string insertSql = "insert into user(userName,password,email,age,gender,active,address,phone) value(@userName,@password,@email,@age,@gender,@active,@address,@phone)";
                using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                {
                    mySqlCommand.CommandText = insertSql;
                    mySqlCommand.Parameters.AddWithValue("@userName", user.UserName);
                    mySqlCommand.Parameters.AddWithValue("@password", user.Password);
                    mySqlCommand.Parameters.AddWithValue("@email", user.Email);
                    mySqlCommand.Parameters.AddWithValue("@age", user.Age);
                    mySqlCommand.Parameters.AddWithValue("@gender", user.Gender);
                    mySqlCommand.Parameters.AddWithValue("@active", !user.Active);
                    mySqlCommand.Parameters.AddWithValue("@address", user.Address);
                    mySqlCommand.Parameters.AddWithValue("@phone", user.Phone);
                    var rowsAffected = mySqlCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBConnectionConfig.DBConnection))
            {
                mySqlConnection.Open();
                string sql = "select * from user";
                using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                {
                    mySqlCommand.CommandText = sql;
                    var rd = mySqlCommand.ExecuteReader();
                    while (rd.Read())
                    {
                        User user = new User();
                        user.UserName = rd.GetString("username");
                        user.Email = rd.GetString("email");
                        user.Id = rd.GetInt32("id");
                        user.Active = rd.GetBoolean("active");
                        users.Add(user);
                    }
                    rd.Close();
                }
            }
            return users;
        }

        public bool UpdateUsers(User user)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBConnectionConfig.DBConnection))
            {
                mySqlConnection.Open();
                string querySql = "select id from user where id = @id";
                string updateSql = "update user set username = @username, password = @password, email = @email, age = @age, gender = @gender, address = @address, phone = @phone where id = @id";

                using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                {
                    // check if user exists
                    mySqlCommand.CommandText = querySql;
                    mySqlCommand.Parameters.AddWithValue("@id", user.Id);
                    using (var reader = mySqlCommand.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return false;
                        }
                    }

                    // Reset parameters and prepare for update
                    mySqlCommand.Parameters.Clear();
                    mySqlCommand.CommandText = updateSql;
                    mySqlCommand.Parameters.AddWithValue("@id", user.Id);
                    mySqlCommand.Parameters.AddWithValue("@username", user.UserName);
                    mySqlCommand.Parameters.AddWithValue("@password", user.Password);
                    mySqlCommand.Parameters.AddWithValue("@email", user.Email);
                    mySqlCommand.Parameters.AddWithValue("@age", user.Age);
                    mySqlCommand.Parameters.AddWithValue("@gender", user.Gender);
                    mySqlCommand.Parameters.AddWithValue("@address", user.Address);
                    mySqlCommand.Parameters.AddWithValue("@phone", user.Phone);

                    var rowsAffected = mySqlCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteUser(int id)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBConnectionConfig.DBConnection))
            {
                mySqlConnection.Open();
                string deleteSql = "delete from user where id = @id";
                using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                {
                    mySqlCommand.CommandText = deleteSql;
                    mySqlCommand.Parameters.AddWithValue("@id", id);
                    var rowsAffected = mySqlCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}


