namespace A15_Ex03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public class Bmessage : IMessage
    {
        public string CreateMessage(float result, ref PictureBox pictureBox)
        {
            if (result > 0.66666)
            {
                UpdateProfilePic.UpdatePicture(ref pictureBox, 1);
                return "You are nerd!!!";

            }
            else if (result < 0.3333)
            {
                UpdateProfilePic.UpdatePicture(ref pictureBox, 2);
                return "Well done!!! Girls love you!!!";
            }
            else
            {
                UpdateProfilePic.UpdatePicture(ref pictureBox, 3);
                return "The fine. But can also be more";
            }

        }
    }
}