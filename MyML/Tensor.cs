namespace myml;

public class Tensor
{
    private readonly float[] _array;
    private int[] _shape;

    public Tensor(float[] floats)
    {
        _array = floats;
        _shape = new int[] {floats.Length};
    }

    public void Reshape(int[] shape)
    {
        var dim = 1;
        foreach (var i in shape) dim *= i;
        var curr_dim = 1;
        foreach (var i in _shape) curr_dim *= i;
        if (curr_dim != dim) throw new ArgumentException("Dimension mismatch");
        _shape = shape;
    }

    public int[] Shape => _shape;

    public IEnumerable<float> EnumerateAll()
    {
        foreach (var number in _array) yield return number;
    }

    public float this[int[] indeces]
    {
        get
        {
            var index = 0;
            for (var i = 0; i < _shape.Length; i++)
            {
                index = indeces[i] * _shape[i];
            }
            return _array[index];
        }
        set
        {
            var index = 0;
            for (var i = 0; i < _shape.Length; i++)
            {
                index = indeces[i] * _shape[i];
            }
            _array[index] = value;
        }
    }

    public static Tensor Zeros(int[] shape)
    {
        var dim = 1;
        foreach (var i in shape) dim *= i;
        var array = new float[dim];
        for (var i = 0; i < dim; i++) array[i] = 0;
        var tensor = new Tensor(array);
        tensor.Reshape(shape);
        return tensor;
    }
}