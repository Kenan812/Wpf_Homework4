using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_Homework4.Services;
using Wpf_Homework4.ViewModel;

namespace Wpf_Homework4.MyControls
{
    /// <summary>
    /// Interaction logic for RatingControl.xaml
    /// </summary>
    public partial class RatingControl : UserControl, INotifyPropertyChanged
    {
        private List<Image> imageList; 

        bool isClicked = false;

        public int RatingValue
        {
            get { return (int)GetValue(RateControlValueProperty); }
            set { SetValue(RateControlValueProperty, value); }
        }

        public static readonly DependencyProperty RateControlValueProperty =
            DependencyProperty.Register(nameof(RatingValue), typeof(int), typeof(RatingControl),
                new PropertyMetadata());


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string proppertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proppertyName));
        }






        public RatingControl()
        {
            InitializeComponent();

            imageList = new List<Image> { i1, i2, i3, i4, i5 };
            for (int i = 0; i < imageList.Count; i++)
            {
                imageList[i].Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "image/blankStar.png"));
            }
        }


        #region Mouse Events


        private void i_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;

            int selectedImage = Int32.Parse(image.Name[1].ToString());


            for (int i = 0; i < selectedImage; i++)
            {
                imageList[i].Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "image/coloredStar.png"));
            }

            for (int i = selectedImage; i < 5; i++)
            {
                imageList[i].Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "image/blankStar.png"));
            }
        }

        private void i_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isClicked = true;
            Image image = sender as Image;

            RatingValue = Int32.Parse(image.Name[1].ToString());
        }

        private void i_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!isClicked)
            {
                Image image = sender as Image;

                for (int i = 0; i < 5; i++)
                {
                    imageList[i].Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "image/blankStar.png"));
                }
            }

            else
            {
                for (int i = 0; i < RatingValue; i++)
                {
                    imageList[i].Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "image/coloredStar.png"));
                }

                for (int i = RatingValue; i < 5; i++)
                {
                    imageList[i].Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "image/blankStar.png"));
                }
            }
        }


        #endregion


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (RatingValue != 0) isClicked = true;

            for (int i = 0; i < RatingValue; i++)
            {
                imageList[i].Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "image/coloredStar.png"));
            }
        }
    }
}
