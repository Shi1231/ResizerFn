using System.ComponentModel.Design;
using System.Text;

namespace ResReplacer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(1) Set res (1720), (2) Reset res (1920): ");

            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int result))
            {
                Console.WriteLine();
                if (result == 1 || result == 2)
                {
                    List<string> list = new List<string>() { "ResolutionSizeX", "LastUserConfirmedResolutionSizeX", "DesiredScreenWidth", "LastUserConfirmedDesiredScreenWidth" };
                    string file = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\FortniteGame\\Saved\\Config\\WindowsClient\\GameUserSettings.ini";
                    string resX = "";

                    if (File.Exists(file))
                    {
                        if (result == 1)
                        {
                            resX = "1720";
                        }
                        else if (result == 2)
                        {
                            resX = "1920";
                        }

                        try
                        {
                            // Read all lines of the file into an array
                            string[] lines = File.ReadAllLines(file);

                            // Iterate through the lines to find the keys and update their values
                            for (int i = 0; i < lines.Length; i++)
                            {
                                foreach (string key in list)
                                {
                                    if (lines[i].Trim().StartsWith(key + "="))
                                    {
                                        // Replace the line with the updated value
                                        lines[i] = $"{key}={resX}";
                                        Console.WriteLine($"Line {i + 1} modified: {lines[i]}");
                                    }
                                }
                            }

                            // Write the modified lines back to the file
                            File.WriteAllLines(file, lines, Encoding.UTF8);

                            Console.WriteLine("INI file has been updated.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }
                    }
                    else
                        Console.WriteLine($"{file} does not exist.");
                }
                else
                    Console.WriteLine($"{result} is not a valid option.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"{Console.ReadKey().KeyChar.ToString()} is not a valid option.");
            }
        }
    }
}