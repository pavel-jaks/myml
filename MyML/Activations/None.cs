namespace myml.Activations;

public class None<T> : IActivationFunction<T, T>
{
    public T Apply(T input)
    {
        return input;
    }
}