using System;
using myml.Activations;
using myml.Aggregations;

namespace myml.NN;

public class Neuron
{
    private readonly IAggregation _agregation;
    private readonly IActivationFunction _activation;

    public Neuron(IAggregation aggregation, IActivationFunction activation)
    {
        _agregation = aggregation;
        _activation = activation;
    }

    public float apply(Tensor input)
    {
        return _activation.Apply(_agregation.Agregate(input));
    }

    public float[] Parameters => _agregation.Parameters;

    public static Neuron ReLU(int inSize)
    {
        var rand = new Random();
        var parameters = new float[inSize];
        for (int i = 0; i < parameters.Length; i++)
        {
            parameters[i] = rand.NextSingle();
        }
        return new Neuron(new WeighedSum(parameters), new RectifiedLinear());
    }

    public static Neuron ReLU(float[] weights)
    {
        return new Neuron(new WeighedSum(weights), new RectifiedLinear());
    }
}