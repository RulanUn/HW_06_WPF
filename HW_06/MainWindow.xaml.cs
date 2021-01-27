

using System;
using System.Windows;
using System.Windows.Controls;


namespace Calculator
{
    public partial class MainWindow : Window
    {
        string operation = "";
        string leftop = "";
        string rightop = "";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)((Button)e.OriginalSource).Content;
            textBlockCalculator.Text += s;
            double num;
            bool result = double.TryParse(s, out num);
            if (result == true)
            {
                if (operation == "")
                    leftop += s;
                else
                    rightop += s;
            }
            else
            {
                if (s == "=")
                {
                    Update_RightOp();
                    textBlockCalculator.Text = rightop;
                    operation = "";
                }
                else if (s == "AC")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBlockCalculator.Text = "";
                }
                else
                {
                    if (rightop != "")
                    {
                        Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }

        private void Update_RightOp()
        {
            double num1 = double.Parse(leftop);
            double num2 = double.Parse(rightop);

            switch (operation)
            {
                case "+":
                    rightop = (num1 + num2).ToString();
                    break;
                case "-":
                    rightop = (num1 - num2).ToString();
                    break;
                case "*":
                    rightop = (num1 * num2).ToString();
                    break;
                case "/":
                    rightop = (num1 / num2).ToString();
                    break;
                default:
                    break;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement c in LayoutRootCalculator.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UsualCalculator_Button(object sender, RoutedEventArgs e)
        {
            engineeringButtons.Visibility = Visibility.Hidden;
        }

        private void EngineeringCalculator_Button(object sender, RoutedEventArgs e)
        {
            engineeringButtons.Visibility = Visibility.Visible;
        }

        private void About_Button(object sender, RoutedEventArgs e)
        {
            HW_06.About about = new HW_06.About();
            about.Show();
        }
    }
}
