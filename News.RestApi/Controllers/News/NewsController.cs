using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.Services.News;
using News.Services.News.Contracts;
using News.Services.News.Contracts.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News.RestApi.Controllers.News
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsService _service;

        public NewsController(NewsService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddNewsDto dto)
        {
            await _service.Add(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateNewsDto dto)
        {
            await _service.Update(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllNewsDto>>> GetAll()
        {
            var newsList = await _service.GetAll();
            return Ok(newsList);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetNewsDto>> GetById([FromRoute] int id)
        {
            var news = await _service.GetById(id);
            return Ok(news);
        }
    }
}
