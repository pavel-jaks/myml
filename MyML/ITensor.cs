using System;
using System.Collections.Generic;

namespace myml;
public interface ITensor<T>
{
    int[] Shape { get; }
    IEnumerable<T> EnumerateAll();
}
