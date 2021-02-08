using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFoodMine.Core;
using OdeToFoodMine.Data;

namespace OdeToFoodMine.Pages.Restaurants
{
	public class EditModel : PageModel
	{
		private readonly IHtmlHelper htmlHelper;
		private readonly IRestaurantData restaurantData;

		[BindProperty]
		public Restaurant Restaurant { get; set; }
		public IEnumerable<SelectListItem> Cuisines { get; set; }

		public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
		{
			this.restaurantData = restaurantData;
			this.htmlHelper = htmlHelper;
		}


		public IActionResult OnGet(int? restaurantId)
		{
			Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
			if (restaurantId.HasValue)
			{
				Restaurant = restaurantData.GetById(restaurantId);
			}
			else
			{
				Restaurant = new Restaurant();
			}
			if (Restaurant == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
		}

		public IActionResult OnPost(Restaurant restaurant)
		{
			if (!ModelState.IsValid)
			{
				Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
				return Page();
			}

			if (restaurant.Id > 0)
			{
				restaurantData.Update(restaurant);
				TempData["Message"] = "Restaurant updated!";
			}
			else
			{
				restaurantData.Add(restaurant);
				TempData["Message"] = "Restaurant saved!";
			}
			restaurantData.Commit();

			return RedirectToPage($"./Detail", new { restaurantId = restaurant.Id }); //redirects to Detail?restaurantId=3
		}
	}
}
