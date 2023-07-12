using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Application.Contracts.Persistence;
using Tranzact.Premium.Domain;
using Tranzact.Premium.Persistence.DatabaseContext;

namespace Tranzact.Premium.Persistence.Repositories
{
    public class StateRepository : GenericRepository<State>, IStateRepository
    {
        public StateRepository(PremiumDatabaseContext context) : base(context)
        {
        }
    }
}
