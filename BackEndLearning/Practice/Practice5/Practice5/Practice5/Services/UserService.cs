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
                string insertSql = "insert into user(userName,password,email,age,gender,active,address,phone) value(@userName,@password,@email,@age,@gender,@active,@address,@phone)";
                using (MySqlCommand mySqlCommand = mySqlConnection.CreateCommand())
                {
                    mySqlCommand.CommandText = insertSql;
                    mySqlCommand.Parameters.AddWithValue("@userName", user.UserName);
                    mySqlCommand.Parameters.AddWithValue("@password", user.Password);
                    mySqlCommand.Parameters.AddWithValue("@email", user.Email);
                    mySqlCommand.Parameters.AddWithValue("@age", user.Age);
                    mySqlCommand.Parameters.AddWithValue("@gender", user.Gender);
                    mySqlCommand.Parameters.AddWithValue("@active", user.Active);
                    mySqlCommand.Parameters.AddWithValue("@address", user.Address);
                    mySqlCommand.Parameters.AddWithValue("@phone", user.Phone);
                    var count = mySqlCommand.ExecuteNonQuery();
                    return count > 0;
                }
            }
        }

    }
}
