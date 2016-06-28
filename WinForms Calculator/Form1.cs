using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Calculator
{
    public partial class Form1 : Form
    {

        double ResultValue = 0;
        string OperationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBoxResult.Text = "0";
        }

        
        private void ButtonClick(object sender, EventArgs e)
        {
            if ((TextBoxResult.Text == "0") || (isOperationPerformed))
                TextBoxResult.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            

            if (button.Text == ".")
            {
                if (!TextBoxResult.Text.Contains("."))
                    TextBoxResult.Text = TextBoxResult.Text + button.Text;
            }
            else
                TextBoxResult.Text = TextBoxResult.Text + button.Text;
        }



        private void operatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (ResultValue != 0)
            {
                Result.PerformClick();
                OperationPerformed = button.Text;
                labelCurrentOperation.Text = ResultValue + "" + OperationPerformed;
                isOperationPerformed = true;
            }
            else
            {

                OperationPerformed = button.Text;
                ResultValue = double.Parse(TextBoxResult.Text);
                labelCurrentOperation.Text = ResultValue + "" + OperationPerformed;
                isOperationPerformed = true;
            }
        }

        private void ButtonClickClearEntry(object sender, EventArgs e)
        {
            TextBoxResult.Text = "0";
        }

        private void ButtonClickClear(object sender, EventArgs e)
        {
            TextBoxResult.Text = "0";
            ResultValue = 0;

        }

        private void Equality(object sender, EventArgs e)
        {
            switch(OperationPerformed)
            {
                case "+":
                    TextBoxResult.Text = (ResultValue + double.Parse(TextBoxResult.Text)).ToString();
                    break;
                case "-":
                    TextBoxResult.Text = (ResultValue - double.Parse(TextBoxResult.Text)).ToString();
                    break;
                case "*":
                    TextBoxResult.Text = (ResultValue * double.Parse(TextBoxResult.Text)).ToString();
                    break;
                case "/":
                    TextBoxResult.Text = (ResultValue / double.Parse(TextBoxResult.Text)).ToString();
                    break;
                
            }
            ResultValue = double.Parse(TextBoxResult.Text);
            labelCurrentOperation.Text = " ";
        }
    }
}
