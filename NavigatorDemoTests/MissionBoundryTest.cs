using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigatorDemo.Model;

namespace NavigatorDemoTests
{
    [TestClass]
    public class MissionBoundryTest
    {
        [TestMethod]
        public void MissionBoundryConstructorTestMinXAssignment()
        {
            //Arrange 
            int x = 1;

            //Act
            var boundry = new MissionBoundary(minX: x, minY: 1, maxX: 5, maxY: 6);

            //Assert 
            Assert.AreEqual(boundry.MinX, x);
        }

        [TestMethod]
        public void MissionBoundryConstructorTestMinYAssignment()
        {
            //Arrange 
            int y = 4;

            //Act
            var boundry = new MissionBoundary(minX: 1, minY: y, maxX: 5, maxY: 6);

            //Assert 
            Assert.AreEqual(boundry.MinY, y);
        }

        [TestMethod]
        public void MissionBoundryConstructorTestMaxXAssignment()
        {
            //Arrange 
            int x = 10;

            //Act
            var boundry = new MissionBoundary(minX: 1, minY: 1, maxX: x, maxY: 6);

            //Assert 
            Assert.AreEqual(boundry.MaxX, x);
        }

        [TestMethod]
        public void MissionBoundryConstructorTestMaxYAssignment()
        {
            //Arrange 
            int y = 8;

            //Act
            var boundry = new MissionBoundary(minX: 1, minY: 1, maxX: 5, maxY: y);

            //Assert 
            Assert.AreEqual(boundry.MaxY, y);
        }

        [TestMethod]
        public void MissionBoundryConstructorTestAssignmentByRegion()
        {
            //Arrange          
            var reg = new Region(id: 1, x: 2, y: 1, width: 5, height: 5);

            //Act
            var boundry = new MissionBoundary(reg);

            //Assert 
            Assert.AreEqual(boundry.MinX, reg.X);
            Assert.AreEqual(boundry.MinY, reg.Y);
            Assert.AreEqual(boundry.MaxX, reg.X + reg.Width);
            Assert.AreEqual(boundry.MaxY, reg.X + reg.Height);
        }
    }
}
