using csscript;
using CSScriptLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using CCWin.SkinControl;
using CCWin.SkinClass;
using CSEngineTest.重构帮助文档;

namespace CSEngineTest
{
    public partial class Form1 : Skin_Mac
    {
        /// <summary>
        /// 编译报警内容
        /// </summary>
        public string Err_content { get; set; } = string.Empty;//编译报警内容
        /// <summary>
        /// 指示是否编译成功
        /// </summary>
        public bool succeed { get; set; } = false;//指示是否编译成功
        /// <summary>
        /// 编译成功的内容
        /// </summary>
        public string content { get; set; } = string.Empty;//编译成功的内容
        /// <summary>
        /// 默认显示的编号--指示着当前编辑的ID
        /// </summary>
        public int serial { get; set; } = 0;//默认显示的编号
        /// <summary>
        /// 默认显示的宏指令名称
        /// </summary>
        public string Name_1 { get; set; } = "Main";//默认显示的宏指令名称
        /// <summary>
        /// 默认500ms运行间隔
        /// </summary>
        public int run_time { get; set; } = 500;//默认500ms运行间隔
        /// <summary>
        /// 默认加载的方法--目前不可改变方法--
        /// </summary>
        public int current_method { get; set; } = 0;//默认加载的方法
        /// <summary>
        /// 指示着是否周期执行
        /// </summary>
        public bool period_run { get; set; } = false;//指示着是否周期执行
        /// <summary>
        /// 加载的内容
        /// </summary>
        public string Load_content { get; set; } = string.Empty;//加载的内容
        /// <summary>
        /// 是否加载数据库内容
        /// </summary>
        public bool Load_OK { get; set; } = false;//是否加载数据库内容
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public  delegate int MyDelegate(int ID,Form1 form);//EF刷新委托
        /// <summary>
        /// 注册对象Action<TextBoxBase, string>
        /// </summary>
        Action<TextBoxBase, string> txtBoxAction;
        /// <summary>
        /// 注册对象 Action<Label, long> labelAction;
        /// </summary>
        Action<Label, long> labelAction;
        /// <summary>
        /// 定时器 watch 测量时间
        /// </summary>
        Stopwatch watch = new Stopwatch();

        
        int a = 7;
        int b = 3;
        string message = "supcon";
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Form1()
        {
            InitializeComponent();            
        }
        /// <summary>
        /// 运行任务构造函数
        /// </summary>
        List<string> Data;//要加载的任务表
        bool Run;//是否加载数据
        public Form1(List<string> Data,bool Run)
        {
            InitializeComponent();
            this.Data = Data;
            this.Run = Run;
        }
        public void Load_Refresh()//刷新窗口
        {
            this.skinTextBox1.Text = serial.ToString();//获取设置的编号
            this.skinTextBox2.Text = Name_1;//获取宏指令名称
            this.skinTextBox3.Text = run_time.ToString();//获取刷新时间
            this.skinCheckBox1.Checked = period_run;//是否周期执行
            if(Load_content.IsNull()!=true) this.txtSampleCode.Text = Load_content.Trim();//获取刷新后的内容
            this.cmbSampleMethod.SelectedIndex = current_method;//设置选择的方法
            this.cmbSampleMethod.SelectedItem = current_method;//设置选择的方法
        }

        /// <summary>
        /// 窗口加载 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            InitScriptConfig();
            LoadSampleFunctions();//初始化
          
        }

        private void InitScriptConfig()
        {
            CSScriptLibrary.CSScript.EvaluatorConfig.Engine = CSScriptLibrary.EvaluatorEngine.CodeDom;//可以用于其他项目
        }
        /// <summary>
        /// 初始化参数
        /// </summary>
        private void LoadSampleFunctions()
        {
            cmbSampleMethod.DataSource = SampleManager.GetAllSample();
            cmbSampleMethod.DisplayMember = "MethodName";
            cmbSampleMethod.ValueMember = "SampleCode";
        }
        /// <summary>
        /// 开始运行任务事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (txtSampleCode.Text.Trim() == "")
            {
                MessageBox.Show("内容不能为空！！！");
                return;
            }
            //
            var item = cmbSampleMethod.SelectedItem as MethodSample;
            switch (item.Index)
            {
                case 1:
                    CompileCode();
                    break;
                case 2:
                    CompileMethod();
                    break;
                case 3:
                    CreateDelegate();
                    break;
                case 4:
                    CreateDelegateWithType();
                    break;
                case 5:
                    LoadCode();
                    break;
                case 6:
                    LoadCodeWithType();
                    break;
                case 7:
                    LoadDelegateWithType();
                    break;
                case 8:
                    LoadFile();
                    break;
                case 9:
                    LoadFileWithType();
                    break;
                case 10:
                    LoadMethod();
                    break;
                case 11:
                    LoadMethodWithType();
                    break;
                default:
                    MessageBox.Show("找不到对应方法！！！");
                    break;
            }
        }
        /// <summary>
        /// 判断调用的 事例
        /// </summary>
        #region 调用示例

        //调用示例01
        private void CompileCode()
        {
            watch.Start();

            try
            {
                Assembly asm = CSScript.Evaluator.CompileCode(txtSampleCode.Text);
                dynamic obj = asm.CreateObject("*");
                var result = obj.Sum(a, b);
                watch.Stop();
                SetTxtSampleCode(txtOutput, Format(a, b, Convert.ToString(result)));
                SetLabel(lblTime, watch.ElapsedMilliseconds);
                succeed = true;//编译成功
                content = this.txtSampleCode.Text;//获取编译成功的内容
                watch.Reset();
            }
            catch (/*CompilerException*/Exception ex)
            {
                SetTxtSampleCode(txtOutput, ex.Message);               
                watch.Reset();
                succeed = false;//编译失败
                Err_content= this.txtSampleCode.Text;//获取编译失败报警内容
            }

        }

        //调用示例02
        private void CompileMethod()
        {
            watch.Start();
            try
            {
                Assembly asm = CSScript.Evaluator.CompileMethod(txtSampleCode.Text);
                dynamic obj = asm.CreateObject("*");
                var result = obj.Sum(a, b);
                watch.Stop();
                SetTxtSampleCode(txtOutput, Format(a, b, Convert.ToString(result)));
                SetLabel(lblTime, watch.ElapsedMilliseconds);
                watch.Reset();
            }
            catch (Exception ex)
            {
                SetTxtSampleCode(txtOutput, ex.Message);
                watch.Reset();
            }

        }

        //调用示例03
        private void CreateDelegate()
        {
            watch.Start();
            try
            {
                var log = CSScript.Evaluator.CreateDelegate(txtSampleCode.Text);
                var result = log(message);
                watch.Stop();
                SetTxtSampleCode(txtOutput, "message=" + message + "\r\n" + Convert.ToString(result));
                SetLabel(lblTime, watch.ElapsedMilliseconds);
                watch.Reset();
            }
            catch (Exception ex)
            {
                SetTxtSampleCode(txtOutput, ex.Message);
                watch.Reset();
            }
        }

        //调用示例04
        private void CreateDelegateWithType()
        {
            watch.Start();
            try
            {
                var product = CSScript.Evaluator.CreateDelegate<int>(txtSampleCode.Text);
                int result = product(a, b);
                watch.Stop();
                SetTxtSampleCode(txtOutput, Format(a, b, Convert.ToString(result)));
                SetLabel(lblTime, watch.ElapsedMilliseconds);
                watch.Reset();
            }
            catch (Exception ex)
            {
                SetTxtSampleCode(txtOutput, ex.Message);
                watch.Reset();
            }
        }

        //调用示例05
        private void LoadCode()
        {
            watch.Start();
            try
            {
                dynamic obj = CSScript.Evaluator.LoadCode(txtSampleCode.Text);
                var result = obj.Sum(a, b);
                watch.Stop();
                SetTxtSampleCode(txtOutput, Format(a, b, Convert.ToString(result)));
                SetLabel(lblTime, watch.ElapsedMilliseconds);
                watch.Reset();
            }
            catch (Exception ex)
            {
                SetTxtSampleCode(txtOutput, ex.Message);
                watch.Reset();
            }
        }

        //调用示例06
        private void LoadCodeWithType()
        {
            watch.Start();
            try
            {
                ITest test = CSScript.Evaluator.LoadCode<ITest>(txtSampleCode.Text);
                int result = test.Div(a, b);
                watch.Stop();
                SetTxtSampleCode(txtOutput, Format(a, b, Convert.ToString(result)));
                SetLabel(lblTime, watch.ElapsedMilliseconds);
                watch.Reset();
            }
            catch (Exception ex)
            {
                SetTxtSampleCode(txtOutput, ex.Message);
                watch.Reset();
            }
        }


        //调用示例07
        private void LoadDelegateWithType()
        {
            watch.Start();
            try
            {
                var func = CSScript.Evaluator.LoadDelegate<Func<int, int, int>>(txtSampleCode.Text);
                int result = func(a, b);
                watch.Stop();
                SetTxtSampleCode(txtOutput, Format(a, b, Convert.ToString(result)));
                SetLabel(lblTime, watch.ElapsedMilliseconds);
                watch.Reset();
            }
            catch (Exception ex)
            {
                SetTxtSampleCode(txtOutput, ex.Message);
                watch.Reset();
            }
        }

        //调用示例08
        private void LoadFile()
        {

        }

        //调用示例09
        private void LoadFileWithType()
        {

        }

        //调用示例10
        private void LoadMethod()
        {
            watch.Start();
            try
            {
                dynamic obj = CSScript.Evaluator.LoadMethod(txtSampleCode.Text);
                var result = obj.Product(a, b);
                watch.Stop();
                SetTxtSampleCode(txtOutput, Format(a, b, Convert.ToString(result)));
                SetLabel(lblTime, watch.ElapsedMilliseconds);
                watch.Reset();
            }
            catch (Exception ex)
            {
                SetTxtSampleCode(txtOutput, ex.Message);
                watch.Reset();
            }
        }


        //调用示例11
        private void LoadMethodWithType()
        {
            watch.Start();
            try
            {
                ITest product = CSScript.Evaluator.LoadMethod<ITest>(txtSampleCode.Text);
                int result = product.Div(a, b);
                watch.Stop();
                SetTxtSampleCode(txtOutput, Format(a, b, Convert.ToString(result)));
                SetLabel(lblTime, watch.ElapsedMilliseconds);
                watch.Reset();
            }
            catch (Exception ex)
            {
                SetTxtSampleCode(txtOutput, ex.Message);
                watch.Reset();
            }
        }


        #endregion
        /// <summary>
        /// 事例运行结果
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private string Format(int a, int b, string result)
        {
            return string.Format("a={0},b={1}\r\n{2}", a, b, result);
        }
        /// <summary>
        /// 下拉菜单 动态加载 事例--
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSampleMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cmbSampleMethod.SelectedItem as MethodSample;
            SetTxtSampleCode(txtSampleCode, item.SampleCode);
        }

        /// <summary>
        /// 加载事例
        /// </summary>
        /// <param name="txtBox"></param>
        /// <param name="sampleCode"></param>
        private void SetTxtSampleCode(TextBoxBase txtBox, string sampleCode)
        {
            if (txtBox.InvokeRequired)
            {
                txtBoxAction = SetTxtSampleCode;
                txtSampleCode.Invoke(txtBoxAction, sampleCode);
            }
            else
            {
                txtBox.Text = sampleCode;
            }
        }
        /// <summary>
        /// 输出定时器 任务运行的值
        /// </summary>
        /// <param name="label"></param>
        /// <param name="time"></param>
        private void SetLabel(Label label, long time)
        {
            string timeStr = Convert.ToString(time);
            if (label.InvokeRequired)
            {
                labelAction = SetLabel;
                txtSampleCode.Invoke(labelAction, timeStr);
            }
            else
            {
                label.Text = "耗时：" + timeStr + "ms";
                state = false;
            }
            
        }
        /// <summary>
        /// 用户点击了函数文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        Explain document_Form;
        private void toolStripMenuItem3_Click(object sender, EventArgs e)//用户点击了函数文档
        {
            if (document_Form.IsNull())
            {
                document_Form = new Explain();
                document_Form.Show();//打开文档
            }
            else
                document_Form.Activate();//窗口已打开直接激活
        }
        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        bool state = false;
        private void Form1_Shown(object sender, EventArgs e)//显示窗口
        {
            if (Load_OK) Load_Refresh();
            this.skinTextBox1.Text = serial.ToString();//获取设置的编号
            this.skinTextBox2.Text = Name_1;//获取宏指令名称
            if (Run)
            {
                this.skinGroupBox1.Visible = true;
                this.skinProgressBar1.Visible = true;
                foreach (string i in Data)
                {
                    state = true;                 
                    this.txtSampleCode.Text = i;
                    this.btnRun_Click(1, new EventArgs());//开始运行任务
                    while (state) { };//死循环等待任务完成     
                    MessageBox.Show("完成了");

                }
                this.skinGroupBox1.Visible = false;
                this.skinProgressBar1.Visible = false;
                this.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//关闭窗口前
        {
            serial= this.skinTextBox1.Text.ToInt32();//获取设置的编号
            Name_1=this.skinTextBox2.Text;//获取宏指令名称
            run_time=this.skinTextBox3.Text.ToInt32();//获取刷新时间
            period_run=this.skinCheckBox1.Checked;//是否周期执行
            current_method = this.cmbSampleMethod.SelectedIndex;//设置选择的方法
            if (document_Form.IsNull() != true) document_Form.Close();//关闭窗口
        }
    }
}
