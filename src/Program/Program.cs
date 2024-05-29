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
            Parte1();
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
            IPicture picture = provider.GetPicture(@"D:\ProgramasC#\Comp\src\Program\beer.jpg");
            IPicture modifiedImage = pipeSerial2.Send(picture);
            provider.SavePicture(modifiedImage, @"D:\ProgramasC#\Comp\src\Program\modifiedBeer1.jpg");
        }

        public static void Parte2()
        {
        
            PictureProvider provider = new PictureProvider();
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerial5 = new(new FilterNull(@"luke-final2.jpg"), pipeNull);
            PipeSerial pipeSerial4 = new(new FilterNegative(), pipeSerial5);
            PipeSerial pipeSerial3 = new(new FilterNull(@"luke-intermediate2.jpg"), pipeSerial4);
            PipeSerial pipeSerial2 = new(new FilterGreyscale(), pipeSerial3);
            PipeSerial pipeSerial1 = new(new FilterNull(@"luke-initial2.jpg"), pipeSerial2);
            IPicture picture = provider.GetPicture(@"luke.jpg");
            pipeSerial1.Send(picture);
        }
        public static void Parte3()
        {
            PictureProvider provider = new PictureProvider();

            PipeNull pipeNull = new PipeNull();

            PipeSerial pipeSerial5 = new(new FilterTwitter("Birra3", @"beer-final3.jpg"), pipeNull);
            PipeSerial pipeSerial4 = new(new FilterNegative(), pipeSerial5);
            PipeSerial pipeSerial3 = new(new FilterTwitter("Birra2", @"beer-intermediate3.jpg"), pipeSerial4);
            PipeSerial pipeSerial2 = new(new FilterGreyscale(), pipeSerial3);
            PipeSerial pipeSerial1 = new(new FilterTwitter("Birra1", @"beer-initial3.jpg"), pipeSerial2);

            IPicture picture = provider.GetPicture(@"beer.jpg");
            pipeSerial1.Send(picture);
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
