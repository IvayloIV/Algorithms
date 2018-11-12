using System;

public class Area : IComparable<Area>
{
    public int Row { get; private set; }

    public int Col { get; private set; }

    public int Size { get; private set; }


    public Area(int row, int col, int size)
    {
        this.Row = row;
        this.Col = col;
        this.Size = size;
    }

    public int CompareTo(Area other)
    {
        var cmp = other.Size.CompareTo(this.Size);

        if (cmp == 0)
        {
            cmp = this.Row.CompareTo(other.Row);
        }

        if (cmp == 0)
        {
            cmp = this.Col.CompareTo(other.Col);
        }

        return cmp;
    }

    public string ToString(int number)
    {
        return $"Area #{number} at ({this.Row}, {this.Col}), size: {this.Size}";
    }
}