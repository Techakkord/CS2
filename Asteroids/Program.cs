using System;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroids
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            form.MaximumSize = new Size(form.Width, form.Height);
            form.MinimumSize = new Size(form.Width, form.Height);
            form.Text = "Евгений Филимонов (С)Версия от 30.03.2022";
            form.Icon = new System.Drawing.Icon("file.ico");
            form.Show();
            Game.Init(form);
            Application.Run(form);

        }
    }
}
