using System;

namespace myml.Agregations;

public class WeighedSum<T> : IAgregation<T, float, float>
{
    private readonly float[] _weights;
    private readonly int _length;

    public WeighedSum(float[] weights)
    {
        _weights = weights;
        _length = weights.Length;
    }

    public float Agregate(ITensor<T> tensor)
    {
        var shape = tensor.Shape;
        var res = 1;
        foreach (var i in shape) res *= i;
        if (res != _length) throw new ArgumentException("Given tensor of bad shape");
        var index = 0;
        double sum = 0;
        foreach (var maybenumber in tensor.EnumerateAll())
        {
            if (maybenumber is double number) 
                sum += _weights[index] * number;
            else throw new ArgumentException("Given tensor of bad type");
            index++;
        }
        return (float)sum;
    }

    public float[] Parameters => _weights;
}