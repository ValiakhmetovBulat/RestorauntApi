using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestorauntApi.Models.Entities;
using RestorauntApi.Models.EntititesRepositories.Entities;
using RestorauntApi.Models;
using RestorauntApi.Models.EntititesRepositories.Interfaces;

namespace RestorauntApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        ISectionsRepository _db;

        public SectionController(ISectionsRepository context)
        {
            _db = context;
        }

        /// <summary>
        /// Gets all the sections
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public async Task<IEnumerable<Section>> Get() => await _db.GetAll();

        /// <summary>
        /// Gets section by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Section>> Get(int id)
        {
            var secton = await _db.GetById(id);

            if (secton == null)
                return NotFound("No such section");

            return secton;
        }

        /// <summary>
        /// Creates new section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Section>> Post(Section section)
        {
            if (section == null)
                return BadRequest("Object was null");

            return await _db.Create(section);
        }

        /// <summary>
        /// Updates section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Section>> Put(Section section)
        {
            if (section == null)
                return BadRequest("Object was null");

            return await _db.Update(section);
        }


        /// <summary>
        /// Deletes section with passed ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Section>> Delete(int id)
        {
            var sec = _db.Find(x => x.Id == id).Result.FirstOrDefault();

            if (sec == null)
                return BadRequest("No such section");

            return await _db.Delete(sec);
        }
    }
}
