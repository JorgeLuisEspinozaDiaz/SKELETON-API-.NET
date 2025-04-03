using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovaCore.Service.Almacen.Application.IRepositories;
using NovaCore.Service.Almacen.Core.Entities;

namespace NovaCore.Service.Almacen.Infrastructure.Repositories
{
    public class TestRepository : RepositoryBase<Test>, ITestRepository
    {
        public TestRepository(AlmacenDbContext dbContext) : base(dbContext)
        {
        }
    }
}