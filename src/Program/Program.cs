using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"C:\Users\uru24\Prog2\Comp\src\Program\luke.jpg");
            PipeNull pipeNull = new PipeNull();
            FilterNegative negative = new FilterNegative();
            PipeSerial serial = new PipeSerial (negative, pipeNull);
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            PipeFork pipeFork = new PipeFork()

           
            FilterGreyscale greyscale = new FilterGreyscale();
            PipeSerial serialtwo = new PipeSerial(greyscale, serial);
            provider.SavePicture(serialtwo.Send(picture), @"C:\Users\uru24\OneDrive\Pictures\newLuke.jpg");

            // Paso previo al flitro intermedio
           // provider.SavePicture(serial.Send(picture), @"C:\Users\uru24\OneDrive\Pictures\newLuke2.jpg");

            //Publicar en Twitter
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Luke", @"C:\Users\uru24\OneDrive\Pictures\newLuke.jpg"));
            

        }
    }
}
