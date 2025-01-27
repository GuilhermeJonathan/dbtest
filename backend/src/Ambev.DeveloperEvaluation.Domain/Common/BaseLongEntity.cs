using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public class BaseLongEntity : IComparable<BaseEntity>
    {
        public long Id { get; set; }

        public Task<IEnumerable<ValidationErrorDetail>> ValidateAsync()
        {
            return Validator.ValidateAsync(this);
        }

        public int CompareTo(BaseEntity? other)
        {
            if (other == null)
            {
                return 1;
            }

            return other!.Id.CompareTo(Id);
        }
    }
}
