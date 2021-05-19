using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace OneDimetionalArraysReview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[] arr = new int[17];
            int s = 1;

            do
            {
                arr[s] = 3 * s - 2;
                s++;
            }
            while (s < 17);

            MessageBox.Show(arr[5].ToString());

            int x = arr[4];

            MessageBox.Show(arr[x + 5].ToString());
        }

        /*
         * DataEntry - inputs the names of students and their history marks (the entry of
         * each students’ history mark should be dummy proofed) and places them into the
         * appropriate arrays.
         */
        private void button2_Click(object sender, EventArgs e) => DataEntry();
        List<string> studentNames = new List<string>();
        List<int> studentMarks = new List<int>();
        private void DataEntry()
        {
            while (true)
            {
                string currentName = Interaction.InputBox("Enter the student name.", "Student Name", "");
                studentNames.Add(currentName);

                int currentMark = Convert.ToInt32(Interaction.InputBox("Enter the student mark.", "Student Mark", ""));
                if (currentMark < 0 || currentMark > 100)
                    MessageBox.Show("Please enter a valid mark.");
                else
                    studentMarks.Add(Convert.ToInt32(currentMark));

                string continueOrBreak = Interaction.InputBox("Continue? Y/N.", "Continue?", "").ToLower();
                if (continueOrBreak == "n")
                    break;
            }
        }

        /*
         * PassFail - Displays the names and history marks of the students in columns with
         * appropriate titles. Beside each students mark include ‘pass’ or ‘fail’
         */
        private void button3_Click(object sender, EventArgs e) => PassOrFail();
        private void PassOrFail()
        {
            TxtDisplay.Text = "";
            TxtDisplay.Text += "Names:\tMarks:\tPassed or Failed:";

            for (int i = 0; i < studentNames.Count; i++)
            {
                if (studentMarks[i] < 50)
                    TxtDisplay.Text += studentNames[i] + "\t" + studentMarks[i] + "\t" + "Fail." + Environment.NewLine;
                else
                    TxtDisplay.Text += studentNames[i] + "\t" + studentMarks[i] + "\t" + "Pass." + Environment.NewLine;
            }
        }


        /*
         * Between - Displays the name(s) of the people with marks between 50 and 75.
         */
        private void button4_Click(object sender, EventArgs e) => Between();
        private void Between()
        {
            TxtDisplay.Text = "";
            TxtDisplay.Text += "People whose marks are between 50 and 75." + Environment.NewLine;
            for (int i = 0; i < studentMarks.Count; i++)
            {
                if (studentMarks[i] >= 50 && studentMarks[i] <= 75)
                {
                    TxtDisplay.Text += studentNames[i] + Environment.NewLine;
                }
            }
        }


        /*
         * Deduct5 - Deducts 5 from all the marks
         */
        private void button5_Click(object sender, EventArgs e) => Deduct5();
        private void Deduct5()
        {
            foreach (int mark in studentMarks)
            {
                _ = mark - 5;
            }

            MessageBox.Show("5 has been removed from all marks.");
        }

        /*
         * HighLow - Determines the lowest and highest history marks and the names of the
         * students who obtained those marks
         */
        private void button6_Click(object sender, EventArgs e) => HighLow();
        private void HighLow()
        {
            string highestMarkName = "";
            string lowestMarkName = "";
            int highestMark = -1;
            int lowestMark = 101;

            for (int i = 0; i < studentMarks.Count; i++)
            {
                if ( lowestMark < studentMarks[i] )
                {
                    lowestMark = studentMarks[i];
                    lowestMarkName = studentNames[i];
                }

                if (highestMark > studentMarks[i])
                {
                    highestMark = studentMarks[i];
                    highestMarkName = studentNames[i];
                }
            }

            TxtDisplay.Text = "";
            TxtDisplay.Text += "Highest Mark student:\t" + highestMarkName + "\tMark:\t" + highestMark;
            TxtDisplay.Text += "Lowest Mark student:\t" + lowestMarkName + "\tMark:\t" + lowestMark;
        }

        /*
         * CategoryCount - Determines the number of “A” marks (80-100) , the number of
         * “B” marks (70-79), and the number of “F” marks (<50). Display the results with
         * appropriate titles.
         */
        private void button7_Click(object sender, EventArgs e) => CategoryCount();
        private void CategoryCount()
        {
            TxtDisplay.Text = "";
            TxtDisplay.Text += "Total A's:\tTotal B's:\tTotal F's:";
            int countA = 0;
            int countB = 0;
            int countF = 0;

            for (int i = 0; i < studentMarks.Count; i++)
            {
                if (studentMarks[i] >= 80)
                    countA++;
                else if (studentMarks[i] >= 70 && studentMarks[i] <= 79)
                    countB++;
                else if (studentMarks[i] < 50)
                    countF++;
            }

            TxtDisplay.Text += countA + "\t" + countB + "\t" + countF + Environment.NewLine;
        }

    }
}
