using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.ApiModels;
using Fishing_API.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace Fishing_API.Controllers {
    [Route("api/[controller]")]
    public class BaitBrandController(IBaitBrandRepository brandRepository) : Controller {
        private readonly IBaitBrandRepository _brandRepository = brandRepository;

        [HttpGet("list")]
        public async Task<ActionResult<PageListModel<BaitBrandModel>>> List() {
            IQueryable<BaitBrandModel> query = _brandRepository.ListQuery();

            return Ok(await _brandRepository.List(query, 1));
        }
    }
}
