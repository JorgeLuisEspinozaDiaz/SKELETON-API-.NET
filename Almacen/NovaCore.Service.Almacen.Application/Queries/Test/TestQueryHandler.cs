using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;
using NovaCore.Service.Almacen.Application.IRepositories;
using Entities = NovaCore.Service.Almacen.Core.Entities;

namespace NovaCore.Service.Almacen.Application.Queries.Test
{
    public class TestQueryHandler : IRequestHandler<TestQuery, List<TestDTO>>
    {


        private readonly ITestRepository _testRepository;
        public TestQueryHandler(ITestRepository _testRepository)
        {
            this._testRepository = _testRepository;
        }

        public async Task<List<TestDTO>> Handle(TestQuery request, CancellationToken cancellationToken)
        {

            var response = new List<TestDTO>();
            Expression<Func<Entities.Test, bool>> expression = x => x.Deleted == null;
            var result = await _testRepository.GetAsync(expression);
            if (result != null)
            {
                response = result.Select(x => new TestDTO
                {
                    Id = x.TestId,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();
            }
            return response;
        }
    }
}