using System;
using System.Data.SqlClient;
using System.Drawing;

namespace VehicleManagement
{
    public class Vehicle
    {
        public int? Insert(int ownerId, string type, string brand, DateTime checkIn, string subscription, Image picture)
        {
            string query = @"
        INSERT INTO [Vehicle] (ownerId, type, brand, checkIn, subscription, picture)
        VALUES (@ownerId, @type, @brand, @checkIn, @subscription, @picture);
        SELECT SCOPE_IDENTITY();"; // Trả về ID mới thêm

            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@ownerId", ownerId);
            command.Parameters.AddWithValue("@type", type);
            command.Parameters.AddWithValue("@brand", brand);
            command.Parameters.AddWithValue("@checkIn", checkIn);
            command.Parameters.AddWithValue("@subscription", subscription);
            command.Parameters.AddWithValue("@picture", Helper.imageToByteArray(picture));

            object result = SqlHelper.ExecuteScalar(command);
            if (result != null && int.TryParse(result.ToString(), out int newId))
                return newId;

            return null;
        }

        public bool Update(int id, int ownerId, string type, string brand, DateTime checkIn, string subscription, Image picture)
        {
            string query = @"
                UPDATE [Vehicle]
                SET ownerId = @ownerId,
                    type = @type,
                    brand = @brand,
                    checkIn = @checkIn,
                    subscription = @subscription,
                    picture = @picture
                WHERE id = @id";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@ownerId", ownerId);
            command.Parameters.AddWithValue("@type", type);
            command.Parameters.AddWithValue("@brand", brand);
            command.Parameters.AddWithValue("@checkIn", checkIn);
            command.Parameters.AddWithValue("@subscription", subscription);
            command.Parameters.AddWithValue("@picture", Helper.imageToByteArray(picture));
            return SqlHelper.Execute(command);
        }

        public bool Delete(int id)
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
