using CompAndDel.Filters;

namespace CompAndDel.Pipes
{
    public class PipeConditionalFork : IPipe
    {
        IPipe truePipe;

        
        IPipe falsePipe;
        
        FilterConditional chooserPipe;
        
        public PipeConditionalFork(IPipe truePipe, IPipe falsePipe, string imagePath) 
        {
            this.falsePipe = falsePipe;
            this.truePipe = truePipe;  
            this.chooserPipe = new FilterConditional(imagePath);         
        }

        public IPicture Send(IPicture picture)
        {
            this.chooserPipe.Filter(picture);
            if (this.Choose())
            {
                return this.truePipe.Send(picture);
            }
            return this.falsePipe.Send(picture);
        }

        private bool Choose()
        {
            return this.chooserPipe.HasFace();
        }
    }
}