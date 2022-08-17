using CasaPopular.Domain.Entities;
using System.Collections.Generic;

namespace CasaPopular.API.Models
{
    public class PontuacaoModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public int Pontos { get; set; }

        public static IEnumerable<PontuacaoModel> EntityToModel(IEnumerable<Pontuacao> entities)
        {
            List<PontuacaoModel> models = new List<PontuacaoModel>();
            foreach (var item in entities)
            {
                models.Add(EntityToModel(item));
            }

            return models;
        }
        public static PontuacaoModel EntityToModel(Pontuacao entity)
        {
            return new PontuacaoModel()
            {
                Id = entity.Id,
                Descricao = entity.Descricao,
                Valor = entity.Valor,
                Pontos = entity.Pontos                
            };
        }

        public static IEnumerable<Pontuacao> ModelToEntity(IEnumerable<PontuacaoModel> models)
        {
            List<Pontuacao> entities = new List<Pontuacao>();
            foreach (var item in models)
            {
                entities.Add(ModelToEntity(item));
            }
            return entities;
        }

        public static Pontuacao ModelToEntity(PontuacaoModel model)
        {
            return new Pontuacao()
            {
                Id = model.Id,
                Descricao=model.Descricao,
                Pontos = model.Pontos,
                Valor = model.Valor,
            };
        }
    }
}
