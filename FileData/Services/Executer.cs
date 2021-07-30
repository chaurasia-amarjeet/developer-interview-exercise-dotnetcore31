using FileData.Extensions;
using FileData.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace FileData.Services
{
    public class Executer : IExecuter
    {
        private readonly IFileDetailsService _fileDetailsService;
        private readonly IValidator _validator;
        private readonly ILogger<Executer> _logger;

        public Executer(
            IFileDetailsService fileDetailsService, 
            IValidator validator,
            ILogger<Executer> logger)
        {
            _fileDetailsService = fileDetailsService;
            _validator = validator;
            _logger = logger;
        }

        public void Execute(string[] args)
        {
            try
            {
                _logger.LogDebug("Validating args...");
                _validator.ValidateConsoleArguments(args);

                var operation = args[0].GetOperation();

                _logger.LogDebug("Performing operation: {operation}", operation);
                PerformOperation(operation, args[1]);
            }
            catch (Exception)
            {
                _logger.LogError("Exception occured.");
            }
        }

        private void PerformOperation(Enum.Operation operation, string filePath)
        {
            switch (operation)
            {
                case Enum.Operation.FileVersion:
                    Console.WriteLine("File version: " + _fileDetailsService.GetFileVersion(filePath));
                    break;
                case Enum.Operation.FileSize:
                    Console.WriteLine("File size: " + _fileDetailsService.GetFileSize(filePath));
                    break;
            }
        }
    }
}
