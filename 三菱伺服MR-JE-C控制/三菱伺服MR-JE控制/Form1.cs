using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using 命令处理;
using CCWin;
using 三菱伺服MR_JE控制.通讯链接界面;

namespace 三菱伺服MR_JE控制
{
    public partial class Form1 :Skin_VS
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool gohome = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (gohome == true) return;
            lock (this)
            {
                if (!command.Servo_ready)
                    return;
                Task.Run(() =>
                {
                    gohome = true;
                    command.Servo_GoHome();
                    uiLedBulb11.On = command.Servo_Home;
                    gohome = false;
                });
            }
        }
        Command command;
        public bool Hiel { get; set; } = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            Hiel = true;
            command = new Command();
            if(command.Servo_ready)
            {
                command.Torque_Just = Convert.ToInt32(skinTextBox11.Text);
                command.Torque_Lose= Convert.ToInt32(skinTextBox10.Text);
                command.Accelerate = Convert.ToInt32(skinTextBox8.Text);
                command.Decelerate = Convert.ToInt32(skinTextBox9.Text);
            }
        }

        private void 状态刷新_Tick(object sender, EventArgs e)
        {
            this.BeginInvoke((EventHandler)delegate
            {
                //写入伺服参数
                command.Torque_Just = Convert.ToInt32(skinTextBox11.Text);
                command.Torque_Lose = Convert.ToInt32(skinTextBox10.Text);
                command.Accelerate = Convert.ToInt32(skinTextBox8.Text);
                command.Decelerate = Convert.ToInt32(skinTextBox9.Text);
                //指示灯状态
                var data = command.State_Bool;
                uiLedBulb1.On = data[0];
                uiLedBulb2.On = data[1];
                uiLedBulb3.On = data[2];
                uiLedBulb4.On = data[3];
                uiLedBulb5.On = data[5];
                uiLedBulb6.On = data[6];
                uiLedBulb7.On = data[7];
                uiLedBulb8.On = data[8];
                uiLedBulb9.On = data[9];
                uiLedBulb10.On = data[10];
                uiLedBulb12.On = data[12];
                //当前伺服状态
                skinTextBox1.Text = command.Pattern.ToString();
                skinTextBox2.Text = command.State.ToString();
                skinTextBox4.Text = command.Present_Pulse.ToString();
                skinTextBox5.Text = command.Present_Torque.ToString();
                skinTextBox6.Text = command.ServoErr_code.ToString();
                //当前速度 位置
                skinTextBox7.Text = command.Present_Speed.ToString();
                skinTextBox3.Text = command.Present_Location.ToString();

                //伺服使能
                uiLedBulb13.On = command.Servo_Enabled;
                //定位信号
                uiLedBulb14.On = command.Servo_busy;
                //回零完成信号
                uiLedBulb11.On = command.Servo_Home;
                //通讯链接状态
                uiLedBulb15.On = command.Servo_ready;
                //JOG速度
                //command.JOG_Speed = Convert.ToInt32(skinTextBox16.Text);
            });
        }
        bool Orientation = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (Orientation == true) return;
            lock (this)
            {
                if (!command.Servo_ready)
                    return;
                //伺服定位
                Task.Run(() =>
                {
                    Orientation = true;
                    command.Servo_Orientation(false, Convert.ToInt32(skinTextBox12.Text), Convert.ToInt32(skinTextBox13.Text));
                    Orientation = false;
                });
            }
        }
        bool Enabled=false;
        private void button3_Click(object sender, EventArgs e)
        {
            if (Enabled)
                Enabled = false;
            else
                Enabled = true;
            command.Servo_Enabled = Enabled;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            command.Servo_Rst();
        }

        private void ucNavigationMenu1_ClickItemed(object sender, EventArgs e)
        {
            if (this.ucNavigationMenu1.SelectItem.Text.ToString() == "通讯链接")
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
        }
        /// <summary>
        /// 修改定位速度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinTextBox13_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }
        /// <summary>
        /// 正向GOJ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            this.BeginInvoke((EventHandler)delegate
            {
                command.JOG_Speed = Convert.ToInt32(this.skinTextBox16.Text);
                command.Servo_JOG(true, (sender as Control));
            });
        }
        /// <summary>
        /// 反向JOG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            this.BeginInvoke((EventHandler)delegate
            {
                command.JOG_Speed = Convert.ToInt32(this.skinTextBox16.Text);
                command.Servo_JOG(false, (sender as Control));
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hiel = false;
        }
    }
}


