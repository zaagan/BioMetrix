using System.Drawing;
using System.Windows.Forms;

namespace BioMetrixCore
{
    public partial class DataEmpty : UserControl
    {
        public DataEmpty()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                         Color.FromArgb(214, 214, 214), 2, ButtonBorderStyle.Outset,
                                         Color.FromArgb(214, 214, 214), 2, ButtonBorderStyle.Outset,
                                         Color.FromArgb(214, 214, 214), 2, ButtonBorderStyle.Inset,
                                         Color.FromArgb(214, 214, 214), 2, ButtonBorderStyle.Inset);
        }
    }
}
