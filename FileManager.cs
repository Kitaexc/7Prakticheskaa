using System.Diagnostics;

public static class FileManager
{
    public static IEnumerable<DriveInfo> GetDrives()
    {
        return DriveInfo.GetDrives();
    }

    public static IEnumerable<string> GetDirectories(string path)
    {
        return Directory.GetDirectories(path);
    }

    public static IEnumerable<string> GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }

    public static void OpenFile(string filePath)
    {
        Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
    }

    public static void DisplayDirectoryContents(string path)
    {
        Console.WriteLine($"Выбран диск или директория: {path}");
        Console.WriteLine(new string('-', 80));

        DirectoryInfo dirInfo = new DirectoryInfo(path);

        foreach (var dir in dirInfo.GetDirectories())
        {
            Console.WriteLine($"{dir.Name.PadRight(30), -25} {dir.CreationTime.ToString("dd.MM.yyyy HH:mm:ss").PadRight(20), -25} [папка]");
        }

        foreach (var file in dirInfo.GetFiles())
        {
            Console.WriteLine($"{file.Name.PadRight(30), -25} {file.CreationTime.ToString("dd.MM.yyyy HH:mm:ss").PadRight(20), -25} [{file.Extension}]");
        }

        Console.WriteLine(new string('-', 80));
    }

   
    public static string GetItemDetails(string path)
    {
        FileInfo fileInfo = new FileInfo(path);
        return $"Created: {fileInfo.CreationTime}, Size: {fileInfo.Length} bytes";
    }
    public static void CreateFile(string path)
    {
        Console.Write("Введите имя файла: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(path, fileName);

        if (!File.Exists(filePath))
        {     
            File.Create(filePath).Close();
            Console.WriteLine("Файл создан успешно.");
        }
        else
        {
            Console.WriteLine("Файл уже существует.");
        }
        Console.ReadKey();
    }

    public static void CreateDirectory(string path)
    {
        Console.Write("Введите имя директории: ");
        string dirName = Console.ReadLine();
        string dirPath = Path.Combine(path, dirName);

        if (!Directory.Exists(dirPath))
        {   
            Directory.CreateDirectory(dirPath);
            Console.WriteLine("Директория создана успешно.");
        }
        else
        {
            Console.WriteLine("Директория уже существует.");
        }
        Console.ReadKey();
    }

    public static void DeleteFile(string path)
    {
        Console.Write("Введите имя файла для удаления: ");
        string fileName = Console.ReadLine();
        string filePath = Path.Combine(path, fileName);

        if (File.Exists(filePath))
        {    
            File.Delete(filePath);
            Console.WriteLine("Файл удален успешно.");
        }
        else
        {
            Console.WriteLine("Файл не найден.");
        }
        Console.ReadKey();
    }

    public static void DeleteDirectory(string path)
    {
        Console.Write("Введите имя директории для удаления: ");
        string dirName = Console.ReadLine();
        string dirPath = Path.Combine(path, dirName);

        if (Directory.Exists(dirPath))
        {
            Directory.Delete(dirPath, true);
            Console.WriteLine("Директория удалена успешно.");
        }
        else
        {
            Console.WriteLine("Директория не найдена.");
        }
        Console.ReadKey();
    }
}
