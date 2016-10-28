namespace A15_Ex03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using FacebookWrapper;


    static class Program
    {
        [STAThread]
        static void Main()
        {
            Clipboard.SetText("DesignPatterns");
            FacebookService.s_UseForamttedToStrings = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FacebookApplication());
        }
    }
}
