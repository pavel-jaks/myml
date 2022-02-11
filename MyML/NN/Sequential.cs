using System.Collections.Generic;
using System.Linq;


namespace myml.NN;

public class Sequential : INeuralNetwork
{
    private readonly int[] _neuron_counts;
    private readonly SequentialLayer[] _layers;

    public Sequential(int input_count, int[] neuron_counts)
    {
        _neuron_counts = neuron_counts;
        var layers = new List<SequentialLayer>();
        var counts = new List<int>();
        counts.Add(input_count);
        counts.AddRange(neuron_counts);
        for (var i = 1; i < counts.Count; i++)
        {
            layers.Add(new SequentialLayer(counts[i - 1], counts[i]));
        }
        _layers = layers.ToArray();
    }

    public IEnumerable<Tensor> ApplyBatch(IEnumerable<Tensor> examples)
    {
        return examples.Select(x => ApplyNetwork(x));
    }

    public Tensor ApplyNetwork(Tensor example)
    {
        var result = example;
        for (var i = 0; i < (_layers != null ? _layers.Length : 0); i++)
        {
            result = _layers != null ?_layers[i].ApplyLayer(result) : result;
        }
        return result;
    }
}