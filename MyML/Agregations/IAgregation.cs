namespace myml.Agregations;

public interface IAgregation<IN, OUT, PARAMETERS>
{
    OUT Agregate(ITensor<IN> tensor);
    PARAMETERS[] Parameters { get; }
}