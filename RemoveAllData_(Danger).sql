USE Zuni_Tutor

DELETE FROM dbo.Admins;
DELETE FROM dbo.WeeklyTimes;
DELETE FROM dbo.Certifications;
DELETE FROM dbo.CourseMajors;
DELETE FROM dbo.OnlineClasses;
DELETE FROM dbo.Orders;
DELETE FROM dbo.OrderDetails;
DELETE FROM dbo.Ratings;
DELETE FROM dbo.Reports;
DELETE FROM dbo.Roles;
DELETE FROM dbo.Students;
DELETE FROM dbo.TeachingCourses;
DELETE FROM dbo.Transactions;
DELETE FROM dbo.Tutors;
DELETE FROM dbo.TutorFeedbacks;
DELETE FROM dbo.Universities;
DELETE FROM dbo.Units;
DELETE FROM dbo.Users;
DELETE FROM dbo.Wallets;
DELETE FROM dbo.FavoriteCourses;
EXEC sp_MSforeachtable 'select * from ?'

EXEC sp_MSforeachtable 'TRUNCATE TABLE ?'
