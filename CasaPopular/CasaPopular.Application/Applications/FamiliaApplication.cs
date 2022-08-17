using CasaPopular.Domain.Entities;
using CasaPopular.Domain.Interfaces.Applications;
using CasaPopular.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaPopular.Application.Applications
{
    public class FamiliaApplication : ApplicationBase<Familia>, IFamiliaApplication
    {
        public FamiliaApplication(IFamiliaService familiaService)
            :base(familiaService)
        {

        }        
    }
}
