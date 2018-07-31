namespace Data_Structures
{
    class UnorderedDynamicArray<T> : DynamicArray<T>
    {

        public UnorderedDynamicArray(int initSize)
            :base(initSize)
        { }

        public override void Add(T item)
        {
            if (count == items.Length)
            {
                Expand();
            }

            items[count] = item;
            count += 1;
        }

        public override int IndexOf(T item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public override bool Remove(T item)
        {
            int itemIndex = IndexOf(item);

            if (itemIndex == -1)
            {
                return false;
            }

            items[itemIndex] = items[count - 1];
            count -= 1;
            return true;
        }
    }
}
