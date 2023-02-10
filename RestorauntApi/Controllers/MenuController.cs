using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestorauntApi.Models;
using RestorauntApi.Models.Entities;
using RestorauntApi.Models.EntititesRepositories;
using RestorauntApi.Models.EntititesRepositories.Entities;
using RestorauntApi.Models.EntititesRepositories.Interfaces;

namespace RestorauntApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        IMenuPositionsRepository _db;

        public MenuController(IMenuPositionsRepository context)
        {
            _db = context;
        }

        /// <summary>
        /// Gets all the menu positions
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public async Task<IEnumerable<MenuPosition>> Get() => await _db.GetAll();

        /// <summary>
        /// Gets positions in the section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        [HttpGet("{section}")]
        public async Task<ActionResult<IEnumerable<MenuPosition>>> Get(string section)
        {
            return _db.Find(x => x.Section.Name == section).Result.ToList();
        }

        /// <summary>
        /// Gets positions in the type of the section
        /// </summary>
        /// <param name="section"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet("{section}/{type}")]
        public async Task<IEnumerable<MenuPosition>> Get(string section, string type)
        {
            return _db.Find(x => x.Section.Name == section && x.PositionType.Name == type).Result.ToList();
        }

        /// <summary>
        /// Creates new menu position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MenuPosition>> Post(MenuPosition position)
        {
            if (position == null)
                return BadRequest("Object was null");

            return await _db.Create(position);
        }

        /// <summary>
        /// Updates position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<MenuPosition>> Put(MenuPosition position)
        {
            if (position == null)
                return BadRequest("Object was null");

            return await _db.Update(position);
        }


        /// <summary>
        /// Deletes position with passed ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuPosition>> Delete(int id)
        {
            var pos = _db.Find(x => x.Id == id).Result.FirstOrDefault();

            if (pos == null)
                return BadRequest("No such menu position");

            return await _db.Delete(pos);
        }
    }
}
