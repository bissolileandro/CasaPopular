using CasaPopular.Domain.Entities;
using CasaPopular.Domain.Interfaces.Applications;
using System.Collections.Generic;

namespace CasaPopular.API.Models
{
    public class FamiliaResultadoModel
    {
        public int Id { get; set; }
        public string NomeDaFamilia { get; set; }
        public double RendaTotal { get; set; }
        public int DependentesMaiores { get; set; }
        public int DependentesMenores { get; set; }
        public int Resultado { get; set; }

        public static IEnumerable<FamiliaResultadoModel> EntityToModel(IEnumerable<Familia> entities, IPontuacaoApplication pontuacaoApplication)
        {
            List<FamiliaResultadoModel> models = new List<FamiliaResultadoModel>();
            foreach (var item in entities)
            {
                models.Add(EntityToModel(item, pontuacaoApplication));
            }

            return models;
        }
        public static FamiliaResultadoModel EntityToModel(Familia entity, IPontuacaoApplication pontuacaoApplication)
        {
            return new FamiliaResultadoModel()
            {
                Id = entity.Id,
                DependentesMaiores = entity.DependentesMaiores,
                DependentesMenores = entity.DependentesMenores,
                NomeDaFamilia = entity.NomeDaFamilia,
                RendaTotal = entity.RendaTotal,
                Resultado = pontuacaoApplication.ObterResultadoDePontuacao(entity.Id)

            };
        }

        public static IEnumerable<Familia> ModelToEntity(IEnumerable<FamiliaResultadoModel> models)
        {
            List<Familia> entities = new List<Familia>();
            foreach (var item in models)
            {
                entities.Add(ModelToEntity(item));
            }
            return entities;
        }

        public static Familia ModelToEntity(FamiliaResultadoModel model)
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
