using System;
using System.Drawing;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FiltroTwitter : IFilter
    {
        public string Text {get;set;}
        public string Foto {get;set;}
        public FiltroTwitter(string text,string foto)
        {
            this.Text = text;
            this.Foto = foto;
        }
        public IPicture Filter(IPicture image)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter(this.Text,this.Foto));
            return image;
        }
    }
}

