using System;

namespace Data_Structures
{
    class OrderedDynamicArray<T> : DynamicArray<T> where T : IComparable
    {
        protected OrderedDynamicArray(int initSize) 
            : base(initSize)
        {
        }

        public override void Add(T item)
        {
            if (count == items.Length)
            {
                Expand();
            }

            int itemLocation = 0;
            while ((itemLocation < count)
                && (items[itemLocation].CompareTo(item) < 0))
            {
                itemLocation += 1;
            }

            ShiftUp(itemLocation);
            items[itemLocation] = item;
            count += 1;
        }

        public override int IndexOf(T item)
        {
            return IndexOf(item, 0, count - 1);
        }

        private int IndexOf(T item, int lowerIndex, int upperIndex)
        {
            int middleIndex = lowerIndex + (upperIndex - lowerIndex) / 2;
            T middleItem = items[middleIndex];

            if (middleIndex.CompareTo(item) == 0)
            {
                return middleIndex;
            }
            else
            {
                if (middleItem.CompareTo(item) == 1)
                {
                    upperIndex = middleIndex - 1;
                }
                else
                {
                    lowerIndex = middleIndex + 1;
                }

                if (lowerIndex > upperIndex)
                {
                    return -1;
                }

                return IndexOf(item, lowerIndex, upperIndex);
            }

        }

        public override bool Remove(T item)
        {
            int itemIndex = IndexOf(item);
            if (itemIndex == -1)
            {
                return false;
            }

            ShiftDown(itemIndex + 1);
            count -= 1;
            return true;
        }

        private void ShiftUp(int index)
        {
            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }
        }

        private void ShiftDown(int index)
        {
            for (int i = index; i < count; i++)
            {
                items[i - 1] = items[i];
            }
        }
    }
}
