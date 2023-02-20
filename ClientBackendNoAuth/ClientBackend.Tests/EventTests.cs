using ClientBackend.Controllers;
using ClientBackendNoAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClientBackend.Tests
{
    public class Tests
    {
        /// <summary>
        /// Will need inmemory db for proper usage,
        /// todo for rework
        /// </summary>
        EventController eventController;
        List<ClientBackendNoAuth.Models.Event> events;

        [SetUp]
        public void Setup()
        {
            //events = GetTestEvents();
            //eventController = new EventController(events);
        }

        [Test]
        public void GetAllEventsAsync_ShouldReturnAllEvents()
        {
            var res = eventController.GetEvents().Result;
            Assert.That(events, Is.EqualTo(res));
        }

        [Test]
        public void GetEvent_ResponseShouldNotBeNull()
        {
            var res = eventController.Get(2);
            Assert.NotNull(res);
        }

        [Test]
        public void DeleteEvent_ShouldDeleteEvent()
        {
            var res = eventController.Delete(2);
            Assert.NotNull(res);
        }


        private List<Event> GetTestEvents()
        {
            return new List<Event>() {
                new Event { Id = 1, Name = "test", Country = "TestCountry", Location = "TestCity", Capacity = new decimal[] { 22.00m, 0 } },
                new Event { Id = 2, Name = "test1", Country = "TestCountry", Location = "TestCity", Capacity = new decimal[] { 22.00m, 0 } },
                new Event { Id = 3, Name = "test2", Country = "TestCountry", Location = "TestCity", Capacity = new decimal[] { 22.00m, 0 } },
                new Event { Id = 4, Name = "test3", Country = "TestCountry", Location = "TestCity", Capacity = new decimal[] { 22.00m, 0 } }};
        }
    }
}