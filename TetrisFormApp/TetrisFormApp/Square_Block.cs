using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisFormApp
{
    class Square_Block: Block
    {
        public Square_Block()
        {
            rectangleList = new List<Rectangle>
            {
                new Rectangle(0, 0, 10, 10),
                new Rectangle(10, 0, 10, 10),
                new Rectangle(0, 10, 10, 10),
                new Rectangle(10, 10, 10, 10)
            };
            width = 20;
            height = 20;
            color = Color.Yellow;
        }
    }
}
