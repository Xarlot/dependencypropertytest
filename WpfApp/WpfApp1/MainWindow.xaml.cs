
using System.Diagnostics;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var testClass = new TestClass<int>();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 200000; i++)
                testClass.Test++;
            MessageBox.Show(sw.ElapsedMilliseconds.ToString());

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var testClass = new TestClass<int>();
            Stopwatch sw = Stopwatch.StartNew();
            int test = 0;
            for (int i = 0; i < 200000; i++)
                test += testClass.Test;

            MessageBox.Show(sw.ElapsedMilliseconds.ToString());
        }
    }

    public class TestClass<T> : DependencyObject
    {
        T test;
        public static readonly DependencyProperty TestProperty = DependencyProperty.Register("Test", typeof(T), typeof(TestClass<T>),
            new PropertyMetadata(default(T), (d, e) => ((TestClass<T>)d).TestChanged((T)e.OldValue, (T)e.NewValue)));

        private void TestChanged(T oldValue, T newValue)
        {
            test = newValue;
        }

        public T Test {
            get => (T)GetValue(TestProperty);
            set => SetValue(TestProperty, value);
        }
    }
}
