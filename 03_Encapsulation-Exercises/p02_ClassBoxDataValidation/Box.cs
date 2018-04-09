using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private const string MESSAGE = " cannot be zero or negative.";

    private double length;
    private double width;
    private double height;

    public double Length
    {
        get { return this.length; }
        private set
        {
            ValidateSide(value, "Length");
            this.length = value;
        }
    }

    public double Width
    {
        get { return this.width; }
        private set
        {
            ValidateSide(value, "Width");
            this.width = value;
        }
    }

    public double Height
    {
        get { return this.height; }
        private set
        {
            ValidateSide(value, "Height");
            this.height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double GetSurfaceArea()
    {
        double surfaceArea = 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        return surfaceArea;
    }

    public double GetLateralSurfaceArea()
    {
        double lateralSurfaceArea = 2 * Length * Height + 2 * Width * Height;
        return lateralSurfaceArea;
    }

    public double GetVolume()
    {
        double volume = Length * Width * Height;
        return volume;
    }

    private static void ValidateSide(double value, string side)
    {
        if (value <= 0)
        {
            throw new ArgumentException(side + MESSAGE);
        }
    }
}