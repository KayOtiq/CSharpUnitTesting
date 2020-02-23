using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    //since mocking can get a bit noisy and redundent, this is when we should move the arrange into a setup method

    {
       // private FileReader _fileReader;
       // private VideoService _videoService;
        [SetUp]
    public void Setup()
    {
        //_fileReader = new Mock<IFileReader>();
      //  _videoService = new VideoService(_fileReader.Object);

    }

    
        [Test]
        public void ReadVideoServiceTitle_EmptyFile_ReturnsErrorMsg()
        {
            //arrange
            // orignal
            //var service = new VideoService();
            //using passing parameter
            //var result = service.ReadVideoTitle(new FakeFileReader());

            //using property
            //service.FileReader = new FakeFileReader();

            //using contructor injection
            //var service = new VideoService(new FakeFileReader());

            //using moq
            //var fileReader = new Mock<IFileReader>();

            //original
            // var service = new VideoService(new FakeFileReader());

            //use mocks for dealing with external dependencies
            //using moq
            //var _videoService = new VideoService(_fileReader.Object);

            //this is setting up the test with the mock
            //filereader points to read video.txt and returns null

            //promoting this to to the setup method so can use it in other tests
           var _fileReader = new Mock<IFileReader>();
            
            //telling the mock that when we call the read method with this argument, it should return some string

            //this is for an empty file, so look for an empty string
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            //var service = new _videoService(new FakeFileReader());

            //promoting this to to the setup method so can use it in other tests
            //this is the actual object that implements iFileReader
            var _videoService = new VideoService(_fileReader.Object);


            // act
            //using injection by property
            //var service = new _videoService(new FakeFileReader());
            //var result = _videoService.ReadVideoTitle();
            var result = _videoService.ReadVideoTitle();


            //assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
