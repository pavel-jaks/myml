namespace myml.NN;

public class SoftMaxLayer : ILayer
{
    private readonly int _dimension;

    public SoftMaxLayer(int dimension)
    {
        _dimension = dimension;
    }

    public float[] Parameters => new float[] {};

    public Tensor ApplyLayer(Tensor input)
    {
        var shape = input.Shape;
        var my_dim = shape[_dimension];
        var tensor = Tensor.Zeros(shape);
        // TODO:
        return tensor;
    }
}