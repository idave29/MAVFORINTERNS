﻿namespace MAV.Web.Data.Repositories
{
    using MAV.Common.Models;
    using MAV.Web.Data.Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        IEnumerable<SelectListItem> GetComboOwners();
        Task<Owner> GetByIdOwnerWithMaterialsAsync(int id);
        IQueryable GetOwnersWithUser();
        IEnumerable<OwnerRequest> GetOwnersWithMaterials();
        OwnerRequest GetOwnerWithMaterialsByEmail(EmailRequest emailOwner);
        IEnumerable<OwnerRequest> GetOwnersWithMaterialsByName(string name);
        OwnerRequest GetOwnerWithMaterialsById(int id);
    }
}
