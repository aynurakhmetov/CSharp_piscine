using System;

namespace ex00
{
    class Storage
    {
        private int numOfGoods;
        public int NumOfGoods
        {
            get
            {
                return numOfGoods;
            }
            set
            {
                if (value >= 0)
                    numOfGoods = value;
            }
        }
        public Storage(int num)
        {
            this.numOfGoods = num;
        }

        public void IsEmpty() => Console.WriteLine("Storage is empty");
    }
}