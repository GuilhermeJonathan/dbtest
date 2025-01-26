namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public static class DiscountCalculator
    {
        public static decimal CalculateDiscount(int quantity)
        {
            if (quantity >= 10 && quantity < 20)
            {
                return 0.20m; // 20% discount
            }            
            else if (quantity > 4)
            {
                return 0.10m; // 10% discount
            }
            else
            {
                return 0.00m; // without discount
            }
        }
    }
}
