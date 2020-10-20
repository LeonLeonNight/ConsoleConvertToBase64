using System;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

namespace ConsoleConvertToBase64
{
    public class Program
    {
        public static async Task Main()
        {
            String date = DateTime.Now.ToString("yyyy.MM.dd");
            var writepath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+@$"\{date}.txt";
            Console.WriteLine("Введите путь до фото: ");
            var path = Console.ReadLine();
            try
            {
                using (Image image = Image.FromFile(path))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        using (StreamWriter sw = new StreamWriter(writepath, false, System.Text.Encoding.Default))
                        {
                            await sw.WriteLineAsync(base64String);
                        }
                        Console.WriteLine("File is save");
                        Console.ReadKey();
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
