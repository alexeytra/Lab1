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
    public partial class DeleteKeys : Form
    {
        RegistryKey hklm;
        RegistryKey hkSoftware;
        RegistryKey hkRegistryDemo;
        string[] keys;


        public DeleteKeys()
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
            var result = MessageBox.Show("Удалить ключ?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                hkRegistryDemo.DeleteSubKey(selectedKey);
                hkRegistryDemo.Close();
                UpdateKeys();
            }

        }

        private void UpdateKeys()
        {
            this.listBox1.Items.Clear();
            hklm = Registry.CurrentUser;
            hkSoftware = hklm.OpenSubKey("SOFTWARE");
            hkRegistryDemo = hkSoftware.OpenSubKey("Registry Demo", true);
            keys = hkRegistryDemo.GetSubKeyNames();
            listBox1.Items.AddRange(keys);
            hkRegistryDemo.Close();
        }
    }
}
