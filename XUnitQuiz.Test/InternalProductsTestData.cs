using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitQuiz.Test
{
    public class InternalProductsTestData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { new Product { Name = "Shampoo", IsSold = false }, "Shampoo" };
                yield return new object[] { new Product { Name = "Conditioner", IsSold = false }, "Conditioner" };
                yield return new object[] { new Product { Name = "Soap", IsSold = false }, "Soap" };
                yield return new object[] { new Product { Name = "Toothpaste", IsSold = false }, "Toothpaste" };
                yield return new object[] { new Product { Name = "Mouthwash", IsSold = false }, "Mouthwash" };
            }
        }

        public static IEnumerable<object[]> NullNamesTestData
        {
            get
            {
                yield return new object[] { new Product { Name = null, IsSold = true } };
                yield return new object[] { new Product { Name = null, IsSold = false }, };
            }
        }

        public static IEnumerable<object[]> SoldProductsTestData
        {
            get
            {
                yield return new object[] { new Product { Name = "Shampoo", IsSold = false }, "Shampoo" };
                yield return new object[] { new Product { Name = "Conditioner", IsSold = false }, "Conditioner" };
                yield return new object[] { new Product { Name = "Soap", IsSold = false }, "Soap" };
            }
        }

    }

}
