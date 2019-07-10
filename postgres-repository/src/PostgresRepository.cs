namespace Emerging.Account.PostgresRepository
{
    using System;
    using System.Linq;
    using Emerging.Account.DomainModel.Entities;
    using Emerging.Account.DomainModel.Repositories;

    public class PostgresRepository : AccountRepository
    {
        private readonly AccountContext context;

        public PostgresRepository(AccountContext context)
        {
            this.context = context;
        }

        public Account GetById(string id)
        {
            var entity = context.Account.SingleOrDefault(a => a.Id.Equals(id));
            return entity?.ToAccount();
        }

        public bool IsEmailInUse(string email)
        {
            return context.Account.Any(a => a.Email.Equals(email));
        }

        public bool IsPhoneInUse(string phone)
        {
            return context.Account.Any(a => a.Phone.Equals(phone));
        }

        public void Save(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "The account is null.");
            }

            var entity = account.ToAccountEntity();
            context.Account.Add(entity);
            context.SaveChanges();
        }
    }
}
