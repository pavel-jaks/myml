using System.Collections.Generic;
using myml;

namespace myml.NN;

public interface INeuralNetwork<IN, OUT>
{
    ITensor<OUT> ApplyNetwork(ITensor<IN> example);
    IEnumerable<ITensor<OUT>> ApplyBatch(IEnumerable<ITensor<IN>> examples);
}
