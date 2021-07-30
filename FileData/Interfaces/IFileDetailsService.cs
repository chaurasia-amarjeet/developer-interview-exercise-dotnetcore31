namespace FileData.Interfaces
{
    public interface IFileDetailsService
    {
        string GetFileVersion(string filePath);
        int GetFileSize(string filePath);
    }
}
