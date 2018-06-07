using HnD.Business.Interfaces.Models;

namespace HnD.Business.Interfaces.Services
{
    public interface IHeroService
    {
        Result<HeroModel> CreateHero(string name);
    }
}