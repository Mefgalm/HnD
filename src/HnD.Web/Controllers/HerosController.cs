using HnD.Business.Interfaces.Models;
using HnD.Business.Interfaces.Services;
using HnD.View.Requests;
using HnD.View.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HnD.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HerosController : ControllerBase
    {
        private readonly IHeroService _heroService;

        public HerosController(IHeroService heroService)
        {
            _heroService = heroService;
        }
        
        public Response<HeroModel> Create(CreateHeroRequest request)
        {
            return ToResponse(_heroService.CreateHero(request.Name));
        }
        
        
        
        private Response<T> ToResponse<T>(Result<T> result) => new Response<T>();
    }
}