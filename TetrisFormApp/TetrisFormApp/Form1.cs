using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisFormApp
{
    public partial class Form1 : Form
    {
        List<Block> blockList;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            blockList = new List<Block>();
            AddBlock();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Block b in blockList)
            {
                b.Draw(e.Graphics);
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (blockList.Count > 0)
            {
                Block lastBlock = blockList.Last();
                if(GetTouchingBlock(lastBlock)[0] == false)
                {
                    lastBlock.Update(pictureBox1.Height);
                }
                else
                {
                    lastBlock.hasFallen = true;
                }
                lastBlock.Update(pictureBox1.Height);

                if (lastBlock.hasFallen)
                {
                    AddBlock();
                }
            }
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void AddBlock()
        {
            Block newBlock = null;
            Random randomBlock = new Random();
            switch (randomBlock.Next(7))
            {
                case 0:
                    newBlock = new Line_Block();
                    break;
                case 1:
                    newBlock = new J_Block();
                    break;
                case 2:
                    newBlock = new L_Block();
                    break;
                case 3:
                    newBlock = new S_Block();
                    break;
                case 4:
                    newBlock = new Square_Block();
                    break;
                case 5:
                    newBlock = new T_Block();
                    break;
                case 6:
                    newBlock = new Z_Block();
                    break;
            }
            blockList.Add(newBlock);
        }
        //[System.Security.Permissions.UIPermission(
        //System.Security.Permissions.SecurityAction.Demand,
        //Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (blockList.Count > 0)
            {
                Block lastBlock = blockList.Last();
                if ((keyData & Keys.KeyCode) == Keys.Down)
                {
                    lastBlock.Move(new Point(0, 10), pictureBox1.Size);
                }

                else if ((keyData & Keys.KeyCode) == Keys.Left)
                {
                    lastBlock.Move(new Point(-10, 0), pictureBox1.Size);
                }
                else if ((keyData & Keys.KeyCode) == Keys.Right)
                {
                    lastBlock.Move(new Point(10, 0), pictureBox1.Size);
                }

            }
            return base.ProcessDialogKey(keyData);
        }
        private bool[] GetTouchingBlock(Block block)
        {
            bool[] isTouchArray = new bool[] { false, false, false };
            List<Rectangle> rectangleList1 = block.GetRectangleList();

            foreach (Block b in blockList)
            {
                if (b != block)
                {
                    List<Rectangle> rectangleList2 = b.GetRectangleList();
                    foreach (Rectangle rect in rectangleList1)
                    {
                        //if touching bottom
                        if (rectangleList2.Exists(r => rect.Left == r.Left && rect.Bottom == r.Top))
                        {
                            isTouchArray[0] = true;
                        }
                        //if touching left
                        if (rectangleList2.Exists(r => rect.Left == r.Right && rect.Top == r.Top))
                        {
                            isTouchArray[1] = true;
                        }
                        //if touching right
                        if (rectangleList2.Exists(r => rect.Right == r.Left && rect.Top == r.Top))
                        {
                            isTouchArray[2] = true;
                        }

                    }
                }
            }
            return isTouchArray;
        }
    }

    //private void buttonII_Click(object sender, EventArgs e)
    //{
    //    Block b = new Line_Block();
    //    blockList.Add(b);
    //}

    //private void buttonJ_Click(object sender, EventArgs e)
    //{
    //    Block b = new J_Block();
    //    blockList.Add(b);
    //}

    //private void buttonL_Click(object sender, EventArgs e)
    //{
    //    Block b = new L_Block();
    //    blockList.Add(b);
    //}

    //private void buttonO_Click(object sender, EventArgs e)
    //{
    //    Block b = new Square_Block();
    //    blockList.Add(b);
    //}

    //private void buttonS_Click(object sender, EventArgs e)
    //{
    //    Block b = new S_Block();
    //    blockList.Add(b);
    //}

    //private void buttonZ_Click(object sender, EventArgs e)
    //{
    //    Block b = new Z_Block();
    //    blockList.Add(b);
    //}

    //private void buttonT_Click(object sender, EventArgs e)
    //{
    //    Block b = new T_Block();
    //    blockList.Add(b);
    //}
}

