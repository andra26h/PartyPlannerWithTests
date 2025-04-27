using PartyPlanner.Models;
using PartyPlanner.Repositories.Implementations;
using PartyPlanner.Data; // Asigură-te că ai referință la PartyPlannerContext
using System;
using System.Linq;
using Xunit;

namespace PartyPlanner.Tests.Events
{
    public class EventTests
    {
        [Fact]
        public void AddEvent_ShouldAddEventSuccessfully()
        {
            var context = TestUtils.CreateContext();

            var repository = new GenericRepository<Event>(context);

            var newEvent = new Event("Andra's Birthday Party", "Sibiu", DateTime.Parse("2026-12-31"));
            repository.Add(newEvent);

            context.SaveChanges();

            var addedEvent = context.Events.FirstOrDefault(e => e.Title == "Andra's Birthday Party");
            Assert.NotNull(addedEvent); 
            Assert.Equal("Andra's Birthday Party", addedEvent.Title); 
            Assert.Equal("Sibiu", addedEvent.Location); 
            Assert.Equal(DateTime.Parse("2026-12-31"), addedEvent.Date); 


            Console.WriteLine($"Event added: ID = {addedEvent.Id}, Title = {addedEvent.Title}, Location = {addedEvent.Location}, Date = {addedEvent.Date}");
        }

        [Fact]
        public void UpdateEvent_ShouldUpdateEventSuccessfully()
        {
            var context = TestUtils.CreateContext();

            var repository = new GenericRepository<Event>(context);

            var newEvent = new Event("Birthday Party", "New York", DateTime.Parse("2023-12-31"));
            repository.Add(newEvent);
            context.SaveChanges(); 

            
            var existingEvent = context.Events.FirstOrDefault(e => e.Title == "Birthday Party");
            existingEvent.Title = "Wedding Party";
            existingEvent.Location = "Los Angeles";
            existingEvent.Date = DateTime.Parse("2024-05-20"); 

            
            repository.Update(existingEvent);
            context.SaveChanges(); 

            
            var updatedEvent = context.Events.FirstOrDefault(e => e.Title == "Wedding Party");
            Assert.NotNull(updatedEvent); 
            Assert.Equal("Wedding Party", updatedEvent.Title); 
            Assert.Equal("Los Angeles", updatedEvent.Location); 
            Assert.Equal(DateTime.Parse("2024-05-20"), updatedEvent.Date); 


            Console.WriteLine($"Event updated: ID = {updatedEvent.Id}, Title = {updatedEvent.Title}, Location = {updatedEvent.Location}, Date = {updatedEvent.Date}");
        }
    }
}
