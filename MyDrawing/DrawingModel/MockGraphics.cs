using MyDrawing;
using System.Collections.Generic;
using System.Linq;

public class MockGraphics : IGraphics
{
    public List<string> Calls { get; private set; } = new List<string>();

    public void DrawCircle(int x, int y, int width, int height)
    {
        Calls.Add($"DrawCircle({x}, {y}, {width}, {height})");
    }

    public void DrawRectangle(int x, int y, int width, int height)
    {
        Calls.Add($"DrawRectangle({x}, {y}, {width}, {height})");
    }

    public void DrawText(int x, int y, string text)
    {
        Calls.Add($"DrawText({x}, {y}, \"{text}\")");
    }

    public void DrawEllipse(int x, int y, int width, int height)
    {
        Calls.Add($"DrawEllipse({x}, {y}, {width}, {height})");
    }

    public void DrawDiamond(int x, int y, int width, int height)
    {
        Calls.Add($"DrawDiamond({x}, {y}, {width}, {height})");
    }

    public void DrawShapeBoundingBox(int x, int y, int width, int height)
    {
        Calls.Add($"DrawShapeBoundingBox({x}, {y}, {width}, {height})");
    }

    public void DrawTextBoundingBox(int x, int y, string text)
    {
        Calls.Add($"DrawTextBoundingBox({x}, {y}, \"{text}\")");
    }
    public void DrawConnectionPoint(int x, int y, int size)
    {
        Calls.Add($"DrawConnectionPoint({x}, {y}, {size})");
    }
    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        Calls.Add($"DrawLine({x1}, {y1}, {x2}, {y2})");
    }
    public void ClearAll()
    {
        Calls.Add("ClearAll()");
    }
}
