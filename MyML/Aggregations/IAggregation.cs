namespace myml.Aggregations;

public interface IAggregation
{
    float Agregate(Tensor tensor);
    float[] Parameters { get; }
}