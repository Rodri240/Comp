using System;
using Ucu.Poo.Twitter;

namespace CompAndDel.Filters
{
 
    public class FilterTwitter : IFilter
    {
      
        private readonly string Text;
        
     
        private readonly FilterNull FilterNull;

        private readonly TwitterImage TwitterImage;

        public FilterTwitter(string textToPublish, string imagePath)
        {
            this.TwitterImage = new TwitterImage();
            this.Text = textToPublish;
            this.FilterNull = new FilterNull(imagePath);
        }

        public IPicture Filter(IPicture image)
        {
            IPicture result = this.SavePicture(image);
            this.PublishPicture();
            return result;
        }

     
        private void PublishPicture()
        {
            Console.WriteLine(this.TwitterImage.PublishToTwitter(this.Text, this.FilterNull.ImagePath));
        }

        private IPicture SavePicture(IPicture image)
        {
            return this.FilterNull.Filter(image);
        }
    }
}