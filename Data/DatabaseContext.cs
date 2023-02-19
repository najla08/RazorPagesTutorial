using System;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesTutorial.Data
{
	public class DatabaseContext:DbContext
	{

        public DatabaseContext(DbContextOptions <DatabaseContext>options) : base(options)
        {
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Category> Category { get; set; }

    }


}

