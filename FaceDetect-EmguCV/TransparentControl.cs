using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceDetect_EmguCV
{
    class TransparentControl : Control
    {
        List<Rectangle> rect = new List<Rectangle>();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        public void DrawRectangle(List<Rectangle> objRectangle)
        {
            rect = objRectangle;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Yellow, 3))
            {
                for (int i = 0; i < rect.Count; i++)
                    e.Graphics.DrawRectangle(pen, rect[i]);
            }
        }
    }
}
