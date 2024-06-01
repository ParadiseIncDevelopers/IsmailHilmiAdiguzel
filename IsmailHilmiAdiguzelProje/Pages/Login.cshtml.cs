using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace IsmailHilmiAdiguzelProje.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {

        private readonly static string connectionString = "Server=hangelyazilim.mysql.database.azure.com;Port=3306;Database=hangel;Uid=yusufsalimozbek;Pwd=hangelyazilim!997;default command timeout=20;";

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public IActionResult OnGet()
        {
            // Return the login page
            return Page();
        }

        public async Task<IActionResult> OnPostLoginUserAsync()
        {

            // SQL command to query the user based on email and password
            string queryUserSql = $"SELECT name, surname FROM users_table WHERE email = '{Email}' AND password = '{Password}'";

            // Create MySqlConnection object
            using (MySqlConnection connection = new(connectionString))
            {
                // Create MySqlCommand object
                using (MySqlCommand command = new(queryUserSql, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("email", Email);
                    command.Parameters.AddWithValue("password", Password);

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
                                TempData["NameAndSurname"] = $"{reader["name"]} {reader["surname"]}";

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
