using System;

public static class Tools
{
    public static string ConvertBase64ToFile(string base64, string saveToPath, string fileName = null)
    {
        if (base64 != null)
        {
            var base64array = Convert.FromBase64String(base64);
            // Assume file type
            // jpg as default
            string fileType = ".jpg";

            switch (base64[0])
            {

                case 'i': // png
                    fileType = ".png";
                    break;
                case 'R': //gif
                    fileType = ".gif";
                    break;
                case 'U': // webp
                    fileType = ".webp";
                    break;
                case '/': // jpeg
                default:
                    break;
            }

            var filePath = saveToPath + (fileName == null ? Guid.NewGuid() + fileType : fileName + fileType);
            System.IO.File.WriteAllBytes(filePath, base64array);
            return System.IO.Path.GetFileName(filePath);
        }
        return null;
    }
    public static bool DeleteFile(string filePath)
    {
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
            return true;
        }
        return false;
    }
}
