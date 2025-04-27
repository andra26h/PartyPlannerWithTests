using Microsoft.EntityFrameworkCore;
using PartyPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPlanner.Tests
{
    public static class TestUtils
    {
        public static PartyPlannerContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<PartyPlannerContext>()
                .UseInMemoryDatabase("PartyPlannerInMemoryDb") // Numele bazei de date în memorie
                .Options;

            var context = new PartyPlannerContext(options);
            return context;
        }


    }
}
