using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecurityLibrary;
using SecurityLibrary.MD5;
using SecurityLibrary.RSA;
using SecurityLibrary.AES;
namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MD5 md5 = new MD5();
            MD5_Output.Text = md5.GetHash(MD5_Input.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RSA_TextCheck.Checked)
            {
                RSA rsa = new RSA();
                RSA_Output.Text = rsa.Encrypt(int.Parse(RSA_P.Text), int.Parse(RSA_Q.Text), RSA_Input.Text,
                    int.Parse(RSA_E.Text));
            }
            else
            {
                RSA rsa = new RSA();
                int result = rsa.Encrypt(int.Parse(RSA_P.Text), int.Parse(RSA_Q.Text), int.Parse(RSA_Input.Text),
                    int.Parse(RSA_E.Text));
                RSA_Output.Text = result.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RSA_TextCheck.Checked)
            {
                RSA rsa = new RSA();
                var chars = RSA_Input.Text.Split();
                string msg = "";
                foreach(string c in chars)
                {
                    var dbytes = rsa.Decrypt(int.Parse(RSA_P.Text), int.Parse(RSA_Q.Text), c,
                    int.Parse(RSA_E.Text));

                    byte[] buffer = new byte[1];
                    buffer[0] = 0;
                    foreach (var b in dbytes)
                    {
                        buffer[0] *= 10;
                        buffer[0] += b;
                    }
                    msg += Encoding.ASCII.GetString(buffer);
                }
                RSA_Output.Text = msg;
            }
            else
            {
                RSA rsa = new RSA();
                int result = rsa.Decrypt(int.Parse(RSA_P.Text), int.Parse(RSA_Q.Text), int.Parse(RSA_Output.Text),
                    int.Parse(RSA_E.Text));
                RSA_Output.Text = result.ToString();
            }
        }

        private void EncryptionButton_Click(object sender, EventArgs e)
        {
            AES aes = new AES();
            string result = aes.Encrypt(AESInputTextBox.Text, AESKeyTextBox.Text);
            AESOutputTextBox.Text = result;
        }

        private void AESDecryptionButton_Click(object sender, EventArgs e)
        {
            AES aes = new AES();
            string result = aes.Decrypt(AESInputTextBox.Text, AESKeyTextBox.Text);
            AESOutputTextBox.Text = result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExtendedEuclid EE=new ExtendedEuclid();
            string result = EE.GetMultiplicativeInverse(int.Parse(ExtendedNumber.Text), int.Parse(ExtendedBase.Text)).ToString();
            ExtendedResult.Text = result;
        }
    }
}
