namespace ExpenseManagementSystem.API.RequestDTOs
{
    public class CreateUserRequestDto
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Iban { get; set; }
        public string PhoneNumber { get; set; }
    }
}
