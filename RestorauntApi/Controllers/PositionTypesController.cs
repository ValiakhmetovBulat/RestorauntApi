using Microsoft.AspNetCore.Mvc;
using RestorauntApi.Models;
using RestorauntApi.Models.Entities;
using RestorauntApi.Models.EntititesRepositories.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestorauntApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionTypesController : ControllerBase
    {
        IPositionTypesRepository _db;

        public PositionTypesController(IPositionTypesRepository context)
        {
            _db = context;
        }

        /// <summary>
        /// Gets all the position types
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public async Task<IEnumerable<PositionType>> Get() => await _db.GetAll();

        /// <summary>
        /// Gets position type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionType>> Get(int id)
        {
            var type = await _db.GetById(id);

            if (type == null)
                return NotFound("No such position type");

            return type;
        }

        /// <summary>
        /// Creates new position type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PositionType>> Post(PositionType type)
        {
            if (type == null)
                return BadRequest("Object was null");

            return await _db.Create(type);
        }

        /// <summary>
        /// Updates position type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<PositionType>> Put(PositionType type)
        {
            if (type == null)
                return BadRequest("Object was null");

            return await _db.Update(type);
        }


        /// <summary>
        /// Deletes position type with passed ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<PositionType>> Delete(int id)
        {
            var sec = _db.Find(x => x.Id == id).Result.FirstOrDefault();

            if (sec == null)
                return BadRequest("No such position type");

            return await _db.Delete(sec);
        }
    }
}
