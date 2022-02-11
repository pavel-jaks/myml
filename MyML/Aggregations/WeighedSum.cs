using System;

namespace myml.Aggregations;

public class WeighedSum : IAggregation
{
    private readonly float[] _weights;
    private readonly int _length;

    public WeighedSum(float[] weights)
    {
        _weights = weights;
        _length = weights.Length;
    }

    public float Agregate(Tensor tensor)
    {
        var shape = tensor.Shape;
        var res = 1;
        foreach (var i in shape) res *= i;
        if (res != _length) throw new ArgumentException("Given tensor of bad shape");
        var index = 0;
        double sum = 0;
        foreach (var number in tensor.EnumerateAll())
        {
            sum += _weights[index] * number;
            index++;
        }
        return (float)sum;
    }

    public float[] Parameters => _weights;
}