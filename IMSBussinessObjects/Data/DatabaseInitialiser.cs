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
            User admin = new()
            {
                Username = "Admin",
                Email = "admin@gmail.com",
                RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
                Role = 1,
                Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A"
            };

            Team fullstackTeam = new()
            {
                TeamName = "FullStack"
            };

            Team FETeam = new()
            {
                TeamName = "Front End"
            };

            Team BETeam = new()
            {
                TeamName = "Back End"
            };

            List<User> supervisors = new()
            {
        new User
        {
            Username = "Vil",
            Email = "vil@gmail.com",
            Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A",
            RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
            Role = 2,
            Supervisors = new List<Supervisor> { new() { Team = fullstackTeam } }
        },
        new User
        {
            Username = "Alsha",
            Email = "Alsha@gmail.com",
            Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A",
            RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
            Role = 2,
            Supervisors = new List<Supervisor> { new() { Team = FETeam } }
        },
        new User
        {
            Username = "Elen",
            Email = "Elen@gmail.com",
            Password = "45A146CB3ECF0DA9C085501C3B95670DB80049DC5DABEF725A343C143D549F3A",
            RefreshToken = "FB8B0CD03B9B4D76AFAFEC4BE351626C0E6E8C937F5354CF973BA719183D4214",
            Role = 2,
            Supervisors = new List<Supervisor> { new() { Team = BETeam } }
        }
    };

            List<User> internUsers = new()
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

            List<Intern> interns = new()
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
            string imagePath1 = @"D:\PRN221\InternManagementSystem\InternManagementSystem\InternManagement\wwwroot\Image\FS.png";

            // Đọc dữ liệu nhị phân từ tệp ảnh
            byte[] pictureData1 = await File.ReadAllBytesAsync(imagePath1);
            // Đường dẫn tệp ảnh
            string imagePath2 = @"D:\PRN221\InternManagementSystem\InternManagementSystem\InternManagement\wwwroot\Image\BE.png";

            // Đọc dữ liệu nhị phân từ tệp ảnh
            byte[] pictureData2 = await File.ReadAllBytesAsync(imagePath2);
            // Đường dẫn tệp ảnh
            string imagePath3 = @"D:\PRN221\InternManagementSystem\InternManagementSystem\InternManagement\wwwroot\Image\FE.png";

            // Đọc dữ liệu nhị phân từ tệp ảnh
            byte[] pictureData3 = await File.ReadAllBytesAsync(imagePath3);

            List<Campaign> campains = new()
            {
                new Campaign
                {
                    Tittle = "Fullstack",
                    Description  = "A good track record in education. Some experience (6-12 months ideally) in a marketing role, agency or client side. An interest in ideas and brand identity design. Interest in working with global clients and an international mindset. Enthusiasm, energy, and a positive attitude. An ability to work well as part of a team. A good communicator. Keen to learn (new tech, design & presentation skills). An attention to detail. A self-starter who can identify the next steps and requirements of a project",
                    CreatedDate = new DateTime(2024, 7, 1),
                    CreatedBy = "Admin",
                    StartDate = new DateTime(2024, 7, 1),
                    EndDate = new DateTime(2024, 7, 30),
                    Team = fullstackTeam,
                    PictureUrl= pictureData1
                },
                 new Campaign
                {
                    Tittle = "BackEnd",
                    Description  = "Minimum 18 months experience in a similar role within a creative retail display/production environment. Understanding of 3D visual merchandising for retail. Demonstrated client-facing project management experience. Familiarity with material and fabrication processes for 3D prop making. Experience managing external suppliers and budgets exceeding £250k. Ability to manage multiple projects simultaneously. Experience supervising support staff. Strong decision-making and communication skills. Proficiency in Excel and good numeracy skills.",
                    CreatedDate = new DateTime(2024, 7, 1),
                    CreatedBy = "Admin",
                    StartDate = new DateTime(2024, 7, 1),
                    EndDate = new DateTime(2024, 7, 30),
                    Team = FETeam,
                    PictureUrl= pictureData2
                },
                 new Campaign
                {
                    Tittle = "Fronend",
                    Description  = "Proven success in leading and executing sales and business development campaigns. An extensive network of AAA international brand clients. Experience in building and managing a small sales team. Ability to oversee marketing functions to ensure Sales Strategy alignment. Talent for identifying and pursuing strategic opportunities. Strong communication skills for conveying complex strategic ideas to potential clients. A relentless drive to achieve success and win. Excellent interpersonal skills.",
                    CreatedDate = new DateTime(2024, 7, 1),
                    CreatedBy = "Admin",
                    StartDate = new DateTime(2024, 7, 1),
                    EndDate = new DateTime(2024, 7, 30),
                    Team = BETeam,
                    PictureUrl= pictureData3
                }
            };
            List<Assignment> assignments = new()
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
            Grade = 0,
            Weight =20 ,
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
            Grade = 10,
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

            _=await _context.SaveChangesAsync();
        }

    }
}
