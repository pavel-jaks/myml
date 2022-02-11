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

    public int[] Shape => _shape;

    public IEnumerable<float> EnumerateAll()
    {
        foreach (var number in _array) yield return number;
    }
}