using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    public class FiltroCondicional : IFilterConditional
    {
        public string Foto {get;set;}
        public FiltroCondicional(string foto)
        {
            this.Foto = foto;
        }
        public IPicture Filter(IPicture image)
        {
            return image;
        }
        public bool Resultado ()
        {
            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(this.Foto);
            if (cog.FaceFound)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}