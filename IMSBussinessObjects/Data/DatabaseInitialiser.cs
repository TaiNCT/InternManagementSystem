using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IMSBussinessObjects.Data
{
    public interface IDataaseInitialiser
    {
        Task InitialiseAsync();
        Task SeedAsync();
        Task TrySeedAsync();
    }

    public class DatabaseInitialiser : IDataaseInitialiser
    {
        private readonly AppDbContext _context;

        public DatabaseInitialiser(AppDbContext context)
        {
            _context = context;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                // Migrate database - Create database if it does not exist
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task TrySeedAsync()
        {

            if (_context.Teams.Any() && _context.Users.Any()
                && _context.Interns.Any() && _context.Assignments.Any())
            {
                return;
            }

            var fullstackTeam = new Team
            {
                TeamName = "FullStack"
            };
            var FETeam = new Team
            {
                TeamName = "Front End"
            };
            var BETeam = new Team
            {
                TeamName = "Back End"
            };

            var userSupervisor1 = new User
            {
                Username = "Vil",
                Email = "vil@gmail.com",
                Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A",
                RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
                Role = 2,
                Supervisors = new List<Supervisor>
{
    new Supervisor { Team = fullstackTeam }
}
            };
            var userSupervisor2 = new User
            {
                Username = "Alsha",
                Email = "Alsha@gmail.com",
                Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A",
                RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
                Role = 2,
                Supervisors = new List<Supervisor>
{
    new Supervisor { Team = FETeam }
}
            };
            var userSupervisor3 = new User
            {
                Username = "Elen",
                Email = "Elen@gmail.com",
                Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A",
                RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
                Role = 2,
                Supervisors = new List<Supervisor>
{
    new Supervisor { Team = BETeam }
}
            };
            var internUser = new User
            {
                Username = "vinh",
                Email = "Vinh@gmail.com",
                Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A",
                RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
                Role = 3,

            };
            var intern1 = new Intern
            {
                FullName = "John Doe",
                PersonalId = "123456789",
                PhoneNumber = "555-1234",
                Email = "john.doe@example.com",
                Uni = "Example University",
                Major = "Computer Science",
                Gpa = 4,
                Team = fullstackTeam,
                Birthday = new DateTime(1998, 4, 12),
                InternshipStartingDate = new DateTime(2024, 1, 1),
                InternshipEndingDate = new DateTime(2024, 6, 30),
                OverallSuccess = 90,
                Status = "approved",
                User = internUser
            };

            var assignment1 = new Assignment
            {
                Team = fullstackTeam,
                Intern = intern1,
                Description = "Develop a new feature for the project",
                Deadline = new DateTime(2024, 3, 15),
                Grade = 85,
                Weight = 20,
                Complete = true
            };
            var assignment2 = new Assignment
            {
                Team = fullstackTeam,
                Intern = intern1,
                Description = "Develop a Update feature for the project",
                Deadline = new DateTime(2024, 3, 15),
                Grade = 95,
                Weight = 20,
                Complete = true
            };
            var assignment3 = new Assignment
            {
                Team = fullstackTeam,
                Intern = intern1,
                Description = "Develop a create feature for the project",
                Deadline = new DateTime(2024, 3, 15),
                Grade = 75,
                Weight = 20,
                Complete = true
            };

            await _context.Teams.AddRangeAsync(fullstackTeam, FETeam, BETeam);
            await _context.Users.AddRangeAsync(userSupervisor1, userSupervisor2, userSupervisor3, internUser);
            await _context.Interns.AddRangeAsync(intern1);
            await _context.Assignments.AddRangeAsync(assignment1, assignment2, assignment3);

            await _context.SaveChangesAsync();
        }
    }
}
