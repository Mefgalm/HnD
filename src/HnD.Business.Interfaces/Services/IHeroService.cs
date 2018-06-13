using HnD.Business.Interfaces.Models;

namespace HnD.Business.Interfaces.Services
{
    public interface IHeroService
    {
        void Create(HeroName heroName, HeroPassword heroPassword);
    }
}