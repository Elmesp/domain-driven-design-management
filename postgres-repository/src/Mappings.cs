namespace Emerging.Account.PostgresRepository
{
    using Emerging.Account.DomainModel.Entities;
    using Emerging.Account.DomainModel.Values;

    internal static class Mappings
    {
        public static AccountEntity ToAccountEntity(this Account account) => new AccountEntity
        {
            Id = account.Id,
            FirstName = account.FullName.FirstName,
            LastName = account.FullName.LastName,
            Email = account.Email,
            Phone = account.Phone,
            Role = account.Role
        };

        public static Account ToAccount(this AccountEntity entity) => Account.Create(
            entity.Id,
            new FullName(entity.FirstName, entity.LastName),
            entity.Email,
            entity.Phone,
            entity.Role
        );
    }
}
