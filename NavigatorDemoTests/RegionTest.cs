using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigatorDemo.Model;

namespace NavigatorDemoTests
{
    [TestClass]
    public class RegionTest
    {
        [TestMethod]
        public void RegionConstructorTestXAssignment()
        {
            //Arrange 
            int x = 1;

            //Act
            var reg = new Region(id: 1, x: x, y: 1, width: 5, height: 6);

            //Assert 
            Assert.AreEqual(reg.X, x);
        }

        [TestMethod]
        public void RegionConstructorTestYAssignment()
        {
            //Arrange 
            int y = 4;

            //Act
            var reg = new Region(id: 1, x: 2, y: y, width: 5, height: 6);

            //Assert 
            Assert.AreEqual(reg.Y, y);
        }

        [TestMethod]
        public void RegionConstructorTestWidthAssignment()
        {
            //Arrange 
            int width = 10;

            //Act
            var reg = new Region(id: 1, x: 2, y: 1, width: width, height: 6);

            //Assert 
            Assert.AreEqual(reg.Width, width);
        }

        [TestMethod]
        public void RegionConstructorTestHeightAssignment()
        {
            //Arrange 
            int height = 8;

            //Act
            var reg = new Region(id: 1, x: 2, y: 1, width: 5, height: height);

            //Assert 
            Assert.AreEqual(reg.Height, height);
        }
    }
}
