using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPatelQGame
{
    public class ToolPictureBox : PictureBox
    {
        public int OptionValue { get; set; }

        public ToolPictureBox() 
        {
            OptionValue = 0;
        }

    }
}
