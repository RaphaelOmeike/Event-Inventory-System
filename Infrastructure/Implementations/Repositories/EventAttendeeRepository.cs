﻿using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Implementations.Repositories
{
    public class EventAttendeeRepository : GenericRepository<EventAttendee>, IEventAttendeeRepository
    {
        public EventAttendeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
