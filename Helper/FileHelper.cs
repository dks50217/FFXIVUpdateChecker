using FFXIVUpdateChecker.Model;
using System.IO;
using System.Text.RegularExpressions;

namespace FFXIVUpdateChecker.Helper
{
    public class FileHelper
    {
        public static List<CompareFileModel> CompareFiles(string old_folder, string new_folder)
        {
            if (!Directory.Exists(old_folder)) 
            {
                throw new Exception($"{old_folder} not exists");
            }

            if (!Directory.Exists(new_folder))
            {
                throw new Exception($"{new_folder} not exists");
            }

            var new_files = Directory.GetFiles(new_folder).ToList();
            var old_files = Directory.GetFiles(old_folder).ToList();
            var changerList = new ChangeHelper<string>(old_files, new_files, areEqual, formatter);

            List<CompareFileModel> summaryList = new List<CompareFileModel>();

            foreach (var item in changerList.UpdatedItems) 
            {
                CompareFileModel compareModel = new CompareFileModel();
                var newFile = $"{new_folder}\\{item}";
                var oldFile = $"{old_folder}\\{item}";
                var model = CSVHelper.CompareCSVColumns(newFile, oldFile);
                compareModel.FileName = item;
                compareModel.CompareList = model;
                summaryList.Add(compareModel);
            }

            return summaryList;
        }

        private static string formatter(string orgFilePath)
        {
            var regexPattern = @"[^\\]*$";
            return Regex.Match(orgFilePath, regexPattern).Value;
        }

        private static bool areEqual(string oldFilePath, string newFilePath)
        {
            var regexPattern = @"[^\\]*$";
            var oldFileName = Regex.Match(oldFilePath, regexPattern).Value;
            var newFileName = Regex.Match(newFilePath, regexPattern).Value;
            return oldFileName.Equals(newFileName);
        } 
    }
}
