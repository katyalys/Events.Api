using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace Events.Api.Extensions
{
	public static class SeedDatabaseExtensions
	{
		public static async Task<IHost> UseDatabaseSeed(this IHost app)
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
