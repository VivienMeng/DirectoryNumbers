using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace directory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Dowork(object sender, EventArgs e)
        {
            List<List<string>> workStrs = new List<List<string>>();

            int maxIndex = SetDataStructure(workStrs);

            int totalDirs = GetTotal(workStrs, maxIndex);

            MessageBox.Show("The total number of directories is : " + totalDirs);
        }

        private static int GetTotal(List<List<string>> workStrs, int maxIndex)
        {
            int totalDirs = 0;
            for (int i = maxIndex; i > 0; i--)
            {
                List<string> uniqueStrings = new List<string>();
                foreach (List<string> strList in workStrs)
                {
                    if (strList.Count >= i)
                    {
                        string concatStr = string.Empty;
                        for (int j = i; j > 0; j--)
                        {
                            concatStr = strList[j - 1] + concatStr;
                        }

                        if (!uniqueStrings.Contains(concatStr))
                        {
                            uniqueStrings.Add(concatStr);
                        }
                    }
                }

                totalDirs = totalDirs + uniqueStrings.Count;
            }

            return totalDirs;
        }

        private int SetDataStructure(List<List<string>> workStrs)
        {
            int maxIndex = 0;
            foreach (string entry in textBox.Lines)
            {
                // get rid of c:
                int indexOfCol = entry.IndexOf(':');
                string temp = string.Empty;
                if (indexOfCol >= 0)
                {
                    temp = entry.Substring(indexOfCol + 1, entry.Length - (indexOfCol + 1));
                }
                else
                {
                    temp = entry;
                }

                temp = temp.Trim('\\');
                List<string> tempStrs = temp.Split('\\').ToList();
                if (tempStrs.Count > maxIndex)
                {
                    maxIndex = tempStrs.Count;
                }
                workStrs.Add(tempStrs);
            }

            return maxIndex;
        }
    }
}
