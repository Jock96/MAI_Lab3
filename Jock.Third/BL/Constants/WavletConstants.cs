namespace BL.Constants
{
    using System;

    public static class WavletConstants
    {
        /// <summary>
        /// Положительная константа Хаара.
        /// </summary>
        public static readonly double MajorHaarWavletPart = 1 / Math.Sqrt(2);

        /// <summary>
        /// Константа Добеши (d0).
        /// </summary>
        public static readonly double DaubechiesWavletD0 = (1 + Math.Sqrt(3))/(4 * Math.Sqrt(2));

        /// <summary>
        /// Константа Добеши (d1).
        /// </summary>
        public static readonly double DaubechiesWavletD1 = (3 + Math.Sqrt(3)) / (4 * Math.Sqrt(2));

        /// <summary>
        /// Константа Добеши (d2).
        /// </summary>
        public static readonly double DaubechiesWavletD2 = (3 - Math.Sqrt(3)) / (4 * Math.Sqrt(2));

        /// <summary>
        /// Константа Добеши (d4).
        /// </summary>
        public static readonly double DaubechiesWavletD3 = (1 - Math.Sqrt(3)) / (4 * Math.Sqrt(2));
    }
}
