using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        public static List<string> recipes = new List<string>(new string[] { "Oxtail", "Curry Chicken", "Dumplings" });

        [HttpGet("get_all")]
        public ActionResult GetDishes()
        {
            if (!recipes.Any())
                return NotFound();

            return Ok(recipes);
        }

        [HttpGet("get_one/{index}")]
        public ActionResult GetDishes(int index)
        {
            if (!recipes.Any() || recipes.ElementAtOrDefault(index) == null)
                return NotFound();

            return Ok(recipes[index]);
        }

        [HttpPost("add/{recipe}")]
        public ActionResult CreateNewRecipe(string recipe)
        {
            recipes.Add(recipe);

            return Created("", recipe);
        }

        [HttpPut("update/{index}/{value}")]
        public ActionResult UpdateRecipe(int index, string value)
        {
            if (recipes.ElementAtOrDefault(index) == null)
                return NotFound();

            recipes[index] = value;

            return NoContent();
        }

        [HttpDelete("delete/{index}")]
        public ActionResult DeleteRecipes(int index)
        {
           if (recipes.ElementAtOrDefault(index) == null)
                return BadRequest();                

            recipes.RemoveAt(index);

            return NoContent();
        }

    }
}
