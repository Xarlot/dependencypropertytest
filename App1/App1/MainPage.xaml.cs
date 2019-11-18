using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var testClass = new TestClass<int>();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 200000; i++)
                testClass.Test = i++;
            MessageDialog dialog = new MessageDialog(sw.ElapsedMilliseconds.ToString());
            await dialog.ShowAsync();

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var testClass = new TestClass<int>();
            Stopwatch sw = Stopwatch.StartNew();
            int test = 0;
            for (int i = 0; i < 200000; i++)
                test += testClass.Test;

            MessageDialog dialog = new MessageDialog(sw.ElapsedMilliseconds.ToString());
            await dialog.ShowAsync();
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
