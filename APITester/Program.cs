using ExcelDataReader;
using MySql.Data.MySqlClient;

namespace MySQLConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            string connectionString = "Server=hangelyazilim.mysql.database.azure.com;Port=3306;Database=hangel;Uid=yusufsalimozbek;Pwd=hangelyazilim!997;default command timeout=20;";
            string excelFilePath = "C:\\Users\\Yusuf Salim OZBEK\\Desktop\\province.xlsx"; // Change this to the path of your Excel file
            int index = 1;

            // Open and read Excel file
            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Skip the header row
                    reader.Read();
                    
                    while (reader.Read()) // Read each row
                    {
                        // Get data from each column
                        string province = reader.GetString(0).Trim();
                        string city = reader.GetString(1).Trim();
                        string district = reader.GetString(2).Trim();
                        string neighbourhood = reader.GetString(3).Trim();
                        if (index > 61713)
                        {
                            // Write your query
                            string query = "INSERT INTO hangel.user_address_list (id, province, city, district, neighbourhood) VALUES (@id, @province, @city, @district, @neighbourhood)";

                            // Create connection and command
                            using (MySqlConnection connection = new(connectionString))
                            {
                                using (MySqlCommand command = new(query, connection))
                                {
                                    // Add parameters to your command
                                    command.Parameters.AddWithValue("@id", index);
                                    command.Parameters.AddWithValue("@province", province);
                                    command.Parameters.AddWithValue("@city", city);
                                    command.Parameters.AddWithValue("@district", district);
                                    command.Parameters.AddWithValue("@neighbourhood", neighbourhood);

                                    // Open the connection
                                    connection.Open();

                                    // Execute the command
                                    command.ExecuteNonQuery();

                                    // Close the connection
                                    connection.Close();

                                    Console.WriteLine($"Inserted {index} row(s).");
                                    index++;
                                }
                            }
                        }
                        else 
                        {
                            Console.WriteLine("Pass " + index + " line");
                            index++;
                            continue;
                        }
                    }
                }
            }
        }
    }
}
