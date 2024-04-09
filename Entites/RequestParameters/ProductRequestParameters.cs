

namespace Entites.RequestParameters
{
    public class ProductRequestParameters : RequestParameters
    {
        public int? categoryId { get; set; }

        public int MinPrice { get; set; } = 0;

        public int MaxPrice { get; set; } = int.MaxValue;

        public bool isValiPrice => MaxPrice > MinPrice;


    }
}
