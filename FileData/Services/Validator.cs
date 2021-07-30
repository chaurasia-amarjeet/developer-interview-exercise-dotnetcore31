using FileData.Constants;
using FileData.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace FileData.Services
{
    public class Validator : IValidator
    {
        private readonly ILogger<Validator> _logger;

        public Validator(ILogger<Validator> logger)
        {
            _logger = logger;
        }

        public void ValidateConsoleArguments(string[] args)
        {
            if (args.Length < 2)
            {
                _logger.LogError("Expecting atleast 2 arguments.");
                throw new Exception("Expecting atleast 2 arguments.");
            }

            if (!(ListConstants.VersionConstansts.Contains(args[0]) 
                || ListConstants.SizeConstansts.Contains(args[0])))
            {
                _logger.LogError("Invalid first argument: {args[0]}", args[0]);
                throw new Exception($"Invalid first argument: {args[0]}");
            }
        }
    }
}
