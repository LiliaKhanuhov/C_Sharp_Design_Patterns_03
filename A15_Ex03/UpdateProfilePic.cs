using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using System.Drawing;

namespace A15_Ex03
{
    class UpdateProfilePic
    {
        public static void UpdatePicture(ref PictureBox pictureBox, int imageOption)
        {
            if (imageOption == 1)
            {
                pictureBox.Image = Image.FromFile(@"C:\Users\Lilia\Documents\Visual Studio 2010\Projects\A15 Ex03 Lilia 326958568 Wael 200567477\A15_Ex03\picture1.jpg");
            }
            else if (imageOption == 2)
            {
                pictureBox.Image = Image.FromFile(@"C:\Users\Lilia\Documents\Visual Studio 2010\Projects\A15 Ex03 Lilia 326958568 Wael 200567477\A15_Ex03\picture3 (1).jpg");
            }
            else
            {
                pictureBox.Image = Image.FromFile(@"C:\Users\Lilia\Documents\Visual Studio 2010\Projects\A15 Ex03 Lilia 326958568 Wael 200567477\A15_Ex03\picture3 (2).jpg");
            }
        }    
    }
}
