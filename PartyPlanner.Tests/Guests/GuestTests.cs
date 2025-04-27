using PartyPlanner.Models;
using PartyPlanner.Repositories.Implementations;
using PartyPlanner.Data; // Asigură-te că ai referință la PartyPlannerContext
using System;
using System.Linq;
using Xunit;

namespace PartyPlanner.Tests.Guests
{
    public class GuestTests
    {
        // Testează adăugarea unui guest
        [Fact]
        public void AddGuest_ShouldAddGuestSuccessfully()
        {
            // Creează un context in-memory pentru testare
            var context = TestUtils.CreateContext();

            // Creează un repository folosind contextul in-memory
            var repository = new GenericRepository<Guest>(context);

            // Creează un guest nou
            var guest = new Guest("John Doe", "john.doe@example.com", true);

            // Adaugă guest-ul în repository
            repository.Add(guest);

            // Salvează schimbările în contextul de test
            context.SaveChanges();

            // Verifică dacă guest-ul a fost adăugat în baza de date
            var addedGuest = context.Guests.FirstOrDefault(g => g.Name == "John Doe");
            Assert.NotNull(addedGuest); // Asigură-te că guest-ul există
            Assert.Equal("John Doe", addedGuest.Name); // Verifică că numele este corect

            // Afișează datele guest-ului adăugat în consolă
            Console.WriteLine($"Guest added: ID = {addedGuest.Id}, Name = {addedGuest.Name}, Email = {addedGuest.Email}, RSVP = {addedGuest.RSVP}");
        }

        // Testează actualizarea unui guest
        [Fact]
        public void UpdateGuest_ShouldUpdateGuestSuccessfully()
        {
            // Creează un context in-memory pentru testare
            var context = TestUtils.CreateContext();

            // Creează un repository folosind contextul in-memory
            var repository = new GenericRepository<Guest>(context);

            // Creează un guest și adaugă-l în repository
            var guest = new Guest("John Doe", "john.doe@example.com", true);
            repository.Add(guest);
            context.SaveChanges(); // Salvează schimbările inițiale

            // Preia guest-ul din context pentru actualizare
            var existingGuest = context.Guests.FirstOrDefault(g => g.Name == "John Doe");
            existingGuest.Name = "Jane Doe"; // Modifică numele
            existingGuest.Email = "jane.doe@example.com"; // Modifică email-ul

            // Actualizează guest-ul în repository
            repository.Update(existingGuest);
            context.SaveChanges(); // Salvează schimbările în contextul de test

            // Verifică dacă guest-ul a fost actualizat corect
            var updatedGuest = context.Guests.FirstOrDefault(g => g.Name == "Jane Doe");
            Assert.NotNull(updatedGuest); // Verifică dacă guest-ul există în baza de date
            Assert.Equal("Jane Doe", updatedGuest.Name); // Verifică că numele a fost actualizat
            Assert.Equal("jane.doe@example.com", updatedGuest.Email); // Verifică că email-ul a fost actualizat

            // Afișează datele guest-ului actualizat în consolă
            Console.WriteLine($"Guest updated: ID = {updatedGuest.Id}, Name = {updatedGuest.Name}, Email = {updatedGuest.Email}, RSVP = {updatedGuest.RSVP}");
        }
    }
}
