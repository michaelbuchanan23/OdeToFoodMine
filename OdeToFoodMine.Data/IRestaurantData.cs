using OdeToFoodMine.Core;
using System;
using System.Collections.Generic;

namespace OdeToFoodMine.Data
{
	public interface IRestaurantData
	{
		IEnumerable<Restaurant> GetRestaurantsByName(string name);

		Restaurant GetById(int id);
	}
}
