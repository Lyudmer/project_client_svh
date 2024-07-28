using ClientSVH.DocsBodyCore.Services;
using ClientSVH.DocsBodyCore.Entity;
using Microsoft.AspNetCore.Mvc;
namespace ClientSVH.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocsBodyController : ControllerBase
    {
        private readonly DocBodyServices _docbodyService;

        public DocsBodyController(DocBodyServices docbodyService) =>
        _docbodyService = docbodyService;

        [HttpGet]
        public async Task<List<DocBody>> Get() =>
            await _docbodyService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<DocBody>> Get(int id)
        {
            var docBody = await _docbodyService.GetAsync(id);
            
            if (docBody is null)
            {
                return NotFound();
            }
             return docBody;
        }
        [HttpGet("{guid:length(40)}")]
        public async Task<ActionResult<DocBody>> Get(Guid guid)
        {
            
            var docBody = await _docbodyService.GetAsync(guid);
            if (docBody is null)
            {
                return NotFound();
            }
            return docBody;
            
        }
        [HttpPost]
        public async Task<IActionResult> Post(DocBody newDocBody)
        {
            await _docbodyService.CreateAsync(newDocBody);

            return CreatedAtAction(nameof(Get), new { id = newDocBody.Id, guid = newDocBody.DocId }, newDocBody);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateId(int id, DocBody updatedDocBody)
        {
            var docBody = await _docbodyService.GetAsync(id);

            if (docBody is null)
            {
                return NotFound();
            }

            updatedDocBody.Id = docBody.Id;

            await _docbodyService.UpdateAsync(id, updatedDocBody);

            return NoContent();
        }
        [HttpPut("{guid:length(40)}")]
        public async Task<IActionResult> UpdateGuid(Guid guid, DocBody updatedDocBody)
        {
            var docBody = await _docbodyService.GetAsync(guid);

            if (docBody is null)
            {
                return NotFound();
            }

            updatedDocBody.DocId = docBody.DocId;

            await _docbodyService.UpdateAsync(guid, updatedDocBody);

            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteId(int id)
        {
            var docBody = await _docbodyService.GetAsync(id);

            if (docBody is null)
            {
                return NotFound();
            }

            await _docbodyService.RemoveAsync(id);

            return NoContent();
        }
        [HttpDelete("{guid:length(40)}")]
        public async Task<IActionResult> DeleteGuid(Guid guid)
        {
            var docBody = await _docbodyService.GetAsync(guid);

            if (docBody is null)
            {
                return NotFound();
            }

            await _docbodyService.RemoveAsync(guid);

            return NoContent();
        }
    }     
}
