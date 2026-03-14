using System.IO;
using System.Xml.Serialization;
using Avalonia;
using Avalonia.Media;
using BurdUI;
using BurdUI.Utils;
namespace AvaloniaApplication1.Views;

public partial class MainView : Avalonia.Controls.UserControl
{
    public MainView()
    {
        InitializeComponent();

        BurdUiApp.Root = RepaintTest1();
        BurdUiApp.Paint();
        
        
    }
    
    private View BuildTree()
    {
        // write the code building the view tree here...
        var container = new View();
        container.Bounds = new Rect(10, 10, 300, 300);
        var child1 = new View();
        child1.Bounds = new Rect(25, 10, 100, 50);
        
        var child2 = new View();
        child2.Bounds = new Rect(150, 10, 100, 50);
        
        container.Children.Add(child1);
        container.Children.Add(child2);
        return container;
    }
    
    private View BuildTree2()
    {
        // write the code building the view tree here...
        var container = new View();
        container.Bounds = new Rect(10, 10, 300, 300);
        var child1 = new BurdUI.Button("Hello World");
        child1.Bounds = new Rect(25, 10, 100, 50);
        child1.Border = new Border(Color.FromRgb(0,0,255), Color.FromRgb(255,255,255), 3, 5);
        
        
        var child2 = new Button("Click me!");
        child2.Bounds = new Rect(150, 10, 100, 50);
        child2.Border = new Border(Color.FromRgb(255,0,255), Color.FromRgb(255,255,255), 3, 5);
        
        container.Children.Add(child2);
        container.Children.Add(child1);
        return container;
    }

    private View BuildTree3()
    {
        // write the code building the view tree here...
        var container = new VerticalLayoutPanel();
        container.Origin = VerticalStackOrigin.Bottom;
        container.Spacing = 10;
        container.Bounds = new Rect(10, 10, 300, 300);
        var child1 = new Button("Hello World");
        child1.Bounds = new Rect(25, 10, 100, 50);
        child1.Border = new Border(Color.FromRgb(0,0,255), Color.FromRgb(255,255,255), 3, 5);
        
        
        var child2 = new Button("Click me!");
        child2.Bounds = new Rect(150, 10, 100, 50);
        child2.Border = new Border(Color.FromRgb(255,0,255), Color.FromRgb(255,255,255), 3, 5);
        
        container.Children.Add(child1);
        container.Children.Add(child2);
        
        var serializer = new XmlSerializer(typeof(VerticalLayoutPanel));
        
        using (var file = File.Create("ui.xml"))
        {
            serializer.Serialize(file, container);
        }

        return container;
    }

    Button button1, button2, button3;
    public View RepaintTest1()
    {
        var root = new View();
        root.App = BurdUiApp;
        root.Bounds = new Rect(10,0,1024,768);
        
        button1 = new Button("Button one");
        button1.Bounds = new Rect(100,100, 250, 75);
        button1.Border = new Border(Color.FromRgb(0,77,00), Color.FromRgb(99,255, 99), 3, 5);
        button1.Text?.Color = Color.FromRgb(0, 77, 00);
        root.AddChild(button1);

        button2 = new Button("Button two");
        button2.Bounds = new Rect(50,250, 250, 75);
        button2.Border = new Border(Color.FromRgb(0,0,00), Color.FromRgb(255,255, 255), 3, 5);
        button2.Text?.Color = Color.FromRgb(0, 0, 00);
        root.AddChild(button2);
        
        
        button3 = new Button("Button three");
        button3.Bounds = new Rect(300, 350, 250, 75);
        button3.Border = new Border(Color.FromRgb(0,0,77), Color.FromRgb(99,99, 255), 3, 5);
        button3.Text?.Color = Color.FromRgb(0, 0, 77);
        root.AddChild(button3);
        this.KeyDown += (s, e) =>
        {
            button1.Text.Value = "Repaint 1";
            button2.Text.Value = "Repaint 2";
            button3.Text.Value = "Repaint 3";
            button1.Border.BackgroudColor = Color.FromRgb(150,150,150);
            button2.Border.BackgroudColor = Color.FromRgb(150,150,150);
            button3.Border.BackgroudColor = Color.FromRgb(150,150,150);

            var repaint1 = new RepaintEvent()
            {
                Source =  button1, DamagedArea = new Rect(30, 20, 190, 35)
            };
        
            var repaint2 = new RepaintEvent()
            {
                Source =  button2, DamagedArea = new Rect(30, 20, 190, 35)
            };
        
        
            var repaint3 = new RepaintEvent()
            {
                Source =  button3, DamagedArea = new Rect(30, 20, 190, 35)
            };
        
            button1.Invalidate(repaint1);
            button2.Invalidate(repaint2);
            button3.Invalidate(repaint3);
            BurdUiApp.FlushQueue();
            BurdUiApp.InvalidateVisual();
        };
        
        
            
        

        return root;
    }
}