using Domain.Entities;
using Domain.Enums;

namespace Applications.ViewModels
{
    public class UserViewModel 
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Image { get; set; }
        public DateTime? JoinDate { get; set; }
        public string? SelfDecription { get; set; }
        public StudentViewModel? Student { get; set; }
    }

    public class GetUserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public AccountStatus? AccountStatus { get; set; }
        public string? Image { get; set; }
        public DateTime? JoinDate { get; set; }
        public string? SelfDecription { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }

    public class RegisTutorModel
    {
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public TutorViewModelForRegis Tutor { get; set; }
    }

    public class UpdateUserViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Image { get; set; }
        public DateTime? JoinDate { get; set; }
        public string? SelfDecription { get; set; }
    }

}
