using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigatorDemo.Repositories;

namespace NavigatorDemoTests
{
    [TestClass]
    public class FileIOTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FileIOConstructorTestPathAssignment()
        {
            //Arrange 
            string path = "wrongPath.txt";

            //Act
            var fileIo = new FileIO(path);
            var content = fileIo.Content;          
        }       
    }
}
