using FFXIVUpdateChecker.Model;
using System.Data;
using System.Reflection;

namespace FFXIVUpdateChecker.Helper
{
    public class CSVHelper
    {
        public static List<ColumnModel> CompareCSVColumns(string file1, string file2, bool compareData = false)
        {
            DataTable dt1 = GetDataTableFromCSVFile(file1);
            DataTable dt2 = GetDataTableFromCSVFile(file2);

            var oldColumnList = dt1.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
            var newColumnList = dt2.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
            var changer = new ChangeHelper<string>(oldColumnList, newColumnList, areEqual);

            List<ColumnModel> columnModelList = new List<ColumnModel>();

            foreach (PropertyInfo prop in changer.GetType().GetProperties())
            {
                var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                var isColumnType = type == typeof(IEnumerable<string>);

                if (!isColumnType)
                {
                    continue;
                }

                var propName = prop.Name;
                var propValue = prop.GetValue(changer, null) as IEnumerable<string>;

                if (propValue != null)
                {
                    var model = setModel(propValue, propName);
                    columnModelList = columnModelList.Concat(model).ToList();
                }
            }

            return columnModelList;
        }

        private static List<ColumnModel> setModel(IEnumerable<string> list, string actionName)
        {
            List<ColumnModel> columnModelList = new List<ColumnModel>();

            foreach (var item in list)
            {
                ColumnModel model = new ColumnModel();
                model.ColumnName = item;
                model.ActionType = actionName;
                columnModelList.Add(model);
            }

            return columnModelList;
        }


        private static bool areEqual(string oldColumnName, string newColumnName)
        {
            return oldColumnName.Equals(newColumnName);
        }


        private static DataTable GetDataTableFromCSVFile(string filePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }

                //while (!sr.EndOfStream)
                //{
                //    string[] rows = sr.ReadLine().Split(',');
                //    DataRow dr = dt.NewRow();
                //    for (int i = 0; i < headers.Length; i++)
                //    {
                //        dr[i] = rows[i];
                //    }
                //    dt.Rows.Add(dr);
                //}
            }

            return dt;
        }
    }
}
