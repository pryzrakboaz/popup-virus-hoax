using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Popup_windows_Virus
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(IntPtr classname, string title); // extern method: FindWindow

        [DllImport("user32.dll")]
        static extern void MoveWindow(IntPtr hwnd, int X, int Y,
            int nWidth, int nHeight, bool rePaint); // extern method: MoveWindow

        [DllImport("user32.dll")]
        static extern bool GetWindowRect
            (IntPtr hwnd, out Rectangle rect); // extern method: GetWindowRect

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           int eventcount = 0;
    

            while (eventcount < 20)
            {
                Random coordinites = new Random();
                int randomx = coordinites.Next(0, 1280);
                
                int randomy = coordinites.Next(0, 800);
                FindAndMoveMsgBox(randomx, randomy, true, "Delete Error");
                Form2 nf = new Form2();
                nf.Show();
                //MessageBox.Show("Virus Not Deleted!!! Refer to your Microsoft Technician.", "Delete Error");
                eventcount++;
            }
        }
        void FindAndMoveMsgBox(int x, int y, bool repaint, string title)
        {
            Thread thr = new Thread(() => // create a new thread
            {
                IntPtr msgBox = IntPtr.Zero;
                // while there's no MessageBox, FindWindow returns IntPtr.Zero
                while ((msgBox = FindWindow(IntPtr.Zero, title)) == IntPtr.Zero) ;
                // after the while loop, msgBox is the handle of your MessageBox
                Rectangle r = new Rectangle();
                GetWindowRect(msgBox, out r); // Gets the rectangle of the message box
                MoveWindow(msgBox /* handle of the message box */, x, y,
                   r.Width - r.X /* width of originally message box */,
                   r.Height - r.Y /* height of originally message box */,
                   repaint /* if true, the message box repaints */);
            });
            thr.Start(); // starts the thread
        }
    }
}
