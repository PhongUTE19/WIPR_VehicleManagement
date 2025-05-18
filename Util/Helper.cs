using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace VehicleManagement
{
    public class Helper
    {
        public static bool ContainsNumber(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }

        public static bool ContainsLetter(string input)
        {
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                    return true;
            }
            return false;
        }

        public static Image getFileImage()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.png;*.bmp";
                openFileDialog.Title = "Upload image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    return Image.FromFile(openFileDialog.FileName);
            }

            return null;
        }

        public static byte[] imageToByteArray(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    using (Bitmap bmp = new Bitmap(image))
                        bmp.Save(memoryStream, ImageFormat.Jpeg);
                    return memoryStream.ToArray();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Image conversion failed: " + ex.Message);
                    return null;
                }
            }
        }

        public static Image byteArrayToImage(byte[] bytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                return Image.FromStream(memoryStream);
            }
        }

        public static bool IsFieldEmpty(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show(Const.Message.EMPTY_FIELD, Const.Title.INVALID, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            return false;
        }

        public static bool IsFieldEmpty(Image image)
        {
            if (image == null)
            {
                MessageBox.Show(Const.Message.EMPTY_FIELD, Const.Title.INVALID, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }

            return false;
        }
    }
}
