using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Windows.Media.Imaging;
using ColorPop;

namespace ColorPop
{
    public partial class Form1 : Form
    {
        [DllImport(@"C:\Users\karol\source\repos\ja\ColorPop\x64\Debug\assembler.dll")]
        static extern void ASMtoMONO(short[] rightChannel, short[] leftChannel, int startIndex, int endIndex);

        private Stopwatch stopwatch;
        //private SepiaManager sm;
        private Bitmap pictureOriginal;
        private Bitmap pictureResault;
        private float[] pixels;
        private Color pixelColor;
        private float[] chosenColor = new float[3];
    public Form1()
        {
            InitializeComponent();
            pictureBefore.Click += pictureBox1_Click;
            stopwatch = new Stopwatch();
            threadsNumber.Value = System.Environment.ProcessorCount;
            label4.Text = System.Environment.ProcessorCount.ToString();
            threadsNumber.ValueChanged += (sender, e) =>
            {
                label4.Text = threadsNumber.Value.ToString();
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void openImage()
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "Plik graficzny (*.bmp)|*.BMP; *.bmp",
                FileName = "*.bmp"
            };
            openDialog.ShowDialog();

            if (openDialog.FileName != "*.bmp")
            {
                Image image = Image.FromFile(openDialog.FileName);
                openDialog.Dispose();
                pictureOriginal = (Bitmap)image;
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
        private Bitmap ScaleBitmap(Bitmap bmp, PictureBox picBox)
        {

            float ratio = 1.0f;
            int thumbHeight = 0;
            int thumbWidth = 0;

            if (bmp.Height > picBox.Height || bmp.Width > picBox.Width)
            {
                Image.GetThumbnailImageAbort myCallback =
                    new Image.GetThumbnailImageAbort(ThumbnailCallback);

                if (bmp.Height >= bmp.Width)
                {
                    ratio = (((float)bmp.Width) / ((float)bmp.Height));
                    thumbHeight = picBox.Height;
                    thumbWidth = (int)((thumbHeight) * (ratio));
                }
                else
                {
                    ratio = (((float)bmp.Height) / ((float)bmp.Width));
                    thumbWidth = picBox.Width;
                    thumbHeight = (int)((thumbWidth) * (ratio));
                }

                Image myThumbnail = bmp.GetThumbnailImage(thumbWidth, thumbHeight, myCallback, IntPtr.Zero);
                return new Bitmap(myThumbnail);
            }
            return bmp;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            openImage();
            pictureBefore.Image = ScaleBitmap(pictureOriginal, pictureBefore);
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            if ((ASM.Checked || Cpp.Checked) && !pictureBefore.Image.Equals(null))
            {
                String ColorPopMechanism = groupBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;
                BitmapSource bs = Bmp.BitmapToBitmapSource(pictureOriginal);
                pixels = Bmp.ToBmpBGRArray(bs);
                double[] wyniki = new double[320];
                TypeManager manager = null;
                chosenColor[0] = pixelColor.R;
                chosenColor[1] = pixelColor.G;
                chosenColor[2] = pixelColor.B;

                if (ASM.Checked)
                {
                    manager = new TypeManager(bs, ColorPopMechanismType.Assembly, chosenColor, threadsNumber.Value);
                }
                if (Cpp.Checked)
                {
                    manager = new TypeManager(bs, ColorPopMechanismType.Cpp, chosenColor, threadsNumber.Value);
                }

                TimeSpan t;
                BitmapSource bsa = manager.ExecuteEffect(out t);
                pictureAfter.Image = ScaleBitmap(Bmp.BitmapFromSource(bsa), pictureAfter);
                pictureResault = Bmp.BitmapFromSource(bsa);
                time.Text = t.ToString();
            }

        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (pictureResault != null)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = "moj_plik";
                saveDialog.Filter = "Plik graficzny (*.bmp)|*.BMP; *.bmp";
                saveDialog.ShowDialog();
                pictureResault.Save(saveDialog.FileName);
                saveDialog.Dispose();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Get the user's click position
            Point cursorPos = Cursor.Position;
            Point formPos = PointToClient(cursorPos);

            // Get the pixel color at the click position
            pixelColor = GetPixelColor(formPos);

            panel1.BackColor = pixelColor;
            // Do something with the obtained color, like displaying it in a text box
            textBox1.Text = $"Color: R={pixelColor.R}, G={pixelColor.G}, B={pixelColor.B}";
        }

        private Color GetPixelColor(Point position)
        {
            if (pictureOriginal != null && pictureBefore.Image != null)
            {
                // Calculate the scaling factors
                float scaleX = (float)pictureOriginal.Width / pictureBefore.ClientSize.Width;
                float scaleY = (float)pictureOriginal.Height / pictureBefore.ClientSize.Height;

                // Scale the position based on the scaling factors
                int originalX = (int)(position.X * scaleX);
                int originalY = (int)(position.Y * scaleY);

                // Check if the scaled position is within the bounds of the original image
                if (originalX >= 0 && originalX < pictureOriginal.Width && originalY >= 0 && originalY < pictureOriginal.Height)
                {
                    // Get the color of the pixel at the scaled position in the original image
                    Color pixelColor = pictureOriginal.GetPixel(originalX, originalY);
                    return pixelColor;
                }
            }

            return Color.Empty;
        }



    }
}
