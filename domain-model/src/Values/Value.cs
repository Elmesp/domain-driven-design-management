namespace Emerging.Account.DomainModel.Values

{
    public abstract class Value
    {
        protected static bool EqualOperator(Value left, Value right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(Value left, Value right)
        {
            return !(EqualOperator(left, right));
        }
    }
}
