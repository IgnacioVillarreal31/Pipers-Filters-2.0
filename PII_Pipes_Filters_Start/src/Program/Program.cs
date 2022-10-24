using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using TwitterUCU;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            IFilterConditional filtroCondicional = new FiltroCondicional (@"luke.jpg");
            IPipe pipeNull = new PipeNull();

            IFilter filtroTwitter = new FiltroTwitter ("Nada que hacer",@"luke1.jpg");
            IPipe pipeSerial1 = new PipeSerial(filtroTwitter,pipeNull);

            IFilter filtroGuardado3 = new FiltroGuardado (@"luke2.jpg");
            IPipe pipeSerial5 = new PipeSerial(filtroGuardado3,pipeNull);
            IFilter filtroNegativo = new FilterNegative ();
            IPipe pipeSerial2 = new PipeSerial(filtroNegativo,pipeSerial5);

            IPipe pipeCondicional = new PipeCondicional (filtroCondicional,pipeSerial1,pipeSerial2);

            IFilter filtroGuardado2 = new FiltroGuardado (@"luke1.jpg");
            IPipe pipeSerial3 = new PipeSerial(filtroGuardado2,pipeCondicional);

            IFilter filterGreyscale = new FilterGreyscale();
            IPipe pipeSerial4 = new PipeSerial(filterGreyscale,pipeSerial3);

            pipeSerial4.Send(picture);
        }
    }
}
