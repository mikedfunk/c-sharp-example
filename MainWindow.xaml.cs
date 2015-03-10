using System;
using System.Windows;
using System.Windows.Controls;

namespace VisualCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// the current state of the calculator (default: Operation.Start)
        /// </summary>
        private Operation currentOperation = Operation.Start;

        /// <summary>
        /// the current total (finished operation)
        /// </summary>
        double currentValue = 0;

        /// <summary>
        /// the different types of operations
        /// </summary>
        enum Operation { Add, Subtract, Multiply, Divide, Equals, Start };

        /// <summary>
        /// the window provided by asp.net
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            txtOut.Text = currentValue.ToString();
        }

        /// <summary>
        /// when a number button is clicked, either calculate it or remember it for
        /// calculating when we have another number
        /// </summary>
        /// <param name="sender">the clicked button</param>
        /// <param name="e"></param>
        private void BtnEntry_Click(object sender, RoutedEventArgs e)
        {
            // get the clicked value
            Button clickedButton = (Button)sender;

            // if the operation is start, set the number
            int clickedValue = Int32.Parse(clickedButton.Content.ToString());
            if (currentOperation != Operation.Start)
            {
                // calculate the operation, setting the new current value
                Calculate(currentOperation, clickedValue);
            }
            else
            {
                currentValue = clickedValue;
            }

            // display the number clicked
            txtOut.Text = clickedButton.Content.ToString();
        }

        /// <summary>
        /// yeah, this is poorly designed but it's good language practice. This performs
        /// the delayed operation when a second number is chosen and sets the current value.
        /// </summary>
        /// <param name="op"></param>
        /// <param name="newValue"></param>
        private void Calculate(Operation op, double newValue)
        {
            switch (currentOperation)
            {
                // switch on the current operation to perform the different operations
                // to calculate the first number, the operator, and the second number
                case Operation.Add:
                    currentValue += newValue;
                    break;
                case Operation.Subtract:
                    currentValue -= newValue;
                    break;
                case Operation.Divide:
                    currentValue = currentValue / newValue;
                    break;
                case Operation.Multiply:
                    currentValue *= newValue;
                    break;
            }
        }

        /// <summary>
        /// click the add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // set the operation type to add,
            // we'll only apply this operation when they enter a second number
            currentOperation = Operation.Add;
        }

        /// <summary>
        /// click the subtract button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubtract_Click(object sender, RoutedEventArgs e)
        {
            // set the operation type to subtract
            // we'll only apply this operation when they enter a second number
            currentOperation = Operation.Subtract;
        }

        /// <summary>
        /// click the multiply button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            // set the operation type to multiply
            // we'll only apply this operation when they enter a second number
            currentOperation = Operation.Multiply;
        }

        /// <summary>
        /// click the divide button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            // set the operation type to divide
            // we'll only apply this operation when they enter a second number
            currentOperation = Operation.Divide;
        }

        /// <summary>
        /// Clear the current results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            // set the operation type to start
            // we'll only apply this operation when they enter a second number
            currentOperation = Operation.Start;

            // set the current value to zero
            currentValue = 0;

            // clear the display
            txtOut.Text = "";
        }

        /// <summary>
        /// Handle the Equals button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            // set the operation type to start
            // but do not reset the current value
            currentOperation = Operation.Start;

            // display the current calculated value,
            // presumably from the previous operation
            txtOut.Text = currentValue.ToString();
        }

    }
}
