using Microsoft.EntityFrameworkCore;
using OdeToFoodMine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFoodMine.Data
{
	public class OdeToFoodMineDbContext : DbContext
	{
		public OdeToFoodMineDbContext(DbContextOptions<OdeToFoodMineDbContext> options) 
			: base(options)
		{

		}

		public DbSet<Restaurant> Restaurants { get; set; }
	}
}
