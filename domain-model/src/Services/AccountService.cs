namespace Emerging.Account.DomainModel.Services
{
    using Emerging.Account.DomainModel.Entities;
    using Emerging.Account.DomainModel.Repositories;

    public class AccountService
    {
        private readonly AccountRepository repository;

        public AccountService(AccountRepository repository)
        {
            this.repository = repository;
        }

        public void Register(Account account) => repository.Save(account);
        public Account GetById(string id) => repository.GetById(id);
        public bool IsEmailInUse(string email) => repository.IsEmailInUse(email);
        public bool IsPhoneInUse(string phone) => repository.IsPhoneInUse(phone);
    }
}
