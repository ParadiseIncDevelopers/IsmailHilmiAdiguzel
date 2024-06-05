using IsmailHilmiAdiguzelProje.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data;

namespace IsmailHilmiAdiguzelProje
{
    public class MySQLDataContext : DbContext
    {
        public MySQLDataContext(DbContextOptions<MySQLDataContext> options) : base(options)
        {

        }

        public DbSet<User> users_table { get; set; }
    }
}
