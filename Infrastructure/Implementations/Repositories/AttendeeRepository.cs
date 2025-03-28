﻿using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Implementations.Repositories
{
    public class AttendeeRepository : GenericRepository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
