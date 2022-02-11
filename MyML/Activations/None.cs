namespace myml.Activations;

public class None : IActivationFunction
{
    public float Apply(float input)
    {
        return input;
    }
}