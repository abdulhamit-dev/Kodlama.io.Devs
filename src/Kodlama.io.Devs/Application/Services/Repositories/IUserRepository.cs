using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
    {
        IList<OperationClaim> GetOperationClaims(User user);
    }
}
