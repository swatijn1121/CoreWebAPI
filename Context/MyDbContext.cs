using Microsoft.EntityFrameworkCore;
using CoreWebApi.Models;


namespace CoreWebApi.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Students {get; set;}

    }
}