using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny;
using FanucRobot;
using System.Net;
using HZH_Controls.Controls;
namespace Robot通讯控制
{
    public partial class RobotForm : Sunny.UI.UIForm
    {
        public RobotForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 机器人访问对象
        /// </summary>
        FanucRobIntelface robot;
        /// <summary>
        /// 触发链接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton1_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            IPAddress.TryParse(this.uiTextBox1.Text, out ip);
            robot = new FanucRobIntelface(ip.ToString());
            var err = robot.Connect();
            uiButton1.Text = err.isError == true ? "链接失败" : "链接成功";
            if(err.isError==false)
            {
                robot.SocketRead += new EventHandler(SocketRead);
                robot.Socketsedn += new EventHandler(Socketsedn);
            }

        }
        /// <summary>
        /// 创建套接字发送报文
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        public void Socketsedn(object send,EventArgs e)
        {
            uiRichTextBox1.AppendText("\r\n"+BitConverter.ToString((byte[])send));
        }
        /// <summary>
        /// 创建套接字接受报文
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        public void SocketRead(object send,EventArgs e)
        {
            uiRichTextBox2.AppendText("\r\n" + BitConverter.ToString((byte[])send));
        }
        /// <summary>
        /// 接受数据共有方法
        /// </summary>
        /// <param name="title">类型</param>
        /// <param name="obj"></param>
        void PrintResult(RobotIO robot,string title, Array obj)
        {
            switch (robot)
            {
                case RobotIO.Position:

                    var posti = (from Control pi in this.groupBox14.Controls where pi is TextBox_overwrite orderby ((TextBox_overwrite)pi).Serial select pi).ToList();
                    var poste = (from Control pi in this.groupBox15.Controls where pi is TextBox_overwrite orderby ((TextBox_overwrite)pi).Serial select pi).ToList();
                    for (int i = 0; i < obj.Length; i++)
                    {
                        if (i < 6)
                            posti[i].Text = obj.GetValue(i).ToString();
                        else
                            poste[i - 6].Text = obj.GetValue(i).ToString();

                    }
                    break;
                case RobotIO.R:
                    var posR = (from Control pi in this.groupBox12.Controls where pi is TextBox_overwrite orderby ((TextBox_overwrite)pi).Serial select pi).ToList();
                    for (int i = 0; i < obj.Length; i++)
                    {
                        if (i >= posR.Count)
                            break;
                        posR[i].Text = obj.GetValue(i).ToString();
                    }
                    break;
                case RobotIO.PR:
                    var posPR = (from Control pi in this.groupBox13.Controls where pi is TextBox_overwrite orderby ((TextBox_overwrite)pi).Serial select pi).ToList();
                    for (int i = 0; i < obj.Length; i++)
                    {
                        if (i >= posPR.Count)
                            break;
                        posPR[i].Text = obj.GetValue(i).ToString();
                    }
                    break;
                case RobotIO.RI:
                    var posRI = (from Control pi in this.groupBox2.Controls where pi is UCBtnExt_overwrite orderby ((UCBtnExt_overwrite)pi).Serial select pi).ToList();
                    for (int i = 0; i < obj.Length; i++)
                    {
                        var conrt = posRI[i] as UCBtnExt_overwrite;
                        conrt.BtnText = Convert.ToBoolean(obj.GetValue(i)) == true ? $"RI{i+1}-ON" : $"RI{i+1}-OFF";
                        conrt.FillColor = Convert.ToBoolean(obj.GetValue(i)) == false ? Color.FromArgb(255, 87, 34) : Color.FromName("Lime");
                    }
                    break;
                case RobotIO.RO:
                    var posRO = (from Control pi in this.groupBox3.Controls where pi is UCBtnExt_overwrite orderby ((UCBtnExt_overwrite)pi).Serial select pi).ToList();
                    for (int i = 0; i < obj.Length; i++)
                    {
                        var conrt = posRO[i] as UCBtnExt_overwrite;
                        conrt.BtnText = Convert.ToBoolean(obj.GetValue(i)) == true ? $"RO{i + 1}-ON" : $"RO{i + 1}-OFF";
                        conrt.FillColor = Convert.ToBoolean(obj.GetValue(i)) == false ? Color.FromArgb(255, 87, 34) : Color.FromName("Lime");
                    }
                    break;
                case RobotIO.DI:
                    var posDI = (from Control pi in this.groupBox9.Controls where pi is UCBtnExt_overwrite orderby ((UCBtnExt_overwrite)pi).Serial select pi).ToList();
                    for (int i = 0; i < obj.Length; i++)
                    {
                        var conrt = posDI[i] as UCBtnExt_overwrite;
                        conrt.BtnText = Convert.ToBoolean(obj.GetValue(i)) == true ? $"DI{i + 1}-ON" : $"DI{i + 1}-OFF";
                        conrt.FillColor = Convert.ToBoolean(obj.GetValue(i)) == false ? Color.FromArgb(255, 87, 34) : Color.FromName("Lime");
                    }
                    break;
                case RobotIO.DO:
                    var posDO = (from Control pi in this.groupBox8.Controls where pi is UCBtnExt_overwrite orderby ((UCBtnExt_overwrite)pi).Serial select pi).ToList();
                    for (int i = 0; i < obj.Length; i++)
                    {
                        var conrt = posDO[i] as UCBtnExt_overwrite;
                        conrt.BtnText = Convert.ToBoolean(obj.GetValue(i)) == true ? $"DO{i + 1}-ON" : $"DO{i + 1}-OFF";
                        conrt.FillColor = Convert.ToBoolean(obj.GetValue(i)) == false ? Color.FromArgb(255, 87, 34) : Color.FromName("Lime");
                    }
                    break;
                case RobotIO.UI:
                    var posUI = (from Control pi in this.groupBox11.Controls where pi is UCBtnExt_overwrite orderby ((UCBtnExt_overwrite)pi).Serial select pi).ToList();
                    for (int i = 0; i < obj.Length; i++)
                    {
                        var conrt = posUI[i] as UCBtnExt_overwrite;
                        conrt.BtnText = Convert.ToBoolean(obj.GetValue(i)) == true ? $"UI{i + 1}-ON" : $"UI{i + 1}-OFF";
                        conrt.FillColor = Convert.ToBoolean(obj.GetValue(i)) == false ? Color.FromArgb(255, 87, 34) : Color.FromName("Lime");
                    }
                    break;
                case RobotIO.UO:
                    var posU0 = (from Control pi in this.groupBox10.Controls where pi is UCBtnExt_overwrite orderby ((UCBtnExt_overwrite)pi).Serial select pi).ToList();
                    for (int i = 0; i < obj.Length; i++)
                    {
                        var conrt = posU0[i] as UCBtnExt_overwrite;
                        conrt.BtnText = Convert.ToBoolean(obj.GetValue(i)) == true ? $"U0{i + 1}-ON" : $"U0{i + 1}-OFF";
                        conrt.FillColor = Convert.ToBoolean(obj.GetValue(i)) == false ? Color.FromArgb(255, 87, 34) : Color.FromName("Lime");
                    }
                    break;
            }

        }

        /// <summary>
        /// 界面显示时---加载用户数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RobotForm_Shown(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                //更改RI控件组名称
                (from UCBtnExt_overwrite pi in this.groupBox2.Controls where pi is UCBtnExt_overwrite select pi).ToList().ForEach(s=> {
                    s.BtnText = $"RI-{s.Serial}";
                });
                //更改RO控件组名称
                (from UCBtnExt_overwrite pi in this.groupBox3.Controls where pi is UCBtnExt_overwrite select pi).ToList().ForEach(s => {
                    s.BtnText = $"RO-{s.Serial}";
                });
                //更改DI控件组名称
                (from UCBtnExt_overwrite pi in this.groupBox9.Controls where pi is UCBtnExt_overwrite select pi).ToList().ForEach(s => {
                    s.BtnText = $"DI-{s.Serial}";
                });
                //更改DO控件组名称
                (from UCBtnExt_overwrite pi in this.groupBox8.Controls where pi is UCBtnExt_overwrite select pi).ToList().ForEach(s => {
                    s.BtnText = $"DO-{s.Serial}";
                });
                //更改UI控件组名称
                (from UCBtnExt_overwrite pi in this.groupBox11.Controls where pi is UCBtnExt_overwrite select pi).ToList().ForEach(s => {
                    s.BtnText = $"UI-{s.Serial}";
                });
                //更改UO控件组名称
                (from UCBtnExt_overwrite pi in this.groupBox10.Controls where pi is UCBtnExt_overwrite select pi).ToList().ForEach(s => {
                    s.BtnText = $"UO-{s.Serial}";
                });
            });
        }
        private void Ri_TO_Robot(object sender, EventArgs e)
        {
            var conrts = ((UCBtnExt_overwrite)sender);
            robot.WriteRdo(new bool[] { conrts.BtnText== $"RO{conrts.Serial}-OFF"?true:false }, 0 + conrts.Serial);

        }
        private void Do_TO_Robot(object sender, EventArgs e)
        {
            var conrts = ((UCBtnExt_overwrite)sender);
            robot.WriteSdo(new bool[] { conrts.BtnText == $"DO{conrts.Serial}-OFF" ? true : false }, 0 + conrts.Serial);

        }
        private void Uo_TO_Robot(object sender, EventArgs e)
        {
            var conrts = ((UCBtnExt_overwrite)sender);
            robot.WriteUo(new bool[] { conrts.BtnText == $"UO{conrts.Serial}-OFF" ? true : false }, 0 + conrts.Serial);

        }
        private void uiRichTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BeginInvoke((EventHandler)delegate
            {
                if (uiButton1.Text == "链接成功")
                {
                    //刷新位置
                    robot.Refresh();
                    float[] Pos = new float[12];
                    robot.curPos.pc.CopyTo(Pos, 0);
                    robot.curPos.pj.CopyTo(Pos, 6);
                    PrintResult(RobotIO.Position, $"CurrentPos-XYZ", Pos);
                    //刷新R寄存器
                    PrintResult(RobotIO.R, $"int - R", robot.intRegs);
                    //刷新PR寄存器
                    PrintResult(RobotIO.PR, $"int - PR", robot.intRegs);
                    //刷新RI\RO
                    var startIdx = 1;
                    var count = 10;
                    bool[] data = null;
                    var ret = robot.ReadRdi(startIdx, count, ref data);
                    PrintResult(RobotIO.RI,$"RDI[{startIdx}-{count + startIdx - 1}]", data);
                    //刷新RO
                    _= robot.ReadRdo(startIdx, count, ref data);
                    PrintResult(RobotIO.RO,$"RDO[{startIdx}-{count + startIdx - 1}]", data);
                    //刷新DI
                    _=robot.ReadSdI(startIdx, count, ref data);
                    PrintResult(RobotIO.DI, $"RDO[{startIdx}-{count + startIdx - 1}]", data);
                    //刷新DO
                    _ = robot.ReadSdo(startIdx, count, ref data);
                    PrintResult(RobotIO.DO, $"RDO[{startIdx}-{count + startIdx - 1}]", data);
                    //刷新UI
                    _ = robot.ReadRui(startIdx, count, ref data);
                    PrintResult(RobotIO.UI, $"UI[{startIdx}-{count + startIdx - 1}]", data);
                    //刷新UO
                    _ = robot.ReadRuo(startIdx, count, ref data);
                    PrintResult(RobotIO.UO, $"UO[{startIdx}-{count + startIdx - 1}]", data);
                }
            });
        }
    }
}
