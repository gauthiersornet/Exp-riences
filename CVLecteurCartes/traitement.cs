using OpenAI_API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bidouille
{
    public partial class Form1 : Form
    {
        private Image img = null;
        OpenAIAPI api;
        Task<CompletionResult> result;

        static double Racine2 = 1.4142135623730950488016887242097;
        static double UnSurRacine2 = 0.70710678118654752440084436210485;
        static double DeuxFoisUnSurRacine2 = 0.5;

        struct ARGB
        {
            byte B;
            byte G;
            byte R;
            byte A;

            public ARGB(byte a, byte r, byte g, byte b)
            {
                A = a;
                R = r;
                G = g;
                B = b;
            }

            static public byte PixDelta(ARGB v, ARGB w)
            {
                int /*A,*/ R, G, B;
                //A = v.A; A -= w.A;
                R = v.R; R -= w.R;
                G = v.G; G -= w.G;
                B = v.B; B -= w.B;
                return (byte)Math.Sqrt((/*A * A +*/ R * R + G * G + B * B) / 3.0);
            }

            static public ARGB Pond(ARGB v, ARGB w, double p)
            {
                double mp = 1.0 - p;
                ARGB res = new ARGB();
                res.A = (byte)(v.A * mp + w.A * p);
                res.R = (byte)(v.R * mp + w.R * p);
                res.G = (byte)(v.G * mp + w.G * p);
                res.B = (byte)(v.B * mp + w.B * p);
                return res;
            }

            public void Pond(double p)
            {
                R = (byte)(R * p);
                G = (byte)(G * p);
                B = (byte)(B * p);
            }
        }

        public Form1()
        {
            //foreach (var d in Directory.GetDirectories("C:\\Users\\Tigroux\\Desktop\\tt"))
            //{
            //    foreach (var f in Directory.GetFiles(d, "*.gg"))
            //    {
            //        string fn = "F:\\games\\download\\" + f.Substring(f.LastIndexOf("\\"));
            //        if(!File.Exists(fn))File.Copy(f, fn);
            //    }
            //}
            
            InitializeComponent();
            //img = CalculerOnde(0.1, 0.1, 300);
            //img = GrayToImg(CalculerOndeToGray(0.1, 0.1, 300), new Size(601, 601));

            //OpenAIAPI api = new OpenAIAPI("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");
            //OpenAIAPI api = new OpenAIAPI(apiKeys : "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", engine: Engine.Davinci);
            //OpenAIAPI api = new OpenAIAPI(new APIAuthentication("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"), Engine.Davinci);
            //api = new OpenAIAPI(apiKeys: "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", engine: Engine.Davinci, toke);
            //result = api.Completions.CreateCompletionAsync("One Two Three One Two", temperature: 0.1, max_tokens: 10);
            //result = api.Completions.CreateCompletionAsync("Le chat est sur le canapé, il regarde", temperature: 0.1, frequencyPenalty: 0.7, top_p: 1.0, max_tokens: 100);
            //result.GetAwaiter().GetResult().ToString();
            //result.Wait();
            //result.RunSynchronously(); 
            //textBox1.Text = "Le chat est sur le canapé, il regarde";

            /*api = new OpenAI_API.OpenAIAPI(new APIAuthentication("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"), Engine.Default);
            textBox1.Text = "Que penses-tu de la planette terre ?";
            result = api.Completions.CreateCompletionAsync(textBox1.Text, temperature: 0.1, frequencyPenalty: 0.7, top_p: 1.0, max_tokens: 1000);
            result.GetAwaiter().OnCompleted(() => { textBox1.Text += result.Result.ToString(); });*/
            textBox1.Visible = false;
        }

        private void completed_Tick()
        {
            textBox1.Text = result.Result.ToString();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        string[] ImgExt = new string[] { ".JPG", ".PNG", ".BMP" };
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] lstFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (lstFiles != null && lstFiles.Length > 0)
            {
                string file = lstFiles.FirstOrDefault(l => ImgExt.Contains(l.Substring(l.Length -4, 4).ToUpper()));
                if (file != null)
                {
                    /*
                    //img = Bitmap.FromFile(file);
                    Bitmap btmap = Bitmap.FromFile(file) as Bitmap;
                    Size sz = new Size(btmap.Width, btmap.Height);
                    //img = GrayToImg(ImgToGray(btmap), sz);
                    float[] grey = ImgToGray(btmap);
                    //img = GrayToImg(CalculerTFInv(CalculerTF(grey, sz, 40), sz, 40), sz);
                    //img = GrayToImg(CalculerTF(grey, sz, 40), new Size(80, 80));
                    img = GrayToImg(NormaliserGrey(CalculerTF(grey, sz, 50, 0.5), 2), new Size(100, 100));
                    //Bitmap btmp = ImgToImg(Bitmap.FromFile(file) as Bitmap);
                    //Rencoder(file+"2.png", btmp, System.Drawing.Imaging.ImageFormat.Png.Guid, 100L);
                    */

                    Bitmap ddImg = (Bitmap)Bitmap.FromFile(file);
                    byte[] X, Y, XY, YX;
                    sbyte[] ANG;
                    (X, Y, XY, YX) = filtreDelta(ddImg);
                    ANG = deltaAng(X, Y, XY, YX, ddImg.Size);
                    byte[] dMag4 = deltaMag(X, Y, ddImg.Size);
                    byte[] dMag8 = deltaMag(X, Y, XY, YX, ddImg.Size);
                    //img = GrayToImg(deltaMag(X, Y, XY, YX), ddImg.Size);
                    Rencoder(file + "_DELTA_X.png", (Bitmap)GrayToImg(X, ddImg.Size), System.Drawing.Imaging.ImageFormat.Png.Guid, 100L);
                    Rencoder(file + "_DELTA_Y.png", (Bitmap)GrayToImg(Y, ddImg.Size), System.Drawing.Imaging.ImageFormat.Png.Guid, 100L);
                    Rencoder(file + "_DELTA_XY.png", (Bitmap)GrayToImg(XY, ddImg.Size), System.Drawing.Imaging.ImageFormat.Png.Guid, 100L);
                    Rencoder(file + "_DELTA_YX.png", (Bitmap)GrayToImg(YX, ddImg.Size), System.Drawing.Imaging.ImageFormat.Png.Guid, 100L);
                    Rencoder(file + "_DELTA_MAG4.png", (Bitmap)GrayToImg(dMag4, ddImg.Size), System.Drawing.Imaging.ImageFormat.Png.Guid, 100L);
                    Rencoder(file + "_DELTA_MAG8.png", (Bitmap)GrayToImg(dMag8, ddImg.Size), System.Drawing.Imaging.ImageFormat.Png.Guid, 100L);
                    Rencoder(file + "_DELTA_ANG.png", (Bitmap)AngToImg(ANG, ddImg.Size), System.Drawing.Imaging.ImageFormat.Png.Guid, 100L);
                    Rencoder(file + "_DELTA_ANG_DMAG.png", (Bitmap)AngToImg(ANG, dMag8, ddImg.Size), System.Drawing.Imaging.ImageFormat.Png.Guid, 100L);

                    Refresh();
                }
            }
        }

        static (byte[], byte[], byte[], byte[]) filtreDelta(Bitmap img)
        {
            int l = img.Width * img.Height;
            byte[] X = new byte[l];
            byte[] Y = new byte[l];
            byte[] XY = new byte[l];
            byte[] YX = new byte[l];

            BitmapData btDtmap = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe
            {
                try
                {
                    ARGB* ptrImg = (ARGB*)btDtmap.Scan0; //uint v = *(ptrImg + j * img.Width + i);
                    for (int j = 1; j < img.Height; ++j)
                    {
                        int jW = j * img.Width;
                        for (int i = 1; i < img.Width; ++i)
                        {
                            int jWi = jW + i;
                            byte delta;

                            delta = ARGB.PixDelta(ptrImg[jWi - 1], ptrImg[jWi]); // X
                            X[jWi - 1] = delta;
                            //X[jWi] += delta;

                            delta = ARGB.PixDelta(ptrImg[jWi - img.Width], ptrImg[jWi]); // Y
                            Y[jWi - img.Width] = delta;
                            //Y[jWi] += delta;

                            if (i < img.Width - 1)
                            {
                                delta = ARGB.PixDelta(ptrImg[jWi - img.Width + 1], ptrImg[jWi]); // XY /
                                XY[jWi - img.Width + 1] = delta;
                                //XY[jWi] += delta;
                            }

                            delta = ARGB.PixDelta(ptrImg[jWi - img.Width - 1], ptrImg[jWi]); // YX \
                            YX[jWi - img.Width - 1] = delta;
                            //YX[jWi] += delta;
                        }
                    }
                }
                catch { }
                finally { img.UnlockBits(btDtmap); }
            }

            return (X, Y, XY, YX);
        }

        /*
        static byte[] deltaMag(byte[] X, byte[] Y)
        {
            byte[] mag = new byte[X.Length];
            for (int i = 0; i < mag.Length; ++i)
            {
                mag[i] = (byte)(0.70710678118654752440084436210485 * Math.Sqrt((X[i] * X[i] + Y[i] * Y[i])));
            }
            return mag;
        }

        static byte[] deltaMag(byte[] X, byte[] Y, byte[] XY, byte[] YX)
        {
            byte[] mag = new byte[X.Length];
            for (int i = 0; i < mag.Length; ++i)
            {
                 mag[i] = (byte)(0.57735026918962576450914878050195 * Math.Sqrt((X[i] * X[i] + Y[i] * Y[i] + (XY[i] * XY[i] + YX[i] * YX[i]) * DeuxFoisUnSurRacine2)));
            }
            return mag;
        }
        */

        static byte[] deltaMag(byte[] X, byte[] Y, Size taille)
        {
            byte[] mag = new byte[X.Length];
            for (int j = 1; j < taille.Height; ++j)
            {
                int jw = j * taille.Width;
                for (int i = 1; i < taille.Width; ++i)
                {
                    int jwi = jw + i;
                    //mag[jwi] = (byte)(0.70710678118654752440084436210485 * Math.Sqrt((X[jwi] * X[jwi] + Y[jwi] * Y[jwi])));
                    int dX, dY;
                    dX = (X[jwi] + X[jwi - 1]);
                    dY = (Y[jwi] + Y[jwi - taille.Width]);
                    mag[jwi] = (byte)(0.35355339059327376220042218105242 * Math.Sqrt(dX * dX + dY * dY));
                }
            }
            return mag;
        }

        static byte[] deltaMag(byte[] X, byte[] Y, byte[] XY, byte[] YX, Size taille)
        {
            byte[] mag = new byte[X.Length];
            for (int j = 1; j < taille.Height; ++j)
            {
                int jw = j * taille.Width;
                for (int i = 1; i < taille.Width; ++i)
                {
                    int jwi = jw + i;
                    int dX, dY, dXY, dYX;
                    dX = (X[jwi] + X[jwi - 1]);
                    dY = (Y[jwi] + Y[jwi - taille.Width]);
                    if (i < taille.Width - 1) dXY = (XY[jwi] + XY[jwi - taille.Width + 1]); else dXY = 0;
                    dYX = (YX[jwi] + YX[jwi - taille.Width - 1]);
                    mag[jwi] = (byte)(0.28867513459481288225457439025098 * Math.Sqrt((dX * dX + dY * dY + (dXY * dXY + dYX * dYX) * DeuxFoisUnSurRacine2)));
                }
            }
            return mag;
        }

        //static sbyte[] deltaAng(byte[] X, byte[] Y, byte[] XY, byte[] YX)
        //{
        //    sbyte[] ang = new sbyte[X.Length];
        //    for (int i = 0; i < ang.Length; ++i)
        //    {
        //        /*double h = X[i] + Y[i] + XY[i]+ X[i];//Math.Sqrt(X[i] * X[i] + Y[i] * Y[i] + XY[i] * XY[i] + YX[i] * YX[i]);
        //        if (h > 0.000000001)
        //        {
        //            ang[i] = (sbyte)(255.0 * (0.0 * X[i] + 0.5 * Y[i] + 0.25 * XY[i] + 0.75 * YX[i]) / h);
        //        }
        //        else ang[i] = (sbyte)-128;*/
        //
        //        double vx = 0.0;
        //        double vy = 0.0;
        //        vx += 1.0 * X[i]; vy += 0.0 * X[i];
        //        vx += 0.0 * Y[i]; vy += 1.0 * Y[i];
        //        //if(X[i] >= Y[i])
        //        //{
        //        //    vx += DeuxFoisUnSurRacine2 * XY[i]; vy -= DeuxFoisUnSurRacine2 * XY[i];
        //        //}
        //        //else
        //        //{
        //        //    vx -= DeuxFoisUnSurRacine2 * XY[i]; vy += DeuxFoisUnSurRacine2 * XY[i];
        //        //}
        //        vx -= DeuxFoisUnSurRacine2 * XY[i]; vy += DeuxFoisUnSurRacine2 * XY[i];
        //        vx += DeuxFoisUnSurRacine2 * YX[i]; vy += DeuxFoisUnSurRacine2 * YX[i];
        //
        //        double h = Math.Sqrt(vx * vx + vy * vy);
        //        if (h > 0.000000001)
        //        {
        //            if (vx < 0.0) h = -h;
        //            vx /= h; vy /= h;
        //            if (vy >= 0.0) ang[i] = (sbyte)(254.0 * ((Math.Acos(vx) / Math.PI)) + 0.5);
        //            else ang[i] = (sbyte)(-254.0 * ((Math.Acos(vx) / Math.PI)) - 0.5);
        //        }
        //        else ang[i] = (sbyte)-128;
        //    }
        //    return ang;
        //}

        static sbyte[] deltaAng(byte[] X, byte[] Y, byte[] XY, byte[] YX, Size taille)
        {
            sbyte[] ang = new sbyte[X.Length];
            for (int i = 0; i < taille.Width; ++i) ang[i] = (sbyte)-128;
            for (int j = 0; j < taille.Height; ++j) ang[j * taille.Width] = (sbyte)-128;
            for (int j = 1; j < taille.Height; ++j)
            {
                int jw = j * taille.Width;
                for (int i = 1; i < taille.Width; ++i)
                {
                    int jwi = jw + i;
                    /*double h = X[i] + Y[i] + XY[i]+ X[i];//Math.Sqrt(X[i] * X[i] + Y[i] * Y[i] + XY[i] * XY[i] + YX[i] * YX[i]);
                    if (h > 0.000000001)
                    {
                        ang[i] = (sbyte)(255.0 * (0.0 * X[i] + 0.5 * Y[i] + 0.25 * XY[i] + 0.75 * YX[i]) / h);
                    }
                    else ang[i] = (sbyte)-128;*/

                    double dX, dY, dXY, dYX;
                    dX = X[jwi] - X[jwi - 1];
                    dY = Y[jwi] - Y[jwi - taille.Width];
                    if (i < taille.Width-1)
                    {
                        dXY = XY[jwi] - XY[jwi - taille.Width + 1];
                    }
                    else dXY = 0.0;
                    dYX = YX[jwi] - YX[jwi - taille.Width - 1];

                    double vx = 0.0;
                    double vy = 0.0;
                    vx += 1.0 * dX; vy += 0.0 * dX;
                    vx += 0.0 * dY; vy += 1.0 * dY;
                    vx -= DeuxFoisUnSurRacine2 * dXY; vy += DeuxFoisUnSurRacine2 * dXY;
                    vx += DeuxFoisUnSurRacine2 * dYX; vy += DeuxFoisUnSurRacine2 * dYX;

                    double h = Math.Sqrt(vx * vx + vy * vy);
                    if (h > 0.000000001)
                    {
                        if (vx < 0.0) h = -h;
                        vx /= h; vy /= h;
                        if (vy >= 0.0) ang[jwi] = (sbyte)(254.0 * ((Math.Acos(vx) / Math.PI)) + 0.5);
                        else ang[jwi] = (sbyte)(-254.0 * ((Math.Acos(vx) / Math.PI)) - 0.5);
                    }
                    else ang[jwi] = (sbyte)-128;
                }
            }
            return ang;
        }

        static public Bitmap Rencoder(Bitmap nbtmap, Guid format, Int64 qualité)
        {
            ImageCodecInfo Encoder = ImageCodecInfo.GetImageDecoders().First(ecd => ecd.FormatID == format);
            EncoderParameter myEncoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualité);
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = myEncoderParameter;
            MemoryStream strm = new MemoryStream();
            nbtmap.Save(strm, Encoder, myEncoderParameters);
            return Image.FromStream(strm) as Bitmap;
        }

        static public void Rencoder(string file, Bitmap nbtmap, Guid format, Int64 qualité)
        {
            ImageCodecInfo Encoder = ImageCodecInfo.GetImageDecoders().First(ecd => ecd.FormatID == format);
            EncoderParameter myEncoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualité);
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = myEncoderParameter;
            //MemoryStream strm = new MemoryStream();
            nbtmap.Save(file, Encoder, myEncoderParameters);
        }

        static private Bitmap ImgToImg(Bitmap btmap)
        {
            //Bitmap nb = new Bitmap(btmap.Width, btmap.Height);
            BitmapData btDtmap = btmap.LockBits(new Rectangle(0, 0, btmap.Width, btmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe
            {
                try
                {
                    uint* ptrImg = (uint*)btDtmap.Scan0;
                    for (int j = 0; j < btmap.Height; ++j)
                    {
                        for (int i = 0; i < btmap.Width; ++i)
                        {
                            uint v = *(ptrImg + j * btmap.Width + i);
                            float f = ((((v >> 16) & 0xFF) + ((v >> 8) & 0xFF) + ((v >> 0) & 0xFF)) / 3.0f) / 255.0f;
                            byte b = (byte)(f * 255 + (1 - f) * 255);
                            byte r = (byte)(f * 255 + (1 - f) * 0);
                            byte g = (byte)(f * 255 + (1 - f) * 0);
                            v = (uint)0xFF << 24 | (uint)r << 16 | (uint)g << 8 | (uint)b;
                            *(ptrImg+j * btmap.Width + i) = v;
                            //nb.SetPixel(i, j, Color.FromArgb((int)v));
                        }
                    }
                }
                catch { }
                finally { btmap.UnlockBits(btDtmap); }
            }
            return btmap;
            /*for (int j = 0; j < btmap.Height; ++j)
            {
                for (int i = 0; i < btmap.Width; ++i)
                {
                    uint v = (uint)btmap.GetPixel(i, j).ToArgb();
                    float f = ((((v >> 16) & 0xFF) + ((v >> 8) & 0xFF) + ((v >> 0) & 0xFF)) / 3.0f) / 255.0f;
                    byte b = (byte)(f * 255 + (1 - f) * 255);
                    byte r = (byte)(f * 255 + (1 - f) * 0);
                    byte g = (byte)(f * 255 + (1 - f) * 0);
                    v = (uint)0xFF << 24 | (uint)r << 16 | (uint)g << 8 | (uint)b;
                    //*(ptrImg+j * btmap.Width + i) = v;
                    nb.SetPixel(i, j, Color.FromArgb((int)v));
                }
            }
            return nb;*/
        }

        /*
                static private Bitmap ImgToImg(Bitmap btmap, int div = 2)
                {
                    Size sz = new Size((btmap.Width + div - 1) / div, (btmap.Height + div - 1) / div);
                    Bitmap res = new Bitmap(btmap.Width , btmap.Height);
                    Graphics graph = Graphics.FromImage(res);
                    Bitmap tmpb = new Bitmap(sz.Width, sz.Height);
                    Graphics gdest = Graphics.FromImage(tmpb);
                    Bitmap tmpbDDD = new Bitmap(sz.Width, sz.Height);
                    for (int y = 0; y < div; ++y)
                    {
                        for (int x = 0; x < div; ++x)
                        {
                            gdest.DrawImage(btmap, new Rectangle(0, 0, sz.Width, sz.Height), new Rectangle(x * sz.Width, y * sz.Height, sz.Width, sz.Height), GraphicsUnit.Pixel);
                            BitmapData btDtmap = tmpb.LockBits(new Rectangle(0, 0, sz.Width, sz.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                            BitmapData btDtmapDDD = tmpbDDD.LockBits(new Rectangle(0, 0, sz.Width, sz.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                            unsafe
                            {
                                try
                                {
                                    uint* ptrImg = (uint*)btDtmap.Scan0;
                                    uint* ptrImgDDD = (uint*)btDtmapDDD.Scan0;
                                    for (int j = 0; j <= sz.Height; ++j)
                                    {
                                        for (int i = 0; i <= sz.Width; ++i)
                                        {
                                            uint v = *(ptrImg+j * sz.Width + i);
                                            float f = ((((v >> 16) & 0xFF) + ((v >> 8) & 0xFF) + ((v >> 0) & 0xFF)) / 3.0f) / 255.0f;
                                            byte b = (byte)(f * 255 + (1 - f) * 255);
                                            byte r = (byte)(f * 255 + (1 - f) * 0);
                                            byte g = (byte)(f * 255 + (1 - f) * 0);
                                            v = (uint)0xFF << 24 | (uint)r << 16 | (uint)g << 8 | (uint)b;
                                            //*(ptrImg+j * sz.Width + i) = v;
                                            *(ptrImgDDD + j * sz.Width + i) = v;
                                        }
                                    }
                                }
                                catch { }
                                finally { tmpb.UnlockBits(btDtmap); tmpbDDD.UnlockBits(btDtmapDDD); }
                            }
                            graph.DrawImage(tmpbDDD, new Rectangle(x * sz.Width, y * sz.Height, sz.Width, sz.Height), new Rectangle(0, 0, sz.Width, sz.Height), GraphicsUnit.Pixel);
                        }
                    }
                    return res;
                }
        */

        private Image CalculerOnde(double freqX, double freqY, int sz)
        {
            Bitmap btmap = new Bitmap(1 + 2 * sz, 1 + 2 * sz);
            BitmapData btDtmap = btmap.LockBits(new Rectangle(0, 0, btmap.Width, btmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe
            {
                try
                {
                    uint* ptrImg = (uint*)btDtmap.Scan0;
                    for(int j = -sz; j <= sz; ++j)
                    {
                        double y = Math.Sin(j * freqY);
                        for (int i = -sz; i <= sz; ++i)
                        {
                            double x = Math.Sin(i * freqX);
                            byte g = (byte)(127.5+127.5*(x*y) + 0.5);
                            *(ptrImg + (sz + j) * btmap.Width + (sz + i)) = ((uint)0xFF << 24) | ((uint)g << 16) | ((uint)g << 8) | (uint)g;
                        }
                    }
                }
                catch { }
                finally { btmap.UnlockBits(btDtmap); }
            }
            return btmap;
        }

        private float[] CalculerOndeToGray(double freqX, double freqY, int sz)
        {
            int w = (1 + 2 * sz);
            float[] grey = new float[w * w];
            for (int j = -sz; j <= sz; ++j)
            {
                double y = Math.Sin(j * freqY);
                for (int i = -sz; i <= sz; ++i)
                {
                    double x = Math.Sin(i * freqX);
                    grey[(sz + j) * w + (sz + i)] = (float)(x * y);
                }
            }
            return grey;
        }

        private float[] CalculerPondSin(float[] grey, Size sz, int def, float freqdef)
        {
            float nbpix = sz.Width * sz.Height;
            int w = 1 + 2 * def;
            float[] pondSin = new float[w * w];
            for (int v = -def; v <= +def; ++v)
            {
                for (int u = -def; u <= +def; ++u)
                {
                    float fx = freqdef * u;
                    float fy = freqdef * v;
                    float c = 0.0f;

                    for (int j = 0; j <= sz.Height; ++j)
                    {
                        double y = Math.Sin(j * fy);
                        for (int i = 0; i <= sz.Width; ++i)
                        {
                            int idx = j * sz.Width + i;
                            double x = Math.Sin(i * fx);
                            c+= (float)(grey[idx] - (x * y));
                        }
                    }

                    pondSin[(def + v) * def + (def + u)] = c / nbpix;
                }
            }
            return pondSin;
        }

        private float[] NormaliserGrey(float[] grey, float coef = 1.0f)
        {
            float min = grey.Min();
            float max = grey.Max();
            float dlt = (max - min);
            if(dlt < -0.00001 || dlt > 0.00001)
            {
                for (int i = 0; i < grey.Length; ++i) grey[i] = coef * ((2.0f * (grey[i] - min) / dlt) - 1.0f);
            }
            return grey;
        }

        /*private float[] CalculerTF(float[] grey, Size sz, int def, double freqdef)
        {
            float nbpix = sz.Width * sz.Height;
            float[] tf = new float[def * def];
            for (int v = 0; v < def; ++v)
            {
                for (int u = 0; u < def; ++u)
                {
                    double c = 0.0f;

                    for (int j = 0; j < sz.Height; ++j)
                    {
                        for (int i = 0; i < sz.Width; ++i)
                        {
                            int idx = j * sz.Width + i;
                            c += grey[idx] * Math.Exp(-freqdef * 2 * Math.PI * (((double)(i * u) / (double)sz.Width) + ((double)(j * v) / (double)sz.Height)));
                            //c += grey[idx] * Math.Exp(-freqdef * 2 * Math.PI * (((i * u) + (j * v)) / def));
                        }
                    }

                    tf[v * def + u] = (float)(c / nbpix);
                }
            }
            return tf;
        }

        private float[] CalculerTFInv(float[] tf, Size sz, int def, double freqdef)
        {
            //double nbpix = def * def;
            float[] grey = new float[sz.Width * sz.Height];
            for (int j = 0; j < sz.Height; ++j)
            {
                for (int i = 0; i < sz.Width; ++i)
                {
                    int idx = j * sz.Width + i;

                    double g = 0.0f;

                    for (int v = 0; v < def; ++v)
                    {
                        for (int u = 0; u < def; ++u)
                        {
                            //g += tf[v * def + u] * Math.Exp(freqdef * 2 * Math.PI * (((i * u) / sz.Width) + ((j * v) / sz.Height)));
                            g += tf[v * def + u] * Math.Exp(freqdef * 2 * Math.PI * (((double)(i * u) + (double)(j * v)) / (double)def));
                        }
                    }

                    grey[idx] = (float)(g / def);
                }
            }

            return grey;
        }*/

        private float[] CalculerTF(float[] grey, Size sz, int def, double cfech = 1.0)
        {
            int w = 2 * def;
            double nbpix = sz.Width * sz.Height;
            float[] tf = new float[w * w];
            for (int v = -def; v < +def; ++v)
            {
                for (int u = -def; u < +def; ++u)
                {
                    double re = 0.0;
                    double im = 0.0;

                    for (int j = 0; j < sz.Height; ++j)
                    {
                        for (int i = 0; i < sz.Width; ++i)
                        {
                            int idx = j * sz.Width + i;
                            re += grey[idx] * Math.Cos(cfech * 2 * Math.PI * ((((double)(i * u)) / (double)sz.Width) + (((double)(j * v)) / (double)sz.Height)));
                            im -= grey[idx] * Math.Sin(cfech * 2 * Math.PI * ((((double)(i * u)) / (double)sz.Width) + (((double)(j * v)) / (double)sz.Height)));
                        }
                    }

                    double c = Math.Sqrt(re * re + im * im);

                    /*
                    double c = 0.0;
                    for (int j = 0; j < sz.Height; ++j)
                    {
                        for (int i = 0; i < sz.Width; ++i)
                        {
                            int idx = j * sz.Width + i;
                            c += grey[idx] * Math.Exp(-freqdef * 2 * Math.PI * ((((double)(i*u)) / (double)sz.Width) + (((double)(j*v)) / (double)sz.Height)));
                            //c += grey[idx] * Math.Exp(-freqdef * 2 * Math.PI * ((((double)(i * u)) / (double)def) + (((double)(j * v)) / (double)def)));
                        }
                    }
                    tf[(def + v) * w + (def + u)] = (float)(c / nbpix);
                    */

                    tf[(def + v) * w + (def + u)] = (float)(c);
                }
            }
            return tf;
        }

        private float[] CalculerTFInv(float[] tf, Size sz, int def)
        {
            int w = 2 * def;
            double nbspec = w * w;
            float[] grey = new float[sz.Width * sz.Height];
            for (int j = 0; j < sz.Height; ++j)
            {
                for (int i = 0; i < sz.Width; ++i)
                {
                    int idx = j * sz.Width + i;

                    double g = 0.0f;

                    for (int v = -def; v < +def; ++v)
                    {
                        for (int u = -def; u < +def; ++u)
                        {
                            //g += tf[(def + v) * def + (def + u)] * Math.Exp(freqdef * 2 * Math.PI * (((i * u) / sz.Width) + ((j * v) / sz.Height)));
                            g += tf[(def + v) * w + (def + u)] * Math.Exp(2 * Math.PI * ((double)(i * u) + (double)(j * v)) / (double)def);
                        }
                    }

                    grey[idx] = (float)(g / nbspec);
                }
            }

            return grey;
        }

        static private float[] ImgToGray(Bitmap btmap)
        {
            float[] res = new float[btmap.Width * btmap.Height];
            BitmapData btDtmap = btmap.LockBits(new Rectangle(0, 0, btmap.Width, btmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe
            {
                try
                {
                    uint* ptrImg = (uint*)btDtmap.Scan0;
                    for (int j = 0; j < btmap.Height; ++j)
                    {
                        for (int i = 0; i < btmap.Width; ++i)
                        {
                            int idx = j * btmap.Width + i;
                            uint v = *(ptrImg + idx);
                            res[idx] = 2.0f * (((((v >> 16) & 0xFF) / 255.0f) + (((v >> 8) & 0xFF) / 255.0f) + (((v >> 0) & 0xFF) / 255.0f)) / 3.0f) - 1.0f;
                        }
                    }
                }
                catch { }
                finally { btmap.UnlockBits(btDtmap); }
            }
            return res;
        }

        private Image GrayToImg(float[] grey, Size sz)
        {
            Bitmap btmap = new Bitmap(sz.Width, sz.Height);
            BitmapData btDtmap = btmap.LockBits(new Rectangle(0, 0, btmap.Width, btmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe
            {
                try
                {
                    uint* ptrImg = (uint*)btDtmap.Scan0;
                    for (int j = 0; j < sz.Height; ++j)
                    {
                        for (int i = 0; i < sz.Width; ++i)
                        {
                            int idx = j * btmap.Width + i;
                            double dg = (127.5 + 127.5 * grey[idx] + 0.5);
                            byte g = (dg > 255.0) ? (byte)255 : (byte)dg;
                            *(ptrImg + idx) = ((uint)0xFF << 24) | ((uint)g << 16) | ((uint)g << 8) | (uint)g;
                        }
                    }
                }
                catch { }
                finally { btmap.UnlockBits(btDtmap); }
            }
            return btmap;
        }

        private Image GrayToImg(sbyte[] grey, Size sz)
        {
            Bitmap btmap = new Bitmap(sz.Width, sz.Height);
            BitmapData btDtmap = btmap.LockBits(new Rectangle(0, 0, btmap.Width, btmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe
            {
                try
                {
                    uint* ptrImg = (uint*)btDtmap.Scan0;
                    for (int j = 0; j < sz.Height; ++j)
                    {
                        for (int i = 0; i < sz.Width; ++i)
                        {
                            int idx = j * btmap.Width + i;
                            byte g = (byte)(2 * Math.Abs(grey[idx]));
                            *(ptrImg + idx) = ((uint)0xFF << 24) | ((uint)g << 16) | ((uint)g << 8) | (uint)g;
                        }
                    }
                }
                catch { }
                finally { btmap.UnlockBits(btDtmap); }
            }
            return btmap;
        }

        private Image GrayToImg(byte[] grey, Size sz)
        {
            Bitmap btmap = new Bitmap(sz.Width, sz.Height);
            BitmapData btDtmap = btmap.LockBits(new Rectangle(0, 0, btmap.Width, btmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe
            {
                try
                {
                    uint* ptrImg = (uint*)btDtmap.Scan0;
                    for (int j = 0; j < sz.Height; ++j)
                    {
                        for (int i = 0; i < sz.Width; ++i)
                        {
                            int idx = j * btmap.Width + i;
                            byte g = grey[idx];
                            *(ptrImg + idx) = ((uint)0xFF << 24) | ((uint)g << 16) | ((uint)g << 8) | (uint)g;
                        }
                    }
                }
                catch { }
                finally { btmap.UnlockBits(btDtmap); }
            }
            return btmap;
        }

        //X = bleu
        static ARGB CX = new ARGB(255, 0, 0, 255);
        //Y = rouge
        static ARGB CY = new ARGB(255, 255, 0, 0);
        //XY = vert
        static ARGB CXY = new ARGB(255, 0, 255, 0);
        //YX = jaune
        static ARGB CYX = new ARGB(255, 0, 255, 255);

        private Image AngToImg(sbyte[] ang, Size sz)
        {
            Bitmap btmap = new Bitmap(sz.Width, sz.Height);
            BitmapData btDtmap = btmap.LockBits(new Rectangle(0, 0, btmap.Width, btmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe
            {
                try
                {
                    ARGB* ptrImg = (ARGB*)btDtmap.Scan0;
                    for (int j = 0; j < sz.Height; ++j)
                    {
                        for (int i = 0; i < sz.Width; ++i)
                        {
                            int idx = j * btmap.Width + i;
                            sbyte a = ang[idx];

                            //X -> XY = 0 -> 63.75
                            //XY -> Y = 63.75 -> 127.5
                            //Y -> YX = 127.5 -> 191.25

                            ARGB cAng;
                            if (a != -128)
                            {
                                if (a < -64) cAng = ARGB.Pond(CY, CYX, (a + 128) / 64.0);
                                else if (a < 0) cAng = ARGB.Pond(CYX, CX, (a + 64) / 64.0);
                                else if (a < 64) cAng = ARGB.Pond(CX, CXY, (a - 0) / 64.0);
                                else cAng = ARGB.Pond(CXY, CY, (a - 64) / 64.0);
                            }
                            else cAng = new ARGB();

                            ptrImg[idx] = cAng;
                        }
                    }
                }
                catch { }
                finally { btmap.UnlockBits(btDtmap); }
            }
            return btmap;
        }

        /*private Image AngToImg(sbyte[] ang, sbyte[] axe, Size sz)
        {
            Bitmap btmap = new Bitmap(sz.Width, sz.Height);
            BitmapData btDtmap = btmap.LockBits(new Rectangle(0, 0, btmap.Width, btmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe
            {
                try
                {
                    ARGB* ptrImg = (ARGB*)btDtmap.Scan0;
                    for (int j = 0; j < sz.Height; ++j)
                    {
                        for (int i = 0; i < sz.Width; ++i)
                        {
                            int idx = j * btmap.Width + i;
                            sbyte a = ang[idx];

                            //X -> XY = 0 -> 63.75
                            //XY -> Y = 63.75 -> 127.5
                            //Y -> YX = 127.5 -> 191.25

                            ARGB cAng;
                            if (a != -128)
                            {
                                if (a < -64) cAng = ARGB.Pond(CY, CYX, (a + 128) / 64.0);
                                else if (a < 0) cAng = ARGB.Pond(CYX, CX, (a + 64) / 64.0);
                                else if (a < 64) cAng = ARGB.Pond(CX, CXY, (a - 0) / 64.0);
                                else cAng = ARGB.Pond(CXY, CY, (a - 64) / 64.0);
                                cAng.Pond(Math.Abs(axe[idx]) / 127.0);
                            }
                            else cAng = new ARGB();

                            ptrImg[idx] = cAng;
                        }
                    }
                }
                catch { }
                finally { btmap.UnlockBits(btDtmap); }
            }
            return btmap;
        }*/

        private Image AngToImg(sbyte[] ang, byte[] mag, Size sz)
        {
            Bitmap btmap = new Bitmap(sz.Width, sz.Height);
            BitmapData btDtmap = btmap.LockBits(new Rectangle(0, 0, btmap.Width, btmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            unsafe
            {
                try
                {
                    ARGB* ptrImg = (ARGB*)btDtmap.Scan0;
                    for (int j = 0; j < sz.Height; ++j)
                    {
                        for (int i = 0; i < sz.Width; ++i)
                        {
                            int idx = j * btmap.Width + i;
                            sbyte a = ang[idx];

                            //X -> XY = 0 -> 63.75
                            //XY -> Y = 63.75 -> 127.5
                            //Y -> YX = 127.5 -> 191.25

                            ARGB cAng;
                            if (a != -128)
                            {
                                if (a < -64) cAng = ARGB.Pond(CY, CYX, (a + 128) / 64.0);
                                else if (a < 0) cAng = ARGB.Pond(CYX, CX, (a + 64) / 64.0);
                                else if (a < 64) cAng = ARGB.Pond(CX, CXY, (a - 0) / 64.0);
                                else cAng = ARGB.Pond(CXY, CY, (a - 64) / 64.0);
                                cAng.Pond(Math.Abs(mag[idx]) / 255.0);
                            }
                            else cAng = new ARGB();

                            ptrImg[idx] = cAng;
                        }
                    }
                }
                catch { }
                finally { btmap.UnlockBits(btDtmap); }
            }
            return btmap;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if(img != null)
            {
                //e.Graphics.ScaleTransform(6.0f, 6.0f);
                e.Graphics.DrawImage(img, 0, 0);
            }
        }
    }
}
