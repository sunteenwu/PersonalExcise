using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CInkCanavas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private InkPresenter _inkPresenter;
        public MainPage()
        {
            this.InitializeComponent();
            _inkPresenter = drawInkCanvas.InkPresenter;
            _inkPresenter.InputDeviceTypes =
                CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Touch;
            UpdatePen();
        }

        private void UpdatePen()
        {
            if (_inkPresenter != null)            {
                var defaultAttributes = _inkPresenter.CopyDefaultDrawingAttributes();
                switch (penColor.SelectedValue.ToString())
                {
                    case "Black":
                        defaultAttributes.Color = Colors.Black;
                        break;
                    case "Red":
                        defaultAttributes.Color = Colors.Red;
                        break;
                    case "Blue":
                        defaultAttributes.Color = Colors.Blue;
                        break;
                    case "Green":
                        defaultAttributes.Color = Colors.Green;
                        break;
                }
                _inkPresenter.UpdateDefaultDrawingAttributes(defaultAttributes);
            }
        }
        private async void CopyCommand(InkCanvas canvas)
        {
            canvas.InkPresenter.StrokeContainer.SelectWithLine(new Point(0, 0), new Point(300, 200));
            canvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
        }

        private async void PasterCommand(InkCanvas canvas)
        {
            if (canvas.InkPresenter.StrokeContainer.CanPasteFromClipboard())
            {
                canvas.InkPresenter.StrokeContainer.PasteFromClipboard(new Point(10, 10));
            }
        }

        private void penColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePen();
        }

        private void clearAll_Click(object sender, RoutedEventArgs e)
        {
            _inkPresenter.StrokeContainer.Clear();
        }

        private void copy_Click(object sender, RoutedEventArgs e)
        {
            drawInkCanvas.InkPresenter.StrokeContainer.SelectWithLine(new Point(0, 0), new Point(300, 200));
            drawInkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
        }

        private void paster_Click(object sender, RoutedEventArgs e)
        {
            var test = drawInkCanvas.InkPresenter.StrokeContainer.CanPasteFromClipboard();
            new Windows.UI.Popups.MessageDialog(test.ToString()).ShowAsync();
            //if (drawInkCanvas.InkPresenter.StrokeContainer.CanPasteFromClipboard())
            //{
            drawInkCanvas.InkPresenter.StrokeContainer.PasteFromClipboard(new Point(10, 10));
            //}
        }
    }

}
