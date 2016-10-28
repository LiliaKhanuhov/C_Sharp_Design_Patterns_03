namespace A15_Ex03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public class Message
    {
        public static String BuilderMessage(String userGender, float result, ref PictureBox pictureBox)
        {
            if (userGender.Equals("female"))
            {
                Fmessage fmsg = new Fmessage();
                return fmsg.CreateMessage(result, ref pictureBox);


            }
            else
            {
                Bmessage bmsg = new Bmessage();
                return bmsg.CreateMessage(result, ref pictureBox);
            }
        }
    }
}