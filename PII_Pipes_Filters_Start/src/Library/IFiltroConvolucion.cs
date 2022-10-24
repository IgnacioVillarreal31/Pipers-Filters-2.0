using System;

namespace CompAndDel
{
    public interface IFiltroConvolucion : IFilter
    {
        int[,] kernel {get;set;}
        
    }
}