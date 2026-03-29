using Avalonia;
using Avalonia.Media;
using BurdUI.Utils;

namespace BurdUI;

public class TextField: View
{
    public Border? Border { get; set; }
    public AlignedText? Text { get; set; }
    
    public TextField(string label = "")
    {
        this.Text = new AlignedText(label)
        {
            HorizontalAlignment = AlignedText.HorizontalTextAlignment.Left,
            VerticalAlignment = AlignedText.VerticalTextAlignment.Middle
        };

        this.Border = new Border()
        {
            BackgroudColor = Colors.White,
            Color =  Colors.Black,
            CornerRadius = 4
        };
    }
    
    public override void Paint(DrawingContext g, Rect clip)
    {
        
        
        using (g.PushClip(new Rect(clip.X, clip.Y,clip.Width,clip.Height)))
        {
            var thickBounds = new Rect(
                Bounds.X + Border.StrokeThickness, Bounds.Y + Border.StrokeThickness,
                Bounds.Width - 2.0 * Border.StrokeThickness,
                Bounds.Height - 2.0 * Border.StrokeThickness
            );
            this.Border?.Fill(g, thickBounds);
            this.Text?.Draw(g, this.Bounds);
            this.Border?.Draw(g, thickBounds);
        }
        
    }
    
}