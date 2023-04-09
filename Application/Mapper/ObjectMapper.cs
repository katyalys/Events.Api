using Application.Commands.Update;
using Application.Models;
using Application.Resources.Commands.Create;
using Core.Entity;
using Mapster;

namespace Application.Mapper
{
    public class ObjectMapper: IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Event, EventDto>()
                    .TwoWays();

            config.NewConfig<EventDto, CreateEventCommand>()
                  .TwoWays()
                  .Map(dest => dest.NewEvent, src => src);

            config.NewConfig<EventDto, UpdateEventCommand>()
                  .TwoWays()
                  .Map(dest => dest.UpdatedEvent, src => src);

            config.NewConfig<Event, UpdateEventCommand>()
                 .TwoWays()
                 .Map(dest => dest.UpdatedEvent, src => src);

            config.NewConfig<Event, CreateEventCommand>()
                 .TwoWays()
                 .Map(dest => dest.NewEvent, src => src);
        }
    }
}
