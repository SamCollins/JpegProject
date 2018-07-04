using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JpegProject
{
    public partial class Form1 : Form
    {
        Bitmap srcImage;
        static int width;
        static int height;

        static double[] Y;
        static double[] Cb;
        static double[] Cr;

        static double[,] dctY;
        static double[,] dctCb;
        static double[,] dctCr;

        static double[,] calcY;
        static double[,] calcCb;
        static double[,] calcCr;

        static sbyte[,] Ybytes;
        static sbyte[,] Cbbytes;
        static sbyte[,] Crbytes;

        static byte[,] uYbytes;
        static byte[,] uCbbytes;
        static byte[,] uCrbytes;

        static zigCoord[] zigOffset = new zigCoord[64];
        static List<byte> streamList = new List<byte>();

        static byte[] stream;


        //Motion Vectors
        Bitmap motiondogSrc;
        Bitmap motiondogDest;
        bool bDrawGrid = false;

        static double[,] MVsrcY;
        static double[,] MVdestY;

        static motionVec[,] vectors;

        static int SEARCH_AREA = 16;

        static double[,] lumQuan = {
            { 16, 11, 10, 16, 24, 40, 51, 61 },
            { 12, 12, 14, 19, 26, 58, 60, 55 },
            { 14, 13, 16, 24, 40, 57, 69, 56 },
            { 14, 17, 22, 29, 51, 87, 80, 62 },
            { 18, 22, 37, 56, 68, 109, 103, 77 },
            { 24, 35, 55, 64, 81, 104, 113, 92 },
            { 49, 64, 78, 87, 103, 121, 120, 101 },
            { 72, 92, 95, 98, 112, 100, 103, 99 },
            };

        static double[,] chromQuan = {
            { 17, 18, 24, 47, 99, 99, 99, 99 },
            { 18, 21, 26, 66, 99, 99, 99, 99 },
            { 24, 26, 56, 99, 99, 99, 99, 99 },
            { 47, 66, 99, 99, 99, 99, 99, 99 },
            { 99, 99, 99, 99, 99, 99, 99, 99 },
            { 99, 99, 99, 99, 99, 99, 99, 99 },
            { 99, 99, 99, 99, 99, 99, 99, 99 },
            { 99, 99, 99, 99, 99, 99, 99, 99 },
            };

        public struct motionVec
        {
            public int x;
            public int y;

            public motionVec(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public struct zigCoord
        {
            public int x;
            public int y;

            public zigCoord(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public static void initZigCoord()
        {
            zigOffset[0] = new zigCoord(0, 0);
            zigOffset[1] = new zigCoord(1, 0);
            zigOffset[2] = new zigCoord(0, 1);
            zigOffset[3] = new zigCoord(0, 2);
            zigOffset[4] = new zigCoord(1, 1);
            zigOffset[5] = new zigCoord(2, 0);
            zigOffset[6] = new zigCoord(3, 0);
            zigOffset[7] = new zigCoord(2, 1);
            zigOffset[8] = new zigCoord(1, 2);
            zigOffset[9] = new zigCoord(0, 3);
            zigOffset[10] = new zigCoord(0, 4);
            zigOffset[11] = new zigCoord(1, 3);
            zigOffset[12] = new zigCoord(2, 2);
            zigOffset[13] = new zigCoord(3, 1);
            zigOffset[14] = new zigCoord(4, 0);
            zigOffset[15] = new zigCoord(5, 0);
            zigOffset[16] = new zigCoord(4, 1);
            zigOffset[17] = new zigCoord(3, 2);
            zigOffset[18] = new zigCoord(2, 3);
            zigOffset[19] = new zigCoord(1, 4);
            zigOffset[20] = new zigCoord(0, 5);
            zigOffset[21] = new zigCoord(0, 6);
            zigOffset[22] = new zigCoord(1, 5);
            zigOffset[23] = new zigCoord(2, 4);
            zigOffset[24] = new zigCoord(3, 3);
            zigOffset[25] = new zigCoord(4, 2);
            zigOffset[26] = new zigCoord(5, 1);
            zigOffset[27] = new zigCoord(6, 0);
            zigOffset[28] = new zigCoord(7, 0);
            zigOffset[29] = new zigCoord(6, 1);
            zigOffset[30] = new zigCoord(5, 2);
            zigOffset[31] = new zigCoord(4, 3);
            zigOffset[32] = new zigCoord(3, 4);
            zigOffset[33] = new zigCoord(2, 5);
            zigOffset[34] = new zigCoord(1, 6);
            zigOffset[35] = new zigCoord(0, 7);
            zigOffset[36] = new zigCoord(1, 7);
            zigOffset[37] = new zigCoord(2, 6);
            zigOffset[38] = new zigCoord(3, 5);
            zigOffset[39] = new zigCoord(4, 4);
            zigOffset[40] = new zigCoord(5, 3);
            zigOffset[41] = new zigCoord(6, 2);
            zigOffset[42] = new zigCoord(7, 1);
            zigOffset[43] = new zigCoord(7, 2);
            zigOffset[44] = new zigCoord(6, 3);
            zigOffset[45] = new zigCoord(5, 4);
            zigOffset[46] = new zigCoord(4, 5);
            zigOffset[47] = new zigCoord(3, 6);
            zigOffset[48] = new zigCoord(2, 7);
            zigOffset[49] = new zigCoord(3, 7);
            zigOffset[50] = new zigCoord(4, 6);
            zigOffset[51] = new zigCoord(5, 5);
            zigOffset[52] = new zigCoord(6, 4);
            zigOffset[53] = new zigCoord(7, 3);
            zigOffset[54] = new zigCoord(7, 4);
            zigOffset[55] = new zigCoord(6, 5);
            zigOffset[56] = new zigCoord(5, 6);
            zigOffset[57] = new zigCoord(4, 7);
            zigOffset[58] = new zigCoord(5, 7);
            zigOffset[59] = new zigCoord(6, 6);
            zigOffset[60] = new zigCoord(7, 5);
            zigOffset[61] = new zigCoord(7, 6);
            zigOffset[62] = new zigCoord(6, 7);
            zigOffset[63] = new zigCoord(7, 7);

        }

        public Form1()
        {
            InitializeComponent();
        }

        public static void DCT(double[,] image, double[,] result, int xIndex, int yIndex)
        {
            //All 8's should be M/N
            double value = 0;

            for (int v = 0; v < 8; v++)
            {
                for (int u = 0; u < 8; u++)
                {
                    value = 0;
                    
                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            //yIndex going out of bounds
                            //8 in this one might need to be 4 (textbook)
                            value += Math.Cos(((2 * i + 1) * u * Math.PI) / 16)
                                   * Math.Cos(((2 * j + 1) * v * Math.PI) / 16)
                                   * image[yIndex + j, xIndex + i];
                        }
                    }

                    //8 should be square root of M * N
                    result[yIndex + v, xIndex + u] = Math.Round(value * ((2 * C(u) * C(v)) / 8));
                }
            }
        }

        //Deal with padding 0's for non uniform images
        public static void performDCT(double[,] component, double [,] result, sbyte[,] finalData, double[,] quanTable)
        {
            for (int x = 0; x < component.GetLength(0); x += 8)
            {
                for (int y = 0; y < component.GetLength(1); y += 8)
                {
                    DCT(component, result, x, y);
                    quantize(result, finalData, quanTable, x, y); 
                }
            }

        }

        public static void quantize(double[,] image, sbyte[,] finalData, double[,] quanTable, int xIndex, int yIndex)
        {
            //byte[,] test = new byte[8, 8];
            for (int j = 0; j < quanTable.GetLength(1); j++)
            {
                for (int i = 0; i < quanTable.GetLength(0); i++)
                {
                    finalData[yIndex + j, xIndex + i] = Convert.ToSByte(Math.Round(image[yIndex + j, xIndex + i] / quanTable[j, i]));
                }
            }
        }

        //Not done
        public static void IDCT(double[,] image, double[,] result, int xIndex, int yIndex)
        {
            //All 8's should be M/N
            //double[,] image = new double[8, 8];
            double value = 0;

            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    value = 0;
                    for (int v = 0; v < 8; v++)
                    {
                        for (int u = 0; u < 8; u++)
                        {
                            value += Math.Cos(((2 * i + 1) * u * Math.PI) / 16)
                                   * Math.Cos(((2 * j + 1) * v * Math.PI) / 16)
                                   * image[yIndex + v, xIndex + u] * ((2 * C(u) * C(v)) / 8);
                        }
                    }

                    //8 should be square root of M * N
                    //Make a function for C(x) garbo
                    result[yIndex + j, xIndex + i] = Math.Round(value);
                }
            }
        }

        public static void invQuantize(sbyte[,] data, double[,] image, double[,] quanTable, int xIndex, int yIndex)
        {
            //byte[,] test = new byte[8, 8];
            for (int j = 0; j < quanTable.GetLength(1); j++)
            {
                for (int i = 0; i < quanTable.GetLength(0); i++)
                {
                    image[yIndex + j, xIndex + i] = data[yIndex + j, xIndex + i] * quanTable[j, i];
                }
            }
        }

        public static void performIDCT(sbyte[,] data, double[,] component, double[,] result, double[,] quanTable)
        {
            for (int x = 0; x < component.GetLength(0); x += 8)
            {
                for (int y = 0; y < component.GetLength(1); y += 8)
                {
                    invQuantize(data, component, quanTable, x, y);
                    IDCT(component, result, x, y);
                }
            }
        }

        private static double C(int x)
        {
            double num = 1.0;
            if (x == 0)
            {
                num = 1 / Math.Sqrt(2);
            }
            return num;
        }

        #region Functions

        private static int boundsCheck(int val)
        {
            if (val > 255)
                val = 255;
            if (val < 0)
                val = 0;
            return val;
        }

        private static double centerBoundsCheck(double val)
        {
            if (val > 127)
                val = 127;
            if (val < -128)
                val = -128;
            return val;
        }

        private static double[,] convert1DArray(double[] data, int aWidth, int aHeight)
        {

            double[,] newArray = new double[aWidth, aHeight];

            int i = 0;
            for (int y = 0; y < aWidth; y++)
            {
                for (int x = 0; x < aHeight; x++)
                {
                    newArray[y, x] = data[i];
                    i++;
                }
            }

            return newArray;
        }

        private static double[] convert2DArray(double[,] data, int aLength)
        {
            double[] newArray = new double[aLength];

            //could be bad
            int aWidth = data.GetLength(0);
            int aHeight = data.GetLength(1);

            int i = 0;
            for (int y = 0; y < aWidth; y++)
            {
                for (int x = 0; x < aHeight; x++)
                {
                    newArray[i] = data[y, x];
                    i++;
                }
            }

            return newArray;
        }

        public void RGBtoYCbCr()
        {
            Bitmap image = new Bitmap(srcImage);
            width = srcImage.Width;
            height = srcImage.Height;

            Y = new double[width * height];
            Cb = new double[width * height];
            Cr = new double[width * height];

            int i = 0;
            for (int y = 0; y < image.Width; y++)
            {
                for (int x = 0; x < image.Height; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    //byte test = pixelColor.R;
                    //might need casts later

                    //testing 128 to 0.5
                    Y[i] = ((0.299 * pixelColor.R) + (0.587 * pixelColor.G) + (0.114 * pixelColor.B));
                    Cb[i] = ((-0.169 * pixelColor.R) - (0.331 * pixelColor.G) + (0.5 * pixelColor.B));
                    Cr[i] = ((0.5 * pixelColor.R) - (0.419 * pixelColor.G) - (0.081 * pixelColor.B));

                    //Y[i] = centerBoundsCheck(Y[i] - 128); //TESTING
                    //Cb[i] = centerBoundsCheck(Cb[i] - 128); //TESTING
                    //Cr[i] = centerBoundsCheck(Cr[i] - 128); //TESTING

                    i++;
                }
            }
        }

        public void YCbCrtoRGB(double[] Y, double[] Cb, double[] Cr)
        {
            Bitmap ycbcr = new Bitmap(width, height);

            //ImageConverter converter = new ImageConverter();
            //byte[] srcBytes = (byte[])converter.ConvertTo(srcImage, typeof(byte[]));

            //+(0.000 * (Cb[i] - 128)) R
            //+(0.000 * (Cr[i] - 128)) B

            int i = 0;
            for (int y = 0; y < ycbcr.Width; y++)
            {
                for (int x = 0; x < ycbcr.Height; x++)
                {
                    //Y[i] += 128; //TESTING
                    //Cb[i] += 128; //TESTING
                    //Cr[i] += 128; //TESTING

                    int r = (int)(Y[i] + (1.402 * Cr[i]));
                    int g = (int)(Y[i] - (0.344 * Cb[i]) - (0.714 * Cr[i]));
                    int b = (int)(Y[i] + (1.772 * Cb[i]));

                    r = boundsCheck(r);
                    b = boundsCheck(b);
                    g = boundsCheck(g);

                    Color newColor = Color.FromArgb(r, g, b);
                    ycbcr.SetPixel(x, y, newColor);

                    i++;
                }
            }
            setPicBoxImage(destPicture, ycbcr);
        }

        public void MVYCbCrtoRGB()
        {
            Bitmap image = new Bitmap(motiondogSrc);

            double[] srcY = new double[image.Width * image.Height];
            //double[] Cb = new double[width * height];
            //double[] Cr = new double[width * height];

            int i = 0;
            for (int y = 0; y < image.Width; y++)
            {
                for (int x = 0; x < image.Height; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    //byte test = pixelColor.R;
                    //might need casts later

                    //testing 128 to 0.5
                    srcY[i] = ((0.299 * pixelColor.R) + (0.587 * pixelColor.G) + (0.114 * pixelColor.B));
                    //Cb[i] = ((-0.169 * pixelColor.R) - (0.331 * pixelColor.G) + (0.5 * pixelColor.B));
                    //Cr[i] = ((0.5 * pixelColor.R) - (0.419 * pixelColor.G) - (0.081 * pixelColor.B));
                    i++;
                }
            }

            MVsrcY = convert1DArray(srcY, image.Width, image.Height);

            image = new Bitmap(motiondogDest);
            double[] destY = new double[image.Width * image.Height];

            i = 0;
            for (int y = 0; y < image.Width; y++)
            {
                for (int x = 0; x < image.Height; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    
                    destY[i] = ((0.299 * pixelColor.R) + (0.587 * pixelColor.G) + (0.114 * pixelColor.B));
                    //Cb[i] = ((-0.169 * pixelColor.R) - (0.331 * pixelColor.G) + (0.5 * pixelColor.B));
                    //Cr[i] = ((0.5 * pixelColor.R) - (0.419 * pixelColor.G) - (0.081 * pixelColor.B));
                    i++;
                }
            }

            MVdestY = convert1DArray(destY, image.Width, image.Height);

        }

        //Make this work with any width/height
        public double[] subSample(double[] component)
        {
            double[] subArray = new double[component.Length / 4];

            int cI = 0;
            int sI = 0;
            for (int y = 0; y < 256; y += 2)
            {
                for (int i = 0; i < 256; i += 2)
                {
                    subArray[sI] = component[cI];
                    sI++;
                    cI += 2;
                }
                cI += 256;
            }

            return subArray;
        }

        public double[] superSample(double[] subArray)
        {
            double[] superArray = new double[subArray.Length * 4];

            for (int i = 0, j = 0; i < subArray.Length - 256; i++, j += 2)
            {
                if (j % 256 == 0 && j != 0)
                {
                    j += 256;
                }
                superArray[j] = subArray[i];
                superArray[j + 1] = subArray[i];
                superArray[j + 256] = subArray[i];
                superArray[j + 256 + 1] = subArray[i];
            }

            return superArray;
        }

        #endregion

        public static void zigzag(byte[,] component, byte[] values, int xCoord, int yCoord, int index)
        {
            for (int i = 0; i < 64; i++)
            {
                values[index + i] = component[yCoord + zigOffset[i].y, xCoord + zigOffset[i].x];
            }
        }

        public static void performZigzag(byte[,] component, byte[] values)
        {
            int i = 0; 
            for (int y = 0; y < component.GetLength(1); y += 8)
            {
                for (int x = 0; x < component.GetLength(0); x += 8)
                {
                    zigzag(component, values, x, y, i);
                    i += 64;
                }
            }
        }

        public static void invZigzag(byte[] values, byte[,] component, int xCoord, int yCoord, int index)
        {
            for (int i = 0; i < 64; i++)
            {
                component[yCoord + zigOffset[i].y, xCoord + zigOffset[i].x] = values[index + i];
            }
        }

        public static void performInvZigzag(byte[] values, byte[,] component)
        {
            int i = 0;
            for (int y = 0; y < component.GetLength(1); y += 8)
            {
                for (int x = 0; x < component.GetLength(0); x += 8)
                {
                    invZigzag(values, component, x, y, i);
                    i += 64;
                }
            }
        }

        public static void RLE(byte[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == 0)
                {
                    byte count = 0;
                    int j = 0;
                    while (i + j < values.Length && values[i + j] == 0)
                    {
                        count++;
                        j++;
                    }
                    streamList.Add(0);
                    streamList.Add(count);
                    i += j - 1;

                }
                else
                {
                    streamList.Add(values[i]);
                }
            }
        }

        public static void invRLE(byte[] values, byte[] result, int length)
        {
            int resInd = 0;
            for (int i = 0; i < length; i++)
            {
                if (values[i] == 0)
                {
                    int count = values[i + 1];
                    for (int j = 0; j < count; j++)
                    {
                        result[resInd] = 0;
                        resInd++;
                    }
                    i++;
                }
                else
                {
                    result[resInd] = values[i];
                    resInd++;
                }
            }
        }

        public static void compress()
        {
            byte[] encodeY = new byte[256 * 256];
            byte[] encodeCb = new byte[128 * 128];
            byte[] encodeCr = new byte[128 * 128];

            performDCT(calcY, dctY, Ybytes, lumQuan);
            performDCT(calcCb, dctCb, Cbbytes, chromQuan);
            performDCT(calcCr, dctCr, Crbytes, chromQuan);

            Buffer.BlockCopy(Ybytes, 0, uYbytes, 0, 256 * 256);
            Buffer.BlockCopy(Cbbytes, 0, uCbbytes, 0, 128 * 128);
            Buffer.BlockCopy(Crbytes, 0, uCrbytes, 0, 128 * 128);

            performZigzag(uYbytes, encodeY);
            performZigzag(uCbbytes, encodeCb);
            performZigzag(uCrbytes, encodeCr);

            RLE(encodeY);
            RLE(encodeCb);
            RLE(encodeCr);

            stream = streamList.ToArray();
        }

        public static void decompress()
        {
            byte[] comeback = new byte[98304];
            invRLE(stream, comeback, stream.Length);

            byte[] decodeY = new byte[256 * 256];
            byte[] decodeCb = new byte[128 * 128];
            byte[] decodeCr = new byte[128 * 128];

            Buffer.BlockCopy(comeback, 0, decodeY, 0, 256 * 256);
            Buffer.BlockCopy(comeback, 256 * 256, decodeCb, 0, 128 * 128);
            Buffer.BlockCopy(comeback, 256 * 256 + 128 * 128, decodeCr, 0, 128 * 128);

            performInvZigzag(decodeY, uYbytes);
            performInvZigzag(decodeCb, uCbbytes);
            performInvZigzag(decodeCr, uCrbytes);

            Buffer.BlockCopy(uYbytes, 0, Ybytes, 0, 256 * 256);
            Buffer.BlockCopy(uCbbytes, 0, Cbbytes, 0, 128 * 128);
            Buffer.BlockCopy(uCrbytes, 0, Crbytes, 0, 128 * 128);

            performIDCT(Ybytes, calcY, dctY, lumQuan);
            performIDCT(Cbbytes, calcCb, dctCb, chromQuan);
            performIDCT(Crbytes, calcCr, dctCr, chromQuan);

            Y = convert2DArray(dctY, 256 * 256);
            Cb = convert2DArray(dctCb, 128 * 128);
            Cr = convert2DArray(dctCr, 128 * 128);
        }

        public void loadData()
        {
            RGBtoYCbCr();

            Cb = subSample(Cb);
            Cr = subSample(Cr);

            dctY = new double[srcImage.Width, srcImage.Height];
            dctCb = new double[srcImage.Width / 2, srcImage.Height / 2];
            dctCr = new double[srcImage.Width / 2, srcImage.Height / 2];

            calcY = convert1DArray(Y, srcImage.Width, srcImage.Height);
            calcCb = convert1DArray(Cb, srcImage.Width / 2, srcImage.Height / 2);
            calcCr = convert1DArray(Cr, srcImage.Width / 2, srcImage.Height / 2);

            Ybytes = new sbyte[srcImage.Width, srcImage.Height];
            Cbbytes = new sbyte[srcImage.Width / 2, srcImage.Height / 2];
            Crbytes = new sbyte[srcImage.Width / 2, srcImage.Height / 2];

            uYbytes = new byte[256, 256];
            uCbbytes = new byte[128, 128];
            uCrbytes = new byte[128, 128];

            initZigCoord();
        }

        public void setPicBoxImage(PictureBox picBox, Bitmap image)
        {
            picBox.Image = image;
        }

        #region Motion Vectors

        public void loadMVImages()
        {
            OpenFileDialog imageDialog = new OpenFileDialog();
            if (imageDialog.ShowDialog() == DialogResult.OK)
            {
                motiondogSrc = new Bitmap(Image.FromFile(imageDialog.FileName));
            }
            if (imageDialog.ShowDialog() == DialogResult.OK)
            {
                motiondogDest = new Bitmap(Image.FromFile(imageDialog.FileName));
            }

            setPicBoxImage(srcPicture, motiondogSrc);
            setPicBoxImage(destPicture, motiondogDest);

            bDrawGrid = true;

            MVYCbCrtoRGB();

            findMotionVectors();
        }

        public void findMotionVectors()
        {
            //300 / 8 for number of macroblocks
            vectors = new motionVec[307 / 8, 307 / 8];
            
            for (int y = 0; y < 300 - 4; y += 8)
            {
                for (int x = 0; x < 300 - 4; x += 8)
                {
                    vectors[y / 8, x / 8] = getMotionVec(x + 4, y + 4);
                }
            }
        }

        public motionVec getMotionVec(int xCoord, int yCoord)
        {
            motionVec vector = new motionVec(0, 0);

            
            double minDist = calculateDiff(xCoord, yCoord, xCoord, yCoord);
            
            if (minDist == 0)
            {
                return vector;
            }

            for (int y = -SEARCH_AREA; y <= SEARCH_AREA; y++)
            {
                if (yCoord + y - 4 < 0 || yCoord + y + 4 >= 300)
                {
                    continue;
                }

                for (int x = -SEARCH_AREA; x <= SEARCH_AREA; x++)
                {
                    if (xCoord + x - 4 < 0 || xCoord + x + 4 >= 300)
                    {
                        continue;
                    }

                    double result = calculateDiff(xCoord, yCoord, xCoord + x, yCoord + y);
                    if (result < minDist)
                    {
                        minDist = result;
                        vector = new motionVec(x, y);
                    }
                }
            }

            return vector;
        }

        public double calculateDiff(int xOrg, int yOrg, int xOff, int yOff)
        {
            double diff = 0;

            for (int y = -4; y < 4; y++)
            {
                for (int x = -4; x < 4; x++)
                {
                    diff += Math.Abs(MVsrcY[yOrg + y, xOrg + x] - MVdestY[yOff + y, xOff + x]);
                }
            }

            return diff;
        }

        public void destPicture_Paint(object sender, PaintEventArgs e)
        {
            if (bDrawGrid)
            {
                Graphics g = e.Graphics;

                Pen pen = new Pen(Color.Black);

                for (int i = 0; i < 300; i += 8)
                {
                    g.DrawLine(pen, 0, i, 300, i);
                    g.DrawLine(pen, i, 0, i, 300);
                }

                pen = new Pen(Color.Red);

                for (int y = 0; y < 300; y += 8)
                {
                    for (int x = 0; x < 300; x += 8)
                    {
                        g.DrawLine(pen, x + 4, y + 4, x + 4 + vectors[y / 8, x / 8].x, y + 4 + vectors[y / 8, x/ 8].y);
                    }
                }
            }
        }

        #endregion

        private void srcPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog imageDialog = new OpenFileDialog();
            Bitmap fileImage = null;
            if (imageDialog.ShowDialog() == DialogResult.OK)
            {
                fileImage = new Bitmap(Image.FromFile(imageDialog.FileName));
            }
            srcPicture.Image = fileImage;

            srcImage = new Bitmap(fileImage);

            loadData();

            bDrawGrid = false;
        }

        #region Display toolstrip items

        private void redComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap testPic = new Bitmap(srcImage);
            for (int x = 0; x < testPic.Width; x++)
            {
                for (int y = 0; y < testPic.Height; y++)
                {
                    Color pixelColor = testPic.GetPixel(x, y);
                    byte test = pixelColor.R;
                    Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                    testPic.SetPixel(x, y, newColor);
                }
            }
            setPicBoxImage(destPicture, testPic);
        }

        private void greenComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap testPic = new Bitmap(srcImage);
            for (int x = 0; x < testPic.Width; x++)
            {
                for (int y = 0; y < testPic.Height; y++)
                {
                    Color pixelColor = testPic.GetPixel(x, y);
                    Color newColor = Color.FromArgb(0, pixelColor.G, 0);
                    testPic.SetPixel(x, y, newColor);
                }
            }
            setPicBoxImage(destPicture, testPic);
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap testPic = new Bitmap(srcImage);
            for (int x = 0; x < testPic.Width; x++)
            {
                for (int y = 0; y < testPic.Height; y++)
                {
                    Color pixelColor = testPic.GetPixel(x, y);
                    Color newColor = Color.FromArgb(0, 0, pixelColor.B);
                    testPic.SetPixel(x, y, newColor);
                }
            }
            setPicBoxImage(destPicture, testPic);
        }

        private void yCbCrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Y = new double[Y.Length];
            //Cr = new double[Y.Length / 4];
            //Cb = new double[Y.Length / 4];

            double[] tempCb = superSample(Cb);
            double[] tempCr = superSample(Cr);

            YCbCrtoRGB(Y, tempCb, tempCr);
        }

        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Y = new double[Y.Length];
            double[] zCr = new double[Y.Length];
            double[] zCb = new double[Y.Length];

            YCbCrtoRGB(Y, zCr, zCb);
        }

        private void crToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] zY = new double[Y.Length];
            //Cr = new double[Y.Length / 4];
            double[] zCb = new double[Y.Length];

            double[] tempCr = superSample(Cr);

            YCbCrtoRGB(zY, zCb, tempCr);
        }

        private void cbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[] zY = new double[Y.Length];
            double[] zCr = new double[Y.Length];

            double[] tempCb = superSample(Cb);

            YCbCrtoRGB(zY, tempCb, zCr);
        }

        #endregion

        private void dCTToolStripMenuItem_Click(object sender, EventArgs e)
        {

            compress();

            //calcY = (double[,])dctY.Clone();
            //calcCb = (double[,])dctCb.Clone();
            //calcCr = (double[,])dctCr.Clone();

            decompress();

        }

        private void showVectorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadMVImages();
        }

        private void compressImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compress();

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Custom DigiPro Jpeg|*.garbo";
            save.ShowDialog();

            if (save.FileName != "")
            {
                FileStream fs = (FileStream)save.OpenFile();

                fs.Write(stream, 0, stream.Length);

                fs.Close();
            }

            Array.Clear(stream, 0, stream.Length);
        }

        private void decompressImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();

            if (open.FileName != "")
            {
                FileStream fs = (FileStream)open.OpenFile();

                fs.Read(stream, 0, stream.Length);

                fs.Close();
            }

            decompress();

            double[] tempCb = superSample(Cb);
            double[] tempCr = superSample(Cr);

            YCbCrtoRGB(Y, tempCb, tempCr);
        }
    }
}
