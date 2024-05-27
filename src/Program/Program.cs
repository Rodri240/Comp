using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Descomentar por partes.
            //Parte1();
            //Parte2();
            //Parte3();
            //Parte4();

        }
        public static void Parte1()
        {
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerial1 = new PipeSerial(new FilterNegative(), pipeNull);
            PipeSerial pipeSerial2 = new PipeSerial(new FilterGreyscale(), pipeSerial1);
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");
            IPicture modifiedImage = pipeSerial2.Send(picture);
            provider.SavePicture(modifiedImage, @"modifiedBeer1.jpg");
        }

        public static void Parte2()
        {
        
            PictureProvider provider = new PictureProvider();
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerialE = new(new FilterPersister(@"luke-final2.jpg"), pipeNull);
            PipeSerial pipeSerialD = new(new FilterNegative(), pipeSerialE);
            PipeSerial pipeSerialC = new(new FilterPersister(@"luke-intermediate2.jpg"), pipeSerialD);
            PipeSerial pipeSerialB = new(new FilterGreyscale(), pipeSerialC);
            PipeSerial pipeSerialA = new(new FilterPersister(@"luke-initial2.jpg"), pipeSerialB);
            IPicture picture = provider.GetPicture(@"luke.jpg");
            pipeSerialA.Send(picture);
        }
        public static void Parte3()
        {
            PictureProvider provider = new PictureProvider();

            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeSerialE = new(new FilterTwitter("Birra3", @"beer-final3.jpg"), pipeNull);
            PipeSerial pipeSerialD = new(new FilterNegative(), pipeSerialE);
            PipeSerial pipeSerialC = new(new FilterTwitter("Birra2", @"beer-intermediate3.jpg"), pipeSerialD);
            PipeSerial pipeSerialB = new(new FilterGreyscale(), pipeSerialC);
            PipeSerial pipeSerialA = new(new FilterTwitter("Birra1", @"beer-initial3.jpg"), pipeSerialB);

            IPicture picture = provider.GetPicture(@"beer.jpg");
            pipeSerialA.Send(picture);
        }

        public static void Parte4()
        {
            
            PipeNull pipeNullFalse = new PipeNull();
            PipeSerial pipeSerialFalse = new PipeSerial(new FilterNegative(), pipeNullFalse);
            PipeNull pipeNullTrue = new PipeNull();
            PipeSerial pipeSerialTrue = new PipeSerial(new FilterTwitter("Hola Luke", @"HasFaceImage4.jpg"), pipeNullTrue);
            PipeConditionalFork pipeConditionalFork = new PipeConditionalFork(pipeSerialTrue, pipeSerialFalse, @"modifiedImage4.jpg");
            PipeSerial pipeSerialCommon = new PipeSerial(new FilterGreyscale(), pipeConditionalFork);
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            IPicture modifiedPicture = pipeSerialCommon.Send(picture);
            provider.SavePicture(modifiedPicture, @"finalLuke4.jpg");
            picture = provider.GetPicture(@"beer.jpg");
            modifiedPicture = pipeSerialCommon.Send(picture);
            provider.SavePicture(modifiedPicture, @"finalBeer4.jpg");
    }
}
}
