using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitQuiz.Test
{

    public class ProductsAppShould
    {
        [Fact]
        public void NotBeAddingNullProduct()
        {
            //Arrange
            Products sut = new Products();

            //Act and
            Action act = () => sut.AddNew(null);

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Theory]
        [MemberData(nameof(InternalProductsTestData.TestData), MemberType = typeof(InternalProductsTestData))]
        public void BeAbleToAddValidProduct(Product product, string expected)
        {
            //Arrange
            Products sut = new Products();
            Product product1 = new Product{ Name = "Lotion", IsSold = true };
            Product product2 = new Product { Name = "BabyOil", IsSold = false };

            //Act
            sut.AddNew(product1);
            sut.AddNew(product2);
            sut.AddNew(product);

            //Assert
            Assert.Contains(expected, sut.Items.Select(s => s.Name));
        }


        [Theory]
        [MemberData(nameof(InternalProductsTestData.SoldProductsTestData), MemberType = typeof(InternalProductsTestData))]
        public void HideProductsIfSold(Product product, string expected)
        {
            //Arrange
            Products sut = new Products();
            Product product1 = new Product { Name = "Lotion", IsSold = true };
            Product product2 = new Product { Name = "BabyOil", IsSold = false };

            //Act
            sut.AddNew(product1);
            sut.AddNew(product2);
            sut.AddNew(product);
            sut.Sold(product);

            //Assert
            Assert.DoesNotContain(expected, sut.Items.Select(s => s.Name));

        }

        [Theory]
        [MemberData(nameof(InternalProductsTestData.NullNamesTestData), MemberType = typeof(InternalProductsTestData))]
        public void NotAllowNoOrNullProductName(Product product)
        {
            //Arrange
            Products sut = new Products();
            Product product1 = new Product { Name = "Lotion", IsSold = true };
            Product product2 = new Product { Name = "BabyOil", IsSold = false };

            //Act
            sut.AddNew(product1);
            sut.AddNew(product2);
            Action act = () => sut.AddNew(product);

            //Assert
            Assert.Throws<NameRequiredException>(act);
        }
    }
}
