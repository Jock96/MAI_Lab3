namespace UI.Commands
{
    using BL.Helpers;
    using BL.Extensions;

    using Microsoft.Win32;

    using System;
    using System.Drawing;
    using System.Windows;

    using UI.ViewModels;

    /// <summary>
    /// Загрузить изображение.
    /// </summary>
    public class LoadCommand : BaseTCommand<MainWindowVM>
    {
        /// <summary>
        /// Выполнить команду.
        /// </summary>
        /// <param name="parameter">Параметр.</param>
        protected override void Execute(MainWindowVM parameter)
        {
            var fileDialog = new OpenFileDialog
            {
                Filter = @"(*.bmp)|*.bmp",
                InitialDirectory = PathHelper.GetResourcesPath()
            };

            var file = fileDialog.ShowDialog();

            if (!file.HasValue || string.Equals(string.Empty, fileDialog.FileName))
                return;

            try
            {
                using (var fileStream = fileDialog.OpenFile())
                {
                    var bitmap = new Bitmap(fileStream);

                    parameter.ImageBitmap = bitmap;
                    parameter.Image = bitmap.ConvertToImageSource();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось импортировать файл!" +
                    $"\nОшибка: {exception.ToString()}");
            }
        }
    }
}
