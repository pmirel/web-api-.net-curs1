using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_api_forecast.Models
{
    public class MustDoContext : DbContext
    {
        public MustDoContext(DbContextOptions<MustDoContext> options)
            : base(options)
        {
        }

        public DbSet<MustDoItem> MustDoItems { get; set; }
    }
}
