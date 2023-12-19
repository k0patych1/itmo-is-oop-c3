using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record Dimensions
{
    public Dimensions(int height, int depth, int width)
    {
        if (height < 0) throw new NegativeArgumentException(nameof(height));
        if (depth < 0) throw new NegativeArgumentException(nameof(depth));
        if (width < 0) throw new NegativeArgumentException(nameof(width));

        Height = height;
        Depth = depth;
        Width = width;
    }

    public int Height { get; }
    public int Depth { get; }
    public int Width { get; }
}