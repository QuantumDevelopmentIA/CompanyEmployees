using CompanyEmployees.Core.Domain.Repositories;
using CompanyEmployees.Core.Domain.Entities;

namespace CompanyEmployees.Infrastructure.Persistence.Repositories;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }
}
