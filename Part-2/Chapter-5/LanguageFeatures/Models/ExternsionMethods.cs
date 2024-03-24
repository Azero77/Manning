using System.Collections.Generic;

namespace LanguageFeatures.Models
{
    public static class ExternsionMethods
    {
        public static decimal GetTotal(this IEnumerable<Product?> items)
        {
            decimal total = 0;
           
            foreach (var item in items)
            {
                total += item?.Price ?? 0;
            }
            
            return total;
        }

        /*public static IEnumerable<Product?> FilterByValue(this IEnumerable<Product?> products,decimal value)
        {
            foreach (Product? product in products)
            {
                if((product?.Price ?? 0) > value)
                    yield return product;
            }
        }*/
        public static IEnumerable<Product?> Filter(this IEnumerable<Product?> products, Func<Product?, bool> select)
        {
            foreach (Product? item in products)
            {
                if (select(item))
                {
                    yield return item;
                }
            }
        }
    }
}
