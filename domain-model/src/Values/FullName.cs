namespace Emerging.Account.DomainModel.Values

{
    using System;

    public class FullName : Value
    {
        public FullName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName), "First name is null or emtpy.");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName), "Last name is null or emtpy.");
            }

            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
