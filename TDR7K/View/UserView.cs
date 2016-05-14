using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TDR7K.Controller;


namespace TDR7K.View
{
    public partial class UserView : Form,IView
    {
     
        public UserView()
        {
            InitializeComponent();
        }
        AppController _controller;
        private void UserView_Load(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _controller.WhatScene();
        }
        delegate void SetTextCallback(string text);
        public void AddMsgToRichText(string text)
        {
            try
            {
                if (this.richTextBox1.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(AddMsgToRichText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    string now = DateTime.Now.ToString("HH:mm:ss");
                    richTextBox1.AppendText(String.Format("{0} : {1}{2}", now, text, Environment.NewLine));

                    richTextBox1.SelectionStart = richTextBox1.TextLength;
                    richTextBox1.ScrollToCaret();
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
          
        }
        public void SetController(AppController controller)
        {
            _controller = controller;
        }
    }
}
