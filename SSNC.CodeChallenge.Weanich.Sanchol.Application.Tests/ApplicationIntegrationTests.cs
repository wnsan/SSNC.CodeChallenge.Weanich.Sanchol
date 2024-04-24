using System.Diagnostics;
using System.Text;

namespace SSNC.CodeChallenge.Weanich.Sanchol.Application.Tests
{
    [TestClass]
    public class ApplicationIntegrationTests
    {
        [TestMethod]
        public void ExampleInputandOutputA()
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
        public void ExampleInputandOutputB()
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
        public void ExampleInputandOutputC()
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

        [TestMethod]
        public void IgnoreAllAction_WhenToyNotPlaced()
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
            Assert.AreEqual("", output.ToString());
        }

        [TestMethod]
        public void IgnoreAllAction_WhenCommandInValid()
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
            standardInput.WriteLine("JUMP 1,2,NORTH");
            standardInput.WriteLine("REPORT");

            standardInput.WriteLine("EXIT");
            standardInput.Flush();
            p.WaitForExit(100);
            p.Kill();

            // Assert
            Assert.AreEqual("", output.ToString());
        }

        [TestMethod]
        [DataRow("PLACE x,1,NORTH")]
        [DataRow("PLACE 1,x,NORTH")]
        [DataRow("PLACE 1,1,BELOW")]
        public void IgnorePlaceAction_WhenArgumentsInValid(string command)
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
            standardInput.WriteLine(command);
            standardInput.WriteLine("REPORT");
            standardInput.WriteLine("EXIT");
            standardInput.Flush();
            var isExited = p.WaitForExit(100);
            p.Kill();

            // Assert
            Assert.AreEqual("", output.ToString());
            Assert.AreEqual(0, p.ExitCode);
        }

        [TestMethod]
        public void ExecuteAction_WhenCommandIsEitherUpperOrLowerCase()
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
            standardInput.WriteLine("PlAce 2,0,nOrth");
            standardInput.WriteLine("MovE");
            standardInput.WriteLine("LeFt");
            standardInput.WriteLine("Move");
            standardInput.WriteLine("RiGht");
            standardInput.WriteLine("moVe");
            standardInput.WriteLine("rEpoRt");
            standardInput.WriteLine("EXIT");
            standardInput.Flush();
            p.WaitForExit(100);
            p.Kill();

            // Assert
            Assert.AreEqual("Output: 1,2,NORTH", output.ToString());
        }
    }
}