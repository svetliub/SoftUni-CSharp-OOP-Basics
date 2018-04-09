using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double horizontal;
    private double vertical;

    public Rectangle(string id, double width, double height, double horizontal, double vertical)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.Horizontal = horizontal;
        this.Vertical = vertical;
    }

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    public double Horizontal
    {
        get { return this.horizontal; }
        set { this.horizontal = value; }
    }

    public double Vertical
    {
        get { return this.vertical; }
        set { this.vertical = value; }
    }

    public string AreRectanglesIntersected(Rectangle secondRectangle)
    {
        if (this.ContainsRectangleCorner(secondRectangle) || secondRectangle.ContainsRectangleCorner(this))
        {
            return "true";
        }

        return "false";
    }

    private bool ContainsRectangleCorner(Rectangle secondRectangle)
    {
        return this.ContainsPoint(secondRectangle.Horizontal, secondRectangle.Vertical) ||
               this.ContainsPoint(secondRectangle.Horizontal, secondRectangle.Vertical + height) ||
               this.ContainsPoint(secondRectangle.Horizontal + width, secondRectangle.Vertical) ||
               this.ContainsPoint(secondRectangle.Horizontal + width, secondRectangle.Vertical + height);
    }

    private bool ContainsPoint(double secondHorizontal, double secondVertical)
    {
        return secondHorizontal >= this.Horizontal && secondHorizontal <= this.Horizontal + width &&
               secondVertical >= this.Vertical && secondVertical <= this.Vertical + height;
    }
}

