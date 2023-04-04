namespace FFXIVUCBLL.Model
{
    public class RootModel
    {
        public RootModel()
        {
            ColumnModelList = new List<ColumnModel>();
        }

        public string FileName { get; set; }
        public List<ColumnModel> ColumnModelList { get; set; }

        public string AddList
        {
            get
            {
                var addList = ColumnModelList.Where(c => c.ActionType == "AddedItems");
                return string.Join(",", addList.Select(i => i.ColumnName).ToArray());
            }
        }
    }
}
