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
            provider.SavePicture(picture, @"luke0.jpg");
            
            // Parte 1
            IPipe pipeNull = new PipeNull();
            IFilter filterNegative = new FilterNegative();
            IPipe pipeSerial = new PipeSerial(filterNegative,pipeNull);
            IFilter filterGreyscale = new FilterGreyscale();
            IPipe pipeSerial2 = new PipeSerial(filterGreyscale,pipeSerial);

            picture = pipeSerial.Send(picture);
            provider.SavePicture(picture, @"luke1.jpg");
            picture = pipeSerial2.Send(picture);
            provider.SavePicture(picture, @"luke2.jpg");
            
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Nada que hacer", @"PathToImage.png"));
            
        }
    }
}
