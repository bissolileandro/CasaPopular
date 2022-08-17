using CasaPopular.Domain.Entities;
using CasaPopular.Domain.Interfaces.Repositories;
using CasaPopular.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Service.Services
{
    public class FamiliaService : ServiceBase<Familia>, IFamiliaService
    {
        private readonly IFamiliaRepository familiaRepository;
        public FamiliaService(IFamiliaRepository familiaRepository)
            :base(familiaRepository)
        {
            this.familiaRepository = familiaRepository;
        }

        public async Task<Familia> GetById(int Id)
        {
            return await familiaRepository.GetById(Id);
        }
    }
}
