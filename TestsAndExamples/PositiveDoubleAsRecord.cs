using System;

namespace TestsAndExamples;

public record PositiveDoubleAsRecord
{
    public double Value { get; }

    public PositiveDoubleAsRecord(double value)
    {
        if (value <= 0.0) throw new Exception($"Passed non-positive value {value} when creating PositiveDouble");
        Value = value;
    }
}

public class PositiveDoubleAsClass
{
    public double Value { get; }

    public PositiveDoubleAsClass(double value)
    {
        if (value <= 0.0) throw new Exception($"Passed non-positive value {value} when creating PositiveDouble");
        Value = value;
    }
}