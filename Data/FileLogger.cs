using System;
using System.IO;
namespace UrbanTheater.Data;
public class FileLogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void Log(string message)
    {
        try
        {
            var logMessage = $"{DateTime.Now}: {message}\n";
            File.AppendAllText(_filePath, logMessage);
        }
        catch (Exception ex)
        {

        }
    }
}
