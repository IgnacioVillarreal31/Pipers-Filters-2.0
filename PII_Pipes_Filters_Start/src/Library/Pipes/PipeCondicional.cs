using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;


namespace CompAndDel.Pipes
{
    public class PipeCondicional : IPipe
    {
        IPipe PipeTrue;
        IPipe PipeFalse;
        IFilterConditional Filtro;
        public PipeCondicional(IFilterConditional filtro, IPipe pipeTrue, IPipe pipeFalse) 
        {
            this.PipeTrue = pipeTrue;
            this.PipeFalse = pipeFalse;  
            this.Filtro = filtro;         
        }
        
        public IPicture Send(IPicture picture)
        {
            if (Filtro.Resultado())
            {
                return this.PipeTrue.Send(picture);
            }
            else
            {
                return this.PipeFalse.Send(picture);
            }
        }
    }
}