﻿using MAV.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MAV.Web.Data.Repositories
{
    public class LoanDetailRepository : GenericRepository<LoanDetail>, ILoanDetailRepository
    {
        private readonly DataContext dataContext;

        public LoanDetailRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public IQueryable GetLoanDetailsWithMaterialAndLoan()
        {
            return this.dataContext.LoanDetails
                .Include(t => t.Material)
                .Include(t => t.Loan);
        }

        public IQueryable GetLoanDetails()
        {
            return this.dataContext.LoanDetails
                .Include(ld => ld.Loan)
                .ThenInclude(l => l.Applicant)
                .ThenInclude(a => a.User)
                .Include(ld => ld.Material)
                .Where(ld => ld.DateTimeIn != null);
        }
    }
}
