using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayApi.Controllers;
using RaceDayApi.Data;
using RaceDayApi.DataTransferObjects;
using RaceDayApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xunit;

namespace RaceDayApi.Tests
{
    public class AuthenticationControllerTests
    {
        private RaceDayContext GetInMemoryDbContext()
        {

            var options = new DbContextOptionsBuilder<RaceDayContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())

                .Options;

            return new RaceDayContext(options);
        

        }

        [Fact]

        public async Task Register_ShouldReturnOk_WhenUserIsNew()
        {
            var context = GetInMemoryDbContext();
            var controller = new AuthenticationController(context);

            var registerDto = new RegisterDto
            {
                Email = "organiser@raceday.co.za",
                Password = "Password123!",
                FirstName = "Sipho",
                LastName = "Dlamini",
                Role = "Organiser"
            };


            var result = await controller.Register(registerDto);

            var okResult = Assert.IsType<OkResult>(result);
            Assert.NotNull(okResult.Value);
        
        
        }

        [Fact]
        public async Task Register_ShouldReturnConflict_WhenEmailAlreadyExists()
        {
            var context = GetInMemoryDbContext();
            context.Users.Add(new User
            {
                Email = "runner@raceday.co.za",
                Password = "hash",
                FirstName = "Dike",
                LastName = "Mazibuko",
                Role = "Organiser"

            });

            await context.SaveChangesAsync();

            var controller = new AuthenticationController(context);
            var dublicateDto = new RegisterDto
            {

                Email = "runner@raceday.co.za",
                Password = "Password123!",
                FirstName = "Johnny",
                LastName = "Test",
                Role = "Participant"

            };
            var result = await controller.Register(duplicateDto);

            Assert.IsType<ConflictObjectResult>(result);
        }

    }
}
