using FlightProject.Domain.Entities;
using FlightProject.Persistence.Context;

namespace FlightProject.API.DbInitializer
{
    public class DbInitializer
    {
        public static void Initialize(FlightDbContext context)
        {
            // Veritabanı oluşturulmuş mu kontrol et
            context.Database.EnsureCreated();

            // Veritabanında zaten veri var mı kontrol et
            if (context.Users.Any() || context.Tickets.Any() || context.Flights.Any())
            {
                return;   // Veritabanı zaten doldurulmuş
            }

            // Kullanıcıları oluştur
            var users = new User[]
            {
            new User { FirstName = "Ayşe", LastName = "Yılmaz" },
            new User { FirstName = "Mehmet", LastName = "Kara" }
            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }

            // Uçuşları oluştur
            var flights = new Flight[]
            {
            new Flight { Departure = "IST", Arrival = "ANK", FlightDate = new DateTime(2024, 06, 10) },
            new Flight { Departure = "IST", Arrival = "IZMR", FlightDate = new DateTime(2024, 06, 12) }
            };

            foreach (Flight f in flights)
            {
                context.Flights.Add(f);
            }

            // Biletleri oluştur
            var tickets = new Ticket[]
            {
            new Ticket { PNRNumber = "123", TicketNumber = "456", Departure = "IST", Arrival = "ANK", FlightDate = new DateTime(2024, 06, 10), User = users[0], Flight = flights[0] },

            new Ticket { PNRNumber = "789", TicketNumber = "101", Departure = "IST", Arrival = "IZMR", FlightDate = new DateTime(2024, 06, 12), User = users[1], Flight = flights[1] }
            };

            foreach (Ticket t in tickets)
            {
                context.Tickets.Add(t);
            }

            context.SaveChanges();
        }
    }
}
