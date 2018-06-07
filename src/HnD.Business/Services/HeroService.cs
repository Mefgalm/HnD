using HnD.Business.Attributes;
using HnD.Business.Interfaces.Models;
using HnD.Business.Interfaces.Services;
using HnD.Repositories.Interfaces.Repositories;

namespace HnD.Business.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRespository _heroRespository;

        public HeroService(IHeroRespository heroRespository)
        {
            _heroRespository = heroRespository;
        }
        
        public Result<HeroModel> CreateHero([HeroName] string name)
        {
            throw new System.NotImplementedException();
        }
    }
}