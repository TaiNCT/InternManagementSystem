using Microsoft.EntityFrameworkCore;

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

            // Create entities
            var admin = new User
            {
                Username = "Admin",
                Email = "admin@gmail.com",
                RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
                Role = 1,
                Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A"
            };

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

            var supervisors = new List<User>
    {
        new User
        {
            Username = "Vil",
            Email = "vil@gmail.com",
            Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A",
            RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
            Role = 2,
            Supervisors = new List<Supervisor> { new Supervisor { Team = fullstackTeam } }
        },
        new User
        {
            Username = "Alsha",
            Email = "Alsha@gmail.com",
            Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A",
            RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
            Role = 2,
            Supervisors = new List<Supervisor> { new Supervisor { Team = FETeam } }
        },
        new User
        {
            Username = "Elen",
            Email = "Elen@gmail.com",
            Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A",
            RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
            Role = 2,
            Supervisors = new List<Supervisor> { new Supervisor { Team = BETeam } }
        }
    };

            var internUsers = new List<User>
    {
        new User
        {
            Username = "vinh",
            Email = "Vinh@gmail.com",
            Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A",
            RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
            Role = 3
        },
        new User
        {
            Username = "john",
            Email = "john@gmail.com",
            Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A",
            RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
            Role = 3
        },
        // Add more interns as needed
    };

            var interns = new List<Intern>
    {
        new Intern
        {
            FullName = "Vinh",
            PersonalId = "123456789",
            PhoneNumber = "555-1234",
            Email = "Vinh@gmail.com",
            Uni = "Example University",
            Major = "Computer Science",
            Gpa = 4,
            Team = fullstackTeam,
            Birthday = new DateTime(1998, 4, 12),
            InternshipStartingDate = new DateTime(2024, 7, 1),
            InternshipEndingDate = new DateTime(2024, 7, 30),
            OverallSuccess = 0,
            Status = "approved",

            User = internUsers[0] // Associate with the first user in the list
        },
        new Intern
        {
            FullName = "John",
            PersonalId = "987654321",
            PhoneNumber = "555-4321",
            Email = "john@gmail.com",
            Uni = "Example University",
            Major = "Computer Engineering",
            Gpa = 3.8,
            Team = fullstackTeam,
            Birthday = new DateTime(1997, 6, 15),
            InternshipStartingDate = new DateTime(2024, 7, 1),
            InternshipEndingDate = new DateTime(2024, 7, 30),
            OverallSuccess = 0,
            Status = "approved",
            User = internUsers[1] // Associate with the second user in the list
        },
        // Add more interns as needed
    };


            // Đường dẫn tệp ảnh
            string imagePath = @"D:\PRN221\InternManagementSystem\InternManagementSystem\InternManagement\wwwroot\Image\remix-rumble-1080x1080.jpg";

            // Đọc dữ liệu nhị phân từ tệp ảnh
            byte[] pictureData = await File.ReadAllBytesAsync(imagePath);
            var campains = new List<Campaign>
            {
                new Campaign
                {
                    Tittle = "Fullstack",
                    Description  = "dev",
                    CreatedDate = new DateTime(2024, 7, 1),
                    CreatedBy = "Admin",
                    StartDate = new DateTime(2024, 7, 1),
                    EndDate = new DateTime(2024, 7, 30),
                    Team = fullstackTeam,
                    PictureUrl= pictureData
                },
                 new Campaign
                {
                    Tittle = "BackEnd",
                    Description  = "dev",
                    CreatedDate = new DateTime(2024, 7, 1),
                    CreatedBy = "Admin",
                    StartDate = new DateTime(2024, 7, 1),
                    EndDate = new DateTime(2024, 7, 30),
                    Team = FETeam,
                    PictureUrl= pictureData
                },
                 new Campaign
                {
                    Tittle = "Fronend",
                    Description  = "dev",
                    CreatedDate = new DateTime(2024, 7, 1),
                    CreatedBy = "Admin",
                    StartDate = new DateTime(2024, 7, 1),
                    EndDate = new DateTime(2024, 7, 30),
                    Team = BETeam,
                    PictureUrl= pictureData
                }
            };
            var assignments = new List<Assignment>
    {
        new Assignment
        {
            Team = fullstackTeam,
            Intern = interns[0], // Associate with the first intern in the list
            Description = "Develop a new feature for the project",
            Deadline = new DateTime(2024, 3, 15),
            Grade = 85,
            Weight = 20,
            Feedback="good",
            Submited="abc",
            Complete = true
        },
        new Assignment
        {
            Team = fullstackTeam,
            Intern = interns[0], // Associate with the first intern in the list
            Description = "Develop an update feature for the project",
            Deadline = new DateTime(2024, 3, 15),
            Grade = 95,
            Weight = 20,
            Feedback="good",
            Submited="abc",
            Complete = true
        },
        new Assignment
        {
            Team = fullstackTeam,
            Intern = interns[0], // Associate with the first intern in the list
            Description = "Develop a create feature for the project",
            Deadline = new DateTime(2024, 3, 15),
            Grade = 75,
            Weight =0 ,
            Complete = false
        },new Assignment
        {
            Team = fullstackTeam,
            Intern = interns[1], // Associate with the first intern in the list
            Description = "Develop a new feature for the project",
            Deadline = new DateTime(2024, 3, 15),
            Grade = 100,
            Weight = 20,
            Feedback="good",
            Submited="abc",
            Complete = true
        },
        new Assignment
        {
            Team = fullstackTeam,
            Intern = interns[1], // Associate with the first intern in the list
            Description = "Develop an update feature for the project",
            Deadline = new DateTime(2024, 3, 15),
            Grade = 100,
            Weight = 20,
            Feedback="good",
            Submited="abc",
            Complete = true
        },
        new Assignment
        {
            Team = fullstackTeam,
            Intern = interns[1], // Associate with the first intern in the list
            Description = "Develop a create feature for the project",
            Deadline = new DateTime(2024, 3, 15),
            Grade = 0,
            Weight = 20,
            Complete = false
        }

    };

            // Add entities to database context and save changes
            await _context.Teams.AddRangeAsync(fullstackTeam, FETeam, BETeam);
            await _context.Users.AddRangeAsync(admin);
            await _context.Users.AddRangeAsync(supervisors);
            await _context.Users.AddRangeAsync(internUsers);
            await _context.Interns.AddRangeAsync(interns);
            await _context.Assignments.AddRangeAsync(assignments);
            await _context.Campaigns.AddRangeAsync(campains);

            await _context.SaveChangesAsync();
        }

    }
}
