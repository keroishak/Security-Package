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
                foreach (string c in chars)
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
            ExtendedEuclid EE = new ExtendedEuclid();
            string result = EE.GetMultiplicativeInverse(int.Parse(ExtendedNumber.Text), int.Parse(ExtendedBase.Text)).ToString();
            ExtendedResult.Text = result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AutokeyVigenere autokey = new AutokeyVigenere();
            string result = autokey.Encrypt(AutoPTBox.Text, AutoKeyBox.Text);
            AutoCTBox.Text = result;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AutokeyVigenere autokey = new AutokeyVigenere();
            string result = autokey.Decrypt(AutoCTBox.Text, AutoKeyBox.Text);
            AutoPTBox.Text = result;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AutokeyVigenere autokey = new AutokeyVigenere();
            string result = autokey.Analyse(AutoPTBox.Text, AutoCTBox.Text);
            AutoKeyBox.Text = result;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RepeatingkeyVigenere repkey = new RepeatingkeyVigenere();
            string result = repkey.Encrypt(AutoPTBox.Text, AutoKeyBox.Text);
            AutoCTBox.Text = result;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RepeatingkeyVigenere repkey = new RepeatingkeyVigenere();
            string result = repkey.Decrypt(AutoCTBox.Text, AutoKeyBox.Text);
            AutoPTBox.Text = result;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RepeatingkeyVigenere repkey = new RepeatingkeyVigenere();
            string result = repkey.Analyse(AutoPTBox.Text, AutoCTBox.Text);
            AutoKeyBox.Text = result;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Ceaser ceaser = new Ceaser();
            string result = ceaser.Encrypt(CeaserPTBox.Text, Convert.ToInt32(CeaserKeyBox.Text));
            CeaserCTBox.Text = result;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Ceaser ceaser = new Ceaser();
            string result = ceaser.Decrypt(CeaserCTBox.Text, Convert.ToInt32(CeaserKeyBox.Text));
            CeaserPTBox.Text = result;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Ceaser ceaser = new Ceaser();
            int result = ceaser.Analyse(CeaserPTBox.Text, CeaserCTBox.Text);
            CeaserKeyBox.Text = result.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Columnar columnar = new Columnar();
            List<int> key = new List<int>();
            string[] arr = ColumnarKeyBox.Text.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                key.Add(Convert.ToInt32(arr[i]));
            }
            string result = columnar.Encrypt(ColumnarPTBox.Text, key);
            ColumnarCTBox.Text = result;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Columnar columnar = new Columnar();
            List<int> key = new List<int>();
            string[] arr = ColumnarKeyBox.Text.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                key.Add(Convert.ToInt32(arr[i]));
            }
            string result = columnar.Decrypt(ColumnarCTBox.Text, key);
            ColumnarPTBox.Text = result;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Columnar columnar = new Columnar();
            List<int> key = columnar.Analyse(ColumnarPTBox.Text, ColumnarCTBox.Text);
            string result = "";
            for (int i = 0; i < key.Count; i++)
            {
                if (i != key.Count - 1)
                    result += key[i].ToString() + " ";
                else
                    result += key[i].ToString();
            }
            ColumnarKeyBox.Text = result;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            PlayFair playfair = new PlayFair();
            string result = playfair.Encrypt(PlayFairPTBox.Text, PalyFairKeyBox.Text);
            PlayFairCTBox.Text = result;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            PlayFair playfair = new PlayFair();
            string result = playfair.Decrypt(PlayFairCTBox.Text, PalyFairKeyBox.Text);
            PlayFairPTBox.Text = result;
        }

        private void RailEncrypt_Click(object sender, EventArgs e)
        {

            RailFence railfence = new RailFence();

            string res = "";
            if (RailKey.Text != null)
            {
                res = railfence.Encrypt(PlainText.Text, int.Parse(RailKey.Text));
            }
            else
            {
                MessageBox.Show("enter key value");
            }

            CipherText.Text = res;

        }

        private void RailDecrypt_Click(object sender, EventArgs e)
        {

            RailFence railfence = new RailFence();

            string res = "";
            if (RailKey.Text != null)
            {
                res = railfence.Decrypt(CipherText.Text, int.Parse(RailKey.Text));
            }
            else
            {
                MessageBox.Show("enter key value");
            }

            PlainText.Text = res;
        }

        private void RailAnalays_Click(object sender, EventArgs e)
        {
            RailFence railfence = new RailFence();

            string res = "";

            int key = railfence.Analyse(PlainText.Text, CipherText.Text);

            RailKey.Text = key.ToString();
        }

        private void HillEncrypt_Click(object sender, EventArgs e)
        {
            HillCipher hillcipher = new HillCipher();

            string res = hillcipher.Encrypt(HillPlain.Text, HILLKey.Text);

            HillCipher.Text = res;

        }

        private void HillDecrypt_Click(object sender, EventArgs e)
        {
            HillCipher hillcipher = new HillCipher();

            string res = hillcipher.Decrypt(HillCipher.Text, HILLKey.Text);

            HillPlain.Text = res;
        }

        private void HillAnalays_Click(object sender, EventArgs e)
        {
            HillCipher hillcipher = new HillCipher();

            string res = hillcipher.Analyse(HillPlain.Text, HillCipher.Text);

            HILLKey.Text = res;
        }

        private void MonoEncrypt_Click(object sender, EventArgs e)
        {
            Monoalphabetic mono = new Monoalphabetic();

            string res = mono.Encrypt(MonoPlain.Text, MonoKey.Text);

            MonoCipher.Text = res;
        }

        private void MOnoDecrypt_Click(object sender, EventArgs e)
        {
            Monoalphabetic mono = new Monoalphabetic();

            string res = mono.Decrypt(MonoCipher.Text, MonoKey.Text);

            MonoPlain.Text = res;
        }

        private void MonoAnalays_Click(object sender, EventArgs e)
        {
            Monoalphabetic mono = new Monoalphabetic();

            string res = mono.Analyse(MonoPlain.Text, MonoCipher.Text);

            MonoKey.Text = res;
        }

    }
}
