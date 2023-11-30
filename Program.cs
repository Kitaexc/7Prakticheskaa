class Program
{
    static void Main(string[] args)
    {
        string currentPath = "";
        Stack<string> pathHistory = new Stack<string>();
        List<string> menuItems = new List<string>();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();

            if (string.IsNullOrEmpty(currentPath))
            {
                foreach (var drive in FileManager.GetDrives())
                {
                    menuItems.Add($"{drive.Name} {drive.TotalFreeSpace / (1024 * 1024 * 1024)} ГБ свободно из {drive.TotalSize / (1024 * 1024 * 1024)} ГБ");
                }
            }
            else
            {
                FileManager.DisplayDirectoryContents(currentPath);
                menuItems.Add("..");
                menuItems.AddRange(FileManager.GetDirectories(currentPath));
                menuItems.AddRange(FileManager.GetFiles(currentPath));
            }

            int selectedIndex = MenuController.NavigateMenu(menuItems, currentPath);

            if (selectedIndex == -1)
            {
                continue;
            }

            if (string.IsNullOrEmpty(currentPath))
            {
                currentPath = FileManager.GetDrives().ElementAt(selectedIndex).Name;
                pathHistory.Push(currentPath);
            }
            else
            {
                if (selectedIndex == 0)
                {
                    pathHistory.Pop();
                    currentPath = pathHistory.Count > 0 ? pathHistory.Peek() : "";
                }
                else
                {
                    string selectedPath = menuItems[selectedIndex];
                    if (File.Exists(selectedPath))
                    {
                        FileManager.OpenFile(selectedPath);
                    }
                    else
                    {
                        currentPath = selectedPath;
                        pathHistory.Push(currentPath);
                    }
                }
            }

            menuItems.Clear();
        }
    }
}
