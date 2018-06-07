using HnD.Business.Interfaces.Models;
using HnD.Business.Interfaces.Services;
using HnD.Repositories.Interfaces.Repositories;

namespace HnD.Business
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRespository _heroRespository;

        public HeroService(IHeroRespository heroRespository)
        {
            _heroRespository = heroRespository;
        }
        
        public Result<HeroModel> CreateHero()
        {
            throw new System.NotImplementedException();
        }
    }
}