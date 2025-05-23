﻿using System;
using System.Data.SqlClient;
using System.Drawing;

namespace VehicleManagement
{
    public class Vehicle
    {
        public bool Insert(string id, string owner, string type, string brand, DateTime checkIn, string subscription, Image picture)
        {
            string query = @"
                INSERT INTO [Vehicle] (id, owner, type, brand, checkIn, subscription, picture)
                VALUES (@id, @owner, @type, @brand, @checkIn, @subscription, @picture)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", int.Parse(id));
            command.Parameters.AddWithValue("@owner", owner);
            command.Parameters.AddWithValue("@type", type);
            command.Parameters.AddWithValue("@brand", brand);
            command.Parameters.AddWithValue("@checkIn", checkIn);
            command.Parameters.AddWithValue("@subscription", subscription);
            command.Parameters.AddWithValue("@picture", Helper.imageToByteArray(picture));
            return SqlHelper.Execute(command);
        }

        public bool Update(string id, string owner, string type, string brand, DateTime checkIn, string subscription, Image picture)
        {
            string query = @"
                UPDATE [Vehicle]
                SET owner = @owner, type = @type, brand = @brand, checkIn = @checkIn, subscription = @subscription, picture = @picture
                WHERE id = @id";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", int.Parse(id));
            command.Parameters.AddWithValue("@owner", owner);
            command.Parameters.AddWithValue("@type", type);
            command.Parameters.AddWithValue("@brand", brand);
            command.Parameters.AddWithValue("@checkIn", checkIn);
            command.Parameters.AddWithValue("@subscription", subscription);
            command.Parameters.AddWithValue("@picture", Helper.imageToByteArray(picture));
            return SqlHelper.Execute(command);
        }

        public bool Delete(string id)
        {
            string query = @"
                DELETE FROM [Vehicle]
                WHERE id = @id";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", id);
            return SqlHelper.Execute(command);
        }
    }
}
