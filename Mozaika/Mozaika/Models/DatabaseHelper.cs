using System;
using System.Security.Cryptography;
using System.Text;
using System.Data.SQLite;
using System.Configuration;

namespace Mozaika.Models
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        // В DatabaseHelper.cs добавь:
        public static void UpdatePartnerTotalSales(int partnerId)
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();

                    string query = @"
                UPDATE partners 
                SET total_sales = (
                    SELECT COALESCE(SUM(final_amount), 0) 
                    FROM requests 
                    WHERE partner_id = @partnerId 
                    AND status IN ('оплачена', 'выполнена', 'завершена')
                )
                WHERE id = @partnerId";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@partnerId", partnerId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка обновления total_sales: {ex.Message}");
            }
        }

        // Метод для хэширования пароля (SHA256)
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}