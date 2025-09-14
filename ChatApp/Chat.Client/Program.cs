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

            using var auth = new AuthForm();         // �nce auth ekran�
            if (auth.ShowDialog() == DialogResult.OK)
            {
                // AuthForm i�indeki public property�lerden al
                var userId = auth.AuthenticatedUserId;
                var baseUrl = auth.BaseUrl;

                Application.Run(new MainForm(userId, baseUrl));
            }
        }
    }
}