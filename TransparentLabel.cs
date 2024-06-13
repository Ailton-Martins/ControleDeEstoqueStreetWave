using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms;

public class TransparentLabel : Label
{
    public TransparentLabel()
    {
        SetStyle(ControlStyles.Opaque, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Parent != null)
        {
            using (var bmp = new Bitmap(Parent.Width, Parent.Height))
            {
                Parent.Controls.Cast<Control>()
                    .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
                    .Where(c => c.Bounds.IntersectsWith(Bounds))
                    .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
                    .ToList()
                    .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));

                e.Graphics.DrawImage(bmp, -Left, -Top);
            }
        }

        using (var brush = new SolidBrush(Color.FromArgb(255, ForeColor)))
        {
            e.Graphics.DrawString(Text, Font, brush, ClientRectangle);
        }
    }
}
