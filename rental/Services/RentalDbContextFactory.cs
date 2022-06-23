using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using rental.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Services
{
    public class RentalDbContextFactory : IDesignTimeDbContextFactory<RentalDbContext>
    {
        public RentalDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<RentalDbContext>();
            options.UseMySQL("server=localhost;database=rental;user=admin123;password=12345");
            return new RentalDbContext(options.Options);
        }
    }
}
