namespace _Hire_Me_Now_.API.SystemUserss.DTO.ResponseObject
{
    public class SystemUserResponseObject
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        //public int Role { get; set; }
        public string Role { get; set; }=null!;
        public bool IsBlocked { get; set; }
    }
}
