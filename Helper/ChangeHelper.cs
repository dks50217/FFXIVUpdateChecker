namespace FFXIVUpdateChecker.Helper
{
    public class ChangeHelper<T>
    {
        private readonly IEnumerable<T> oldValues;
        private readonly IEnumerable<T> newValues;
        private readonly Func<T, T, bool> areEqual;

        public ChangeHelper(IEnumerable<T> oldValues, IEnumerable<T> newValues, Func<T, T, bool> areEqual)
        {
            this.oldValues = oldValues;
            this.newValues = newValues;
            this.areEqual = areEqual;
        }

        public IEnumerable<T> AddedItems
        {
            get => newValues.Where(n => oldValues.All(o => !areEqual(o, n)));
        }

        public IEnumerable<T> RemovedItems
        {
            get => oldValues.Where(n => newValues.All(o => !areEqual(n, o)));
        }

        public IEnumerable<T> UpdatedItems
        {
            get => newValues.Where(n => oldValues.Any(o => areEqual(n, o)));
        }
    }
}
