namespace Emerging.Account.DomainModel.Entities
{
    using System;
    using Emerging.Account.DomainModel.Values;

    public class Account : Entity<string>
    {
        private Account(string id, FullName fullName, string email, string phone, string role)
            : base(id)
        {
            FullName = fullName;
            Email = email;
            Phone = phone;
            Role = role;
        }

        public FullName FullName { get; }
        public string Email { get; }
        public string Phone { get; }
        public string Role { get; }

        public static Account Create(string id, FullName fullName, string email, string phone, string role)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id), "The ID is null or empty.");
            }

            if (fullName == null)
            {
                throw new ArgumentNullException(nameof(fullName), "The full name is null.");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email), "The email is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentNullException(nameof(role), "The role is null or empty.");
            }

            return new Account(id, fullName, email, phone, role);
        }
    }
}
