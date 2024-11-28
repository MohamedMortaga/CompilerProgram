using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompilerPro
{
    public partial class Form1 : Form
    {
        List<string> Lines = new List<string>();
        List<variable> L1 = new List<variable>();
        variable t;
        string[] n = {"0", "1", "2", "3", "4", "5", "6", "7", "8","9"};
        int w = 0, flag = 0, r = 0, flagop = 0, done = 0, m = 0, mm = 0,flag2 = 0,flag3=0,p2,p3,p4,flag4=0;
        string num;
        public Form1()
        {
            InitializeComponent();
        }
        public class variable
        {
            public int value=0;
            public char name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < richTextBox1.Lines.Length;i++ )
            {
                Lines.Add(richTextBox1.Lines[i]);
            }
            for (int i = 0; i <Lines.Count; i++)
            {
                num = null;
                r = 0;
                for (int y = 0; y < Lines[i].Length; y++)
                {
                    w = 0;

                    if (Lines[i].ToCharArray()[y] == 'b' && Lines[i].ToCharArray()[y + 1] == 'r' && Lines[i].ToCharArray()[y + 2] == 'e' && Lines[i].ToCharArray()[y + 3] == 'a' && Lines[i].ToCharArray()[y + 4] == 'k' && Lines[i].ToCharArray()[y + 5] == ';')
                    {
                        richTextBox2.AppendText("break" + Environment.NewLine);
                    }
                    if (Lines[i].ToCharArray()[y] == 'c' && Lines[i].ToCharArray()[y + 1] == 'o' && Lines[i].ToCharArray()[y + 2] == 'n' && Lines[i].ToCharArray()[y + 3] == 't' && Lines[i].ToCharArray()[y + 4] == 'i' && Lines[i].ToCharArray()[y + 5] == 'n' && Lines[i].ToCharArray()[y + 6] == 'u' && Lines[i].ToCharArray()[y + 7] == 'e' && Lines[i].ToCharArray()[y + 8] == ';')
                    {
                        richTextBox2.AppendText("continue" + Environment.NewLine);
                    }
                    for (p3 = 0; p3 < L1.Count; p3++)
                    {
                        for (p2 = 0; p2 < L1.Count; p2++)
                        { for (p4 = 0; p4 < L1.Count; p4++)
                         {
                            if (Lines[i].ToCharArray()[y] == 'i' && Lines[i].ToCharArray()[y + 1] == 'f' && Lines[i].ToCharArray()[y + 2] == '(' && Lines[i].ToCharArray()[y + 3] == L1[p3].name && Lines[i].ToCharArray()[y + 4] == '>' && Lines[i].ToCharArray()[y + 5] == L1[p2].name && Lines[i].ToCharArray()[y + 6] == '|' && Lines[i].ToCharArray()[y + 7] == '|' && Lines[i].ToCharArray()[y + 8] == L1[p3].name && Lines[i].ToCharArray()[y + 9] == '>' && Lines[i].ToCharArray()[y+10] == L1[p4].name)
                            {
                                if (L1[p3].value > L1[p2].value || L1[p3].value > L1[p4].value)
                                {
                                    
                                    flag3 = 1;
                                  
                                    break;
                                }


                            }
                        }
                        }
                        if (flag3 == 1)
                        {
                           
                            break;
                        }

                    }

                    if (flag3 == 1 && Lines[i].ToCharArray()[y] == '{')
                    {

                        flag3 = 2;
                   
                    }
                    for (p3 = 0; p3 < L1.Count; p3++)
                    {
                        for (p2 = 0; p2 < L1.Count; p2++)
                        {
                            if (flag3 == 2 && Lines[i].ToCharArray()[y] == 'i' && Lines[i].ToCharArray()[y + 1] == 'f' && Lines[i].ToCharArray()[y + 2] == '(' && Lines[i].ToCharArray()[y + 3] == L1[p3].name && Lines[i].ToCharArray()[y + 4] == '>' && Lines[i].ToCharArray()[y + 5] == L1[p2].name && Lines[i].ToCharArray()[y + 6] == ')')
                            {
                                if (L1[p3].value > L1[p2].value)
                                {
                                   
                                    flag3 = 3;
                        
                                    break;
                                }
                            }
                        } 
                        if (flag3 == 3)
                        {
                           
                            break;
                        }
                    }
                    if(flag3 ==3 && Lines[i].ToCharArray()[y] == '{')
                    {
                        flag3 = 4;
                    }
                    

                    if (Lines[i].ToCharArray()[y] == 'i' && Lines[i].ToCharArray()[y + 1] == 'n' && Lines[i].ToCharArray()[y + 2] == 't' && Lines[i].ToCharArray()[y + 3] == ' '  && Lines[i].ToCharArray()[y + 4] <= 'z' && Lines[i].ToCharArray()[y + 4] >= 'a' )
                    {
                        flag = 1;
                    }
                    if (flag == 1 && Lines[i].ToCharArray()[y + 1] == ';')
                    {
                        flag = 3;
                    }
                    if (flag == 1 && Lines[i].ToCharArray()[y + 1] == '=')
                    {
                        flag = 2;
                    }

                    if (flag == 2 && Convert.ToInt16(Lines[i].ToCharArray()[y]) >= 0 || flag == 3 || flag == 0 || flag4 == 0 || flag4 == 1)
                    {

                        for (int o = 0; o < 10; o++)
                        {
                            if (Lines[i].ToCharArray()[y] == Convert.ToChar(n[o]))
                            {
                                num += Lines[i].ToCharArray()[y];
                               
                            }
                        }
                      
                        
                    }
                    
                    if (flag == 2 && Lines[i].ToCharArray()[y]==';')
                    {
                        int u = Convert.ToInt16(num);

                        if (flagop == 1 || flagop == 0)
                        {
                            r += u;
                        }
                        if (flagop == 2 )
                        {
                            r -= u;
                        }
                        if (flagop == 3 )
                        {
                            r *= u;
                        }
                        if (flagop == 4 )
                        {
                            r /= u;
                        }

                        variable k=new variable();

                        k.name=Lines[i].ToCharArray()[4];
                        k.value = r;
                        num = null;
                        for (int j = 0; j < L1.Count; j++)
                        {
                            if (Lines[i].ToCharArray()[4] != L1[j].name)
                            {
                                w++;
                            }
                        }
                        if (w == L1.Count)
                        {
                            L1.Add(k);
                            mm = 1;
          
                        }
                        if (w != L1.Count && mm == 0)
                        {
                            mm=1;
                            richTextBox2.AppendText("error" + Environment.NewLine);
                        }
                     
                        flag = 0;

                        
                    }
                    if (Lines[i].ToCharArray()[y] == '+')
                    {
                        
                        int u = Convert.ToInt16(num);
                        r += u;
                        flagop = 1;
                       
                        num = null;
                       
                    }
                    if (Lines[i].ToCharArray()[y] == '-')
                    {

                        int u = Convert.ToInt16(num);
                        done++;
                        if(done==1)
                        {
                           r += u;
                        }
                        else
                        {
                             r -= u;
                        }
                        flagop = 2;
                        num = null;

                    }
                    if (Lines[i].ToCharArray()[y] == '*')
                    {

                        int u = Convert.ToInt16(num);
                        done++;
                        if (done == 1)
                        {
                            r += u;
                        }
                        else
                        {
                            r *= u;
                        }
                        flagop = 3;
                        num = null;

                    }
                    if (Lines[i].ToCharArray()[y] == '/')
                    {

                        int u = Convert.ToInt16(num);
                        done++;
                        if (done == 1)
                        {
                            r += u;
                        }
                        else
                        {
                            r /= u;
                        }
                        flagop = 4;
                        num = null;

                    }
                    if (flag == 3)
                    {
                        variable x = new variable();
                        x.name = Lines[i].ToCharArray()[y];
                        for (int j = 0; j < L1.Count; j++)
                        {
                            if (Lines[i].ToCharArray()[4] != L1[j].name)
                            {
                                w++;
                            }
                        }
                        if (w == L1.Count)
                        {
                            L1.Add(x);
                            m = 11;
                     
                        }
                        if (w != L1.Count && m==0 )
                        {
                            m = 1;
                            richTextBox2.AppendText("error"+ Environment.NewLine);
                        }
                        flag = 0;
                        
                    }
                    if (y > 0)
                    {
                        if (Lines[i].ToCharArray()[y - 1] == '=')
                        {
                            for (int j = 0; j < L1.Count; j++)
                            {
                                if (Lines[i].ToCharArray()[0] == L1[j].name && Convert.ToInt32(num) != L1[j].value)
                                {
                                    L1[j].value = Convert.ToInt16(num);
                                    break;
                                }
                                for (int h = 0; h < L1.Count; h++)
                                {
                                    int l;
                                    if (Lines[i].ToCharArray()[y] == L1[j].name && Lines[i].ToCharArray()[y + 1] == '+' && Lines[i].ToCharArray()[y + 2] == L1[h].name && done !=4)
                                    {
                                        variable x = new variable();
                                        x.name = Lines[i].ToCharArray()[y - 2];
                                        x.value = L1[j].value + L1[h].value;
                                        for ( l = 0; l < L1.Count; l++)
                                        {
                                            if (Lines[i].ToCharArray()[y-1] != L1[l].name)
                                            {
                                                w++;
                                                break;
                                            }
                                        }
                                        if (w == L1.Count)
                                        {
                                            L1.Add(x);
                                            done = 4;
                                            break;
                                        }
                                        else
                                        {
                                            t = x;
                                        }
                                        break;
                                    }
                                }

                                for (int h = 0; h < L1.Count; h++)
                                {
                                    if (Lines[i].ToCharArray()[y] == L1[j].name && Lines[i].ToCharArray()[y + 1] == '-' && Lines[i].ToCharArray()[y + 2] == L1[h].name && done != 4)
                                    {int l;
                                        variable x = new variable();
                                        x.name = Lines[i].ToCharArray()[y - 2];
                                        x.value = L1[j].value - L1[h].value;
                                        for ( l = 0; l < L1.Count; l++)
                                        {
                                            if (Lines[i].ToCharArray()[y - 1] != L1[l].name)
                                            {
                                                w++;
                                                break;
                                            }
                                        }
                                        if (w == L1.Count)
                                        {
                                            L1.Add(x);
                                            done = 4;
                                            break;
                                        }
                                        else
                                        {
                                            t = x;


                                        }
                                        break;
                                    }
                                }
                                for (int h = 0; h < L1.Count; h++)
                                {
                                    if (Lines[i].ToCharArray()[y] == L1[j].name && Lines[i].ToCharArray()[y + 1] == '*' && Lines[i].ToCharArray()[y + 2] == L1[h].name && done != 4)
                                    {
                                        int l;
                                        variable x = new variable();
                                        x.name = Lines[i].ToCharArray()[y - 2];
                                        x.value = L1[j].value * L1[h].value;
                                        for (l = 0; l < L1.Count; l++)
                                        {
                                            if (Lines[i].ToCharArray()[y - 1] != L1[l].name)
                                            {
                                                w++;
                                                break;
                                            }
                                        }
                                        if (w == L1.Count)
                                        {
                                            L1.Add(x);
                                            done = 4;
                                            break;
                                        }
                                        else
                                        {
                                            t = x;
                                        }
                                        break;
                                    }
                                }
                                for (int h = 0; h < L1.Count; h++)
                                {
                                    int l;
                                    if (Lines[i].ToCharArray()[y] == L1[j].name && Lines[i].ToCharArray()[y + 1] == '/' && Lines[i].ToCharArray()[y + 2] == L1[h].name && done != 4)
                                    {
                                        variable x = new variable();
                                        x.name = Lines[i].ToCharArray()[y - 2];
                                        x.value = L1[j].value / L1[h].value;
                                        for ( l = 0; l < L1.Count; l++)
                                        {
                                            if (Lines[i].ToCharArray()[y - 1] != L1[l].name)
                                            {
                                                w++;
                                                break;
                                            }
                                        }
                                        if (w == L1.Count)
                                        {
                                            L1.Add(x);
                                            done = 4;
                                            break;
                                        }
                                        else
                                        {
                                            t = x;
                                        }
                                        break;
                                    }
                                }


                            }
                            if (t != null)
                            {
                                L1[L1.Count - 1] = t;
                            }
                        }
                    }
                    if (Lines[i].ToCharArray()[y] == 'w' && Lines[i].ToCharArray()[y+1] == 'h' && Lines[i].ToCharArray()[y+2] == 'i' && Lines[i].ToCharArray()[y+3] == 'l' && Lines[i].ToCharArray()[y+4] == 'e' &&Lines[i].ToCharArray()[y+5] == '(')
                    {
                        for (int j = 0; j < L1.Count; j++)
                        {
                            for (int k = 0; k < L1.Count; k++)
                            {
                                if (Lines[i].ToCharArray()[y + 6] == L1[j].name && Lines[i].ToCharArray()[y + 7] == '<' || Lines[i].ToCharArray()[y + 7] == '>' && Lines[i].ToCharArray()[y + 8] == L1[k].name && Lines[i].ToCharArray()[y + 9] == ')' && Lines[i].ToCharArray()[y + 10] == '{')
                                {
                                    if (Lines[i].ToCharArray()[y + 7] == '<')
                                    {
                                        for (int x1 = 0; x1 < L1.Count; x1++)
                                        {
                                            if (Lines[i].ToCharArray()[y + 11] == L1[x1].name && Lines[i].ToCharArray()[y + 12] == '=' && Lines[i].ToCharArray()[y + 13] == L1[x1].name && Lines[i].ToCharArray()[y + 14] == '+')
                                            {
                                                flag2 = 1;
                                                int value = Convert.ToInt32(Lines[i].ToCharArray()[y+15]);
                                                while (L1[j].value < L1[k].value)
                                                {
                                                    MessageBox.Show("ally abl al operator less than ally ba3do");
                                                    L1[j].value++;
                                                }
                                            }
                                        }
                                        /*if (L1[j].value < L1[k].value)
                                        {
                                            
                                        }
                                        if (L1[k].value < L1[j].value)
                                        {
                                            while (L1[k].value < L1[j].value)
                                            {
                                                L1[k].value++;
                                                //MessageBox.Show("al3ks");
                                            }
                                        }
                                         */
                                    }
                                }
                            }
                        }
                    }
                    if (Lines[i].ToCharArray()[y] == 'c' && Lines[i].ToCharArray()[y + 1] == 'o' && Lines[i].ToCharArray()[y + 2] == 'u' && Lines[i].ToCharArray()[y + 3] == 't' && Lines[i].ToCharArray()[y + 4] == '<' && Lines[i].ToCharArray()[y + 5] == '<')
                    {

                        for (int p = 0; p < L1.Count; p++)
                        {
                            if (L1[p].name == Lines[i].ToCharArray()[y + 6])
                            {
                                richTextBox2.AppendText(Convert.ToString(L1[p].name) + " = ");
                                richTextBox2.AppendText(Convert.ToString(L1[p].value) + Environment.NewLine);
                            }
                        }
                    } if (flag3 == 4 && Lines[i].ToCharArray()[y] == '}')
                    {
                        flag3 = 5;
                    }
                    if (flag3 == 5 && Lines[i].ToCharArray()[y] == '}')
                    {
                        flag3 = 6;
                    }
                }


                if (i == Lines.Count)
                {
                    if (flag3 > 0 && flag3 < 5)
                    {
                        richTextBox2.AppendText("error" + Environment.NewLine);
                    }
                }
            }
            
            
            Lines.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
