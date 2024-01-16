namespace WebApplication04.Extensions;

public static class FileExtensions
{
    public static string RootPath { get; set; }

    public static bool IsValidSize(this IFormFile file, float kb = 20)
        => file.Length <= kb * 1024;

    public static bool IsCorrectType(this IFormFile file, string contentType = "image")
        => file.ContentType.Contains(contentType);

    public static async Task<string> SaveAsync(this IFormFile file, string path = "data")
    {
        string extension = Path.GetExtension(file.FileName);
        string fileName = Path.GetFileNameWithoutExtension(file.FileName).Length > 32 ?
            file.FileName.Substring(0, 32) :
            Path.GetFileNameWithoutExtension(file.FileName);
        fileName = Path.Combine(path, Path.GetRandomFileName() + fileName + extension);
        using (FileStream fs = File.Create(Path.Combine(RootPath, fileName)))
        {
            await file.CopyToAsync(fs);
        }
        return fileName;
    }
}
