using Microsoft.EntityFrameworkCore;
using PartyPlanner.Data;
using PartyPlanner.Models;
using PartyPlanner.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPlanner.Tests
{
    public class GenericRepositoryTests
    {
        [Fact]
        public void CreateGuestRepository_ShouldCreateRepositorySuccessfully()
        {
            // Crearea unui context
            var context = TestUtils.CreateContext();

            // Crearea repository-ului pentru Guest
            var repository = new GenericRepository<Guest>(context);

            // Verificarea că repository-ul a fost creat
            Assert.NotNull(repository);
        }

        [Fact]
        public void CreateEventRepository_ShouldCreateRepositorySuccessfully()
        {
            // Crearea unui context
            var context = TestUtils.CreateContext();

            // Crearea repository-ului pentru Event
            var repository = new GenericRepository<Event>(context);

            // Verificarea că repository-ul a fost creat
            Assert.NotNull(repository);
        }

        [Fact]
        public void CreateSupplierRepository_ShouldCreateRepositorySuccessfully()
        {
            // Crearea unui context
            var context = TestUtils.CreateContext();

            // Crearea repository-ului pentru Supplier
            var repository = new GenericRepository<Supplier>(context);

            // Verificarea că repository-ul a fost creat
            Assert.NotNull(repository);
        }

        [Fact]
        public void CreatePlanningTaskRepository_ShouldCreateRepositorySuccessfully()
        {
            // Crearea unui context
            var context = TestUtils.CreateContext();

            // Crearea repository-ului pentru PlanningTask
            var repository = new GenericRepository<PlanningTask>(context);

            // Verificarea că repository-ul a fost creat
            Assert.NotNull(repository);
        }
    }
}
