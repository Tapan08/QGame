using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPatelQGame
{
    public partial class DesignForm : Form
    {
        PictureBox[,] pictureBoxes;

        int wall = 0;
        int door = 0;
        int box = 0;


        public DesignForm()
        {
            InitializeComponent();

            button1.ImageList = imageList1;
            button1.ImageIndex = 0;
            button2.ImageList = imageList1;
            button2.ImageIndex = 1;
            button3.ImageList = imageList1;
            button3.ImageIndex = 2;
            button4.ImageList = imageList1;
            button4.ImageIndex = 3;
            button5.ImageList = imageList1;
            button5.ImageIndex = 4;
            button6.ImageList = imageList1;
            button6.ImageIndex = 5;
        }



        private void Generate(int Rows, int Cols)
        {
            pictureBoxes = new ToolPictureBox[Rows, Cols];

            

         

            if(tableLayoutPanel1.Controls.Count == 0)
            {
                tableLayoutPanel1.Controls.Clear();

                tableLayoutPanel1.RowCount = Rows;

                tableLayoutPanel1.ColumnCount = Cols;

                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        pictureBoxes[i, j] = new ToolPictureBox();
                        pictureBoxes[i, j].Dock = DockStyle.Fill;
                        pictureBoxes[i, j].BorderStyle = BorderStyle.FixedSingle;
                        pictureBoxes[i, j].Tag = "Empty";
                        pictureBoxes[i, j].Click += ToolPictureBox_Click;
                        pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.StretchImage;

                        tableLayoutPanel1.Controls.Add(pictureBoxes[i, j], j, i);

                    }
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Do you want to create the new level ?\n If you do, the current level will be lost ", "Error", MessageBoxButtons.YesNo);

                if(dr == DialogResult.Yes)
                {
                    tableLayoutPanel1.Controls.Clear();

                    tableLayoutPanel1.RowCount = Rows;

                    tableLayoutPanel1.ColumnCount = Cols;

                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Cols; j++)
                        {
                            pictureBoxes[i, j] = new ToolPictureBox();
                            pictureBoxes[i, j].Dock = DockStyle.Fill;
                            pictureBoxes[i, j].BorderStyle = BorderStyle.FixedSingle;
                            pictureBoxes[i, j].Tag = "Empty";
                            pictureBoxes[i, j].Click += ToolPictureBox_Click;
                            pictureBoxes[i, j].SizeMode = PictureBoxSizeMode.StretchImage;

                            tableLayoutPanel1.Controls.Add(pictureBoxes[i, j], j, i);

                        }
                    }
                }
            }

           

        }

      



        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*"; 
                saveFileDialog.Title = "Save File"; 
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    StringBuilder content = new StringBuilder();

                    content.AppendLine(textBox1.Text.ToString());
                    content.AppendLine(textBox2.Text.ToString());

                    int Rows = int.Parse(textBox1.Text.ToString());
                    int Columns = int.Parse(textBox2.Text.ToString());


                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            ToolPictureBox pictureBox = (ToolPictureBox)pictureBoxes[i, j];
                            content.AppendLine(i.ToString()); 
                            content.AppendLine(j.ToString());
                            content.AppendLine(pictureBox.OptionValue.ToString());

                            
                        }


                    }
                    File.WriteAllText(filePath, content.ToString());

                    MessageBox.Show($"File has saved Successfully\n Total number of walls: {wall}\n  Total number of Doors: {door}\n  Total number of boxes: {box}\n");
                } 
            }
        }

        private string click = "None";

        private void ToolPictureBox_Click(object sender, EventArgs e)
        {
            ToolPictureBox pictureBox = sender as ToolPictureBox;
          

           
            switch (click)
            {
                case "None":
                    pictureBox.OptionValue = 0;
                    pictureBox.Image = default;
                    pictureBox.Tag = "None";
                    break;

                case "Wall":
                    pictureBox.OptionValue = 1;
                    pictureBox.Image = Properties.Resources.wall;
                    pictureBox.Tag = "Wall";
                    wall += 1;
                    break;

                case "redDoor":
                    pictureBox.OptionValue = 2;
                    pictureBox.Image = Properties.Resources.reddoor;
                    pictureBox.Tag = "redDoor";
                    door += 1;
                    break;

                case "greenDoor":
                    pictureBox.OptionValue = 3;
                    pictureBox.Image = Properties.Resources.greendoor;
                    pictureBox.Tag = "greenDoor";
                    door += 1;
                    break;

                case "redBox":
                    pictureBox.OptionValue = 4;
                    pictureBox.Image = Properties.Resources.redbox;
                    pictureBox.Tag = "redBox";
                    box += 1;
                    break;

                case "greenBox":
                    pictureBox.OptionValue = 5;
                    pictureBox.Image = Properties.Resources.greenbox;
                    pictureBox.Tag = "greenBox";
                    box += 1;
                    break;

                default:
                    break;
            }
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            int row, columns;

            if((int.TryParse(textBox1.Text, out row) && int.TryParse(textBox2.Text, out columns)))
            {
                if(row > 0 && columns > 0)
                {
                    Generate(row, columns);
                }
                else if(row > 0 && columns < 0)
                {
                    MessageBox.Show("Please enter valid positive number for Columns");
                }
                else if(row < 0 && columns > 0)
                {
                    MessageBox.Show("Please enter valid positive number for rows ");
                }
                else if(row == 0 && columns == 0)
                {
                    MessageBox.Show("Please enter valid Positive value for rows and Columns");
                    
                }
            }
            else if(int.TryParse(textBox1.Text, out row) == false || int.TryParse(textBox2.Text, out columns) == false)
            {
                MessageBox.Show("Please enter valid numbers for row and columns (Both must be interger. Input string was not in a correct format.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            click = "None";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            click = "Wall";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            click = "redDoor";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            click = "greenDoor";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            click = "redBox";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            click = "greenBox";
        }
    }
}
