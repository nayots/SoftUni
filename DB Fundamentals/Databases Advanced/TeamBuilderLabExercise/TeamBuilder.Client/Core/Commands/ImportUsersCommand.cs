using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Services;

namespace TeamBuilder.Client.Core.Commands
{
    public class ImportUsersCommand
    {
        private readonly UserService userService;
        public ImportUsersCommand(UserService userService)
        {
            this.userService = userService;
        }
        public string Execute(string[] data)
        {
            if (data.Count() != 1)
            {
                throw new FormatException("Invalid arguments count!");
            }

            string filePath = data[0];

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Path {filePath} is not valid!");
            }


            int importedUsersCount = 0;
            try
            {
                importedUsersCount = userService.ImportUsers(filePath);
            }
            catch (Exception)
            {
                throw new FormatException("Invalid Xml format!");
            }


            string result = $"You have successfully imported {importedUsersCount} users!";
            return result;
        }
    }
}
