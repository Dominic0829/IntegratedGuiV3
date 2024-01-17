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

namespace IntegratedGuiV2
{
    public partial class LoadingForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int RightRect,
            int BottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public LoadingForm()
        {
            InitializeComponent();
            //this.TransparencyKey = BackColor;
            //this.Opacity = 0.5;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public LoadingForm(Form parent)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
            if (parent != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(parent.Location.X + parent.Width / 2 - this.Width / 2,
                    parent.Location.Y + parent.Height / 2 - this.Height / 2);
            }
            else
                this.StartPosition = FormStartPosition.CenterParent;
        }

        public void CloseWaitForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            if (label1.Image != null)
            {
                label1.Image.Dispose();
            }
        }
    }
}
