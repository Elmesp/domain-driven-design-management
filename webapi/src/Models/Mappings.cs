namespace Emerging.Account.WebApi.Models
{
    using Emerging.Account.DomainModel.Entities;
    using Emerging.Account.DomainModel.Values;

    internal static class Mappings
    {
        public static AccountPostResponseBody ToAccountPostResponseBody(this Account account) => new AccountPostResponseBody
        {
            Id = account.Id,
            FirstName =  account.FullName.FirstName,
            LastName = account.FullName.LastName,
            Email = account.Email,
            Phone = account.Phone,
            Role = account.Role
        };

        public static Account ToAccount(this AccountPostRequestBody model, string id) => Account.Create(
            id, new FullName(model.FirstName, model.LastName), model.Email, model.Phone, model.Role
        );
    }
}
