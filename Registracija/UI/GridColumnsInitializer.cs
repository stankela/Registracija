using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Registracija.UI
{
    public class GridColumnsInitializer
    {
        public static int getMaxWidth(List<string> strings, DataGridView dataGridView)
        {
            Graphics g = dataGridView.CreateGraphics();
            float maxWidth = 0.0f;
            foreach (string s in strings)
            {
                float width = g.MeasureString(s, dataGridView.Font).Width;
                if (width > maxWidth)
                    maxWidth = width;
            }
            g.Dispose();
            return (int)Math.Ceiling(maxWidth);
        }
    }
}
