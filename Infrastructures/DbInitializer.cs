using Applications.Utils;
using Bogus;
using Bogus.Extensions;
using Domain.Base;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures
{
    public class DbInitializer
    {
        private const string WORDS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NUMBERS = "1234567890";
        private readonly AppDbContext context;

        public DbInitializer(AppDbContext context)
        {
            this.context = context;
        }
        #region fake_Hard_Data
        private List<string> _videos = new List<string>()
            {
                "https://www.youtube.com/watch?v=M0jdFS4ZyEk&list=PLRhlTlpDUWsyK1TIsewrQ7WwC7QkCSCPD&index=1&pp=iAQB",
                "https://youtu.be/B36H9eOELgY?list=PLRhlTlpDUWsyK1TIsewrQ7WwC7QkCSCPD",
                "https://youtu.be/NP0BGVfPD9s?list=PLRhlTlpDUWsyK1TIsewrQ7WwC7QkCSCPD",
                "https://youtu.be/_TQVelWQ_0A?list=PLRhlTlpDUWsyK1TIsewrQ7WwC7QkCSCPD",
                "https://youtu.be/ctxTfF1E8B4?list=PLRhlTlpDUWsyK1TIsewrQ7WwC7QkCSCPD",
                "https://youtu.be/fVDXDL4P2zc?list=PLRhlTlpDUWsyK1TIsewrQ7WwC7QkCSCPD",
            };
        #endregion
        private bool HasData()
        {
            var dbSets = new List<IQueryable<object>> // Use 'object' to create a list that can hold different DbSet types
            {
                context.Admins,//
                context.WeeklyTimes,//
                context.Certifications,
                context.CourseMajors,//
                context.OnlineClasses,
                context.Orders,//
                context.OrderDetails,//
                context.Ratings,//
                context.Reports,//
                context.Roles,//
                context.Students,//
                context.TeachingCourses,//
                context.Transactions,//
                context.Tutors,//
                context.TutorFeedbacks,//
                context.Universities,//
                context.Units,//
                context.Users,//
                context.Wallets,//
                context.FavoriteCourses//
            };

            foreach (var dbSet in dbSets)
            {
                if (dbSet.Any())
                {
                    return true;
                }
            }

            return false;
        }

        public void Seed()
        {
            if (HasData())
            {
                return;
            }
            var roles = CreateRole();
            var users = CreateUser(10, roles);
            var students = users.Where(x => x.Student != null).Select(x => x.Student).ToList();
            var tutors = users.Where(x => x.Tutor != null).Select(x => x.Tutor).ToList();
            var admins = users.Where(x => x.Admin != null).Select(x => x.Admin).ToList();
            var universities = CreateUniversity(10);
            var teachingCourses = CreateTeachingCourse(10, tutors, universities);
            var wallets = users.Select(x => x.Wallet).ToList();
            var transactions = CreateTransactions(10, wallets);
            var orders = CreateOrders(10, students, tutors);
            var orderDetails = CreateOrderDetails(50, orders, teachingCourses);
            var ratings = CreateRatings(20, students, teachingCourses);
            var reports = CreateReports(20, users, admins);
            var units = CreateUnits(50, teachingCourses);
            var favorites = CreateFavoriteCourses(20, students, teachingCourses);
            var tutorFeedbacks = CreateTutorFeedbacks(20, students, tutors);
            var weeklyTimes = CreateWeeklyTimes(10, teachingCourses);
            var OnlineClasses = CreateOnlineClasses(20, students, teachingCourses);
            var Certifications = CreateCertifications(20,tutors,admins);
        }

        private List<Certification> CreateCertifications(int count, List<Tutor> tutors, List<Admin> admins)
        {
            var certifications = new Faker<Certification>()
                .RuleFor(c => c.CertificationName, f => f.Lorem.Word())
                .RuleFor(c => c.CertificationLink, f => f.Internet.Url())
                .RuleFor(c => c.IsAuthorize, f => f.Random.Bool())
                .RuleFor(c => c.AuthorizeBy, f => f.PickRandom(admins).Id)
                .RuleFor(c => c.TutorId, f => f.PickRandom(tutors).Id)
                .Generate(count);

            context.Certifications.AddRange(certifications);
            context.SaveChanges();

            return certifications;
        }

        private List<OnlineClass> CreateOnlineClasses(int count, List<Student> students, List<TeachingCourse> teachingCourses)
        {
            var existingKeys = new Dictionary<string, OnlineClass>();

            var onlineClasses = new Faker<OnlineClass>()
                .RuleFor(oc => oc.StudentId, f => f.PickRandom(students).Id)
                .RuleFor(oc => oc.TeachingCourseId, f => f.PickRandom(teachingCourses).Id)
                .FinishWith((faker, onlineClass) =>
                {
                    var key = $"{onlineClass.StudentId}:{onlineClass.TeachingCourseId}";

                    if (!existingKeys.ContainsKey(key))
                    {
                        existingKeys.Add(key, onlineClass);
                    }
                }).Generate(count);

            onlineClasses = existingKeys.Values.ToList();
            context.OnlineClasses.AddRange(onlineClasses);
            context.SaveChanges();

            return onlineClasses;
        }

        private List<WeeklyTime> CreateWeeklyTimes(int count, List<TeachingCourse> teachingCourses)
        {
            List<WeeklyTime> weeklyTimes = new Faker<WeeklyTime>()
                .RuleFor(wt => wt.DayOfWeek, f => f.PickRandom<DayOfWeek>())
                .RuleFor(wt => wt.StartTime, f => f.Date.Recent())
                .RuleFor(wt => wt.EndTime, (f, wt) => wt.StartTime.AddHours(f.Random.Number(1, 5)))
                .RuleFor(wt => wt.TeachingCourseId, f => f.PickRandom(teachingCourses).Id)
                .Generate(count);

            context.WeeklyTimes.AddRange(weeklyTimes);
            context.SaveChanges();

            return weeklyTimes;
        }
        private List<TutorFeedback> CreateTutorFeedbacks(int count, List<Student?> students, List<Tutor?> tutors)
        {
            var existingKeys = new Dictionary<string, TutorFeedback>();

            List<TutorFeedback> tutorFeedbacks = new Faker<TutorFeedback>()
                .RuleFor(tf => tf.StudentId, f => f.PickRandom(students).Id)
                .RuleFor(tf => tf.TutorId, f => f.PickRandom(tutors).Id)
                .RuleFor(tf => tf.FeedbackContent, f => f.Lorem.Sentence())
                .RuleFor(tf => tf.RatingStar, f => f.Random.Number(1, 5))
                .RuleFor(tf => tf.CreationDate, f => f.Date.Recent())
                .RuleFor(tf => tf.CreatedBy, f => f.Random.Int(1, 100))
                .FinishWith((faker, tutorFeedback) =>
                {
                    var key = $"{tutorFeedback.StudentId}:{tutorFeedback.TutorId}";

                    if (!existingKeys.ContainsKey(key))
                    {
                        existingKeys.Add(key, tutorFeedback);
                    }
                    else
                    {
                        // If the key already exists, set the object to null.
                        tutorFeedback = null;
                    }
                })
                .Generate(count);

            // Save tutorFeedbacks to the context and save changes
            tutorFeedbacks = existingKeys.Values.ToList();
            context.TutorFeedbacks.AddRange(tutorFeedbacks);
            context.SaveChanges();
            return tutorFeedbacks;
        }

        public List<FavoriteCourse> CreateFavoriteCourses(int count, List<Student> students, List<TeachingCourse> courses)
        {

            var existingKeys = new Dictionary<string, FavoriteCourse>();

            List<FavoriteCourse> favorites = new Faker<FavoriteCourse>()
              .RuleFor(f => f.Id, f => f.UniqueIndex)
              .RuleFor(f => f.StudentId, f => f.PickRandom(students).Id)
              .RuleFor(f => f.TeachingCourseId, f => f.PickRandom(courses).Id)
             .FinishWith((faker, favoriteCourse) =>
             {
                 var key = $"{favoriteCourse.StudentId}:{favoriteCourse.TeachingCourseId}";

                 if (!existingKeys.ContainsKey(key))
                 {
                     existingKeys.Add(key, favoriteCourse);
                     return;
                 }
                 favoriteCourse = null;
             }).Generate(count);

            // Save to context

             favorites = existingKeys.Select(x=>x.Value).ToList();
            context.AddRange(favorites);
            context.SaveChanges();
            return favorites;

        }
        public List<Unit> CreateUnits(int count, List<TeachingCourse> courses)
        {
            List<Unit> units = new Faker<Unit>()
                          .RuleFor(u => u.UnitName, f => f.Lorem.Sentence(5))
                          .RuleFor(u => u.MinuteTime, f => f.Random.Number(30, 90))
                          .RuleFor(u => u.Content, f => f.Lorem.Paragraphs(1, 4))
                          .RuleFor(u => u.HomeWorkFile, f => GetSeedingFile(f))
                          .RuleFor(u => u.TeachingMaterialFile, f => GetSeedingFile(f))
                          .RuleFor(u => u.TeachingCourseId, f => f.PickRandom(courses).Id)
                          .Generate(count);
            context.AddRange(units);
            context.SaveChanges();
            return units;
        }
        public List<Report> CreateReports(int count, List<User> users, List<Admin> admins)
        {
            List<Report> reports = new Faker<Report>()
                          .RuleFor(r => r.ReportName, f => f.Lorem.Sentence(5))
                          .RuleFor(r => r.ReportContent, f => f.Lorem.Paragraphs(1, 4))
                          .RuleFor(r => r.RequestType, f => f.PickRandom<RequestType>())
                          .RuleFor(r => r.ReportStatus, f => f.PickRandom<ReportStatus>())
                          .RuleFor(r => r.ResolveBy, f => f.PickRandom(admins).Id)
                          .RuleFor(r => r.CreationDate, f => f.Date.Past(1))
                          .RuleFor(r => r.UserId, f => f.PickRandom(users).Id)
                          .Generate(count);
            context.AddRange(reports);
            context.SaveChanges();
            return reports;

        }
        private List<Rating> CreateRatings(int count, List<Student> students, List<TeachingCourse> courses)
        {
            var existingKeys = new Dictionary<string, Rating>();
            List<Rating> ratings = new Faker<Rating>()
                          .RuleFor(r => r.RatingStar, f => f.Random.Number(1, 5))
                          .RuleFor(r => r.Feedback, f => f.Lorem.Sentence())
                          .RuleFor(r => r.CreationDate, f => f.Date.Past())
                          .RuleFor(r => r.StudentId, f => f.PickRandom(students).Id)
                          .RuleFor(r => r.TeachingCourseId, f => f.PickRandom(courses).Id)
                            .FinishWith((faker, rating) =>
                            {
                                var key = $"{rating.StudentId}:{rating.TeachingCourseId}";

                                if (!existingKeys.ContainsKey(key))
                                {
                                    existingKeys.Add(key,rating);
                                    return;
                                }
                                rating = null;
                            }).Generate(count).Where(x => x != null).ToList();
            ratings = existingKeys.Values.ToList();
            context.AddRange(ratings);
            context.SaveChanges();
            return ratings;
        }

        private List<OrderDetail> CreateOrderDetails(int count, List<Order> orders, List<TeachingCourse> teachingCourses)
        {
            var existingKeys = new Dictionary<string, OrderDetail>();
            List<OrderDetail> orderDetails = new Faker<OrderDetail>()
                            .RuleFor(d => d.OrderId, f => f.PickRandom(orders).Id)
                            .RuleFor(d => d.TeachingCourseId, f => f.PickRandom(teachingCourses).Id)
                            .FinishWith((faker, orderDetail) =>
                            {
                                var key = $"{orderDetail.OrderId}:{orderDetail.TeachingCourseId}";
                                
                                if (!existingKeys.ContainsKey(key))
                                {
                                    existingKeys.Add(key,orderDetail);
                                    return;
                                }
                            }).Generate(count);
            orderDetails = existingKeys.Values.ToList();
            context.AddRange(existingKeys.Values.ToList());
            context.SaveChanges();
            return orderDetails;
        }

        private List<Order> CreateOrders(int count, List<Student> students, List<Tutor> tutors)
        {
            List<Order> orders = new Faker<Order>()
                          .RuleFor(o => o.Student, f => f.PickRandom(students))
                          .RuleFor(o => o.StudentName, (f, o) => o.Student?.User?.FullName)
                          .RuleFor(o => o.TutorName, (f, o) => f.PickRandom(tutors.Select(x => x.User?.FullName).ToList()))
                          .RuleFor(o => o.OrderDate, f => f.Date.Past(1))
                          .RuleFor(o => o.OrderStatus, f => f.PickRandom<OrderStatus>())
                          .RuleFor(o => o.TotalPrice, f => f.Finance.Amount(10, 100))
                          .Generate(count);
            context.AddRange(orders);
            context.SaveChanges();
            return orders;
        }

        private List<Transaction> CreateTransactions(int count, List<Wallet?> wallets)
        {
            List<Transaction> transactions = new Faker<Transaction>()
                          .RuleFor(t => t.TransactionStatus, f => f.PickRandom<TransactionStatus>())
                          .RuleFor(t => t.AmountTransaction, f => f.Finance.Amount())
                          .RuleFor(t => t.TransactionDescription, f => f.Commerce.ProductName())
                          .RuleFor(t => t.Wallet, f => f.PickRandom(wallets))
                          .Generate(count);
            context.AddRange(transactions);
            context.SaveChanges();
            return transactions;
        }

        private List<University> CreateUniversity(int v)
        {
            var universityFaker = new Faker<University>()
                  .RuleFor(u => u.UniversityName, f => f.Company.CompanyName())
                  .RuleFor(u => u.UniversityArea, f => f.PickRandom<UniversityArea>())
                  .RuleFor(u => u.TeachingCourses, f => new List<TeachingCourse>());
            var universities = universityFaker.Generate(v); // Generate 5 random University objects
            context.AddRange(universities);
            context.SaveChanges();
            return universities;
        }

        private List<TeachingCourse> CreateTeachingCourse(int v, List<Tutor?> tutors, List<University> universities)
        {
            var teachingCourseFaker = new Faker<TeachingCourse>()
            .RuleFor(tc => tc.CourseName, f => f.Commerce.ProductName())
            .RuleFor(tc => tc.Duration, f => f.Random.Number(1, 12)) // Adjust the range as needed
            .RuleFor(tc => tc.TotalWeek, f => f.Random.Number(4, 16)) // Adjust the range as needed
            .RuleFor(tc => tc.TeachingType, f => f.PickRandom<TeachingType>())
            .RuleFor(tc => tc.StartDate, f => f.Date.Recent())
            .RuleFor(tc => tc.EndDate, (f, tc) => tc.StartDate.AddMonths(tc.Duration))
            .RuleFor(tc => tc.CoursePrice, f => f.Random.Decimal(50, 500)) // Adjust the range as needed
            .RuleFor(tc => tc.Description, f => f.Lorem.Paragraph())
            .RuleFor(tc => tc.SyllabusFile, f => GetSeedingFile(f))
            .RuleFor(tc => tc.CourseSampleVideo, f => f.PickRandom(_videos))
            .RuleFor(tc => tc.TotalStudent, f => f.Random.Number(5, 100)) // Adjust the range as needed
            .RuleFor(tc => tc.AllowJoiningClass, f => f.PickRandom<AllowJoiningClass>())
            .RuleFor(tc => tc.CourseType, f => f.PickRandom<CourseType>())
            .RuleFor(tc => tc.CourseFile, f => GetSeedingFile(f))
            .RuleFor(tc => tc.CourseStatus, f => f.PickRandom<CourseStatus>())
            .RuleFor(tc => tc.ClassLocation, f => f.Address.City())
            .RuleFor(tc => tc.CreationDate, f => f.Date.Past())
            .RuleFor(tc => tc.CreatedBy, (f, tc) => tc.Tutor?.Id) // Adjust the range as needed
            .RuleFor(tc => tc.Tutor, f => f.PickRandom(tutors)) // Adjust the range as needed
            .RuleFor(tc => tc.University, f => f.PickRandom(universities)) // Adjust the range as needed
            .RuleFor(tc => tc.CourseMajor, f => new CourseMajor
            {
                CourseMajorName = f.Name.JobArea()
            }); // Adjust the range as needed;

            var teachingCourses = teachingCourseFaker.Generate(v); // Generate 10 random TeachingCourse objects
            context.AddRange(teachingCourses);
            context.SaveChanges();
            return teachingCourses;
        }

        private string GetSeedingFile(Faker f)
        {
            string filePath = "assets/files/example.txt";
            string fileContent = f.Lorem.Paragraph(5);
            FileInfo fileInfo = new FileInfo(filePath);

            if (!fileInfo.Exists)
            {
                try
                {
                    File.WriteAllText(filePath, fileContent);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return filePath;
        }

        private List<Role> CreateRole()
        {
            var roles = new List<Role>()
            {
                new Role { Rolename = "Admin" },
                new Role { Rolename = "Tutor" },
                new Role { Rolename = "Student" }
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();
            return roles;
        }
        private List<User> CreateUser(int v, List<Role> roles)
        {
            var userFaker = new Faker<User>()
            .RuleFor(u => u.FullName, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Password, f => StringUtils.Hash("12345"))
            .RuleFor(u => u.DateOfBirth, f => f.Date.Past(18))
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.AccountStatus, f => f.PickRandom<AccountStatus>())
            .RuleFor(u => u.Image, f => f.Image.PicsumUrl())
            .RuleFor(u => u.JoinDate, f => f.Date.Past(1))
            .RuleFor(u => u.Role, f => f.PickRandom(roles))
            .RuleFor(u => u.SelfDecription, f => f.Lorem.Sentence())
            .RuleFor(u => u.IsDeleted, f => f.Random.Bool())
            .RuleFor(u => u.Wallet, f => new Wallet
            {
                WalletAmount = f.Random.Decimal2(1000, 100000000)
            });  // Change the range as needed
                 // You can generate fake reports similarly

            var users = userFaker.Generate(v); // Generate 10 random User objects
            users[0].Role = roles[0];
            users[1].Role = roles[1];
            users[2].Role = roles[2];
            CreateRoleFromUser(users);

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.FullName}, Email: {user.Email}, Role: {user.Role?.Rolename}");
            }
            context.Users.AddRange(users);
            context.SaveChanges();
            return users;
        }

        private void CreateRoleFromUser(List<User> users)
        {

            var adminFaker = new Faker<Admin>();
            var studentFaker = new Faker<Student>()
                .RuleFor(x => x.SelfDescription, f => f.Lorem.Paragraph())
                .RuleFor(x => x.TotalCourseLearned, f => f.Random.Number(1, 10));
            var tutorFaker = new Faker<Tutor>()
                .RuleFor(x => x.SelfDescription, f => f.Lorem.Paragraph())
                .RuleFor(x => x.ExampleVideoStyle, f => f.PickRandom(_videos))
                .RuleFor(x => x.AvgRatingStar, f => f.Random.Number(1, 10))
                .RuleFor(x => x.TutorLocation, f => f.Address.FullAddress())
                .RuleFor(x => x.TutorCourseSold, f => f.Random.Number(1, 10));

            foreach (var user in users)
            {
                var role = user.Role;
                if (role == null) continue;
                if (role.Rolename == "Admin")
                {

                    user.Admin = adminFaker.Generate();
                }
                if (role.Rolename == "Tutor")
                {
                    user.Tutor = tutorFaker.Generate();
                }
                if (role.Rolename == "Student")
                {
                    user.Student = studentFaker.Generate();
                }
            }
        }
    }
}