namespace CompAndDel.Filters
{
    public class FilterNull : IFilter
    {
        public readonly string ImagePath;

        private readonly PictureProvider PictureSaver;

        public FilterNull(string imagePath)
        {
            this.PictureSaver = new PictureProvider();
            this.ImagePath = imagePath;
        }

        public IPicture Filter(IPicture image)
        {
            IPicture result = image;
            this.SavePicture(image);
            return result;
        }

        private void SavePicture(IPicture image)
        {
            this.PictureSaver.SavePicture(image, this.ImagePath);
        }
    }
}