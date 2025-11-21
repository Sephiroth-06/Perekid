using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Mozaika.Models
{
    public class ProductionCalculator
    {
        /// <summary>
        /// Расчет количества продукции получаемой из указанного количества сырья
        /// </summary>
        /// <param name="productType">Тип продукции (напольная, настенная и т.д.)</param>
        /// <param name="materialType">Тип материала (сырье, покрытие и т.д.)</param>
        /// <param name="rawMaterialQuantity">Количество сырья</param>
        /// <param name="productParam1">Параметр продукции 1 (длина в метрах)</param>
        /// <param name="productParam2">Параметр продукции 2 (ширина в метрах)</param>
        /// <returns>Количество продукции или -1 при ошибке</returns>
        public int CalculateProductQuantity(string productType, string materialType,
    int rawMaterialQuantity, double productParam1, double productParam2)
        {
            try
            {
                // Проверка входных параметров
                if (string.IsNullOrEmpty(productType) || string.IsNullOrEmpty(materialType) ||
                    rawMaterialQuantity <= 0 || productParam1 <= 0 || productParam2 <= 0)
                    return -1;

                // Получаем коэффициенты из БД
                double productCoefficient = GetProductCoefficient(productType);
                double lossPercentage = GetMaterialLossPercentage(materialType);

                Console.WriteLine($"Коэффициент продукции '{productType}': {productCoefficient}");
                Console.WriteLine($"Потери материала '{materialType}': {lossPercentage}%");

                if (productCoefficient <= 0 || lossPercentage < 0)
                {
                    MessageBox.Show($"Не найдены коэффициенты:\n• Тип продукции: {productType}\n• Тип материала: {materialType}\n\nПожалуйста, проверьте настройки коэффициентов в базе данных.",
                        "Ошибка коэффициентов");
                    return -1;
                }

                // Расчет: площадь плитки × коэффициент типа продукции
                double area = productParam1 * productParam2; // площадь в м²
                double rawMaterialPerUnit = area * productCoefficient;

                Console.WriteLine($"Площадь плитки: {area:0.000} м²");
                Console.WriteLine($"Сырьё на единицу: {rawMaterialPerUnit:0.000} кг");

                if (rawMaterialPerUnit <= 0)
                    return -1;

                // Учет потерь: эффективное количество сырья = общее количество × (1 - % потерь)
                double effectiveRawMaterial = rawMaterialQuantity * (1 - lossPercentage / 100);

                // Расчет: эффективное сырьё / сырьё на единицу продукции
                int productQuantity = (int)Math.Floor(effectiveRawMaterial / rawMaterialPerUnit);

                Console.WriteLine($"Эффективное сырьё: {effectiveRawMaterial:0} кг");
                Console.WriteLine($"Результат расчета: {productQuantity} шт.");

                return productQuantity > 0 ? productQuantity : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка расчета: {ex.Message}\n\nДетали: {ex.StackTrace}", "Ошибка расчета");
                return -1;
            }
        }

        private double GetProductCoefficient(string productType)
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT coefficient FROM product_type_coefficients WHERE product_type = @productType";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@productType", productType);
                        var result = command.ExecuteScalar();

                        return result != null ? Convert.ToDouble(result) : -1;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        private double GetMaterialLossPercentage(string materialType)
        {
            try
            {
                var db = new DatabaseHelper();
                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT loss_percentage FROM material_loss_percentages WHERE material_type = @materialType";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@materialType", materialType);
                        var result = command.ExecuteScalar();

                        return result != null ? Convert.ToDouble(result) : -1;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }
    }
}