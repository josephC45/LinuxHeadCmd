using TestProject.Mock;
/*
 * I read that we are not suppose to have dependencies (files,db,etc) when it comes to testing.
 * Will revisit in the future.
 */
namespace TestProject
{
    [TestFixture]
    public class HeadCmdFunctionalityTests
    {
        [TestFixture]
        public class HeadCmdTests
        {

            [TestCase(@"TestFile1.txt", ExpectedResult = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n")]
            [TestCase(@"TestFile2.txt", ExpectedResult = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n")]
            [TestCase(@"TestFile3.txt", ExpectedResult = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n9\r\n10\r\n")]
            public async Task<string> GivenFilePathWithNoOption_ShouldReturnTenLinesOrLessFromFile(string? filePath)
            {
                //Arrange
                var sut = CreateSut();
                //Act
                var actual = await sut.GetLines(filePath);
                //Assert
                return actual ?? "null";
            }

            [TestCase(@"TestFile1.txt", 4, ExpectedResult = "1\r\n2\r\n3\r\n4\r\n")]
            [TestCase(@"TestFile1.txt", 6, ExpectedResult = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n")]
            [TestCase(@"TestFile1.txt", 8, ExpectedResult = "1\r\n2\r\n3\r\n4\r\n5\r\n6\r\n7\r\n8\r\n")]
            public async Task<string?> GivenFilePathWithNOption_ShouldReturnCorrectNumberOfLinesFromFile(string filePath, short numOfLinesToReturn = 10)
            {
                //Arrange
                var sut = CreateSut();
                //Act
                string? actual = await sut.GetLines(filePath, numOfLinesToReturn);
                //Assert
                return actual;
            }

            [TestCase(@"TestFile4.txt", 3, ExpectedResult = "123")]
            [TestCase(@"TestFile4.txt", 2, ExpectedResult = "12")]
            [TestCase(@"TestFile4.txt", 5, ExpectedResult = "12345")]
            [TestCase(@"TestFile4.txt", 0, ExpectedResult = "")]
            [TestCase(@"TestFile4.txt", 10, ExpectedResult = "12345\r\n678")]
            public async Task<string?> GivenFilePathWithCOption_ShouldReturnCorrectNumberOfBytesFromFileAsString(string? filePath, short numOfBytes)
            {
                //Arrange
                var sut = CreateSut();
                //Act
                string? actual = await sut.GetBytes(filePath, numOfBytes);
                //Assert
                return actual;
            }
        }

        [TestFixture]
        public class HeadCmdOptionTests
        {
            [TestCase("-d")]
            [TestCase("-e")]
            [TestCase("-f")]
            [TestCase("-c")]
            [TestCase("-n")]
            public void GivenCmdOption_ShouldReturnTrueOrFalseIfCmdOptionIsSupported(string? option)
            {
                //Arrange
                var sut = CreateSut();

                //Act
                string? actual = sut.GetCmdOption(option);

                //Assert
                Assert.IsTrue(actual == null || actual.Equals("-n") || actual.Equals("-c"));
            }
        }
        private static MockFunctionalityHandler CreateSut()
        {
            return new MockFunctionalityHandler(new MockFunctionality());
        }
    }
}
