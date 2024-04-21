using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Identity.Client;
using NZZwalks.CustomActionFilters;
using NZZwalks.Models.Domain;
using NZZwalks.Models.DTO;
using NZZwalks.WalkRepository;

namespace NZZwalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepo walkRepo;

        public WalksController(IMapper mapper, IWalkRepo walkRepo)
        {
            this.mapper = mapper;
            this.walkRepo = walkRepo;
        }

        //create walk
        
        [HttpPost] 
        [ValidateModel] //custom validaton
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkDTO addWalkDTO)
        {
            var WalkDomain = mapper.Map<Walk>(addWalkDTO);
            var domain = await walkRepo.AddWalk(WalkDomain);
            //
            var getdto = mapper.Map<SendWalkDto>(domain);
            return Ok(getdto);
        }
        //get all walks
        //GET:Walks
        //GEt:/api/walks?filterOn=name?filterquery=track&sortBy=Name&isAscending=true&PageNumber=1&PageSize=1
        [HttpGet]
        public async Task<IActionResult> GetAllwalks([FromQuery] string? filteron, [FromQuery] string? filterquery,
            [FromQuery] string? sortBy,  bool? IsAscending, [FromQuery] int PageNumber = 1 , [FromQuery] int PageSize = 100)
        {
            var domainwalk = await walkRepo.GetAllWalks(filteron, filterquery, sortBy, IsAscending ?? true, PageNumber, PageSize);
            //convert to dto
            var dto = mapper.Map<List<SendWalkDto>>(domainwalk);
            if(dto == null)
            {
                return NotFound();
            }    
            return Ok(dto);
        }

        //get walk by id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            var walkDomain = await walkRepo.GetWalk(id);
            if(walkDomain == null)
            {
                return NotFound();
            }

            var senddto = mapper.Map<SendWalkDto>(walkDomain);

            return Ok(senddto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody] WalkUpdateDto walkUpdateDto)
        {
            //convert incoming dto to domain 
            var domanWak = mapper.Map<Walk>(walkUpdateDto);
            var domain = await walkRepo.WalkUpdate(id, domanWak);
            if(domain == null)
            {
                return NotFound();
            }
            //convert domain to dto
            var sendDto = mapper.Map<SendWalkDto>(domain);
            return Ok(sendDto);
        }
        

    }
}
