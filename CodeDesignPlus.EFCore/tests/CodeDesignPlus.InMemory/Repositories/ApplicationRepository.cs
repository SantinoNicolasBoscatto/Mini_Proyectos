using CodeDesignPlus.Abstractions;
using CodeDesignPlus.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDesignPlus.InMemory.Repositories
{
    public class ApplicationRepository : Repository, IApplicationRepository
    {
        public ApplicationRepository(DbContext context) : base(context)
        { }
    }
}
