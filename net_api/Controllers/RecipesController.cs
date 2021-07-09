using Microsoft.AspNetCore.Mvc;
using net_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace net_api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        public static List<Recipe> recipes = new List<Recipe>() {
            new () { Title = "Oxtail", Updated = new DateTime(2021,1,15)},
            new () { Title = "Curry Chicken", Updated = new DateTime(2021,5,19)},
            new () { Title = "Dumplings", Updated = DateTime.Now},
        };

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

        [HttpPost("add")]
        public ActionResult CreateNewRecipe([FromBody] Recipe recipe)
        {
            recipes.Add(recipe);

            return Created("", recipe.Title);
        }
        /*
        {
          "title": "Gallo Pinto",
          "description": "Typical Costa Rican recipe",
          "directions": [
            "to be defined . . ."
          ],
          "ingredients": [
            "Rice", "Beans", "Lizano"
          ],
          "updated": "1900-01-01"
        }         
         */

        [HttpPut("update/{index}")]
        public ActionResult UpdateRecipe(int index, [FromBody] Recipe recipe)
        {
            if (recipes.ElementAtOrDefault(index) == null)
                return NotFound();

            recipes[index] = recipe;

            return NoContent();
        }
        /*
        {
	        "title": "Oxtail",
	        "description": "",
	        "directions": null,
	        "ingredients": [
		        "Chopped Oxtail", "Leeks", "Celery", "Carrots"
	        ],
	        "updated": "2021-07-08"
        } 
         */

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
