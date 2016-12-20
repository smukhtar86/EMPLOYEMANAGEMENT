using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;
namespace BaseDataAccess
{
    public class General
    {
        public static DateTime ConvertddMMToMMdd(string theDDMMdate)
        {

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            DateTime aDtDdMm = Convert.ToDateTime(theDDMMdate);

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            aDtDdMm = Convert.ToDateTime(aDtDdMm);


            return (aDtDdMm);
        }


        public string SetSession(System.Web.UI.Page thePage)
        {
            string sts = "";
            if (thePage.Session["ID"] == null)
            {
                HttpCookie pwdCookie = new HttpCookie("pwdCookie");
                pwdCookie = thePage.Request.Cookies["pwdCookie"];
                if (pwdCookie != null)
                {
                    thePage.Session["CODE"] = pwdCookie.Values["CODE"].ToString();//  ds.Tables[0].Rows[0]["CODE"].ToString();
                    thePage.Session["ID"] = pwdCookie.Values["ID"].ToString();
                    thePage.Session["TYP"] = pwdCookie.Values["TYP"].ToString();
                    thePage.Session["NAME"] = pwdCookie.Values["NAME"].ToString();
                    thePage.Session["IMG"] = pwdCookie.Values["IMG"].ToString();
                    sts = "Logout";
                }
                else
                {
                    sts = "Login";
                }
            }
            return sts;
        }

        public static int ConvertToInt(object theInt)
        {
            try
            {
                if (Convert.ToString(theInt).Trim() == "")
                {
                    return 0;
                }
                else
                    return Convert.ToInt32(theInt);
            }
            catch { return 0; }
        }
        public static decimal ConvertToDec(object theDec)
        {
            try
            {
                if (Convert.ToString(Math.Round(Convert.ToDecimal(theDec), 3)).Trim() == "")
                {
                    return 0;
                }
                else
                    return Math.Round(Convert.ToDecimal(theDec), 3);
            }
            catch { return 0; }
        }
    }
    public class AspectRatio
    {
        public AspectRatio()
        {
        }
        private int d_Width = 0;
        private int d_Height = 0;
        public int Width
        {
            get { return d_Width; }
            set { d_Width = value; }
        }
        public int Height
        {
            get { return d_Height; }
            set { d_Height = value; }
        }
        /// <summary>
        /// Methord For Calculate Hight and Width
        /// </summary>
        /// <param name="aWidth"></param>
        /// <param name="aHeight"></param>
        /// <param name="dWidth"></param>
        /// <param name="dHeight"></param>
        public void WidthAndHeight(int aWidth, int aHeight, int dWidth, int dHeight)
        {
            double height = aHeight;
            double width = aWidth;
            double rWidht = Convert.ToDouble(dWidth);
            double rHeight = Convert.ToDouble(dHeight);
            int fWidth = 0;
            int fHeight = 0;
            double hRatio = 0.0;
            double vRatio = 0.0;
            if (width > rWidht)
            {
                hRatio = (rWidht / width);
                vRatio = (rHeight / height);

                if (vRatio > hRatio)
                {
                    fWidth = Convert.ToInt32((double)width * hRatio);
                    fHeight = Convert.ToInt32((double)height * hRatio);
                }
                else
                {
                    fWidth = Convert.ToInt32((double)width * vRatio);
                    fHeight = Convert.ToInt32((double)height * vRatio);
                }

            }
            else if (rWidht > width)
            {
                hRatio = (rWidht / width);
                vRatio = (rHeight / height);

                if (vRatio > hRatio)
                {
                    fWidth = Convert.ToInt32((double)width * hRatio);
                    fHeight = Convert.ToInt32((double)height * hRatio);
                }
                else
                {
                    fWidth = Convert.ToInt32((double)width * vRatio);
                    fHeight = Convert.ToInt32((double)height * vRatio);
                }
            }
            else if (height > rHeight)
            {
                hRatio = (rWidht / width);
                vRatio = (rHeight / height);

                if (vRatio > hRatio)
                {
                    fWidth = Convert.ToInt32((double)width * hRatio);
                    fHeight = Convert.ToInt32((double)height * hRatio);
                }
                else
                {
                    fWidth = Convert.ToInt32((double)width * vRatio);
                    fHeight = Convert.ToInt32((double)height * vRatio);
                }
            }
            else if (rHeight > height)
            {
                hRatio = (rWidht / width);
                vRatio = (rHeight / height);

                if (vRatio > hRatio)
                {
                    fWidth = Convert.ToInt32((double)width * hRatio);
                    fHeight = Convert.ToInt32((double)height * hRatio);
                }
                else
                {
                    fWidth = Convert.ToInt32((double)width * vRatio);
                    fHeight = Convert.ToInt32((double)height * vRatio);
                }
            }
            //Test
            if (aWidth == dWidth && aHeight == dHeight)
            {
                fWidth = aWidth;
                fHeight = aHeight;
            }
            d_Width = fWidth;
            d_Height = fHeight;
        }
    }

    public class ImageHandler
    {
        public bool havException { get; set; }
        public string ExceptionMessage { get; set; }
        public ImageHandler()
        {
            havException = false;
            ExceptionMessage = string.Empty;
        }
        public System.Drawing.Image AddWatermarkText(byte[] imageByte, string textOnImage)
        {
            System.Drawing.Image img = null;
            try
            {
                MemoryStream memStream = new MemoryStream(imageByte);
                img = System.Drawing.Image.FromStream(memStream);
                Graphics g = System.Drawing.Graphics.FromImage(img);
                Font font = new Font("Aril", 20, FontStyle.Bold);

                SolidBrush solidBrush = new SolidBrush(Color.Red);
                Point point = new Point(img.Width / 5, img.Height / 2);
                g.DrawString(textOnImage, font, solidBrush, point);
                g.Save();

                memStream.Dispose();
                g.Dispose();
                solidBrush.Dispose();
                font.Dispose();
            }
            catch (Exception ex)
            {
                havException = true;
                ExceptionMessage = ex.Message;
            }
            return img;
        }
        public Bitmap CreateThumbnail(Stream buffer, bool maintainAspectRatio, int desiredWidth, int desiredHeight)
        {
            Bitmap bmp = null;
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(buffer);

                if (maintainAspectRatio)
                {
                    AspectRatio aspectRatio = new AspectRatio();
                    aspectRatio.WidthAndHeight(img.Width, img.Height, desiredWidth, desiredHeight);
                    bmp = new Bitmap(img, aspectRatio.Width, aspectRatio.Height);
                }
                else
                {
                    bmp = new Bitmap(img, desiredWidth, desiredHeight);
                }
            }
            catch (Exception ex)
            {
                havException = true;
                ExceptionMessage = ex.Message;
            }
            return bmp;
        }
        public Bitmap CreateThumbnail(byte[] imageByte, bool maintainAspectRatio, int desiredWidth, int desiredHeight)
        {
            Bitmap bmp = null;
            try
            {
                MemoryStream memStream = new MemoryStream(imageByte);
                System.Drawing.Image img = System.Drawing.Image.FromStream(memStream);

                if (maintainAspectRatio)
                {
                    AspectRatio aspectRatio = new AspectRatio();
                    aspectRatio.WidthAndHeight(img.Width, img.Height, desiredWidth, desiredHeight);
                    bmp = new Bitmap(img, aspectRatio.Width, aspectRatio.Height);
                }
                else
                {
                    bmp = new Bitmap(img, desiredWidth, desiredHeight);
                }
                memStream.Dispose();
            }
            catch (Exception ex)
            {
                havException = true;
                ExceptionMessage = ex.Message;
            }
            return bmp;
        }
    }
}
