
// The Blank Window item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

using Microsoft.UI.Xaml;
using System.Diagnostics;
using Windows.UI.Popups;

namespace App2 {
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window {
        public MainWindow() {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            var testClass = new TestClass<int>();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 200000; i++)
                testClass.Test = i++;
            Title = sw.ElapsedMilliseconds.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            var testClass = new TestClass<int>();
            Stopwatch sw = Stopwatch.StartNew();
            int test = 0;
            for (int i = 0; i < 200000; i++)
                test += testClass.Test;
            Title = sw.ElapsedMilliseconds.ToString();
        }

    }

    public class TestClass<T> : DependencyObject {
        T test;
        public static readonly DependencyProperty TestProperty = DependencyProperty.Register("Test", typeof(T), typeof(TestClass<T>),
            new PropertyMetadata(default(T), (d, e) => ((TestClass<T>)d).TestChanged((T)e.OldValue, (T)e.NewValue)));

        private void TestChanged(T oldValue, T newValue) {
            test = newValue;
        }

        public T Test {
            get => (T)GetValue(TestProperty);
            set => SetValue(TestProperty, value);
        }
    }
}

