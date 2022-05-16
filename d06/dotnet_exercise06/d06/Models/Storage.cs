using System;
using System.Threading;

namespace d06.Models
{
    public class Storage
    {
        public int ItemsInStorage { get; set; }
        public bool IsEmpty => ItemsInStorage <= 0;
        private int _usingResource;
        
        public Storage(int totalItemCount)
        {
            ItemsInStorage = totalItemCount;
            _usingResource = 0;
        }

        public void ReduceItems(int customerItemsInCart)
        {
            if (0 == Interlocked.Exchange(ref _usingResource, 1))
            {
                this.ItemsInStorage -= customerItemsInCart;
                Interlocked.Exchange(ref _usingResource, 0);
            }
        }
    }
}