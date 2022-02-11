using System.Collections.Generic;
using myml;

namespace myml.NN;

public interface INeuralNetwork
{
    Tensor ApplyNetwork(Tensor example);
    IEnumerable<Tensor> ApplyBatch(IEnumerable<Tensor> examples);
}
