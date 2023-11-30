public static class MenuController
{
    public static int NavigateMenu(List<string> items, string currentPath)
    {
        int index = 0;
        ConsoleKeyInfo keyInfo;

        do
        {
            Console.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                if (i == index)
                {
                    Console.Write("=>");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine(items[i]);
            }

            keyInfo = Console.ReadKey(true);

            
            if (keyInfo.Key == ConsoleKey.F1)
            {
                FileManager.CreateFile(currentPath);
                return -1;
            }
            else if (keyInfo.Key == ConsoleKey.F2)
            {
                FileManager.CreateDirectory(currentPath);
                return -1;
            }
            else if (keyInfo.Key == ConsoleKey.F3)
            {
                FileManager.DeleteFile(currentPath);
                return -1;
            }
            else if (keyInfo.Key == ConsoleKey.F4)
            {
                FileManager.DeleteDirectory(currentPath);
                return -1;
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                index = (index > 0) ? index - 1 : items.Count - 1;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                index = (index + 1) % items.Count;
            }

        } while (keyInfo.Key != ConsoleKey.Enter);

        return index;
    }
}
