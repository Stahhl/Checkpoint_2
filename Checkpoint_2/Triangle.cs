using System;
using System.Collections.Generic;
using System.Text;

//hipster överkurs
public enum Point { DESCENDING, ASCENDING }

namespace Checkpoint_2
{
    class Triangle
    {
        public int MySize { get; private set; }
        public Point MyPoint { get; private set; }

        public Triangle(int size, char c)
        {
            MySize = size;

            if (c == 'A')
                MyPoint = Point.ASCENDING;
            if (c == 'B')
                MyPoint = Point.DESCENDING;
            //A check if its 'A' or 'B' should already have been done by this point. But just in case.
            if (c != 'A' && c != 'B')
            {
                throw new Exception("DOOM");
            }
        }
    }
}
