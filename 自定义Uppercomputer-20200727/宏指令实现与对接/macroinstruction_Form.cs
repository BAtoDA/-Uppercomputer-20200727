using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinClass;
using CCWin.SkinControl;
using CSEngineTest;
using 自定义Uppercomputer_20200727.EF实体模型;

namespace 自定义Uppercomputer_20200727.宏指令实现与对接
{
    public partial class macroinstruction_Form : Skin_VS
    {
        public macroinstruction_Form()
        {
            InitializeComponent();
        }
        PLC_macroinstruction_EF PLC_macroinstruction_EF;//EF操作对象
        private void macroinstruction_Form_Shown(object sender, EventArgs e)//加载数据
        {
            PLC_macroinstruction_EF = new PLC_macroinstruction_EF();
            PLC_macroinstruction_EF.skinDataGridView_update(this.skinDataGridView1);       
            if (service)
            {
                this.skinButton4.Text = "任务运行中";
                skinDataGridView1.Enabled = false;
            }//任务运行中不允许进入宏指令
            }
        int Index = 0;
        private void skinDataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Index = e.RowIndex;
            if (e.RowIndex > -1)//判断用户是否选中行
            {
                if (this.skinDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim() == "")//用户是否选中了空行
                {
                    MessageBox.Show("你选中了空行", "Err");//提示异常
                    return; //返回方法
                }
                else
                {
                    CSEngineTest.Form1 Form1_Message = new CSEngineTest.Form1();//弹出窗口
                    PLC_macroinstruction pLC_Macroinstruction = PLC_macroinstruction_EF.PLC_macroinstruction_inquire(this.skinDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToInt32());
                    if (pLC_Macroinstruction.IsNull()!=true)//判断是否有改数据
                    {
                        this.Refresh_data(this.skinDataGridView1.Rows[e.RowIndex].Cells[0].Value.ToInt32(), Form1_Message, pLC_Macroinstruction);//先设置属性                       
                    }
                    else
                    {
                        Form1_Message.serial = PLC_macroinstruction_EF.PLC_macroinstruction_Max();//查询数据库最大值
                        Form1_Message.Name = "Mian" + Form1_Message.serial.ToString();//获取宏指令名称
                    }
                    Form1_Message.ShowDialog();//显示窗口
                    pLC_Macroinstruction_Refresh(Form1_Message.serial, Form1_Message);//保存到数据库
                    PLC_macroinstruction_EF.skinDataGridView_update(this.skinDataGridView1);//更新数据库
                }
            }

        }
        private void Item1_Click(object sender, EventArgs e)//插入宏
        {
            if (service) { MessageBox.Show("任务运行中请停止任务再执行操作"); return; }
            CSEngineTest.Form1 Form1_Message = new CSEngineTest.Form1();//弹出窗口
            Form1_Message.serial = PLC_macroinstruction_EF.PLC_macroinstruction_Max();//查询数据库最大值
            Form1_Message.Name_1 = "Mian"+ Form1_Message.serial.ToString();//获取宏指令名称
            Form1_Message.ShowDialog();//显示窗口
            pLC_Macroinstruction_Refresh(Form1_Message.serial, Form1_Message);//保存到数据库
            PLC_macroinstruction_EF.skinDataGridView_update(this.skinDataGridView1);//更新数据库
        }

        private void Item2_Click(object sender, EventArgs e)//删除宏
        {
            if (service) { MessageBox.Show("任务运行中请停止任务再执行操作"); return; }
            if (this.skinDataGridView1.CurrentCell.RowIndex.IsNull() != true)//判断用户是否选中行
            {
                PLC_macroinstruction_EF.skinDataGridView_RemoveAt(this.skinDataGridView1);//实现删除行
                PLC_macroinstruction_EF.skinDataGridView_update(this.skinDataGridView1);//更新数据库
            }
        }
        private void Item3_Click(object sender, EventArgs e)//编辑宏
        {
            if (service) { MessageBox.Show("任务运行中请停止任务再执行操作"); return; }
            if (Index > -1)//判断用户是否选中行
            {
                if (this.skinDataGridView1.Rows[Index].Cells[0].Value.ToString().Trim() == "")//用户是否选中了空行
                {
                    MessageBox.Show("你选中了空行", "Err");//提示异常
                    return; //返回方法
                }
                else
                {
                    CSEngineTest.Form1 Form1_Message = new CSEngineTest.Form1();//弹出窗口
                    PLC_macroinstruction pLC_Macroinstruction = PLC_macroinstruction_EF.PLC_macroinstruction_inquire(this.skinDataGridView1.Rows[Index].Cells[0].Value.ToInt32());
                    if (pLC_Macroinstruction.IsNull() != true)//判断是否有改数据
                    {
                        this.Refresh_data(this.skinDataGridView1.Rows[Index].Cells[0].Value.ToInt32(), Form1_Message, pLC_Macroinstruction);//先设置属性                       
                    }
                    else
                    {
                        Form1_Message.serial = PLC_macroinstruction_EF.PLC_macroinstruction_Max();//查询数据库最大值
                    }
                    Form1_Message.ShowDialog();//显示窗口
                    pLC_Macroinstruction_Refresh(Form1_Message.serial, Form1_Message);//保存到数据库
                    PLC_macroinstruction_EF.skinDataGridView_update(this.skinDataGridView1);//更新数据库
                }
            }
        }
        private void Refresh_data(int ID, CSEngineTest.Form1 Form1_Message, PLC_macroinstruction pLC_Macroinstruction)//刷新参数
        {
            Form1_Message.serial= pLC_Macroinstruction.ID;//获取设置的编号
            Form1_Message.Name = pLC_Macroinstruction.宏指令名称.Trim();//获取宏指令名称
            Form1_Message.run_time=pLC_Macroinstruction.运行时间间隔;//获取刷新时间
            Form1_Message.period_run= pLC_Macroinstruction.是否周期执行;//是否周期执行
            Form1_Message.Load_content= pLC_Macroinstruction.内容.Trim();//获取刷新后的内容
            Form1_Message.current_method= pLC_Macroinstruction.方法索引;//设置选择的方法
            Form1_Message.Load_OK = true;//加载内容
        }
        public void pLC_Macroinstruction_Refresh(int ID, CSEngineTest.Form1 Form1_Message)//根据ID进行数据修改或者插入
        {
            if (service!=true) //指示着是用户主动开启的线程--不再停止
            {
                foreach (Thread thread in macroinstruction_data<Thread>.thread)//遍历要中止的线程
                {
                    if (thread.IsNull()) continue;//当前线程未使用直接重开
                    if (thread.IsAlive) thread.Abort();//直接销毁线程
                }
            }
            if (Form1_Message.succeed != true) return;//编译失败
            PLC_macroinstruction pLC_Macroinstruction = PLC_macroinstruction_EF.PLC_macroinstruction_inquire(ID);
            if (pLC_Macroinstruction.IsNull() != true)//判断是否有改数据
            {
                PLC_macroinstruction_EF.PLC_macroinstruction_modification(ID, new PLC_macroinstruction()
                {
                    内容 = Form1_Message.content,
                    宏指令名称 = Form1_Message.Name,
                    方法索引 = Form1_Message.current_method,
                    是否周期执行 = Form1_Message.period_run,
                    运行时间间隔 = Form1_Message.run_time
                });
            }
            else
            {
                PLC_macroinstruction_EF.PLC_macroinstruction_Add(new PLC_macroinstruction()
                {
                    ID = ID,
                    内容 = Form1_Message.content,
                    宏指令名称 = Form1_Message.Name,
                    方法索引 = Form1_Message.current_method,
                    是否周期执行 = Form1_Message.period_run,
                    运行时间间隔 = Form1_Message.run_time
                });
            }
        }
        static bool service = false;//指示用户是否已经在运行中
        private void skinButton4_Click(object sender, EventArgs e)//用户点击运行任务
        {
            if (service) { MessageBox.Show("任务已经在运行中---请停止运行中的任务"); return; }
            if (MessageBox.Show("注意检查宏指令是否使用了外部线程--而且还套接了死循环--这样会导致软件闪退或者资源的抢夺--请注意线程的用法", "运行前警告", MessageBoxButtons.YesNo) == DialogResult.No)
                return;//用户取消了任务运行--返回
            service = true;//指示着任务运行中
            this.skinButton4.Text = "任务运行中";//
            skinDataGridView1.Enabled = false;//任务运行中不允许进入宏指令
            List<PLC_macroinstruction> pLCs = PLC_macroinstruction_EF.PLC_macroinstruction_modification();//查询数据库
            List<string> Data = new List<string>();//创建任务表
            foreach (var i in pLCs)
                Data.Add(i.内容.Trim());//获取数据
            CSEngineTest.Form1 Form1_Message = new CSEngineTest.Form1(Data,true);//弹出窗口
            Form1_Message.ShowDialog();//显示窗口
        }

        private void skinButton5_Click(object sender, EventArgs e)//用户点击了停止
        {
            //if (service != true) { MessageBox.Show("无可用停止的任务"); return; }
            if (MessageBox.Show("是否要停止运行中的任务？", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
                return;//直接返回方法
            foreach (Thread thread in macroinstruction_data<Thread>.thread)//遍历要中止的线程
            {
                if (thread.IsNull()) continue;//当前线程未使用直接重开
                if (thread.IsAlive) thread.Abort();//直接销毁线程
            }
            service = false;//指示着停止任务完成
            this.skinButton4.Text = "任务运行";//
            skinDataGridView1.Enabled = true;//任务运行中允许进入宏指令
        }
    }
}
