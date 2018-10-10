using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {

        RegistryKey hklm;
        RegistryKey hkSoftware;
        RegistryKey hkRegistryDemo;
        RegistryKey newKey;
        RegistryKey chooseKey;
        string[] keys;
        int[] status = { 0x000003e9, 0x000003ea, 0x000003eb, 0x000003ec, 0x000003ed };

        public Form1()
        {
            InitializeComponent();
            hklm = Registry.CurrentUser;
            hkSoftware = hklm.OpenSubKey("SOFTWARE");
            hkRegistryDemo = hkSoftware.OpenSubKey("Registry Demo", true);
            keys = hkRegistryDemo.GetSubKeyNames();
            listBox1.Items.AddRange(keys);


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedKey = listBox1.SelectedItem.ToString();
            chooseKey = hkRegistryDemo.OpenSubKey(selectedKey);
            string pass = (string)chooseKey.GetValue("Password");

            if(!pass.Equals(GetPassword()))
            {
                MessageBox.Show("Неверный пароль!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Пароль введен правильно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameKey = this.textBox1.Text.ToString();
            newKey = hkRegistryDemo.CreateSubKey(nameKey);
            
            newKey.SetValue("Password", GetPassword());
            newKey.SetValue("Status", status[0]);
            PrintMessage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nameKey = this.textBox1.Text.ToString();
            newKey = hkRegistryDemo.CreateSubKey(nameKey);
            newKey.SetValue("Password", GetPassword());
            newKey.SetValue("Status", status[1]);
            PrintMessage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nameKey = this.textBox1.Text.ToString();
            newKey = hkRegistryDemo.CreateSubKey(nameKey);
            newKey.SetValue("Password", GetPassword());
            newKey.SetValue("Status", status[2]);
            PrintMessage();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nameKey = this.textBox1.Text.ToString();
            newKey = hkRegistryDemo.CreateSubKey(nameKey);
            newKey.SetValue("Password", GetPassword());
            newKey.SetValue("Status", status[3]);
            PrintMessage();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string nameKey = this.textBox1.Text.ToString();
            newKey = hkRegistryDemo.CreateSubKey(nameKey);
            newKey.SetValue("Password", GetPassword());
            newKey.SetValue("Status", status[4]);
            PrintMessage();
        }

        private void PrintMessage()
        {
            MessageBox.Show("Запись добавлена!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.textBox1.Text = "";
            keys = hkRegistryDemo.GetSubKeyNames();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(keys);
        }

        public string GetPassword()
        {
            Password password = new Password();
            password.ShowDialog();
            return password.password;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeleteKeys del = new DeleteKeys();
            del.Show();
        }
    }
}
