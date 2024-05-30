using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace IsmailHilmiAdiguzelProje.Pages
{
    public class AssociationRegisterModel : PageModel
    {
        // Connection string for MySQL
        private readonly static string connectionString = "Server=127.0.0.1;Port=3306;Database=users;Uid=root;Pwd=yusufsalim_1997;";

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
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must have at least 8 characters, one uppercase letter, one lowercase letter, one number, and one special character")]
        public string? Password { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostRegisterAssociation()
        {
            if (ModelState.IsValid)
            {
                // SQL command to insert a new user
                string insertUserSql = string.Format("INSERT INTO users.users_association (name, surname, email, phone_number, password, user_type) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', 'ASSOCIATION')", Name, Surname, Email, PhoneNumber, Password);

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
                        command.Parameters.AddWithValue("userType", "ASSOCIATION");

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
