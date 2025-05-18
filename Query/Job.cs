using System;
using System.Data.SqlClient;
using System.Drawing;

namespace VehicleManagement
{
    public class Job
    {
        public bool Insert(string id, string firstname, string lastname, DateTime birthdate, string gender, string phone, string address, Image picture)
        {
            string query = @"
                INSERT INTO dbo.Job (id, firstname, lastname, birthdate, gender, phone, address, picture, email)
                VALUES (@id, @firstname, @lastname, @birthdate, @gender, @phone, @address, @picture, @email)";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", int.Parse(id));
            command.Parameters.AddWithValue("@firstname", firstname);
            command.Parameters.AddWithValue("@lastname", lastname);
            command.Parameters.AddWithValue("@birthdate", birthdate);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@picture", Helper.imageToByteArray(picture));
            command.Parameters.AddWithValue("@email", id + Const.HCMUTE_EMAIL);
            return SqlHelper.Execute(command);
        }

        public bool Update(string id, string firstname, string lastname, DateTime birthdate, string gender, string phone, string address, Image picture)
        {
            string query = @"
                UPDATE dbo.Job
                SET firstname = @firstname, lastname = @lastname, birthdate = @birthdate, gender = @gender, phone = @phone, address = @address, picture = @picture, email = @email
                WHERE id = @id";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", int.Parse(id));
            command.Parameters.AddWithValue("@firstname", firstname);
            command.Parameters.AddWithValue("@lastname", lastname);
            command.Parameters.AddWithValue("@birthdate", birthdate);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@picture", Helper.imageToByteArray(picture));
            command.Parameters.AddWithValue("@email", id + Const.HCMUTE_EMAIL);
            return SqlHelper.Execute(command);
        }

        public bool Delete(string id)
        {
            string query = @"
                DELETE FROM dbo.Job
                WHERE id = @id";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", id);
            return SqlHelper.Execute(command);
        }
    }
}
