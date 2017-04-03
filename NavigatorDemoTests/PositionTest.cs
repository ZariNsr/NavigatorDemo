using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigatorDemo.Model;

namespace NavigatorDemoTests
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void PositionConstructorTestXAssignment()
        {
            //Arrange 
            int x = 1;

            //Act
            var pos = new Position(x: x, y: 1);

            //Assert 
            Assert.AreEqual(pos.X, x);
        }

        [TestMethod]
        public void PositionConstructorTestYAssignment()
        {
            //Arrange 
            int y = 4;

            //Act
            var pos = new Position(x: 2, y: y);

            //Assert 
            Assert.AreEqual(pos.Y, y);
        }

        [TestMethod]
        public void PositionEqualsTestAreEqual()
        {
            //Arrange 
            var pos1 = new Position(x: 2, y: 6);
            var pos2 = new Position(x: 2, y: 6);

            //Act
            var areEqual = pos1.Equals(pos2);

            //Assert 
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void PositionEqualsTestWithDiffX()
        {
            //Arrange 
            var pos1 = new Position(x: 2, y: 7);
            var pos2 = new Position(x: 2, y: 6);

            //Act
            var areEqual = pos1.Equals(pos2);

            //Assert 
            Assert.IsFalse(areEqual);
        }

        [TestMethod]
        public void PositionEqualsTestWithDiffY()
        {
            //Arrange 
            var pos1 = new Position(x: 1, y: 6);
            var pos2 = new Position(x: 2, y: 6);

            //Act
            var areEqual = pos1.Equals(pos2);

            //Assert 
            Assert.IsFalse(areEqual);
        }    
    }
}
