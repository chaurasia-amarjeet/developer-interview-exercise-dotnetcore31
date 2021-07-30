using FileData.Constants;
using FileData.Enum;

namespace FileData.Extensions
{
    public static class StringExtensions
    {
        public static Operation GetOperation(this string value)
        {
            if (ListConstants.VersionConstansts.Contains(value))
            {
                return Operation.FileVersion;
            }

            return Operation.FileSize;
        }
    }
}
