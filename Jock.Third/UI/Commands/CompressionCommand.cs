namespace UI.Commands
{
    using UI.ViewModels;

    using BL.Extensions;
    using System.Windows;

    /// <summary>
    /// Команда преобразования Хаара.
    /// </summary>
    public class CompressionCommand : BaseTCommand<MainWindowVM>
    {
        /// <summary>
        /// Выполнить.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        protected override void Execute(MainWindowVM parameter)
        {
            if (parameter.ImageBitmap == null)
            {
                MessageBox.Show("Необходимо загрузить изображение!");
                return;
            }

            if (parameter.IsHaarSelected)
                parameter.ConvertedImage = parameter.ImageBitmap.CompressionByHaarWavelet();

            if (parameter.IsDaubechiesSelected)
                MessageBox.Show("В стадии реализации!");
        }
    }
}
