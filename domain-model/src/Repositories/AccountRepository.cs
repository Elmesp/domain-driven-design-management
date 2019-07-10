namespace Emerging.Account.DomainModel.Repositories
{
    using Emerging.Account.DomainModel.Entities;

    public interface AccountRepository
    {
        void Save(Account account);
        Account GetById(string id);
        bool IsEmailInUse(string email);
        bool IsPhoneInUse(string phone);
    }
}
