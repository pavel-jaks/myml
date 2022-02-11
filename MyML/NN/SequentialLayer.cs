using myml.Aggregations;
using myml.Activations;

namespace myml.NN;

public class SequentialLayer : ILayer
{
    private readonly int _in_size;
    private readonly int _out_size;

    private Neuron[] _neurons;

    public SequentialLayer(
        int in_size,
        int out_size
    )
    {
        _in_size = in_size;
        _out_size = out_size;
        _neurons = new Neuron[out_size];
        for (var i = 0; i < _neurons.Length; i++)
        {
            _neurons[i] = Neuron.ReLU(in_size);
        }
    }

    public float[] Parameters 
    {
        get 
        { 
            var parameters = new List<float>();
            foreach (var neuron in _neurons) parameters.AddRange(neuron.Parameters);
            return parameters.ToArray();
        }
    }

    public Tensor ApplyLayer(Tensor input)
    {
        var floats = new float[_out_size];
        for (var i = 0; i < floats.Length; i++)
        {
            floats[i] = _neurons[i].apply(input);
        }
        return new Tensor(floats);
    }
}