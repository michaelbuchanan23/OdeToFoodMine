using Microsoft.AspNetCore.Mvc;
using OdeToFoodMine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFoodMine.Pages.ViewComponents
{
	public class RestaurantCountViewComponent : ViewComponent
	{
		private readonly IRestaurantData restaurantData;
		public int Count { get; set; }

		public RestaurantCountViewComponent(IRestaurantData restaurantData)
		{
			this.restaurantData = restaurantData;
		}

		public IViewComponentResult Invoke()
		{
			var count = restaurantData.GetCountOfRestaurants();
			return View(count);
		}

	}
}
