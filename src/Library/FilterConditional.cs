using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    public class FilterConditional : IFilter
    {
        private readonly CognitiveFace CognitiveFace;

        private readonly FilterNull FilterNull;  

        public FilterConditional(string imagePath)
        {
            this.CognitiveFace = new CognitiveFace(false, null);
            this.FilterNull = new FilterNull(imagePath);
        }

        public IPicture Filter(IPicture image)
        {
            IPicture result = this.SavePicture(image);
            return result;
        }

        public bool HasFace()
        {
            this.CognitiveFace.Recognize(this.FilterNull.ImagePath); 
            bool result = this.CognitiveFace.FaceFound;
            return result;
        }

        private IPicture SavePicture(IPicture image)
        {
            return this.FilterNull.Filter(image);
        }
    }
}