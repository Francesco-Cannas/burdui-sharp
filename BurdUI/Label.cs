using Avalonia;
using Avalonia.Media;
using BurdUI.Utils;

namespace BurdUI;

public class Label: View
{
    public AlignedText? Text { get; set; }

    public Label(string label = "")
    {
        this.Text = new AlignedText(label)
        {
            HorizontalAlignment = AlignedText.HorizontalTextAlignment.Left,
            VerticalAlignment = AlignedText.VerticalTextAlignment.Middle
        };
    }
    
    public override void Paint(DrawingContext g, Rect clip)
    {
        
        
        using (g.PushClip(new Rect(clip.X, clip.Y,clip.Width,clip.Height)))
        {
            this.Text?.Draw(g, this.Bounds);
        }
        
    }

}