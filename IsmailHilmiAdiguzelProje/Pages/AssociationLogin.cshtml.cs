using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace IsmailHilmiAdiguzelProje.Pages
{
    public class AssociationLoginModel : PageModel
    {
        private readonly static string connectionString = "Server=hangelyazilim.mysql.database.azure.com;Port=3306;Database=hangel;Uid=yusufsalimozbek;Pwd=hangelyazilim!997;default command timeout=20;";

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostLoginUserAsync(string email, string password)
        {

            // SQL command to query the user based on email and password
            string queryUserSql = $"SELECT name, surname FROM users_table WHERE email = '{email}' AND password = '{password}'";

            // Create MySqlConnection object
            using (MySqlConnection connection = new(connectionString))
            {
                // Create MySqlCommand object
                using (MySqlCommand command = new(queryUserSql, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("email", email);
                    command.Parameters.AddWithValue("password", password);

                    try
                    {
                        // Open the connection
                        await connection.OpenAsync();

                        // Execute the command asynchronously and read the result
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                // User found, set the UserNameAndSurname property
                                ViewData["AssociationNameAndSurname"] = $"{reader["name"]} {reader["surname"]}";

                                // Redirect to the Index page
                                return RedirectToPage("/Index");
                            }
                            else
                            {
                                // User not found or credentials are incorrect, return to the login page
                                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                                return Page();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                        // For simplicity, you can just return a generic error message
                        return StatusCode(500, "An error occurred while logging in.");
                    }
                }
            }
        }
    }
}
