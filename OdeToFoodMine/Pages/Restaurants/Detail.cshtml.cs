using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFoodMine.Core;
using OdeToFoodMine.Data;

namespace OdeToFoodMine.Pages.Restaurants
{
    public class DetailModel : PageModel
    {

		public Restaurant Restaurant { get; set; }
		public IRestaurantData resturantData { get; set; }
		
        public DetailModel(IRestaurantData restaurantData)
		{
            this.resturantData = restaurantData;
		}

        public IActionResult OnGet(int restaurantId)
        {
            
            Restaurant = resturantData.GetById(restaurantId);
            if(Restaurant == null)
			{
                return RedirectToPage("./NotFound");
			}

            return Page();
        }
    }
}

