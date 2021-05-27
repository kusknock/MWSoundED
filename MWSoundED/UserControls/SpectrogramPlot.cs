using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace MWSoundED
{
    public partial class SpectrogramPlot : UserControl
    {
        private List<double[]> spectrogram;
        public List<double[]> Spectrogram
        {
            get { return spectrogram; }
            set
            {
                spectrogram = value;

                if (markline != null)
                {
                    markline.Clear();
                
                    markline = null;
                }

                if (spectrogram == null)
                {
                    return;
                }

                // post-process spectrogram for better visualization

                var spectraCount = spectrogram.Count;

                var minValue = spectrogram.SelectMany(s => s).Min();
                var maxValue = spectrogram.SelectMany(s => s).Max();

                _cmap = new SciColorMaps.ColorMap(ColorMapName, minValue, maxValue);

                Invalidate();
            }
        }

        private List<double> markline;
        public List<double> Markline
        {
            get { return markline; }
            set
            {
                markline = value;
                Invalidate();
            }
        }

        private int marklineThickness;
        public int MarklineThickness
        {
            get { return marklineThickness; }
            set
            {
                marklineThickness = value;
                Invalidate();
            }
        }

        public string ColorMapName { get; set; } = "magma";

        private SciColorMaps.ColorMap _cmap;

        public SpectrogramPlot()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (spectrogram == null)
            { 
                return;
            }

            var g = e.Graphics;
            g.Clear(Color.Black);

            var sWidth = spectrogram.Count;
            var sHeight = spectrogram[0].Length;

            var realPos = 0;

            Bitmap spectrogramBitmap = new Bitmap(Width, Height);

            // step sizes:
            float stepX = 1f * spectrogramBitmap.Width / sWidth;
            float stepY = 1f * spectrogramBitmap.Height / sHeight;

            using (Graphics spectrogramG = Graphics.FromImage(spectrogramBitmap))
            {
                for (int x = 0; x < sWidth; x++, realPos++)
                {
                    for (int y = 0; y < sHeight; y++)
                    {
                        using (SolidBrush brush = new SolidBrush(_cmap.GetColor(spectrogram[x][y])))
                        {
                            spectrogramG.FillRectangle(brush, realPos * stepX, (sHeight - 1 - y) * stepY, stepX, stepY);
                        }
                    }
                }
            }

            g.DrawImage(spectrogramBitmap, 0, 0);

            if (markline != null)
            {
                var pen = new Pen(Color.Red, marklineThickness);

                for (var i = 0; i < markline.Count; i++, realPos++)
                {
                    g.DrawLine(pen, (float)markline[i] * stepX, 0,
                        (float)markline[i] * stepX, spectrogramBitmap.Height);
                }

                pen.Dispose();
            }
        }
    }
}
