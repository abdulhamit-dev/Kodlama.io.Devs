using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }

        public IList<OperationClaim> GetOperationClaims(User user)
        {
            IQueryable<OperationClaim> queryResult = from opc in Context.OperationClaims
                                                join uopc in Context.UserOperationClaims on opc.Id equals uopc.OperationClaimId
                                                where uopc.UserId == user.Id
                                                select new OperationClaim 
                                                { 
                                                    Id = opc.Id, Name = opc.Name 
                                                };
            List<OperationClaim> operationClaims = queryResult.ToList();
            return operationClaims;
        }
    }
}
