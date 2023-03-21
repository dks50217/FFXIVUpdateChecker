namespace FFXIVUpdateChecker.Model
{
    public class CompareFileModel
    {
        public CompareFileModel()
        {
            CompareList = new List<ColumnModel>();
        }

        public string FileName { get; set; }
        public List<ColumnModel> CompareList { get; set; }
    }
}
