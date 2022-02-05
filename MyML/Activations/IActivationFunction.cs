using myml;

namespace myml.Activations;

public interface IActivationFunction<IN, OUT>
{
    OUT Apply(IN input);
}