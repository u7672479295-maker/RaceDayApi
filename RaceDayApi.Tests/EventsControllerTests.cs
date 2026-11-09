using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayApi.Controllers;
using RaceDayApi.Data;
using RaceDayApi.DataTransferObjects;
using RaceDayApi.Models;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaceDayApi.Tests
{
    public class EventsControllerTests
    {
        private RaceDayContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<RaceDayContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new RaceDayContext(options);
        }

        [Fact]
        public async Task GetAllEvents_ShouldReturnEmptyList_WhenNoEventsExist()
        {
            var context = GetInMemoryDbContext();
            var controller = new EventsController(context);

            var result = await controller.GetAllEvents();

            var okresult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okresult.Value);

        }

        [Fact]
        public async Task CreateEvent_ShouldReturnForbidden_WhenUserIsNotOrganiser()

        {
            var context = GetInMemoryDbContext();
            var participant = new User
            {
                UserID = 1,
                Email = "participant@rcaeday.co.za",
                PasswordHash = "hash",
                FirstName = "Jane",
                LastName = "Doe",
                Role = "Participant"
            };

            context.Users.Add(participant);
            await context.SaveChangesAsync();

            var controller = new EventsController(context);
            var eventDto = new CreateEventDto
            
            {
                Name ="soweto marathon",
                Location = "soweto",
                Date = DateTime.Now.AddDays(30),
                EventType = "run",
                OrganiserUserId = 1,

            };

            var result = await controller.CreateEventsAsync(eventDto);

            var statusResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(403, statusResult.Value);
        }
        
        }
    }

