﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
namespace HslCommunicationDemo
{
    public partial class FormLoad : Skin_Mac
    {
        public FormLoad( )
        {
            InitializeComponent( );
        }

        private void button1_Click( object sender, EventArgs e )
        {
            Hide( );
            using (FormSiemens form = new FormSiemens( HslCommunication.Profinet.SiemensPLCS.S1200 ))
            {
                form.ShowDialog( );
            }
            Show( );
        }


        private void button6_Click( object sender, EventArgs e )
        {
            Hide( );
            using (FormModbus form = new FormModbus())
            {
                form.ShowDialog( );
            }
            Show( );
        }

        private void button4_Click( object sender, EventArgs e )
        {
            Hide( );
            using (FormMelsec form = new FormMelsec( ))
            {
                form.ShowDialog( );
            }
            Show( );
        }

        private void button2_Click( object sender, EventArgs e )
        {
            Hide( );
            using (FormSiemens form = new FormSiemens( HslCommunication.Profinet.SiemensPLCS.S1500 ))
            {
                form.ShowDialog( );
            }
            Show( );
            try
            {

            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void button3_Click( object sender, EventArgs e )
        {
            Hide( );
            using (FormSiemens form = new FormSiemens( HslCommunication.Profinet.SiemensPLCS.S300 ))
            {
                form.ShowDialog( );
            }
            Show( );
        }

        private void button5_Click( object sender, EventArgs e )
        {
            Hide( );
            using (FormSiemens form = new FormSiemens( HslCommunication.Profinet.SiemensPLCS.S200Smart ))
            {
                form.ShowDialog( );
            }
            Show( );
        }

        private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            //try
            //{
            //    System.Diagnostics.Process.Start( linkLabel1.Text );
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show( ex.Message );
            //}
        }

        
    }
}
