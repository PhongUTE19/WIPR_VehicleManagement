using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VehicleManagement.Contract
{
    public class Contract
    {
        public int Id { get; set; }
        public string Type { get; set; } // rent, consignment, lease
        public int CustomerId { get; set; }
        public int? VehicleId { get; set; }  // Allow NULL
        public int? StaffId { get; set; }    // Allow NULL
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? RefContractId { get; set; } // Allow NULL (reference another contract)

        // Display
        public string CustomerName { get; set; }
        public string VehicleInfo { get; set; }
        public string StaffName { get; set; }
        public int? OwnerId { get; set; } // Chỉ dùng cho hợp đồng consignment

        public string OwnerName { get; set; } // Dùng cho hiển thị tên Owner trong hợp đồng consignment

        public bool Insert()
        {
            string query = @"INSERT INTO Contract 
                (type, customerId, ownerId, vehicleId, staffId, startDate, endDate, price, description, refContractId)
                VALUES 
                (@type, @customerId, @ownerId, @vehicleId, @staffId, @startDate, @endDate, @price, @description, @refContractId)";

            var parameters = new Dictionary<string, object>
            {
                { "@type", Type },
                { "@customerId", CustomerId },
                { "@ownerId", (object)OwnerId ?? DBNull.Value },
                { "@vehicleId", (object)VehicleId ?? DBNull.Value },
                { "@staffId", (object)StaffId ?? DBNull.Value },
                { "@startDate", StartDate },
                { "@endDate", EndDate },
                { "@price", Price },
                { "@description", (object)Description ?? DBNull.Value },
                { "@refContractId", (object)RefContractId ?? DBNull.Value }
            };

            return SqlHelper.Execute(query, parameters);
        }

        public bool Update()
        {
            string query = @"UPDATE Contract 
                                SET type = @type, customerId = @customerId, ownerId = @ownerId,
                                    vehicleId = @vehicleId, staffId = @staffId, startDate = @startDate,
                                    endDate = @endDate, price = @price, description = @description, refContractId = @refContractId
                                WHERE id = @id";

            var parameters = new Dictionary<string, object>
            {
                { "@id", Id },
                { "@type", Type },
                { "@customerId", CustomerId },
                { "@ownerId", (object)OwnerId ?? DBNull.Value },
                { "@vehicleId", (object)VehicleId ?? DBNull.Value },
                { "@staffId", (object)StaffId ?? DBNull.Value },
                { "@startDate", StartDate },
                { "@endDate", EndDate },
                { "@price", Price },
                { "@description", (object)Description ?? DBNull.Value },
                { "@refContractId", (object)RefContractId ?? DBNull.Value }
            };

            return SqlHelper.Execute(query, parameters);
        }

        public bool Delete()
        {
            string query = "DELETE FROM Contract WHERE id = @id";
            var parameters = new Dictionary<string, object>
            {
                { "@id", Id }
            };

            return SqlHelper.Execute(query, parameters);
        }

        public static Contract GetById(int id)
        {
            string query = @"SELECT * FROM Contract WHERE id = @id";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@id", id);

            var table = SqlHelper.GetTable(command);
            if (table.Rows.Count == 0) return null;

            var row = table.Rows[0];
            return new Contract
            {
                Id = id,
                Type = row["type"].ToString(),
                CustomerId = Convert.ToInt32(row["customerId"]),
                OwnerId = row["ownerId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["ownerId"]),
                VehicleId = row["vehicleId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["vehicleId"]),
                StaffId = row["staffId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["staffId"]),
                StartDate = Convert.ToDateTime(row["startDate"]),
                EndDate = Convert.ToDateTime(row["endDate"]),
                Price = Convert.ToDecimal(row["price"]),
                Description = row["description"] == DBNull.Value ? null : row["description"].ToString(),
                RefContractId = row["refContractId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["refContractId"])
            };
        }

        public static List<Contract> GetConsignmentContracts()
        {
            string query = @"
                    SELECT C.id, C.ownerId, O.firstName + ' ' + O.lastName AS ownerName,
                           C.vehicleId, V.brand + ' ' + V.type AS vehicleInfo
                    FROM Contract C
                    JOIN Owner O ON C.ownerId = O.ownerId
                    JOIN Vehicle V ON C.vehicleId = V.id
                    WHERE C.type = 'consignment'";


            var command = new SqlCommand(query);
            var table = SqlHelper.GetTable(command);

            var list = new List<Contract>();
            foreach (System.Data.DataRow row in table.Rows)
            {
                list.Add(new Contract
                {
                    Id = Convert.ToInt32(row["id"]),
                    OwnerId = Convert.ToInt32(row["ownerId"]),
                    OwnerName = row["ownerName"].ToString(),
                    VehicleId = row["vehicleId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["vehicleId"]),
                    VehicleInfo = row["vehicleInfo"].ToString(),
                    Type = "consignment"
                });
            }
            return list;
        }
    }
}
