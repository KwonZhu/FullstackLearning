﻿using Microsoft.Extensions.Options;
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
                string insertSql = "insert into users(userName,password,email,age,gender,address,phone) value(@userName,@password,@email,@age,@gender,@address,@phone)";
                using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                {
                    mySqlCommand.CommandText = insertSql;
                    mySqlCommand.Parameters.AddWithValue("@userName", user.UserName);
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

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBConnectionConfig.DBConnection))
            {
                mySqlConnection.Open();
                string sql = "select * from users";
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
                string querySql = "select id from users where id = @id";
                string updateSql = "update users set username = @username, password = @password, email = @email, age = @age, gender = @gender, address = @address, phone = @phone where id = @id";

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
                string deleteSql = "delete from users where id = @id";
                using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                {
                    mySqlCommand.CommandText = deleteSql;
                    mySqlCommand.Parameters.AddWithValue("@id", id);
                    var rowsAffected = mySqlCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public User GetUserByUserName(string userName)
        {
            User user = new User();
            using (MySqlConnection mySqlConnection = new MySqlConnection(this.dBConnectionConfig.DBConnection))
            {
                mySqlConnection.Open();
                string sql = "Select * from users where userName = @userName";
                using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                {
                    mySqlCommand.CommandText = sql;
                    mySqlCommand.Parameters.AddWithValue("@userName", userName);

                    using (var rd = mySqlCommand.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            user.Id = rd.GetInt32("id");
                            user.UserName = rd.GetString("username");
                            user.Email = rd.GetString("email");
                            user.Password = rd.GetString("password"); //for if (user.Password == input.Password) in Login()
                        }
                    }
                }
            }
            return user;
        }
    }
}


