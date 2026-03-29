using Avalonia;
using Avalonia.Input;

namespace BurdUI;

public enum BurdUIEventType
{
    Repaint, 
    MouseMove,
    MouseDown,
    MouseUp,
    KeyUp,
    KeyDown,
}

public class BurdUIEvent
{
    public View Source { get; set; }
    public BurdUIEventType Type { get; set; }
    
    public long  Timestamp { get; set; }
}

public class RepaintEvent : BurdUIEvent
{
    public RepaintEvent()
    {
        this.Type = BurdUIEventType.Repaint;
    }
    public Rect DamagedArea { get; set; }
}

public class MouseEvent : BurdUIEvent
{
    
    public double X { get; set; }
    public double Y { get; set; }
    public double ScreenX { get; set; }
    public double ScreenY { get; set; }
    public KeyModifiers Modifiers { get; set; }
    
}

public class KeyEvent : BurdUIEvent
{
    public Key Key { get; set; }
}