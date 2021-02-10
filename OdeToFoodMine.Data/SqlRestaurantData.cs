using OdeToFoodMine.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFoodMine.Data
{
	public class SqlRestaurantData : IRestaurantData
	{
		private readonly OdeToFoodMineDbContext db;

		public SqlRestaurantData(OdeToFoodMineDbContext db)
		{
			this.db = db;
		}
		public Restaurant Add(Restaurant newRestaurant)
		{
			db.Add(newRestaurant);
			Commit();
			return newRestaurant;
		}

		public int Commit()
		{
			return db.SaveChanges();
		}

		public Restaurant Delete(int id)
		{
			var restaurant = GetById(id);
			if(restaurant != null)
			{
				db.Restaurants.Remove(restaurant);
			}
			Commit();
			return restaurant;
		}

		public Restaurant GetById(int? id)
		{
			return db.Restaurants.Find(id);
		}

		public IEnumerable<Restaurant> GetRestaurantsByName(string name)
		{
			var query = from r in db.Restaurants
						where r.Name.StartsWith(name) || string.IsNullOrWhiteSpace(name)
						orderby r.Name
						select r;
			return query;
		}

		public Restaurant Update(Restaurant updatedRestaurant)
		{
			var entity = db.Restaurants.Attach(updatedRestaurant);
			entity.State = EntityState.Modified;
			Commit();
			return updatedRestaurant;
		}
	}
}
