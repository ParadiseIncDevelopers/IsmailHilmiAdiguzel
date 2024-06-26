using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace IsmailHilmiAdiguzelProje.Pages
{
    [BindProperties]
    public class UserRegisterModel : PageModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Surname { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"^\+[1-9]\d{1,14}$", ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Password { get; set; }

        private readonly static string connectionString = "Server=hangelyazilim.mysql.database.azure.com;Port=3306;Database=hangel;Uid=yusufsalimozbek;Pwd=hangelyazilim!997;default command timeout=20;";

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostRegisterUser() 
        {
            // Connection string for MySQL
            

            if (ModelState.IsValid)
            {
                // SQL command to insert a new user
                string insertUserSql = string.Format("INSERT INTO hangel.users_table (name, surname, email, phone_number, password, user_type) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', 'USER')", Name, Surname, Email, PhoneNumber, Password);

                // Create MySqlConnection object
                using (MySqlConnection connection = new(connectionString))
                {
                    // Create MySqlCommand object
                    using (MySqlCommand command = new(insertUserSql, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("name", Name);
                        command.Parameters.AddWithValue("surname", Surname);
                        command.Parameters.AddWithValue("email", Email);
                        command.Parameters.AddWithValue("phoneNumber", PhoneNumber);
                        command.Parameters.AddWithValue("password", Password);
                        command.Parameters.AddWithValue("userType", "USER");

                        try
                        {
                            // Open the connection
                            await connection.OpenAsync();

                            // Execute the command asynchronously
                            await command.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions
                            // For simplicity, you can just return a generic error message
                            return StatusCode(500, "An error occurred while registering the user.");
                        }
                    }
                }

                // Redirect to another page or return a response as needed
                return RedirectToPage("/Index");
            }
            else 
            {
                return Page();
            }
        }
    }
}
