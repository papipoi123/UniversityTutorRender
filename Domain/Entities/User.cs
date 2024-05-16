using Domain.Base;
using Domain.Enums;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        private string _fullName;

        public string FullName { get => _fullName ?? Email; set => _fullName = value; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public AccountStatus? AccountStatus { get; set; }
        public string? Image { get; set; }
        public DateTime? JoinDate { get; set; }
        public string? SelfDecription { get; set; }
        public string? CodeResetPassword { get; set; }
        public DateTime? ResetCodeExpires { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public Wallet? Wallet { get; set; }
        public int? WalletId { get; set; }
        public List<Report>? Reports { get; set; }
        public Admin? Admin { get; set; }
        public int? AdminId { get; set; }
        public Student? Student { get; set; }
        public int? StudentId { get; set; }
        public Tutor? Tutor { get; set; }
        public int? TutorId { get; set; }
    }
}
