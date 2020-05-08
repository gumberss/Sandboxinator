using System.Collections.Generic;
using Attendance.Proposals.Domain.DomainModels;
using Common.Data;

namespace Attendance.Proposals.Domain.Interfaces.Repositories
{
    public interface IProposalRepository : IRepositoryBase<Proposal>
    {
        IEnumerable<Proposal> GetAll();
    }
}
