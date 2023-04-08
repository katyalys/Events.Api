using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Data
{
    public class EventsSeed
    {
		public static void SeedData(EventsDbContext eventsDbContext)
		{
			if (!eventsDbContext.Events.Any())
			{
				var events = new List<Event>
				{
					new Event
					{
						Theme = "Birthday Party",
						Plan = "Birthday plan",
						Description = "Party until 4 am",
						Organizer = "Katya Lysykh",
						Speaker = "Katya Lysykh",
						Date = DateTime.Now,
						Location = "BSUIR"
					},
					new Event
					{
						Theme = "Taylor Swift concert",
						Plan = "Go to concert",
						Description = "Have fun",
						Organizer = "Taylor Swift",
						Speaker = "Taylor Swift",
						Date = DateTime.Now,
						Location = "Minsk"
					},
					new Event
					{
						Theme = "ChatGPT",
						Plan = "Learn how to use",
						Description = "Gives incorrect answers",
						Organizer = "OpenAI",
						Speaker = "cvfdvf",
						Date = new DateTime(2015, 7, 20, 18, 30, 25),
						Location = "Barcelona"
					}
				};
				eventsDbContext.Events.AddRange(events);
				eventsDbContext.SaveChanges();
			}
        }
    }
}
