///anthor: billy huang///
///Bad smell code////////
/////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckSKU
{

    public partial class Form1 : Form
    {
        public Label Label1
        {
            get { return label1; }
        }
        public string Label2
        {
            set { label2.Text = value; }
        }
        public string Label3
        {
            set { label3.Text = value; }
        }
        public string Label4
        {
            set { label4.Text = value; }
        }
        public string Label5
        {
            set { label5.Text = value; }
        }
        public string Label6
        {
            set { label6.Text = value; }
        }
        public string SpecLabel
        {
            set { specLabel.Text = value; }
        }
        public string CurrentLabel
        {
            set { currentLabel.Text = value; }
        }
        public string LogLabel
        {
            set { log.Text = value; }
        }

        private List<Label> labels = new List<Label>();
        private Point resPoint = new Point(-1000, 240);
        bool animationEnable = true;
        Core checkSKU;
        public Form1(string[] args)
        {
            checkSKU = new Core(this);
            checkSKU.parameterCheck(args, ref animationEnable);
            InitializeComponent();
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label2);
            labels.Add(specLabel);
            labels.Add(label6);
            labels.Add(label3);
            labels.Add(currentLabel);
            labels.Add(label1);
            labels.Add(log);
            label1.Visible = false;
            log.Text = "";
            for (int i = 0; i < 7; i++)
            {
                Point p = new Point(labels[i].Location.X, labels[i].Location.Y);
                p.X = -1000 + (-100 * i);
                labels[i].Location = p;
            }
            label1.Location = resPoint;
            if (!animationEnable)
            {
                this.Opacity = 0;
            }
            checkSKU.getSMBIOSDataAndCheckSKU();
            checkSKU.genLogFile(labels);
            checkSKU.startAnimation(timer1, animationEnable);
        }

        public void oneBiosTimer(Object sender, EventArgs e)
        {
            MiniAnimation.runAnimation(labels, animationEnable);
            checkSKU.closeWindow();
            this.Refresh();
        }

    }

}
