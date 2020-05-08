using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Attendance.Proposals.Data.Contexts;
using Attendance.Proposals.Domain.DomainModels;
using Attendance.Proposals.Domain.Interfaces.Repositories;
using Common.Data;

namespace Attendance.Proposals.Data.Repositories
{
    public class ProposalRepository : RepositoryBase<Proposal>, IProposalRepository
    {
        public ProposalRepository(ProposalContext context) : base(context)
        {
        }

        public IEnumerable<Proposal> GetAll()
        {
            return DbSet.ToList();
        }
    }
}
