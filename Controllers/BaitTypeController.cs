using Fishing_API.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fishing_API.Controllers {
    [Route("api/[controller]")]
    public class BaitTypeController(IBaitTypeRepository baitTypeRepository) : Controller {
        private readonly IBaitTypeRepository _baitTypeRepository = baitTypeRepository;

    }
}
