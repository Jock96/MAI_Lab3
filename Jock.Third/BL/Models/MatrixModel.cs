namespace BL.Models
{
    using System;

    /// <summary>
    /// Модели матриц преобразования.
    /// </summary>
    public static class MatrixModel
    {
        /// <summary>
        /// Вейвлет Хаара.
        /// </summary>
        public static double[,] HaarWavelet
        {
            get => new double[,]
                { { 1 / Math.Sqrt(2), 1 / Math.Sqrt(2) },
                { 1 / Math.Sqrt(2), - 1 / Math.Sqrt(2) } };
        }

        /// <summary>
        /// Вейвлет Добеши.
        /// </summary>
        public static double[] DaubechiesWavelet
        {
            get => new double[]
                { (1 + Math.Sqrt(3)) / (4 * Math.Sqrt(2)),
                (3 + Math.Sqrt(3)) / (4 * Math.Sqrt(2)),
                (3 - Math.Sqrt(3)) / (4 * Math.Sqrt(2)),
                (1 - Math.Sqrt(3)) / (4 * Math.Sqrt(2)) };
        }
    }
}
