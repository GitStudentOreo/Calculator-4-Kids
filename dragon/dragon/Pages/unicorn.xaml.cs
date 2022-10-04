using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngouriMath;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dragon
{
   
    public partial class unicorn : ContentPage
    {
        private List<Button> all_btns = new List<Button>();

        private List<string> all_btns_text = new List<string>() {
            "Clear", "/", "7", "8", "9", "×", "4", "5",
            "6", "-", "1", "2", "3", "+","0", "Equal"
        };


        public unicorn()
        {
            InitializeComponent();
            all_btns.Add(Clear);
            all_btns.Add(Div);
            all_btns.Add(seven);
            all_btns.Add(eight);
            all_btns.Add(nine);
            all_btns.Add(x);
            all_btns.Add(four);
            all_btns.Add(five);
            all_btns.Add(six);
            all_btns.Add(sub);
            all_btns.Add(one);
            all_btns.Add(two);
            all_btns.Add(three);
            all_btns.Add(plus);
            all_btns.Add(zero);
            all_btns.Add(Equal);
        }
        private string current_opt = "";
        private string current_opt_below = "";
        private string equal(string exp)
        {
            string new_expr = "";
            foreach (char i in exp)
            {
                char ii = i;
                if (i == '×')
                {
                    ii = '*';
                }
                else if (i == '÷')
                {
                    ii = '/';
                }
                new_expr += ii;
            }
            try
            {
                Entity expr = new_expr;
                double output = (double)expr.EvalNumerical();
                if ((output % 1 == 0) == true)
                {
                    int o = Convert.ToInt32(output);
                    return Convert.ToString(o);
                }
                else
                {
                    return Convert.ToString(output);
                }
            }
            catch
            {
                return exp;
            }
        }
        private int no_char = 0;
        private int opt = 0;


        private async void back_clicked(object sender, EventArgs args)
        {
            Button btn = (Button)sender;
            await Task.Delay(50);
            if (no_char > 0)
            {
                current_opt = current_opt.Remove(current_opt.Length - 1, 1);
                current_opt_below = equal(current_opt);
                Main_number_add.Text = current_opt + " ";
                no_char = current_opt.Length;
                try
                {
                    char l = current_opt[no_char - 1];
                    if (l == '+' || l == '-' || l == '/' || l == 'x')
                    {
                        opt = 1;
                    }
                    else
                    {
                        opt = 0;
                    }
                }
                catch { }
            }
            btn.BackgroundColor = Color.Transparent;

        }

        private int bra = 0;
        private void Button_Clicked(object sender, EventArgs args)
        {
            Button btn = (Button)sender;
            int i = 0;
            foreach (var bt in all_btns)
            {
                if (bt.Id == btn.Id) { break; }
                i++;
            }

            string btn_text = all_btns_text[i];
            if (btn_text == "Clear" || btn_text == "Bracket" || btn_text == "Equal")
            {
                if (btn_text == "Clear")
                {
                    current_opt = "";
                    opt = 0;
                    no_char = current_opt.Length;
                }
                else if (btn_text == "Bracket")
                {
                    if (no_char < 21)
                    {
                        if (bra == 0)
                        {
                            current_opt += "(";
                            bra = 1;
                            opt = 0;
                            no_char = current_opt.Length;
                        }
                        else
                        {
                            if (opt == 0)
                            {
                                char l = current_opt[current_opt.Length - 1];
                                if (l == '+' || l == '-' || l == '/' || l == 'x' || l == '(')
                                {
                                    opt = 1;
                                }
                                else
                                {
                                    current_opt += ")";
                                    bra = 0;
                                    opt = 0;
                                    no_char = current_opt.Length;
                                }
                            }
                        }
                    }
                }
                else
                {
                    current_opt = equal(current_opt);
                    no_char = current_opt.Length;
                    opt = 0;
                }
            }
            else
            {
                if (no_char < 21)
                {
                    if (btn_text == "+" || btn_text == "-" || btn_text == "/" || btn_text == "x")
                    {
                        if (opt == 0)
                        {
                            if (btn_text == "/" || btn_text == "x")
                            {
                                if (no_char > 0)
                                {
                                    char l = current_opt[current_opt.Length - 1];
                                    if (l != '(')
                                    {
                                        current_opt += btn_text;
                                        opt = 1;
                                        no_char = current_opt.Length;
                                    }
                                }
                            }
                            else
                            {
                                current_opt += btn_text;
                                opt = 1;
                                no_char = current_opt.Length;
                            }
                        }
                    }
                    else
                    {
                        if (btn_text == "")
                        {
                            List<string> tex = new List<string>();
                            string s = "";
                            foreach (char t in current_opt)
                            {
                                if (t == '+' || t == '-' || t == '÷' || t == '×')
                                {
                                    tex.Add(s);
                                    s = "";
                                }
                                else
                                {
                                    s += t;
                                }
                            }
                            if (s != "")
                            {
                                tex.Add(s);
                            }
                            if (tex.Count == 0)
                            {
                                current_opt += btn_text;
                                no_char = current_opt.Length;
                            }
                            else
                            {
                                string last_num = tex[tex.Count - 1];
                                int f = 0;
                                foreach (char tt in last_num)
                                {
                                    if (tt == '.')
                                    {
                                        f = 1;
                                        break;
                                    }
                                }
                                if (f == 0)
                                {
                                    current_opt += btn_text;
                                    no_char = current_opt.Length;
                                }
                            }
                        }
                        else
                        {
                            current_opt += btn_text;
                            opt = 0;
                            no_char = current_opt.Length;
                        }
                    }
                }
            }
            if (btn_text != "Equal")
            {
                current_opt_below = equal(current_opt);
            }
            Main_number_add.Text = current_opt + " ";
        }

        private async void book_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new history_tab());
        }

        private async void store_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new theme_menu());
        }
    }
}
