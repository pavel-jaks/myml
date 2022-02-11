using myml;

namespace myml.NN;

public interface ILayer
{
    float[] Parameters { get; }
    Tensor ApplyLayer(Tensor input);
}