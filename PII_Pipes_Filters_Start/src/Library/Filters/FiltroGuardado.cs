using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class FiltroGuardado : IFilter
    {
        public string Path{get;set;}
        public FiltroGuardado(string path)
        {
            this.Path = path;
        }
        public IPicture Filter(IPicture image)
        {
            PictureProvider p = new PictureProvider();
            p.SavePicture(image,this.Path);
            Console.WriteLine("guardando...");
            return image;
        }
    }
}

