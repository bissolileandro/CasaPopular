using CasaPopular.Domain.Entities;
using System.Collections.Generic;

namespace CasaPopular.API.Models
{
    public class FamiliaModel
    {
        public int Id { get; set; }
        public string NomeDaFamilia { get; set; }
        public double RendaTotal { get; set; }
        public int DependentesMaiores { get; set; }
        public int DependentesMenores { get; set; }

        public static IEnumerable<FamiliaModel> EntityToModel(IEnumerable<Familia> entities)
        {
            List<FamiliaModel> models = new List<FamiliaModel>();
            foreach (var item in entities)
            {
                models.Add(EntityToModel(item));
            }

            return models;
        }
        public static FamiliaModel EntityToModel(Familia entity)
        {
            return new FamiliaModel()
            {
                Id = entity.Id,
                DependentesMaiores = entity.DependentesMaiores,
                DependentesMenores = entity.DependentesMenores,
                NomeDaFamilia = entity.NomeDaFamilia,   
                RendaTotal = entity.RendaTotal
            };
        }

        public static IEnumerable<Familia> ModelToEntity(IEnumerable<FamiliaModel> models)
        {
            List<Familia> entities = new List<Familia>();
            foreach (var item in models)
            {
                entities.Add(ModelToEntity(item));
            }
            return entities;
        }

        public static Familia ModelToEntity(FamiliaModel model)
        {
            return new Familia()
            {
                Id = model.Id,
                DependentesMaiores = model.DependentesMaiores,
                NomeDaFamilia = model.NomeDaFamilia,
                DependentesMenores= model.DependentesMenores,
                RendaTotal = model.RendaTotal   
            };
        }
    }
}
