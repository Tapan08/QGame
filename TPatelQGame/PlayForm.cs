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
using System.Xml;

namespace TPatelQGame
{
   
    public partial class PlayForm : Form
    {
       

        int rows;
        int cols;

        public int Box = 0;
       
        public int Moves = 0;

        public PictureBox pb;
        public PlayForm()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {
           
        }

        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private PictureBox CreatePictureBox(int content)
        {
            PictureBox picture = new PictureBox();

            // Set properties based on content (you may need to adjust this based on your game requirements)
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Width = 50;
            picture.Height = 50;

            switch (content)
            {
                case 0: // Empty
                    picture.Image = default;
                    picture.Tag = "Empty";
                    break;
                case 1: // Wall
                    picture.Image = Properties.Resources.wall;
                    picture.Tag = "wall";
                    break;
                case 2: // Box
                    picture.Image = Properties.Resources.redbox;
                    picture.Tag = "Box-Red";
                    Box++;
                    break;
                case 3: // Box
                    picture.Image = Properties.Resources.greenbox;
                    picture.Tag = "Box-Green";
                    Box++;
                    break;
                case 4: // Door
                    picture.Image = Properties.Resources.reddoor;
                    picture.Tag = "Door-Red";
                   
                    break;
                case 5: // Door
                    picture.Image = Properties.Resources.greendoor;
                    picture.Tag = "Door-Green";
                 
                    break;
                default:
                    break;

            }


            picture.Size = new System.Drawing.Size(50, 50);
            //picture.Margin = new Padding(0);
            picture.Click += PictureBox_Click;

            return picture;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox click = (PictureBox)sender;

            string cont = (string)click.Tag;

            if(cont == "Box-Red" || cont == "Box-Green")
            {
                if(pb != null)
                {
                    pb.BorderStyle = BorderStyle.None;
                }

                pb = click;
                pb.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                MessageBox.Show("You cannot move those blocks");
            }
        }

        private void Move(int x, int y)
        {
            Box = int.Parse(textBox2.Text);
            if (pb != null)
            {
                int currentRow = tableLayoutPanel1.GetRow(pb);
                int currentCol = tableLayoutPanel1.GetColumn(pb);

                // Calculate the new position based on the specified direction


                int newR = currentRow + y;
                int newC = currentCol + x;



                // Check if the new position is within bounds
                if (newR >= 0 && newR < tableLayoutPanel1.RowCount &&
                    newC >= 0 && newC < tableLayoutPanel1.ColumnCount)
                {
                    Control dc = tableLayoutPanel1.GetControlFromPosition(newC, newR);
                    Control pc = tableLayoutPanel1.GetControlFromPosition(currentCol, currentRow);

                


                    // Check if the destination cell is empty or a door with the same color
                    if (dc == null || 
                        dc.Tag.ToString() == "Empty" ||
                        (pb.Tag.ToString().StartsWith("Box") &&
                        dc.Tag.ToString().StartsWith("Door") == true &&
                        dc.Tag?.ToString().EndsWith(pb.Tag.ToString().Split('-')[1]) == true))
                    {
                        if (dc == null)  // Setting Image to null, if the background is empty
                        {
                            dc.Tag = "Empty";
                            tableLayoutPanel1.GetControlFromPosition(newC, newR).BackgroundImage = null;
                           
                        }
                        else
                        {
                            tableLayoutPanel1.GetControlFromPosition(newC, newR).BackgroundImage = pb.Image;
                        }

                        if (pc != null)
                        {
                            pc.BackgroundImage = null;
                        }
                        
                      


                        if(dc is PictureBox dc1)
                        {
                            dc1.BackgroundImageLayout = ImageLayout.Stretch;
                            dc1.BackgroundImage = pb.Image;
                        }
                        if(tableLayoutPanel1.GetControlFromPosition(newC, newR) is PictureBox dc2)
                        {
                            dc2.BackgroundImageLayout = ImageLayout.Stretch;
                            dc2.BackgroundImage = pb.Image;
                        }

                        Image image = (pc is PictureBox opc) ? opc.BackgroundImage : default;
                        pb.Visible = false;

                        if(dc == pb)
                        {
                            tableLayoutPanel1.GetControlFromPosition(newC, newR).BackgroundImage = pb.Image;
                        }

                        if(dc == null)
                        {
                            pb.Tag = "Empty";
                            tableLayoutPanel1.GetControlFromPosition(newC, newR).BackgroundImage = null;
                            
                        }
                        else
                        {
                            tableLayoutPanel1.GetControlFromPosition(newC, newR).BackgroundImage = pb.Image;
                        }                    




                        // Checking for the Door Tag
                        if (dc.Tag != null && dc.Tag.ToString().StartsWith("Door") && dc.Tag.ToString().EndsWith(pb.Tag.ToString().Split('-')[1]))
                        {
                           
                            Box--;                           
                           

                        }


                        // If the Box and Door are of the same color. It's detecting throught the Tag from the previous "if" statement
                        if (Box == 0)
                        {
                            MessageBox.Show("Congratulations! You Won !");
                            Moves = -1;
                            Box = 0;
                            tableLayoutPanel1.Controls.Clear();
                           
                        }

                        tableLayoutPanel1.SetRow(pb, newR);
                        tableLayoutPanel1.SetColumn(pb, newC);

                        
                        Moves++;
                        UpdateNumOfBoxTextBox();
                        UpdateNumOfMoves();

                    }

                    else
                    {
                        // Hit a wall or a door with a different color, stop moving
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }










        private void UpdateNumOfBoxTextBox()
        {
            // Assuming textBoxNumOfBox is the name of your TextBox
            textBox2.Text = Box.ToString();

        }

        private void UpdateNumOfMoves()
        {
            // Assuming textBoxNumOfBox is the name of your TextBox
            textBox1.Text = Moves.ToString();

        }

        private void button1_Click(object sender, EventArgs e) //Up
        {
            Move(0, -1);
        }

        private void button2_Click(object sender, EventArgs e) // Down
        {
            Move(0, 1);
        }

        private void button3_Click(object sender, EventArgs e) // Left
        {
            Move(-1, 0);
        }

        private void button4_Click(object sender, EventArgs e) // Right
        {
            Move(1, 0);
        }

        private void loadGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
             OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\txt";
            ofd.Filter = "Text Files Only (*.txt) | *.txt";
            ofd.DefaultExt = "txt";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                tableLayoutPanel1.Controls.Clear();


                try
                {
                    string[] file = File.ReadAllLines(ofd.FileName);


                    if(file.Length > 0)
                    {
                        rows = int.Parse(file[0]);
                        cols = int.Parse(file[1]);

                        tableLayoutPanel1.RowCount = rows;
                        tableLayoutPanel1.ColumnCount = cols;


                        for(int i = 2; i < file.Length; i+= 3)
                        {
                            int row = int.Parse(file[i]);
                            int col = int.Parse(file[i + 1]);
                            int content = int.Parse(file[i + 2]);

                            PictureBox picture = CreatePictureBox(content);

                            tableLayoutPanel1.Controls.Add(picture, col, row);
                        }
                        textBox1.Text = "0";
                        textBox2.Text = Box.ToString();
                    }
                    else
                    {
                        MessageBox.Show("File is Empty");

                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
              
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    

}
