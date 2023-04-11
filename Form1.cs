using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Seifertova_zk {
    public partial class Form1 : Form {

        public string cesta = "";
       
        public Form1() {
            InitializeComponent();

            comboBox1.Items.Clear();
            comboBox1.Items.Add("židle");
            comboBox1.Items.Add("skříň");
            comboBox1.Items.Add("police");
            comboBox1.SelectedIndex = -1;

            timer1.Start();

           
    }

        private void otevřítToolStripMenuItem_Click(object sender, EventArgs e) {
            DialogResult dr = openFileDialog1.ShowDialog();
            cesta = openFileDialog1.FileName;
            if (dr == DialogResult.OK) {
                StreamReader sr = new StreamReader(cesta);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
        private void ulozitToolStripMenuItem_Click(object sender, EventArgs e) {
            saveFileDialog1.FileName = cesta;
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK) {
                StreamWriter writing = new StreamWriter(saveFileDialog1.FileName);
                writing.Write(textBox1.Text);
                writing.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            MessageBox.Show("Toto je nápověda k tomuto programu");
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            lbTrack.Text = trackBar1.Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }



        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e) {
            lbCombo.Text = comboBox1.Text;
        }

        private void comboBox1_TextChanged_1(object sender, EventArgs e) {
            lbCombo.Text = comboBox1.Text;
        }

        private void Form1_Load(object sender, EventArgs e) {
            progressBar1.Maximum = 10000;
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e) {
            progressBar1.Value += timer2.Interval;
            if (progressBar1.Value == progressBar1.Maximum) {
                timer2.Stop();
            }
            lbProgress.Text = (progressBar1.Value / 1000).ToString();
        }

        private void Soucet() {
            int a, b;
            if (int.TryParse(tbA.Text, out a) && int.TryParse(tbB.Text, out b)) {

                int vysledek = a + b;
                lbVysledek.Text = vysledek.ToString();

                if (vysledek > 0) {
                    lbVysledek.Font = new Font(lbVysledek.Font, FontStyle.Bold);
                }
                else {
                    lbVysledek.Font = new Font(lbVysledek.Font, FontStyle.Regular);
                }
            }
        }

        private void tbA_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127) {
                e.Handled = true;
            }
        }

        private void tbB_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127) {
                e.Handled = true;
            }
        }

        private void btrovnase_Click(object sender, EventArgs e) {
            Soucet();
        }

        public void updateAll() {
            System.Windows.Forms.RadioButton[] radioButtons = new System.Windows.Forms.RadioButton[] { radioButton1, radioButton2, radioButton3, };
            string lbText = "";

            foreach (System.Windows.Forms.RadioButton rb in radioButtons) {
                if (rb.Checked) {
                    lbText += rb.Text + " ";
                }

            }
            this.lbRadio.Text = lbText.Trim();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            lbNumeric.Text = numericUpDown1.Value.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if(checkBox1.Checked) {
                lbCheckB.Text = "ANO";            
            }
            else {
                lbCheckB.Text = "NE";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            updateAll();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            updateAll();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) {
            updateAll();
        }

    
    }
}
