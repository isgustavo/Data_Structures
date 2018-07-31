namespace Data_Structures
{
    public abstract class DynamicArray<T>
    {
        const int EXPAND_MULTIPLY_FACTOR = 2;

        protected T[] items;
        protected int count;

        protected DynamicArray(int initSize)
        {
            items = new T[initSize];
            count = 0;
        }

        public abstract void Add(T item);
        public abstract bool Remove(T item);
        public abstract int IndexOf(T item);

        protected void Clear()
        {
            count = 0;
        }

        protected void Expand()
        {
            T[] newItems = new T[items.Length * EXPAND_MULTIPLY_FACTOR];

            for (int i = 0; i < items.Length; i++)
            {
                newItems[i] = items[i];
            }

            items = newItems;
        }
    }
}
