﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;
        public Form1()
        {
            InitializeComponent();
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        public void StartTheQuiz()
        {
            //Вот зачем все это спрашивать?
            Random randomizer = new Random();
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;
            //Ну работает все же
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;
            timeLeft = 30;
            timeLabel.Text = "30 секунд";
            timer1.Start();
        }
        private bool CheckTheAnswer()
        {
            //Может все?
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void startButton_Click_1(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("У тебя все ответы правильные!",
                    "вай молодес!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + "секунды";
            }
            else
            {
                //Как дела?
                timer1.Stop();
                timeLabel.Text = "Время вышло!";
                MessageBox.Show("ты не успел", "сам виноват!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
                
            }
            if (timeLeft <= 5)
            {
                timeLabel.BackColor = Color.Red;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            //Я делал старался а вы придираетесь 
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            { }
            int lengthofAnswer = answerBox.Value.ToString().Length;
            answerBox.Select(0, lengthofAnswer);
        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            { }
            int lengthofAnswer = answerBox.Value.ToString().Length;
            answerBox.Select(0, lengthofAnswer);
        }

        private void product_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            { }
            int lengthofAnswer = answerBox.Value.ToString().Length;
            answerBox.Select(0, lengthofAnswer);
        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            { }
            int lengthofAnswer = answerBox.Value.ToString().Length;
            answerBox.Select(0, lengthofAnswer);
        }
    }// Звуковой сигнал можно не делать по приказу генерала Гавса
}

 