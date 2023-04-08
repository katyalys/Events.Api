using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Events.Api.Extensions
{
	//public static class SeedDatabaseExtensions
	//{
	//	public static void SeedDatabase(IHost host)
	//	{
	//		using (var scope = host.Services.CreateScope())
	//		{
	//			var services = scope.ServiceProvider;
	//			var eventsContext = services.GetRequiredService<EventsDbContext>();
	//			EventsSeed.SeedData(eventsContext);
	//		}
	//	}
	//}

	public static class SeedDatabaseExtensions
	{
		public static async Task<WebApplication> UseDatabaseSeed(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			var services = scope.ServiceProvider;

			await SeedDatabaseAsync(services);

			return app;
		}

		private static async Task SeedDatabaseAsync(IServiceProvider services)
		{
			var eventsContext = services.GetRequiredService<EventsDbContext>();
			await eventsContext.Database.MigrateAsync();

			EventsSeed.SeedData(eventsContext);
		}
	}
}
