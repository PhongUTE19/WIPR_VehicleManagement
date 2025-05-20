using System;
using System.Data.SqlClient;
using System.Drawing;

namespace VehicleManagement
{
    public class Staff
    {
        public bool Insert(string firstName, string lastName, DateTime birthdate, string gender, string phone, string address, string email, Image picture, string role, int jobId)
        {
            string query = @"
        INSERT INTO [Staff] (firstName, lastName, birthdate, gender, phone, address, email, picture, role, jobId)
        VALUES (@firstName, @lastName, @birthdate, @gender, @phone, @address, @email, @picture, @role, @jobId)";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@birthdate", birthdate);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@picture", Helper.imageToByteArray(picture));
            command.Parameters.AddWithValue("@role", role);
            command.Parameters.AddWithValue("@jobId", jobId);

            return SqlHelper.Execute(command);
        }

        public bool Update(int id, string firstName, string lastName, DateTime birthdate, string gender, string phone, string address, string email, Image picture, string role, string job)
        {
            string query = @"
                UPDATE [Staff]
                SET firstName = @firstName,
                    lastName = @lastName,
                    birthdate = @birthdate,
                    gender = @gender,
                    phone = @phone,
                    address = @address,
                    email = @email,
                    picture = @picture,
                    role = @role,
                    job = @job
                WHERE id = @id";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@firstName", firstName);
            command.Parameters.AddWithValue("@lastName", lastName);
            command.Parameters.AddWithValue("@birthdate", birthdate);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@address", address);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@picture", Helper.imageToByteArray(picture));
            command.Parameters.AddWithValue("@role", role);
            command.Parameters.AddWithValue("@job", job);
            return SqlHelper.Execute(command);
        }

        public bool Delete(int id)
        {
            string query = @"
                DELETE FROM [Staff]
                WHERE id = @id";

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", id);
            return SqlHelper.Execute(command);
        }
    }
}
