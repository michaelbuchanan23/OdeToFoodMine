using OdeToFoodMine.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFoodMine.Data
{
	public class InMemoryRestaurantData : IRestaurantData
	{
		readonly List<Restaurant> restaurants;
		

		public InMemoryRestaurantData()
		{
			restaurants = new List<Restaurant>()
			{
				new Restaurant { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian },
				new Restaurant { Id = 2, Name = "Rio Grande", Location = "Kentucky", Cuisine = CuisineType.Mexican },
				new Restaurant { Id = 3, Name = "La Costa", Location = "California", Cuisine = CuisineType.Indian }
			};
		}
		public IEnumerable<Restaurant> GetRestaurantsByName(string name)
		{
			return from r in restaurants
				   where string.IsNullOrWhiteSpace(name) || r.Name.ToUpper().StartsWith(name.ToUpper())
				   orderby r.Name
				   select r;
		}

		public Restaurant GetById(int id)
		{
			return restaurants.SingleOrDefault(x => x.Id == id);
		}
	}
}
