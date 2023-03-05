using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleVideo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [Test]
        public void CutVideo_WithValidArguments_ShouldReturnTrue()
        {
            // Arrange
            var inputFilePath = "path/to/input/file";
            var outputFilePath = "path/to/output/file";
            var startTime = "00:00:00";
            var duration = "00:01:00";

            var processMock = new Mock<Process>();
            processMock.Setup(x => x.WaitForExit()).Verifiable();

            var startInfoMock = new Mock<ProcessStartInfo>();
            startInfoMock.SetupProperty(x => x.FileName);
            startInfoMock.SetupProperty(x => x.Arguments);
            startInfoMock.SetupProperty(x => x.RedirectStandardOutput);
            startInfoMock.SetupProperty(x => x.RedirectStandardError);
            startInfoMock.SetupProperty(x => x.UseShellExecute);
            startInfoMock.Object.FileName = "ffmpeg";
            startInfoMock.Object.Arguments = $"-ss {startTime} -i \"{inputFilePath}\" -t {duration} -c copy \"{outputFilePath}\"";
            startInfoMock.Object.RedirectStandardOutput = true;
            startInfoMock.Object.RedirectStandardError = true;
            startInfoMock.Object.UseShellExecute = false;

            var processStartMock = new Mock<IProcessStartInfo>();
            processStartMock.Setup(x => x.StartInfo).Returns(startInfoMock.Object);
            processStartMock.Setup(x => x.Start()).Returns(processMock.Object);

            // Act
            var video = new Video("video name", "video description", "path/to/video");
            var result = video.CutVideo(inputFilePath, outputFilePath, startTime, duration);

            // Assert
            processStartMock.VerifyAll();
            processMock.Verify(x => x.WaitForExit(), Times.Once());
            Assert.True(result);
        }
    }
}
