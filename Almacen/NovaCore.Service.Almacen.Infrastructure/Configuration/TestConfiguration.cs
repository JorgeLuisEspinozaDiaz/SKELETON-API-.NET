using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NovaCore.Service.Almacen.Core.Entities;

namespace NovaCore.Service.Almacen.Infrastructure.Configuration
{
    public class TestConfiguration 
    {
        public TestConfiguration(EntityTypeBuilder<Test> entityTypeBuilder)
        {
              entityTypeBuilder.HasKey(x => x.TestId);
        }
    }
}