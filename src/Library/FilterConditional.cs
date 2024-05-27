using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    public class FilterConditional : IFilter
    {
        private readonly CognitiveFace CognitiveFace;

        private readonly FilterPersister FilterPersister;  

        public FilterConditional(string imagePath)
        {
            this.CognitiveFace = new CognitiveFace(false, null);
            this.FilterPersister = new FilterPersister(imagePath);
        }

        public IPicture Filter(IPicture image)
        {
            IPicture result = this.SavePicture(image);
            return result;
        }

        public bool HasFace()
        {
            this.CognitiveFace.Recognize(this.FilterPersister.ImagePath); 
            bool result = this.CognitiveFace.FaceFound;
            return result;
        }

        private IPicture SavePicture(IPicture image)
        {
            return this.FilterPersister.Filter(image);
        }
    }
}