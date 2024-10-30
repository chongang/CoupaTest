namespace BlazorPunchOutTest.Controllers
{
    public class FileLoggingService : ILoggingService
    {
        private readonly string _filePath;

        public FileLoggingService(string filePath)
        {
            _filePath = filePath;
            // Ensure the directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
            // Optionally, delete the log file if it exists
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }

        public void Log(string message)
        {
            // Write the log message, overwriting the file each time
            using (var writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine($"{DateTime.UtcNow}: {message}");
            }
        }
    }


}
