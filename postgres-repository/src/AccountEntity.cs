namespace Emerging.Account.PostgresRepository
{
    public class AccountEntity
    {
        public int _Id { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
