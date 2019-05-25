using CalculatorExercise.Contracts;
using System;
using System.Windows.Forms;

namespace CalculatorExercise
{
    public partial class CalculatorForm : Form
    {
        #region Fields
        private ICalculator _calculator { get; set; }
        string operation = string.Empty;
        bool isOperatorClicked = false;
        double result = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for CalculatorForm
        /// </summary>
        /// <param name="calculator">It is object of ICalculator to resolve the dependency </param>
        public CalculatorForm(ICalculator calculator)
        {
            InitializeComponent();
            _calculator = calculator;
        }
        #endregion

        #region Button Click Events
        /// <summary>
        /// Click Event for Button 1, 2 and 3 
        /// </summary>
        /// <param name="sender">Sendor object for Number buttons</param>
        /// <param name="e">EventArgs for Number buttons</param>
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (txtInput.Text == "0" || isOperatorClicked)
                txtInput.Clear();

            isOperatorClicked = false;
            Button btnNumber = (Button)sender;
            txtInput.Text = txtInput.Text + btnNumber.Text;
        }

        /// <summary>
        /// Click Event for Operator Buttons
        /// </summary>
        /// <param name="sender">Sendor object for Operator Buttons</param>
        /// <param name="e">EventArgs for Operator Buttons</param>
        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button btnOperator = (Button)sender;

            if (result != 0)
            {
                PerformCalculation();
            }
            else
            {
                result = Double.Parse(txtInput.Text);
            }
            operation = btnOperator.Text;
            isOperatorClicked = true;

        }

        /// <summary>
        /// Click Event for Result Button
        /// </summary>
        /// <param name="sender">Sendor object for Result Button</param>
        /// <param name="e">EventArgs for Result Button</param>
        private void btnResult_Click(object sender, EventArgs e)
        {
            PerformCalculation();
        }

        /// <summary>
        /// Click Event for Clear Button
        /// </summary>
        /// <param name="sender">Sendor object for Clear Button</param>
        /// <param name="e">EventArgs for Clear Button</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearResult();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This method is used for performing calculation
        /// </summary>
        private void PerformCalculation()
        {
            try
            {
                switch (operation)
                {
                    case "+":
                        result = _calculator.Addition(result, double.Parse(txtInput.Text));
                        break;
                    case "/":
                        result = _calculator.Division(result, double.Parse(txtInput.Text));
                        break;
                    default:
                        break;
                }
                txtInput.Text = result.ToString();
            }
            catch (Exception ex)
            {
                ClearResult();
                MessageBox.Show("Inappropriate operation taken :" + ex.Message);
            }
        }

        /// <summary>
        /// It is used for clearing the input textbox and existing calulation result
        /// </summary>
        private void ClearResult()
        {
            txtInput.Text = "0";
            result = 0;
        }
        #endregion
    }
}
