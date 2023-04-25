namespace FFXIVUCBLL.Model
{
    public class CompareFileModel
    {
        public CompareFileModel()
        {
            CompareList = new List<ColumnModel>();
        }

        public string FileName { get; set; }
        public List<ColumnModel> CompareList { get; set; }

        //public int AddCount
        //{
        //    get => CompareList.Where(c => c.ActionType == "AddedItems").Count();
        //}

        //public int RemoveCount
        //{
        //    get => CompareList.Where(c => c.ActionType == "RemovedItems").Count();
        //}
    }
}
