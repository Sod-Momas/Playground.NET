using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Playground.TakeMoneyFromDream
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly Regex bankAccount = new(@"/^([1-9]{1})(\d{15}|\d{18})$/");
        private readonly Regex bankAccount = new(@"^62\d{6,16}$");
        private readonly Regex chinese = new("^[\u4E00-\u9FA5]{1,3}$");
        private readonly Regex phone = new(@"^1(3\d|4[5-9]|5[0-35-9]|6[567]|7[0-8]|8\d|9[0-35-9])\d{8}$");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (string.IsNullOrEmpty(bankNoTextBox.Text))
            {
                MessageBox.Show("请填写银行卡账号");
                return;
            }
            else if (!bankAccount.IsMatch(bankNoTextBox.Text))
            {
                MessageBox.Show("对不起，目前不支持中国银联以外的银行");
                return;
            }
            if (string.IsNullOrEmpty(bankPasswordPasswordBox.Password))
            {
                MessageBox.Show("请填写银行卡密码");
                return;
            }
            else if (!(int.TryParse(bankPasswordPasswordBox.Password, out int pwd) && 99999 < pwd && pwd < 1000000))
            {
                MessageBox.Show("密码格式错误");
                return;
            }
            if (string.IsNullOrEmpty(holderNameText.Text)||holderNameText.Text.Length<2)
            {
                MessageBox.Show("请填写真实姓名");
                return;
            }
            else if (!chinese.IsMatch(holderNameText.Text))
            {
                MessageBox.Show("请填写中文名字");
                return;
            }
            if (string.IsNullOrEmpty(phoneText.Text))
            {
                MessageBox.Show("请填写银行预留手机号码");
                return;
            }
            else if (!phone.IsMatch(phoneText.Text))
            {
                MessageBox.Show("请输入正确的手机号码");
                return;
            }

            //定义消息框             
            string messageBoxText = "您为何不现在开始做梦?";
            string caption = "您还未开始做梦!";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            //显示消息框              
            MessageBox.Show(messageBoxText, caption, button, icon);
        }
    }
}
