using System;
using Avalonia;
using Avalonia.Media;
using BurdUI.Utils;

namespace BurdUI
{
    public enum HorizontalStackOrigin
    {
        Left,
        Right
    }

    [Serializable]
    public class HorizontalLayoutPanel : View
    {
        
        public Border Border { get; set; }
        /// <summary>
        /// Whether children are laid out from the left or from the right.
        /// </summary>
        public HorizontalStackOrigin Origin { get; set; } = HorizontalStackOrigin.Left;

        /// <summary>
        /// Horizontal spacing (in pixels) between consecutive children.
        /// </summary>
        public double Spacing { get; set; } = 0;

        public HorizontalLayoutPanel()
        {
            this.Border = new Border();
        }

        /// <summary>
        /// Performs the layout of children based on panel Bounds and Origin.
        /// Children are sized to fill the panel height, and their width is taken
        /// from their current Bounds.Width.
        /// Child Bounds are assigned in the panel's local coordinates.
        /// </summary>
        private void LayoutChildren()
        {
            double innerHeight = Math.Max(0.0, this.Bounds.Height);

            if (Origin == HorizontalStackOrigin.Left)
            {
                double x = 0;
                foreach (var child in this.Children)
                {
                    double w = Math.Max(0, child.Bounds.Width);
                    child.Bounds = new Rect(x, 0, w, innerHeight);
                    x += w + Spacing;
                }
            }
            else // HorizontalStackOrigin.Right
            {
                double x = this.Bounds.Width;
                foreach (var child in this.Children)
                {
                    double w = Math.Max(0, child.Bounds.Width);
                    x -= w; // reserve space
                    child.Bounds = new Rect(x, 0, w, innerHeight);
                    x -= Spacing;
                }
            }
        }

        /// <summary>
        /// Lays out children, then defers to base to paint them.
        /// </summary>
        public override void Paint(DrawingContext g, Rect clip)
        {
            // Compute child bounds before drawing
            LayoutChildren();
            
            using (g.PushClip(new Rect(clip.X, clip.Y,clip.Width,clip.Height)))
            {
                var thickBounds = new Rect(
                    Bounds.X + Border.StrokeThickness, Bounds.Y + Border.StrokeThickness,
                    Bounds.Width - 2.0 * Border.StrokeThickness,
                    Bounds.Height - 2.0 * Border.StrokeThickness
                );
                this.Border?.Fill(g, thickBounds);
                this.Border?.Draw(g, thickBounds);
            }

            // base.Paint handles translation by this.Bounds and child painting
            base.Paint(g, clip);
        }
    }
}