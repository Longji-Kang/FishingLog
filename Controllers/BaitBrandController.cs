using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.ApiModels.RequestModels;
using Fishing_API.Models.ApiModels.ResponseModels;
using Fishing_API.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fishing_API.Controllers {
    [Route("api/[controller]")]
    public class BaitBrandController(IBaitBrandRepository brandRepository) : Controller {
        private readonly IBaitBrandRepository _brandRepository = brandRepository;

        [HttpGet("list")]
        public async Task<ActionResult<PageListModel<BaitBrandModel>>> List([FromQuery] PageRequestObject pageRequest) {
            if (pageRequest.currentPage > 0 && (pageRequest.currentPage <= pageRequest.totalPages || pageRequest.totalPages == null)) {
                IQueryable<BaitBrandModel> query = _brandRepository.ListQuery();

                PageListModel<BaitBrandModel> result = await _brandRepository.List(query, pageRequest.currentPage - 1, pageRequest.pageSize);

                if (pageRequest.currentPage <= result.TotalPages ) {
                    return Ok(result);
                } else {
                    return BadRequest("Invalid page number provided");
                }
            } else {
                return BadRequest("Invalid page number provided");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<BaitBrandModel>> Search([FromQuery] string brand) {
            if (brand.Length > 0 && brand != null) {
                BaitBrandModel searchModel = new BaitBrandModel();
                searchModel.Brand = brand;

                BaitBrandModel? result = await _brandRepository.Find(searchModel);

                if (result != null) {
                    return Ok(result);
                } else {
                    return NotFound();
                }
            } else {
                return BadRequest("Brand name can not be empty!");
            }
        }

        [HttpPut("")]
        public async Task<ActionResult<BaitBrandModel>> Add([FromBody] SingleObjectRequests<string> request) {
            if (request != null) {
                string? name = request.Data;

                if (name == null || name.Length == 0) {
                    return BadRequest("Name cannot be empty");
                } else {
                    BaitBrandModel newBrand = new BaitBrandModel();
                    newBrand.Brand = name;

                    BaitBrandModel? baitBrandEntity = await _brandRepository.Add(newBrand);

                    if (baitBrandEntity != null) {
                        return Ok(baitBrandEntity);
                    } else {
                        return Conflict("Bait brand was not successfully added since it already exists!");
                    }
                }
            } else {
                return BadRequest("No valid request object passed!");
            }
        }

        [HttpPatch("")]
        public async Task<ActionResult<BaitBrandModel>> Update([FromBody] SingleObjectRequests<BaitBrandModel> request) {
            if (request != null) {
                BaitBrandModel? requestModel = request.Data;

                if (requestModel == null) {
                    return BadRequest("Request data cannot be empty!");
                } else {
                    if (requestModel.Id <= 0) {
                        return BadRequest("Invalid ID specified!");
                    }

                    if (requestModel.Brand == null) {
                        return BadRequest("Brand name cannot be empty!");
                    }

                    BaitBrandModel? updatedModel = await _brandRepository.Update(requestModel);

                    if (updatedModel != null) {
                        return Ok(updatedModel);
                    } else {
                        return NotFound("No brands with specified ID found!");
                    }
                }
            } else {
                return BadRequest("Request body cannot be empty!");
            }
        }

        [HttpDelete("")]
        public async Task<ActionResult<BaitBrandModel>> Remove([FromBody] SingleObjectRequests<int> request) {
            if (request != null) {
                if (request.Data <= 0) {
                    return BadRequest("Invalid PK provided!");
                }

                BaitBrandModel? deletedModel = await _brandRepository.Remove(request.Data);

                if (deletedModel != null) {
                    return Ok(deletedModel);
                } else {
                    return NotFound("Brand not found!");
                }
            } else {
                return BadRequest("Request cannot be empty!");
            }
        }
    }
}
