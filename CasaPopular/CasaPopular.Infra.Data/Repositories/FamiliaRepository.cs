using CasaPopular.Domain.Entities;
using CasaPopular.Domain.Interfaces.Repositories;
using CasaPopular.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Infra.Data.Repositories
{
    public class FamiliaRepository : RepositoryBase<Familia>, IFamiliaRepository
    {
        public FamiliaRepository(CasaPopularContext context) 
            :base(context)
        {

        }

        public async Task<Familia> GetById(int Id)
        {
            return await db.Set<Familia>().FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
