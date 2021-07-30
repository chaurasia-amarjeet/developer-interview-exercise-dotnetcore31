using FileData.Interfaces;
using ThirdPartyTools;

namespace FileData.Services
{
    public class FileDetailsService : IFileDetailsService
    {
        private readonly FileDetails _fileDetails;

        public FileDetailsService(FileDetails fileDetails)
        {
            _fileDetails = fileDetails;
        }

        public string GetFileVersion(string filePath)
        {
            return _fileDetails.Version(filePath);
        }

        public int GetFileSize(string filePath)
        {
            return _fileDetails.Size(filePath);
        }
    }
}
