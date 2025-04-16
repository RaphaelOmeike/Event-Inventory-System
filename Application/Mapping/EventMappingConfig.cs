using Application.Features.Events.DTOs;
using Domain.Entities;
using Mapster;

namespace Application.Mapping
{
    public class EventMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Event, EventDto>()
                .Map(dest => dest.Duration, src => src.Begin - src.End)
                .Map(dest => dest.RegBegin, src => src.RegistrationBegin)
                .Map(dest => dest.RegEnd, src => src.RegistrationEnd)
                .Map(dest => dest.FilePath, src => src.Picture.FilePath)
                .Map(dest => dest.EventStatuses, src => src.EventStatuses.Select(a => a.Name))
                .Map(dest => dest.EventRegistrars, src => src.EventRegistrars.Select(a => a.Email));
        }
    }
}
