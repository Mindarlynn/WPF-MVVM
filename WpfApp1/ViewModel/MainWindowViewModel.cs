using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1.ViewModel
{
    class MainWindowViewModel : Interface.NotifyPropertyChanged
    {
        readonly Pattern.Factory.StudentFactory factory = new Pattern.Factory.StudentFactory();
        private IEnumerable<Model.Student> foundStudents;

        public IEnumerable<Model.Student> FoundStudents
        {
            get
            {
                return foundStudents;
            }
            set
            {
                foundStudents = value;
                OnPropertyChanged();
            }
        }

        private Model.Student selectedStudent;
        public Model.Student SelectedStudent
        {
            get
            {
                return selectedStudent;
            }
            set
            {
                selectedStudent = value;
                OnPropertyChanged();
            }
        }

        private ICommand readCommand;
        public ICommand ReadCommand
        {
            get
            {
                return (readCommand) ?? (readCommand = new Command.DelegateCommand(Read));
            }
        }

        private void Read()
        {
            FoundStudents = factory.GetAllStudents();
        }

        private ICommand exportCommand;
        public ICommand ExportCommand
        {
            get
            {
                return (exportCommand) ?? (exportCommand = new Command.DelegateCommand(Export));
            }
        }

        private void Export()
        {
            if (FoundStudents == null || FoundStudents.Count() <= 0) return;
            using (var stream = new StreamWriter(File.OpenWrite(@"C:\Users\xklest\Desktop\result.csv")))
            {
                stream.WriteLine(Model.Student.Header);
                foreach(var student in FoundStudents)
                {
                    stream.WriteLine(student.ToString());
                }
            }
            MessageBox.Show("Export Done", "Done");
        }

        private ICommand captureCommand;
        public ICommand CaptureCommand
        {
            get
            {
                return (captureCommand) ?? (captureCommand = new Command.DelegateCommand(Capture));
            }
        }

        public void Capture(object obj)
        {
            var grid = obj as System.Windows.Controls.Grid;

            const double dpi_coef = 2;
            const double dpi = 96 * dpi_coef;

            var width = grid.ColumnDefinitions.Sum((col) =>
            {
                return col.ActualWidth;
            }) * dpi_coef;
            var height = grid.RowDefinitions.Sum((row) =>
            {
                return row.ActualHeight;
            }) * dpi_coef;

            var capture = new RenderTargetBitmap((int)width, (int)height, dpi, dpi, PixelFormats.Default);
            capture.Render(grid);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(capture));

            using (var stream = new FileStream(@"C:\Users\xklest\Desktop\capture.png", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                encoder.Save(stream);
            }

            encoder.Frames.Clear();
            capture.Clear();

            MessageBox.Show("Capture Done", "Done");
        }

        ICommand openCommand;
        public ICommand OpenCommand
        {
            get
            {
                return (openCommand) ?? (openCommand = new Command.DelegateCommand(Open));
            }
        }

        private void Open()
        {
            new MainWindow2()
            {
                DataContext = this
            }.Show();
        }

        public void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            DependencyObject current = sender as DependencyObject;
            DependencyObject parent;
            do
            {
                parent = LogicalTreeHelper.GetParent(current);
                current = parent;
            } while (!(parent is Window));

            new MainWindow2()
            {
                DataContext = parent.GetValue(FrameworkElement.DataContextProperty)
            }.Show();
        }

        public void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            /*
            if (e.Delta > 0)
                MessageBox.Show("pos");
            else if (e.Delta < 0)
                MessageBox.Show("neg");
            e.Handled = true;
            */
        }

        public void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            /*
            var pos = e.GetPosition(sender as UIElement);
            MessageBox.Show($"X: {pos.X}, Y: {pos.Y}");
            e.Handled = true;   
            */
        }
    }
}
