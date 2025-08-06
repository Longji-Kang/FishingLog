using Fishing_API.Data.Repositories.Interfaces;
using Fishing_API.Models.ApiModels.RequestModels;
using Fishing_API.Models.ApiModels.ResponseModels;
using Fishing_API.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace Fishing_API.Controllers {
    [Route("api/[controller]")]
    public class BaitTypeController(IBaitTypeRepository baitTypeRepository) : Controller {
        private readonly IBaitTypeRepository _baitTypeRepository = baitTypeRepository;

        [HttpGet("list")]
        public async Task<ActionResult<PageListModel<BaitTypeModel>>> List([FromQuery] PageRequestObject pageRequest) {
            if (pageRequest.currentPage > 0 && (pageRequest.currentPage <= pageRequest.totalPages || pageRequest.totalPages == null)) {
                IQueryable<BaitTypeModel> query = _baitTypeRepository.ListQuery();

                PageListModel<BaitTypeModel> result = await _baitTypeRepository.List(query, pageRequest.currentPage - 1, pageRequest.pageSize);

                if (pageRequest.currentPage <= result.TotalPages) {
                    return Ok(result);
                } else {
                    return BadRequest("Invalid page number provided");
                }
            } else {
                return BadRequest("Invalid page number provided");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<BaitTypeModel>> Search([FromQuery] string type) {
            if (type != null && type.Length > 0) {
                BaitTypeModel searchModel = new BaitTypeModel();
                searchModel.Type = type;

                BaitTypeModel? result = await _baitTypeRepository.Find(searchModel);

                if (result != null) {
                    return Ok(result);
                } else {
                    return NotFound();
                }
            } else {
                return BadRequest("Bait type cannot be empty");
            }
        }

        [HttpPut("")]
        public async Task<ActionResult<BaitTypeModel>> Add([FromBody] SingleObjectRequests<string> request) {
            if (request != null) {
                string? type = request.Data;

                if (type == null || type.Length == 0) {
                    return BadRequest("Type cannot be empty!");
                } else {
                    BaitTypeModel newType = new BaitTypeModel();
                    newType.Type = type;

                    BaitTypeModel? baitTypeEntity = await _baitTypeRepository.Add(newType);

                    if (baitTypeEntity != null) {
                        return Ok(baitTypeEntity);
                    } else {
                        return Conflict("Bait type already exists!");
                    }
                }
            } else {
                return BadRequest("No valid request object passed!");
            }
        }

        [HttpPatch("")]
        public async Task<ActionResult<BaitTypeModel>> Update([FromBody] SingleObjectRequests<BaitTypeModel> request) {
            if (request != null) {
                BaitTypeModel? requestModel = request.Data;

                if (requestModel != null) {
                    if (requestModel.Id <= 0) {
                        return BadRequest("Invalid ID specified!");
                    }

                    if (requestModel.Type == null || requestModel.Type.Length == 0) {
                        return BadRequest("Type cannot be empty!");
                    }
                    BaitTypeModel? updatedModel = await _baitTypeRepository.Update(requestModel);

                    if (updatedModel != null) {
                        return Ok(updatedModel);
                    } else {
                        return NotFound("No bait types with specified ID found!");
                    }

                } else {
                    return BadRequest("Request data cannot be empty!");
                }
            } else {
                return BadRequest("Request body cannot be empty!");
            }
        }

        [HttpDelete("")]
        public async Task<ActionResult<BaitTypeModel>> Remove([FromBody] SingleObjectRequests<int> request) {
            if (request != null) {
                if (request.Data <= 0) {
                    return BadRequest("Invalid PK provided!");
                }

                BaitTypeModel? deletedModel = await _baitTypeRepository.Remove(request.Data);

                if (deletedModel != null) {
                    return Ok(deletedModel);
                } else {
                    return NotFound("Bait type not found!");
                }
            } else {
                return BadRequest("Request cannot be empty!");
            }
        }
    }
}
