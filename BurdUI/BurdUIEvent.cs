using Avalonia;

namespace BurdUI;

public enum BurdUIEventType
{
    Repaint
}

public class BurdUIEvent
{
    public View Source { get; set; }
    public BurdUIEventType Type { get; set; }
}

public class RepaintEvent : BurdUIEvent
{
    public RepaintEvent()
    {
        this.Type = BurdUIEventType.Repaint;
    }
    public Rect DamagedArea { get; set; }
}