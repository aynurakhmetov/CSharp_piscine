using System;
using System.Runtime.CompilerServices;

namespace d00._05_ex00
{
    public class Storage
    {
        public int NumberOfItemsInStorage { get; set; }
        public Storage(int numberOfItems)
        {
            this.NumberOfItemsInStorage = numberOfItems;
        }
        public bool IsEmpty() => this.NumberOfItemsInStorage == 0;
    }
}