using CasaPopular.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Domain.Interfaces.Services
{
    public interface IFamiliaService : IServiceBase<Familia>
    {
        Task<Familia> GetById(int Id);
    }
}
