using System;

namespace myml.Activations;

public class RectifiedLinear : IActivationFunction
{
    public float Apply(float input)
    {
        return Math.Max(input, 0.0f);
    }
}