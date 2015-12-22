///anthor: billy huang///
/////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CheckSKU
{
    static class MiniAnimation
    {
        static int v = 0;
        static bool isCloseTool = false;
        static int sec = 5;
        static int count = 0;
        static int slineceCount = 0;
        static public void runAnimation(List<Label>labels,bool animationEnable)
        {
            if (!animationEnable)
            {
                if(++slineceCount==10)
                    isCloseTool = true;                
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    Point p = new Point(labels[i].Location.X, labels[i].Location.Y);
                    if (p.X < 40)
                    {
                        p.X += v;
                    }
                    else
                    {
                        p.X = 40;
                    }
                    labels[i].Location = p;
                }
                if (labels[4].Location.X == 40)
                {
                    Point p = new Point(labels[7].Location.X, labels[7].Location.Y);
                    if (p.X < 40)
                    {
                        p.X += v;
                    }
                    else
                    {
                        p.X = 40;
                    }
                    labels[7].Location = p;
                }
                if (v < 40)
                    v += 5;
                /////log animation/////
                if (labels[7].Location.X == 40)
                {
                    if (sec == 0)
                        isCloseTool = true;
                    if (count++ % 50 == 0)
                        sec--;
                    labels[8].Text = "<result.log> already been saved, This tool will auto colse after " + sec + " sec";
                }
            }
        }
        static public bool closeTool() //notify ui closed
        {
            return isCloseTool;        
        }
    }
}
