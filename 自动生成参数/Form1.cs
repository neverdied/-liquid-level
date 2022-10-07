using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自动生成参数
{

    public partial class Form1 : Form
    {
        int[] numList1 = { 41, 52, 39, 61, 39, 45, 51 };
        int[] numList2 = { 9, 8, 9, 7, 8, 9, 7, 33,43 };
        public Form1()
        {
            InitializeComponent();
            foreach(int i in numList1)
            {
                label2.Text += i.ToString()+",";
            }
            foreach(int i in numList2)
            {
                label4.Text += i.ToString()+",";
            }
        }

        public int[] getmaxmin(int[] list,int jud)
        {
            int total = 0;
            int ave = 0;
            int totaldis = 0;
            int avedis = 0;
            int count = 0;
            int max = list[0];
            int min = list[0];
            foreach (int i in list)
            {
                total += i;
            }
            ave = total / list.Length;
            foreach (int i in list)
            {
                totaldis += Math.Abs(i - ave);
            }
            avedis = totaldis / list.Length;
            //ArrayList arrayList = new ArrayList();
            string s = "";
            if (jud == 0)
            {
                s = "好品第";
            }
            else
            {
                s = "坏品第";
            }
            foreach (int i in list)
            {
                count++;
                if (Math.Abs(i - ave) > avedis * 3)
                {
                    s += count+",";
                    //arrayList.Add(count);
                    //MessageBox.Show("第" + count + "个液位波动太大");
                }

            }
            if (s.Length != 3)
            {
                MessageBox.Show( s + "个液位波动太大");

            }
            count = 0;
            foreach (int i in list)
            {
                if (max < i)
                {
                    max = i;
                }
                if (min > i)
                {
                    min = i;
                }
                //label6.Text = "最大值是：" + max + "，最小值是：" + min;
            }
            int[] num= {1,1 };
            num[0] = max;
            num[1] = min;
            return num;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] goodAns=getmaxmin(numList1,0);
            label6.Text = "最大值是" + goodAns[0]+"，最小值是"+goodAns[1];
            int[] badAns = getmaxmin(numList2,1);
            label8.Text = "最大值是" + badAns[0] + ",最小值是" + badAns[1];
            if (goodAns[1] > badAns[0] || goodAns[0] < badAns[1])
            {
                int value = Math.Abs(goodAns[0] - badAns[1]);
                int mid = goodAns[0] + value / 2;
                if (value > Math.Abs(goodAns[1] - badAns[0]))
                {
                    value = Math.Abs(goodAns[1] - badAns[0]);
                    mid = badAns[0] + value / 2;
                }
                label10.Text = "推荐液位高度为：" + mid.ToString();

            }
            else
            {
                int count = 0;
                label10.Text += "坏品";
                foreach (int i in numList2)
                {
                    count++;
                    ArrayList arraylist = new ArrayList();
                    if (i > goodAns[1] && i < goodAns[0])
                    {
                        arraylist.Add(count);
                    }
                    foreach (int j in arraylist)
                    {
                        label10.Text += j + "，";
                    }
                }
                label10.Text += "图片与好品重合";
            }
            }
        }
    }

