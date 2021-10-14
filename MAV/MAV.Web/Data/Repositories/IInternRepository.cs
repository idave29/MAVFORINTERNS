﻿namespace MAV.Web.Data.Repositories
{
    using MAV.Web.Data.Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IInternRepository : IGenericRepository<Intern>
    {
        IEnumerable<SelectListItem> GetComboInterns();
        IQueryable GetInternsWithUser();
        Task<Intern> GetByIdInternWithLoansAsync(int id);
        Task<Intern> GetByIdInternWithLoansLoansDetailsAsync(int id);

        Task<Intern> GetByIdWithUserAsync(int id);
    }
}