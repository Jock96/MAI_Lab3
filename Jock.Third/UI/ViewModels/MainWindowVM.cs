namespace UI.ViewModels
{
    using System.Drawing;
    using System.Windows.Media;

    using UI.Commands;

    /// <summary>
    /// Вью-модель главного окна.
    /// </summary>
    public class MainWindowVM : BaseVM
    {
        /// <summary>
        /// Вью-модель главного окна.
        /// </summary>
        public MainWindowVM()
        {
            LoadCommand = new LoadCommand();
        }

        #region Изображения.

        /// <summary>
        /// Битмап загруженного изображения.
        /// </summary>
        private Bitmap _imageBitmap;

        /// <summary>
        /// Битмап загруженного изображения.
        /// </summary>
        public Bitmap ImageBitmap
        {
            get => _imageBitmap;
            set
            {
                _imageBitmap = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Конвертированное изображение.
        /// </summary>
        private ImageSource _convertedImage;

        /// <summary>
        /// Конвертированное изображение.
        /// </summary>
        public ImageSource ConvertedImage
        {
            get => _convertedImage;
            set
            {
                _convertedImage = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Загруженное изображение.
        /// </summary>
        private ImageSource _image;

        /// <summary>
        /// Загруженное изображение.
        /// </summary>
        public ImageSource Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Команды.

        /// <summary>
        /// Загрузить изображение.
        /// </summary>
        public LoadCommand LoadCommand { get; set; }

        #endregion
    }
}
