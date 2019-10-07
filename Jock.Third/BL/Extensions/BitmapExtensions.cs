namespace BL.Extensions
{
    using BL.Constants;
    using System;
    using System.Drawing;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Класс расширений для <see cref="Bitmap"/>.
    /// </summary>
    public static class BitmapExtensions
    {

        /// <summary>
        /// Конвертирует в ресурс изображения.
        /// </summary>
        /// <param name="bitmapSource">Изображение полученное через <see cref="Bitmap"/>.</param>
        public static ImageSource ConvertToImageSource(
            this Bitmap bitmapSource) => System.Windows.Interop
            .Imaging.CreateBitmapSourceFromHBitmap(
                bitmapSource.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

        /// <summary>
        /// Преобразовать методом Добеши.
        /// </summary>
        /// <param name="bitmap">Изображение.</param>
        /// <returns>Возвращает конвертированое изображение.</returns>
        public static ImageSource CompressionByDaubechiesWavelet(this Bitmap bitmap)
        {
            var width = bitmap.Width;
            var height = bitmap.Height;

            if (bitmap.Width % 2 != 0)
                width -= 1;

            if (bitmap.Height % 2 != 0)
                height -= 1;

            var resizedBitmap = new Bitmap(bitmap, new System.Drawing.Size(width, height));
            var bitmapCopy = new Bitmap(resizedBitmap.Width, resizedBitmap.Height);

            var offset = width / 4;

            for (var yIndex = 0; yIndex < height; yIndex++)
                for (int xIndex = 0, xIndexWithoutOffset = 0;
                    xIndex < width; xIndex += 4, xIndexWithoutOffset++)
                {
                    var firstPixel = resizedBitmap.GetPixel(xIndex, yIndex);
                    var secondPixel = resizedBitmap.GetPixel(xIndex + 1, yIndex);
                    var thirdPixel = resizedBitmap.GetPixel(xIndex + 2, yIndex);
                    var fourthPixel = resizedBitmap.GetPixel(xIndex + 3, yIndex);

                    var rPixelMajor = ToByteValue(Math.Ceiling(
                        WavletConstants.DaubechiesWavletD0 * firstPixel.R + 
                        WavletConstants.DaubechiesWavletD1 * secondPixel.R + 
                        WavletConstants.DaubechiesWavletD2 * thirdPixel.R + 
                        WavletConstants.DaubechiesWavletD3 * fourthPixel.R));

                    var gPixelMajor = ToByteValue(Math.Ceiling(
                        WavletConstants.DaubechiesWavletD0 * firstPixel.G +
                        WavletConstants.DaubechiesWavletD1 * secondPixel.G +
                        WavletConstants.DaubechiesWavletD2 * thirdPixel.G +
                        WavletConstants.DaubechiesWavletD3 * fourthPixel.G));

                    var bPixelMajor = ToByteValue(Math.Ceiling(
                        WavletConstants.DaubechiesWavletD0 * firstPixel.B +
                        WavletConstants.DaubechiesWavletD1 * secondPixel.B +
                        WavletConstants.DaubechiesWavletD2 * thirdPixel.B +
                        WavletConstants.DaubechiesWavletD3 * fourthPixel.B));

                    var rPixelMinor = ToByteValue(Math.Ceiling(
                        WavletConstants.DaubechiesWavletD3 * firstPixel.R -
                        WavletConstants.DaubechiesWavletD2 * secondPixel.R +
                        WavletConstants.DaubechiesWavletD1 * thirdPixel.R -
                        WavletConstants.DaubechiesWavletD0 * fourthPixel.R));

                    var gPixelMinor = ToByteValue(Math.Ceiling(
                        WavletConstants.DaubechiesWavletD3 * firstPixel.G -
                        WavletConstants.DaubechiesWavletD2 * secondPixel.G +
                        WavletConstants.DaubechiesWavletD1 * thirdPixel.G -
                        WavletConstants.DaubechiesWavletD0 * fourthPixel.G));

                    var bPixelMinor = ToByteValue(Math.Ceiling(
                        WavletConstants.DaubechiesWavletD3 * firstPixel.B -
                        WavletConstants.DaubechiesWavletD2 * secondPixel.B +
                        WavletConstants.DaubechiesWavletD1 * thirdPixel.B -
                        WavletConstants.DaubechiesWavletD0 * fourthPixel.B));

                    var colorMajor = System.Drawing.Color.FromArgb(rPixelMajor, gPixelMajor, bPixelMajor);
                    var colorMinor = System.Drawing.Color.FromArgb(rPixelMinor, gPixelMinor, bPixelMinor);

                    bitmapCopy.SetPixel(xIndexWithoutOffset, yIndex, colorMajor);
                    bitmapCopy.SetPixel(xIndexWithoutOffset + offset, yIndex, colorMinor);
                }

            offset = height / 4;

            var resultBitmap = new Bitmap(bitmapCopy.Width, bitmapCopy.Height);

            for (var xIndex = 0; xIndex < width / 2; xIndex++)
            {
                for (int yIndex = 0, yIndexWithoutOffset = 0;
                    yIndex < height; yIndex += 4, yIndexWithoutOffset++)
                {
                    var firstPixel = bitmapCopy.GetPixel(xIndex, yIndex);
                    var secondPixel = bitmapCopy.GetPixel(xIndex, yIndex + 1);
                    var thirdPixel = bitmapCopy.GetPixel(xIndex, yIndex + 2);
                    var fourthPixel = bitmapCopy.GetPixel(xIndex, yIndex + 3);

                    var rPixelMajor = ToByteValue(Math.Ceiling(
                        WavletConstants.DaubechiesWavletD0 * firstPixel.R +
                        WavletConstants.DaubechiesWavletD1 * secondPixel.R +
                        WavletConstants.DaubechiesWavletD2 * thirdPixel.R +
                        WavletConstants.DaubechiesWavletD3 * fourthPixel.R));

                    var gPixelMajor = ToByteValue(Math.Ceiling(
                        WavletConstants.DaubechiesWavletD0 * firstPixel.G +
                        WavletConstants.DaubechiesWavletD1 * secondPixel.G +
                        WavletConstants.DaubechiesWavletD2 * thirdPixel.G +
                        WavletConstants.DaubechiesWavletD3 * fourthPixel.G));

                    var bPixelMajor = ToByteValue(Math.Ceiling(
                        WavletConstants.DaubechiesWavletD0 * firstPixel.B +
                        WavletConstants.DaubechiesWavletD1 * secondPixel.B +
                        WavletConstants.DaubechiesWavletD2 * thirdPixel.B +
                        WavletConstants.DaubechiesWavletD3 * fourthPixel.B));

                    var rPixelMinor = ToByteValue(Math.Ceiling(
                        WavletConstants.DaubechiesWavletD3 * firstPixel.R -
                        WavletConstants.DaubechiesWavletD2 * secondPixel.R +
                        WavletConstants.DaubechiesWavletD1 * thirdPixel.R -
                        WavletConstants.DaubechiesWavletD0 * fourthPixel.R));

                    var gPixelMinor = ToByteValue(Math.Ceiling(
                        WavletConstants.DaubechiesWavletD3 * firstPixel.G -
                        WavletConstants.DaubechiesWavletD2 * secondPixel.G +
                        WavletConstants.DaubechiesWavletD1 * thirdPixel.G -
                        WavletConstants.DaubechiesWavletD0 * fourthPixel.G));

                    var bPixelMinor = ToByteValue(Math.Ceiling(
                        WavletConstants.DaubechiesWavletD3 * firstPixel.B -
                        WavletConstants.DaubechiesWavletD2 * secondPixel.B +
                        WavletConstants.DaubechiesWavletD1 * thirdPixel.B -
                        WavletConstants.DaubechiesWavletD0 * fourthPixel.B));

                    var colorMajor = System.Drawing.Color.FromArgb(rPixelMajor, gPixelMajor, bPixelMajor);
                    var colorMinor = System.Drawing.Color.FromArgb(rPixelMinor, gPixelMinor, bPixelMinor);

                    resultBitmap.SetPixel(xIndex, yIndexWithoutOffset, colorMajor);
                    resultBitmap.SetPixel(xIndex, yIndexWithoutOffset + offset, colorMinor);
                }
            }

            return resultBitmap.ConvertToImageSource();

            //return bitmapCopy.ConvertToImageSource();
        }

        /// <summary>
        /// Преобразовать методом Хаара.
        /// </summary>
        /// <param name="bitmap">Изображение.</param>
        /// <returns>Возвращает конвертированое изображение.</returns>
        public static ImageSource CompressionByHaarWavelet(this Bitmap bitmap)
        {
            var width = bitmap.Width;
            var height = bitmap.Height;

            if (bitmap.Width % 2 != 0)
                width -= 1;

            if (bitmap.Height % 2 != 0)
                height -= 1;

            var resizedBitmap = new Bitmap(bitmap, new System.Drawing.Size(width, height));
            var bitmapCopy = new Bitmap(resizedBitmap.Width, resizedBitmap.Height);

            var offset = width / 2;

            for (var yIndex = 0; yIndex < height; yIndex++)
                for (int xIndex = 0, xIndexWithoutOffset = 0;
                    xIndex < width; xIndex += 2, xIndexWithoutOffset++)
                {
                    var firstPixel = resizedBitmap.GetPixel(xIndex, yIndex);
                    var secondPixel = resizedBitmap.GetPixel(xIndex + 1, yIndex);

                    var rPixelMajor = ToByteValue(Math.Ceiling(WavletConstants.MajorHaarWavletPart * (firstPixel.R + secondPixel.R)));
                    var gPixelMajor = ToByteValue(Math.Ceiling(WavletConstants.MajorHaarWavletPart * (firstPixel.G + secondPixel.G)));
                    var bPixelMajor = ToByteValue(Math.Ceiling(WavletConstants.MajorHaarWavletPart * (firstPixel.B + secondPixel.B)));

                    var rPixelMinor = ToByteValue(Math.Ceiling(WavletConstants.MajorHaarWavletPart * (firstPixel.R - secondPixel.R)));
                    var gPixelMinor = ToByteValue(Math.Ceiling(WavletConstants.MajorHaarWavletPart * (firstPixel.G - secondPixel.G)));
                    var bPixelMinor = ToByteValue(Math.Ceiling(WavletConstants.MajorHaarWavletPart * (firstPixel.B - secondPixel.B)));

                    var colorMajor = System.Drawing.Color.FromArgb(rPixelMajor, gPixelMajor, bPixelMajor);
                    var colorMinor = System.Drawing.Color.FromArgb(rPixelMinor, gPixelMinor, bPixelMinor);

                    bitmapCopy.SetPixel(xIndexWithoutOffset, yIndex, colorMajor);
                    bitmapCopy.SetPixel(xIndexWithoutOffset + offset, yIndex, colorMinor);
                }

            offset = height / 2;

            var resultBitmap = new Bitmap(bitmapCopy.Width, bitmapCopy.Height);

            for (var xIndex = 0; xIndex < width; xIndex++)
                for (int yIndex = 0, yIndexWithoutOffset = 0;
                    yIndex < height; yIndex += 2, yIndexWithoutOffset++)
                {
                    var firstPixel = bitmapCopy.GetPixel(xIndex, yIndex);
                    var secondPixel = bitmapCopy.GetPixel(xIndex, yIndex + 1);

                    var rPixelMajor = ToByteValue(Math.Ceiling(WavletConstants.MajorHaarWavletPart * (firstPixel.R + secondPixel.R)));
                    var gPixelMajor = ToByteValue(Math.Ceiling(WavletConstants.MajorHaarWavletPart * (firstPixel.G + secondPixel.G)));
                    var bPixelMajor = ToByteValue(Math.Ceiling(WavletConstants.MajorHaarWavletPart * (firstPixel.B + secondPixel.B)));

                    var rPixelMinor = ToByteValue(Math.Ceiling(WavletConstants.MajorHaarWavletPart * (firstPixel.R - secondPixel.R)));
                    var gPixelMinor = ToByteValue(Math.Ceiling(WavletConstants.MajorHaarWavletPart * (firstPixel.G - secondPixel.G)));
                    var bPixelMinor = ToByteValue(Math.Ceiling(WavletConstants.MajorHaarWavletPart * (firstPixel.B - secondPixel.B)));

                    var colorMajor = System.Drawing.Color.FromArgb(rPixelMajor, gPixelMajor, bPixelMajor);
                    var colorMinor = System.Drawing.Color.FromArgb(rPixelMinor, gPixelMinor, bPixelMinor);

                    resultBitmap.SetPixel(xIndex, yIndexWithoutOffset, colorMajor);
                    resultBitmap.SetPixel(xIndex, yIndexWithoutOffset + offset, colorMinor);
                }

            return resultBitmap.ConvertToImageSource();
        }

        /// <summary>
        /// Корректное приведение к байту (при выходе за пределы получаются артефакты).
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <returns>Возвращает значение в байтах.</returns>
        private static byte ToByteValue(double value)
        {
            if (value > byte.MaxValue)
                return byte.MaxValue;

            if (value < byte.MinValue)
                return byte.MinValue;

            return (byte)value;
        }
    }
}
