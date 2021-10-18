using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFormApp
{
    class Line_Block: Block
    {
        public Line_Block()
        {
            rectangleList = new List<Rectangle>
            {
                new Rectangle(0, 0, 10, 10),
                new Rectangle(10, 0, 10, 10),
                new Rectangle(20, 0, 10, 10),
                new Rectangle(30, 0, 10, 10)
            };
            width = 40;
            height = 10;
            color = Color.Cyan;
        }
    }
}
