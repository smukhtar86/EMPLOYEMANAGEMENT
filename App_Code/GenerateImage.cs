using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
/// <summary>
/// Summary description for GenerateImage
/// </summary>
public class GenerateImage
{
    public GenerateImage()
    {
        //
        // TODO: Add constructor logic here
        //
    }
  
    public static void GenerateProfileImage(Stream sourcePath, string targetPath)
    {
        decimal imagewidth = 100, ImageHeight = 100;
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            if (image.Width > image.Height)
            {
                imagewidth = 640;
                ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 640;
            }
            else if (image.Height > image.Width)
            {
                //imagewidth = image.Width;
                // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
                ImageHeight = 640;
                imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 640;
                //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
            }



            var newWidth = (int)(imagewidth);
            var newHeight = (int)(ImageHeight);


            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);

            //resizeImage(image, image.Size);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }

    //private void GenerateThumbnails(Stream sourcePath, string targetPath)
    //{
    //    decimal imagewidth = 200, ImageHeight = 200;
    //    using (var image = System.Drawing.Image.FromStream(sourcePath))
    //    {
    //        if (image.Width > image.Height)
    //        {
    //            imagewidth = 200;
    //            ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 200;
    //        }
    //        else if (image.Height > image.Width)
    //        {
    //            //imagewidth = image.Width;
    //            // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
    //            ImageHeight = 200;
    //            imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 200;
    //            //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
    //        }



    //        var newWidth = (int)(imagewidth);
    //        var newHeight = (int)(ImageHeight);


    //        var thumbnailImg = new Bitmap(newWidth, newHeight);
    //        var thumbGraph = Graphics.FromImage(thumbnailImg);
    //        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
    //        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
    //        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
    //        thumbGraph.DrawImage(image, imageRectangle);

    //        //resizeImage(image, image.Size);
    //        thumbnailImg.Save(targetPath, image.RawFormat);
    //    }
    //}

    //private void GenerateSameImageWithOutCompress(Stream sourcePath, string targetPath)
    //{
    //    using (var image = System.Drawing.Image.FromStream(sourcePath))
    //    {
    //        decimal imagewidth = 750, ImageHeight = 540;

    //        if (image.Width > image.Height)
    //        {
    //            imagewidth = 750;
    //            ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 750;
    //        }
    //        else if (image.Height > image.Width)
    //        {
    //            //imagewidth = image.Width;
    //            // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
    //            ImageHeight = 540;
    //            imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 540;
    //            //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
    //        }

    //        int newWidth = (int)(imagewidth);
    //        int newHeight = (int)(ImageHeight);


    //        //var newWidth = (int)(image.Width);//* scaleFactor
    //        //var newHeight = (int)(image.Height);//* scaleFactor
    //        var thumbnailImg = new Bitmap(newWidth, newHeight);
    //        var thumbGraph = Graphics.FromImage(thumbnailImg);
    //        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
    //        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
    //        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
    //        thumbGraph.DrawImage(image, imageRectangle);
    //        thumbnailImg.Save(targetPath, image.RawFormat);
    //    }
    //}

    //private void GenerateSameImage(double scaleFactor, Stream sourcePath, string targetPath)
    //{
    //    using (var image = System.Drawing.Image.FromStream(sourcePath))
    //    {

    //        decimal imagewidth = 750, ImageHeight = 540;

    //        if (image.Width > image.Height)
    //        {
    //            imagewidth = 750;
    //            ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 750;
    //        }
    //        else if (image.Height > image.Width)
    //        {
    //            //imagewidth = image.Width;
    //            // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
    //            ImageHeight = 540;
    //            imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 540;
    //            //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
    //        }

    //        int sourceWidth = (int)(imagewidth);
    //        int sourceHeight = (int)(ImageHeight);

    //        //float nPercent = 0;
    //        //float nPercentW = 0;
    //        //float nPercentH = 0;
    //        //System.Drawing.Size size = image.Size;
    //        //nPercentW = ((float)size.Width / (float)sourceWidth);
    //        //nPercentH = ((float)size.Height / (float)sourceHeight);

    //        //if (nPercentH < nPercentW)
    //        // nPercent = nPercentH;
    //        //else
    //        // nPercent = nPercentW;

    //        //int destWidth = (int)(sourceWidth * nPercent * scaleFactor);
    //        //int destHeight = (int)(sourceHeight * nPercent * scaleFactor);

    //        int destWidth = sourceWidth;
    //        int destHeight = sourceHeight;

    //        //var newWidth = (int)(image.Width * scaleFactor);
    //        //var newHeight = (int)(image.Height * scaleFactor);

    //        var thumbnailImg = new Bitmap(destWidth, destHeight);
    //        var thumbGraph = Graphics.FromImage(thumbnailImg);
    //        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
    //        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
    //        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        var imageRectangle = new Rectangle(0, 0, destWidth, destHeight);
    //        thumbGraph.DrawImage(image, imageRectangle);
    //        thumbnailImg.Save(targetPath, image.RawFormat);
    //    }
    //}

    //private void GenerateSmallImage(Stream sourcePath, string targetPath)
    //{
    //    decimal imagewidth = 35, ImageHeight = 36;
    //    using (var image = System.Drawing.Image.FromStream(sourcePath))
    //    {

    //        if (image.Width > image.Height)
    //        {
    //            imagewidth = 35;
    //            ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 35;
    //        }
    //        else if (image.Height > image.Width)
    //        {
    //            //imagewidth = image.Width;
    //            // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
    //            ImageHeight = 36;
    //            imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 36;
    //            //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
    //        }

    //        var newWidth = (int)(imagewidth);
    //        var newHeight = (int)(ImageHeight);





    //        var thumbnailImg = new Bitmap(newWidth, newHeight);
    //        var thumbGraph = Graphics.FromImage(thumbnailImg);
    //        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
    //        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
    //        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
    //        thumbGraph.DrawImage(image, imageRectangle);
    //        thumbnailImg.Save(targetPath, image.RawFormat);
    //    }
    //}
    //private void GenerateStuffImages(Stream sourcePath, string targetPath)
    //{
    //    decimal imagewidth = 450, ImageHeight = 450;
    //    using (var image = System.Drawing.Image.FromStream(sourcePath))
    //    {
    //        if (image.Width > image.Height)
    //        {
    //            imagewidth = 450;
    //            ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 450;
    //        }
    //        else if (image.Height > image.Width)
    //        {
    //            //imagewidth = image.Width;
    //            // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
    //            ImageHeight = 450;
    //            imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 450;
    //            //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
    //        }



    //        var newWidth = (int)(imagewidth);
    //        var newHeight = (int)(ImageHeight);


    //        var thumbnailImg = new Bitmap(newWidth, newHeight);
    //        var thumbGraph = Graphics.FromImage(thumbnailImg);
    //        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
    //        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
    //        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
    //        thumbGraph.DrawImage(image, imageRectangle);

    //        //resizeImage(image, image.Size);
    //        thumbnailImg.Save(targetPath, image.RawFormat);
    //    }
    //}
    ////////////////////////////////


    public static void Generate_320X240(Stream sourcePath, string targetPath)
    {
        decimal imagewidth = 320, ImageHeight = 240;
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            //if (image.Width > image.Height)
            //{
            //    imagewidth = 320;
            //    ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 240;
            //}
            //else if (image.Height > image.Width)
            //{
            //    //imagewidth = image.Width;
            //    // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
            //    ImageHeight = 240;
            //    imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 320;
            //    //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
            //}
            //else if (image.Height == image.Width)
            //{
                ImageHeight = 240;
                imagewidth = 320;
            //}


            var newWidth = (int)(imagewidth);
            var newHeight = (int)(ImageHeight);


            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);

            //resizeImage(image, image.Size);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }



    public static void Generate_70X70(Stream sourcePath, string targetPath)
    {
        decimal imagewidth = 70, ImageHeight = 70;
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            if (image.Width > image.Height)
            {
                imagewidth = 70;
                ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 70;
            }
            else if (image.Height > image.Width)
            {
                //imagewidth = image.Width;
                // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
                ImageHeight = 70;
                imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 70;
                //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
            }
            else if (image.Height == image.Width)
            {
                ImageHeight = 70;
                imagewidth = 70;
            }


            var newWidth = (int)(imagewidth);
            var newHeight = (int)(ImageHeight);


            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);

            //resizeImage(image, image.Size);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }


    public static void Generate_160X160(Stream sourcePath, string targetPath)
    {
        decimal imagewidth = 160, ImageHeight = 160;
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            if (image.Width > image.Height)
            {
                imagewidth = 160;
                ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 160;
            }
            else if (image.Height > image.Width)
            {
                //imagewidth = image.Width;
                // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
                ImageHeight = 160;
                imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 160;
                //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
            }
            else if (image.Height == image.Width)
            {
                ImageHeight = 160;
                imagewidth = 160;
            }


            var newWidth = (int)(imagewidth);
            var newHeight = (int)(ImageHeight);


            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);

            //resizeImage(image, image.Size);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }


    public static void Generate_230X230(Stream sourcePath, string targetPath)
    {
        decimal imagewidth = 230, ImageHeight = 230;
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            if (image.Width > image.Height)
            {
                imagewidth = 230;
                ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 230;
            }
            else if (image.Height > image.Width)
            {
                //imagewidth = image.Width;
                // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
                ImageHeight = 230;
                imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 230;
                //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
            }
            else if (image.Height == image.Width)
            {
                ImageHeight = 230;
                imagewidth = 230;
            }


            var newWidth = (int)(imagewidth);
            var newHeight = (int)(ImageHeight);


            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);

            //resizeImage(image, image.Size);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }

    public static void Generate_350X230(Stream sourcePath, string targetPath)
    {
        decimal imagewidth = 350, ImageHeight = 230;
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            if (image.Width > image.Height)
            {
                imagewidth = 350;
                ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 230;
            }
            else if (image.Height > image.Width)
            {
                //imagewidth = image.Width;
                // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
                ImageHeight = 230;
                imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 350;
                //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
            }
            else if (image.Height == image.Width)
            {
                ImageHeight = 230;
                imagewidth = 350;
            }


            var newWidth = (int)(imagewidth);
            var newHeight = (int)(ImageHeight);


            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);

            //resizeImage(image, image.Size);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }

    public static void GenerateWithOutCompress_540X750(Stream sourcePath, string targetPath)
    {
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            decimal imagewidth = 750, ImageHeight = 500;

            if (image.Width > image.Height)
            {
                imagewidth = 750;
                ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 750;
            }
            else if (image.Height > image.Width)
            {
                //imagewidth = image.Width;
                // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
                ImageHeight = 500;
                imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 500;
                //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
            }
            else if (image.Height == image.Width)
            {
                ImageHeight = 750;
                imagewidth = 750;
            }
            int newWidth = (int)(imagewidth);
            int newHeight = (int)(ImageHeight);


            //var newWidth = (int)(image.Width);//* scaleFactor
            //var newHeight = (int)(image.Height);//* scaleFactor
            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }



    public static void Generate_SameImage(double scaleFactor, Stream sourcePath, string targetPath)
    {
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {

            //decimal imagewidth = 750, ImageHeight = 500;

            //if (image.Width > image.Height)
            //{
            //    imagewidth = 750;
            //    ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 750;
            //}
            //else if (image.Height > image.Width)
            //{
            //    //imagewidth = image.Width;
            //    // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
            //    ImageHeight = 500;
            //    imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 500;
            //    //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
            //}

            int sourceWidth = (int)(image.Width);
            int sourceHeight = (int)(image.Height);

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            System.Drawing.Size size = image.Size;
            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent * scaleFactor);
            int destHeight = (int)(sourceHeight * nPercent * scaleFactor);

            //int destWidth = sourceWidth;
            //int destHeight = sourceHeight;

            //var newWidth = (int)(image.Width * scaleFactor);
            //var newHeight = (int)(image.Height * scaleFactor);

            var thumbnailImg = new Bitmap(destWidth, destHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, destWidth, destHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }

    public static void Generate_540X750(double scaleFactor, Stream sourcePath, string targetPath)
    {
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {

            decimal imagewidth = 750, ImageHeight = 500;

            if (image.Width > image.Height)
            {
                imagewidth = 750;
                ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 750;
            }
            else if (image.Height > image.Width)
            {
                //imagewidth = image.Width;
                // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
                ImageHeight = 500;
                imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 500;
                //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
            }
            else if (image.Height == image.Width)
            {
                ImageHeight = 750;
                imagewidth = 750;
            }
            int sourceWidth = (int)(imagewidth);
            int sourceHeight = (int)(ImageHeight);

            //float nPercent = 0;
            //float nPercentW = 0;
            //float nPercentH = 0;
            //System.Drawing.Size size = image.Size;
            //nPercentW = ((float)size.Width / (float)sourceWidth);
            //nPercentH = ((float)size.Height / (float)sourceHeight);

            //if (nPercentH < nPercentW)
            //    nPercent = nPercentH;
            //else
            //    nPercent = nPercentW;

            //int destWidth = (int)(sourceWidth * nPercent * scaleFactor);
            //int destHeight = (int)(sourceHeight * nPercent * scaleFactor);

            int destWidth = sourceWidth;
            int destHeight = sourceHeight;

            //var newWidth = (int)(image.Width * scaleFactor);
            //var newHeight = (int)(image.Height * scaleFactor);

            var thumbnailImg = new Bitmap(destWidth, destHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, destWidth, destHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }

    public static void Generate_35X35(Stream sourcePath, string targetPath)
    {
        decimal imagewidth = 35, ImageHeight = 36;
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {

            if (image.Width > image.Height)
            {
                imagewidth = 35;
                ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 35;
            }
            else if (image.Height > image.Width)
            {
                //imagewidth = image.Width;
                // ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
                ImageHeight = 36;
                imagewidth = Convert.ToDecimal(image.Width) / Convert.ToDecimal(image.Height) * 36;
                //ImageHeight = Convert.ToDecimal(image.Height) / Convert.ToDecimal(image.Width) * 900;
            }
            else if (image.Height == image.Width)
            {
                ImageHeight = 35;
                imagewidth = 35;
            }
            var newWidth = (int)(imagewidth);
            var newHeight = (int)(ImageHeight);





            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }
}