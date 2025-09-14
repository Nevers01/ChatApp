using System;
using System.Windows.Forms;

namespace Chat.Client
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();

            using var auth = new AuthForm();         // önce auth ekraný
            if (auth.ShowDialog() == DialogResult.OK)
            {
                // AuthForm içindeki public property’lerden al
                var userId = auth.AuthenticatedUserId;
                var baseUrl = auth.BaseUrl;

                Application.Run(new MainForm(userId, baseUrl));
            }
        }
    }
}