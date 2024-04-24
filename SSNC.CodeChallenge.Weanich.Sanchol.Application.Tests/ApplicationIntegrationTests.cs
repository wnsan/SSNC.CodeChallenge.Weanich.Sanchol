using System.Diagnostics;
using System.Text;

namespace SSNC.CodeChallenge.Weanich.Sanchol.Application.Tests
{
    [TestClass]
    public class ApplicationIntegrationTests
    {
        [TestMethod]
        public void Case1()
        {
            // Arrange
            var output = new StringBuilder();
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.FileName = Path.Combine(AppContext.BaseDirectory, "SSNC.CodeChallenge.Weanich.Sanchol.Application.exe");            
            p.OutputDataReceived += (sender, eventArgs) =>
            {
                output.Append(eventArgs.Data);
            };
            p.Start();
            p.BeginOutputReadLine();

            var standardInput = p.StandardInput;
            
            // Act
            standardInput.WriteLine("PLACE 0,0,NORTH");
            standardInput.WriteLine("MOVE");
            standardInput.WriteLine("REPORT");
            
            
            standardInput.WriteLine("EXIT");
            standardInput.Flush();
            p.WaitForExit(100);
            p.Kill();

            // Assert
            Assert.AreEqual("Output: 0,1,NORTH", output.ToString());
        }

        [TestMethod]
        public void Case2()
        {
            // Arrange
            var output = new StringBuilder();
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.FileName = Path.Combine(AppContext.BaseDirectory, "SSNC.CodeChallenge.Weanich.Sanchol.Application.exe");
            p.OutputDataReceived += (sender, eventArgs) =>
            {
                output.Append(eventArgs.Data);
            };
            p.Start();
            p.BeginOutputReadLine();

            var standardInput = p.StandardInput;

            // Act
            standardInput.WriteLine("PLACE 0,0,NORTH");
            standardInput.WriteLine("LEFT");
            standardInput.WriteLine("REPORT");


            standardInput.WriteLine("EXIT");
            standardInput.Flush();
            p.WaitForExit(100);
            p.Kill();

            // Assert
            Assert.AreEqual("Output: 0,0,WEST", output.ToString());
        }

        [TestMethod]
        public void Case3()
        {
            // Arrange
            var output = new StringBuilder();
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.FileName = Path.Combine(AppContext.BaseDirectory, "SSNC.CodeChallenge.Weanich.Sanchol.Application.exe");
            p.OutputDataReceived += (sender, eventArgs) =>
            {
                output.Append(eventArgs.Data);
            };
            p.Start();
            p.BeginOutputReadLine();

            var standardInput = p.StandardInput;

            // Act
            standardInput.WriteLine("PLACE 1,2,EAST");
            standardInput.WriteLine("MOVE");
            standardInput.WriteLine("MOVE");
            standardInput.WriteLine("LEFT");
            standardInput.WriteLine("MOVE");
            standardInput.WriteLine("REPORT");


            standardInput.WriteLine("EXIT");
            standardInput.Flush();
            p.WaitForExit(100);
            p.Kill();

            // Assert
            Assert.AreEqual("Output: 3,3,NORTH", output.ToString());
        }
    }
}