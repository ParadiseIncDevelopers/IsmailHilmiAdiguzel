using IsmailHilmiAdiguzelProje.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Data;

namespace IsmailHilmiAdiguzelProje
{
    public class MySQLDataContext(DbContextOptions<MySQLDataContext> options) : DbContext(options)
    {
        public DbSet<User> users_table { get; set; }
        public DbSet<UserClickCounter> users_clicks_counters { get; set; }
        public DbSet<OrganisationUser> organisations { get; set; }
    }
}
