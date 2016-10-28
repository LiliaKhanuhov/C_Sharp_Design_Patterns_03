namespace A15_Ex03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public interface IMessage
    {
        String CreateMessage(float result, ref PictureBox pictureBox);
    }
}
