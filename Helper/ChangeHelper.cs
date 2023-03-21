namespace FFXIVUpdateChecker.Helper
{
    public class ChangeHelper<T>
    {
        private readonly IEnumerable<T> oldValues;
        private readonly IEnumerable<T> newValues;
        private readonly Func<T, T, bool> areEqual;
        private readonly Func<T, T> formatter;

        public ChangeHelper(IEnumerable<T> oldValues, IEnumerable<T> newValues, Func<T, T, bool> areEqual, Func<T, T>? formatter = null)
        {
            this.oldValues = oldValues;
            this.newValues = newValues;
            this.areEqual = areEqual;
            this.formatter = formatter;
        }

        public IEnumerable<T> AddedItems
        {
            get
            {
                var list = newValues.Where(n => oldValues.All(o => !areEqual(o, n)));
                return formatter != null ? list.Select(l => formatter(l)) : list;
            }
        }

        public IEnumerable<T> RemovedItems
        {
            get
            {
                var list = oldValues.Where(n => newValues.All(o => !areEqual(n, o)));
                return formatter != null ? list.Select(l => formatter(l)) : list;
            }
        }

        public IEnumerable<T> UpdatedItems
        {
            get
            {
                var list = newValues.Where(n => oldValues.Any(o => areEqual(n, o)));
                return formatter != null ? list.Select(l => formatter(l)) : list;
            }
        }
    }
}
