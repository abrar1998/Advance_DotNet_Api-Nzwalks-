using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NZZwalks.CustomActionFilters;
using NZZwalks.DataContext;
using NZZwalks.Models.Domain;
using NZZwalks.Models.DTO;
using NZZwalks.RegionRepository;

namespace NZZwalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepo regionRepo;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepo regionRepo, IMapper mapper)
        {
            this.regionRepo = regionRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepo.GetAllRegions();
          /*  var regionDto = new List<RegionDTO>();
            foreach (var item in regions)
            {
                regionDto.Add(new RegionDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    RegionImgUlr = item.RegionImgUlr,
                });
            }*/

            var regionDto = mapper.Map<List<RegionDTO>>(regions);

            return Ok(regionDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRegion([FromRoute]Guid id)
        {
            var domain = await regionRepo.GetRegion(id);
            var dto = new RegionDTO
            {
                Id  = domain.Id,
                Name = domain.Name,
                Code = domain.Code,
                RegionImgUlr = domain.RegionImgUlr
            };

            return Ok(dto);
        }
        /*
                [HttpPost]
                public async Task<IActionResult> Create([FromBody] RegionAddDTO regionAddDto)
                {
                    if(ModelState.IsValid)
                    {
                        var domain = new Region
                        {
                            Name = regionAddDto.Name,
                            Code = regionAddDto.Code,
                            RegionImgUlr = regionAddDto.RegionImgUlr
                        };

                        var DomainModel = await regionRepo.Create(domain);
                        //map dont send domain model to get by id method

                        var regionDto = new RegionDTO
                        {
                            Id = DomainModel.Id,
                            Name = DomainModel.Name,
                            Code = DomainModel.Code,
                            RegionImgUlr = domain.RegionImgUlr,
                        };

                        return CreatedAtAction(nameof(GetRegion), new { id = regionDto.Id }, regionDto);
                    }
                    else
                    {
                        return BadRequest(regionAddDto);
                    }

                }*/


        [HttpPost]
        [ValidateModelAttribute]
        public async Task<IActionResult> Create([FromBody] RegionAddDTO regionAddDto)
        {
            
                var domain = new Region
                {
                    Name = regionAddDto.Name,
                    Code = regionAddDto.Code,
                    RegionImgUlr = regionAddDto.RegionImgUlr
                };

                var DomainModel = await regionRepo.Create(domain);
                //map dont send domain model to get by id method

                var regionDto = new RegionDTO
                {
                    Id = DomainModel.Id,
                    Name = DomainModel.Name,
                    Code = DomainModel.Code,
                    RegionImgUlr = domain.RegionImgUlr,
                };

                return CreatedAtAction(nameof(GetRegion), new { id = regionDto.Id }, regionDto);
          

        }


        //update
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RegionAddDTO regionAddDto)
        {
          
            var regionDomain = new Region
            {
                Name = regionAddDto.Name,
                Code = regionAddDto.Code,
                RegionImgUlr = regionAddDto.RegionImgUlr,
            };

            var updated = await regionRepo.Update(id, regionDomain);
            return Ok(updated);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {

            var deleted = await regionRepo.Delete(id);
            if(deleted == null)
            {
                return NotFound();
            }

            var dto = new RegionDTO
            {
                Id = deleted.Id,
                Name = deleted.Name,
                Code = deleted.Code,
                RegionImgUlr= deleted.RegionImgUlr,
            };
            return Ok(dto);
        }


    }
}
