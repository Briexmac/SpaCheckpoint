using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpaCheckpoint.Models
{
    public class ServiceProvidersContext : DbContext
    {
        public ServiceProvidersContext (DbContextOptions<ServiceProvidersContext> options)
            : base(options)
        {
        }

        public DbSet<SpaCheckpoint.Models.ServiceProviders> ServiceProviders { get; set; }
    }
}
