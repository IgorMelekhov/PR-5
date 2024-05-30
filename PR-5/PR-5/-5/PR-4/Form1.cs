using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PR_4
{
    public partial class Form1 : Form
    {
        delegate T[] Sel<T>(T[]intValue);
        delegate T[] Sel3<T>(T[] intValue,int l,int r);
        public Form1()
        {
            InitializeComponent();
            array.Validating += array_Validating;
        }
        private void array_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(array.Text))
            { errorProvider1.SetError(array, "Поле не может быть пустым!"); }
            //else if (!double.TryParse(array.Text, out _))
            //{errorProvider1.SetError(array, "В поле должно быть введено число!");}
            else
            { errorProvider1.Clear(); }
        }
        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            array.Clear();
            arrayBuble.Clear();
            arraySelect.Clear();
            arrayMerge.Clear();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newF = new Form2();
            newF.Show();
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            try
            {
                bool selectBuble = false;
                bool selectSelect = false;
                bool selectMerge=false;
                if (checkBuble.Checked) selectBuble = true;
                if (checkSelect.Checked) selectSelect = true;
                if (checkMerge.Checked) selectMerge = true;
                string[] values = array.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); ;
                if ((Int32.TryParse(values[0], out _)) == true)
                {
                    Sort<int> sort = new Sort<int>();
                    Sel<int> sel;
                    Sel3<int> sel3;
                    int[] intValue = new int[values.Length];
                    for (int i = 0; i < values.Length; i++)
                    {
                        intValue[i] = Convert.ToInt32(values[i]);
                    }
                    if (selectBuble == true)
                    {
                        sel = sort.Buble;
                        string res = String.Join(";", sel(intValue));
                        arrayBuble.Text = res;
                    }
                    if (selectSelect )
                    {
                        sel = sort.Select;
                        string res = string.Join(";", sel(intValue));
                        arraySelect.Text = res;
                    }
                    if (selectMerge == true)
                    {
                        int l = 0;
                        int r = intValue.Length - 1;
                        sel3 = sort.MergeSort;
                        string res = string.Join(";", sel3(intValue, l, r));
                        arrayMerge.Text = res;
                    }
                }
                else if (double.TryParse(values[0], out _))
                {
                    Sort<double> sort = new Sort<double>();
                    Sel<double> sel;
                    Sel3<double> sel3;
                    double[] doubleValue = new double[values.Length];
                    for (int i = 0; i < values.Length; i++)
                    {
                        doubleValue[i] = Convert.ToDouble(values[i]);
                    }
                    if (selectBuble == true)
                    {
                        sel = sort.Buble;
                        string res = string.Join(";", sel(doubleValue));
                        arrayBuble.Text = res;
                    }
                    if (selectSelect == true)
                    {
                        sel = sort.Select;
                        string res = string.Join(";", sel(doubleValue));
                        arraySelect.Text = res;
                    }
                    if (selectMerge == true)
                    {
                        int l = 0;
                        int r = doubleValue.Length - 1;
                        sel3 = sort.MergeSort;
                        string res = string.Join(";", sel3(doubleValue, l, r));
                        arrayMerge.Text = res;
                    }
                }
            }
            catch { }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            array.Clear();
            arrayBuble.Clear();
            arraySelect.Clear();
            arrayMerge.Clear();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
