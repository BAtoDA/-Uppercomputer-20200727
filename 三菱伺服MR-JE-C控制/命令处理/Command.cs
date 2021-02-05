using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace 命令处理
{
    //==============================================================
    //  作者：BAtoDA
    //  时间：2021/2/3 16:23:55 
    //  文件名：Command 
    //  版本：V1.0.1  
    //  说明： 实现处理MR-JE-C伺服使能 复位 JOG 回零  定位等操作
    //  修改者：***
    //  修改说明： 
    //==============================================================
    /// <summary>
    /// 实现处理MR-JE-C伺服使能 复位 JOG 回零  定位等操作
    /// </summary>
    public class Command : public_Class
    {
        /// <summary>
        /// 需要链接的伺服IP与端口
        /// </summary>
        private IPEndPoint IPEnd;
        /// <summary>
        /// MODBUS tcp通讯对象
        /// </summary>
        static MODBUD_TCP modbus;
        /// <summary>
        /// 伺服循环通讯准备好
        /// </summary>
        public bool Servo_ready { get => ready; }//PLC准备好
        private bool ready
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    if (Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)) != 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// 伺服已回零
        /// </summary>
        public bool Servo_Home { get => Home; }
        private bool Home = false;
        /// <summary>
        /// 伺服报警代码
        /// </summary>
        public int ServoErr_code { get => code; }//PLC报警代码
        private int code
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("2A42", 16).ToString(), numerical_format.Signed_16_Bit));
                else
                    return 999;
            }
        }
        /// <summary>
        ///伺服报警内容
        /// </summary>
        public string ServoErr_content { get => content; }//PLC报警内容
        private string content;
        /// <summary>
        /// 伺服使能状态
        /// </summary>
        public bool Servo_Enabled { get => Enabled; set => Enabled = value; }
        private bool Enabled
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    return this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16)[2];
                }
                else
                    return false;
            }
            set
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    if(Enabled)
                       modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("07", 16).ToString(), numerical_format.Signed_16_Bit);
                    else
                       modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("1F", 16).ToString(), numerical_format.Signed_16_Bit);
                }
            }
        }
        /// <summary>
        /// 伺服转矩限制正
        /// </summary>
        public int Torque_Just
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("60E0", 16).ToString(), Convert.ToInt32("1F", 16).ToString(), numerical_format.Signed_16_Bit);
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("60E0", 16).ToString(), numerical_format.Signed_16_Bit));
                }
                else
                    return 0;
            }
            set
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("60E0", 16).ToString(),value.ToString(), numerical_format.Signed_16_Bit);
                }
            }
        }
        /// <summary>
        /// 伺服转矩限制负
        /// </summary>
        public int Torque_Lose
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("60E1", 16).ToString(), Convert.ToInt32("1F", 16).ToString(), numerical_format.Signed_16_Bit);
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("60E1", 16).ToString(), numerical_format.Signed_16_Bit));
                }
                else
                    return 0;
            }
            set
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("60E1", 16).ToString(), value.ToString(), numerical_format.Signed_16_Bit);
                }
            }
        }
        /// <summary>
        /// 伺服加速时间
        /// </summary>
        public int Accelerate
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {             
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6083", 16).ToString(), numerical_format.Signed_32_Bit));
                }
                else
                    return 0;
            }
            set
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6083", 16).ToString(), value.ToString(), numerical_format.Signed_32_Bit);
                }
            }

        }
        /// <summary>
        /// 伺服减速时间
        /// </summary>
        public int Decelerate
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6084", 16).ToString(), numerical_format.Signed_32_Bit));
                }
                else
                    return 0;
            }
            set
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6084", 16).ToString(), value.ToString(), numerical_format.Signed_32_Bit);
                }
            }

        }
        /// <summary>
        /// 伺服当前控制模式
        /// </summary>
        public int Pattern
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6061", 16).ToString(), numerical_format.Signed_16_Bit));
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// 伺服当前控制状态
        /// </summary>
        public int State
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit));
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// 伺服当前控制状态_布尔状态显示
        /// </summary>
        public bool[] State_Bool
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    return this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)),16);
                }
                else
                    return new bool[16];
            }
        }
        /// <summary>
        /// 伺服当前位置
        /// </summary>
        public int Present_Location
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6064", 16).ToString(), numerical_format.Signed_32_Bit));
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// 伺服当前速度
        /// </summary>
        public int Present_Speed
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("606C", 16).ToString(), numerical_format.Signed_32_Bit));
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// 伺服当前滞留脉冲
        /// </summary>
        public int Present_Pulse
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("60F4", 16).ToString(), numerical_format.Signed_32_Bit));
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// 伺服当前转矩
        /// </summary>
        public int Present_Torque
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6077", 16).ToString(), numerical_format.Signed_16_Bit));
                }
                else
                    return 0;
            }
        }
        /// <summary>
        /// 伺服运行速度
        /// </summary>
        public int Instruct_Speed
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6081", 16).ToString(), numerical_format.Signed_32_Bit));
                }
                else
                    return 0;
            }
            set
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    Convert.ToInt32(modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6081", 16).ToString(),value.ToString(), numerical_format.Signed_32_Bit));
                }
            }
        }
        /// <summary>
        /// 伺服JOG速度
        /// </summary>
        public int JOG_Speed
        {
            get
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    return Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("60FF", 16).ToString(), numerical_format.Signed_32_Bit));
                }
                else
                    return 0;
            }
            set
            {
                if (MODBUD_TCP.IPLC_interface_PLC_ready)
                {
                    Convert.ToInt32(modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("60FF", 16).ToString(), value.ToString(), numerical_format.Signed_32_Bit));
                }
            }
        }
        /// <summary>
        /// 伺服定位状态  false 定位中 true 定位完成
        /// </summary>
        public bool Servo_busy { get => busy; }
        private bool busy;
        /// <summary>
        /// 构造函数
        /// </summary>
        public Command(IPEndPoint iPEnd)
        {
            this.IPEnd = iPEnd;//获取IP
            modbus = new MODBUD_TCP(this.IPEnd,this.IPEnd.Port.ToString());//实例化通讯对象
        }
        public Command()
        {

        }
        /// <summary>
        /// 链接伺服
        /// </summary>
        /// <returns></returns>
        public bool Servo_Open()
        {
            if(!MODBUD_TCP.IPLC_interface_PLC_ready)
            {
                modbus.IPLC_interface_PLC_open();
            }
            return MODBUD_TCP.IPLC_interface_PLC_ready;
        }
        public bool Servo_GoHome()
        {
            int Step = 0;
            bool[] Status = new bool[16];
            bool GoHome_err=false;
            Home = false;
            //实例化看门狗定时器
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Enabled = true;
            timer.Interval = 5000;
            timer.Tick += ((send, e) =>
              {
                  GoHome_err = true;
              });
            try
            {
                while (true)
                {
                    if (GoHome_err)
                    {
                        MessageBox.Show("回原点超时");
                        Home = false;
                        timer.Stop();
                        return true;
                    }
                    if (!MODBUD_TCP.IPLC_interface_PLC_ready)
                    {
                        MessageBox.Show("网络异常，执行回零操作失败");
                        Home = false;
                        timer.Stop();
                        return true;
                    }
                    //传入定位位置 与 速度
                    modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("607A", 16).ToString(), "0", numerical_format.Signed_32_Bit);
                    modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6081", 16).ToString(),"5000", numerical_format.Signed_32_Bit);

                    if (Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("2A42", 16).ToString(), numerical_format.Signed_16_Bit)) != 0 & Step > 1)
                        MessageBox.Show("回零点过程中出现伺服报警");
                    switch (Step)
                    {
                        case 0://复位伺服-->TO-->6040
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("80", 16).ToString(), numerical_format.Signed_16_Bit);

                            //判断伺服有无报警
                            Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                            if (Status[3] == false & modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("2A42", 16).ToString(), numerical_format.Signed_16_Bit) == "0")
                                Step = 1;
                            break;
                        case 1://等待打开伺服使能-->TO-->6040
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("06", 16).ToString(), numerical_format.Signed_16_Bit);
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("07", 16).ToString(), numerical_format.Signed_16_Bit);
                            //判断伺服有无报警
                            Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                            if (Status[0])
                                Step = 2;
                            break;
                        case 2://等待伺服运行-->TO-->6040
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("0F", 16).ToString(), numerical_format.Signed_16_Bit);
                            //判断伺服有无报警
                            Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                            if (Status[0])
                                Step = 3;
                            break;
                        case 3://切换伺服运行模式--回零模式-->TO-->6060
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6060", 16).ToString(), Convert.ToInt32("06", 16).ToString(), numerical_format.Signed_16_Bit);
                            //判断伺服有无报警
                            Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                            if (Status[0] & Status[1] & Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6061", 16).ToString(), numerical_format.Signed_16_Bit)) == 6)
                                Step = 4;
                            break;
                        case 4://启动回零模式-->TO-->6040
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("1F", 16).ToString(), numerical_format.Signed_16_Bit);
                            //判断伺服有无报警
                            Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                            if (Status[0] & Status[1] & Status[2] & Status[12] & Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6064", 16).ToString(), numerical_format.Signed_16_Bit)) == 0)
                                Step = 5;
                            break;
                        case 5://松开使能-->TO-->6040
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("0F", 16).ToString(), numerical_format.Signed_16_Bit);
                            //判断伺服有无报警
                            Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                            if (Status[0] & Status[1] & Status[2])
                                Step = 6;
                            break;
                        case 6://回零完成-->TO-->6060
                           modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6060", 16).ToString(), Convert.ToInt32("01", 16).ToString(), numerical_format.Signed_16_Bit);
                            if (Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6061", 16).ToString(), numerical_format.Signed_16_Bit)) == 01)
                                modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("1F", 16).ToString(), numerical_format.Signed_16_Bit);
                            //判断伺服有无报警
                            Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                            if (Status[0] & Status[1] & Status[2] & Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6061", 16).ToString(), numerical_format.Signed_16_Bit)) == 01)
                                Step = 7;
                            break;
                        case 7:
                            MessageBox.Show("回原点完成");
                            Home = true;
                            timer.Stop();
                            return true;
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("回原点异常"+e.Message);
                Home = false;
                timer.Stop();
                return true;
            }
        }
        /// <summary>
        /// 复位伺服故障
        /// </summary>
        /// <returns></returns>
        public bool Servo_Rst()
        {
            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("07", 16).ToString(), numerical_format.Signed_16_Bit);
            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("80", 16).ToString(), numerical_format.Signed_16_Bit);
            bool[] Status = new bool[16];
            Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
            if (Status[0] & Status[3] == false)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 伺服定位启动--需要先回原点
        /// </summary>
        /// <param name="type">定位类型 OFF绝对 ON 相对</param>
        /// <param name="location">定位位置</param>
        /// <param name="speed">定位速度</param>
        /// <returns></returns>
        public bool Servo_Orientation(bool type,int location,int speed)
        {
            int Step = 0;
            bool[] Status = new bool[16];
            bool Orientation_err = false;
            busy = false;
            //实例化看门狗定时器
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Enabled = true;
            timer.Interval = 2000;
            timer.Tick += ((send, e) =>
            {
                Orientation_err = true;
            });
            if (!this.Home)
            {
                MessageBox.Show("请先执行回原点操作");
                busy = true;
                return false;
            }
            while(true)
            {

                if (Orientation_err)
                {
                    timer.Stop();
                    MessageBox.Show("定位超时");
                    busy = true;
                    return false;
                }
                //传入定位位置 与 速度
                busy = false;
                modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("607A", 16).ToString(),location.ToString(), numerical_format.Signed_32_Bit);
               modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6081", 16).ToString(), speed.ToString(), numerical_format.Signed_32_Bit);
                switch (Step)
                {

                    case 0://判断伺服是否进入位置模式？		
                        if (Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6061", 16).ToString(), numerical_format.Signed_16_Bit)) != 01)
                            Step = 100;//强行进入位置模式
                        modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("1F", 16).ToString(), numerical_format.Signed_16_Bit);
                        //判断伺服有无报警
                        Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                        if (Status[0] & Status[1] & Status[2] & Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6061", 16).ToString(), numerical_format.Signed_16_Bit)) == 01)
                            Step = 1;
                        break;
                    case 1://判断伺服定位类型
                        if(type)
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("6F", 16).ToString(), numerical_format.Signed_16_Bit);
                        else
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("2F", 16).ToString(), numerical_format.Signed_16_Bit);
                        //判断伺服有无报警
                        Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                        if (Status[0] & Status[1] & Status[2] & Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6061", 16).ToString(), numerical_format.Signed_16_Bit)) == 01)
                            Step = 2;
                        break;
                    case 2://启动伺服定位
                        if (type)
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("7F", 16).ToString(), numerical_format.Signed_16_Bit);
                        else
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("3F", 16).ToString(), numerical_format.Signed_16_Bit);
                        //判断伺服有无报警
                        Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                        if (Status[0] & Status[1] & Status[2] & Status[12] || Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6064", 16).ToString(), numerical_format.Signed_16_Bit)) == location)
                            Step = 3;
                        break;
                    case 3:
                        if (type)
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("6F", 16).ToString(), numerical_format.Signed_16_Bit);
                        else
                            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("2F", 16).ToString(), numerical_format.Signed_16_Bit);
                        //判断伺服有无报警
                        Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                        if (Status[0] & Status[1] & Status[2])
                            Step = 4;
                        break;
                    case 4://定位完成
                        timer.Stop();
                        busy = true;
                        return true;
                    case 100://复位伺服-->TO-->6040
                        modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("80", 16).ToString(), numerical_format.Signed_16_Bit);

                        //判断伺服有无报警
                        Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                        if (Status[3] == false & modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("2A42", 16).ToString(), numerical_format.Signed_16_Bit) == "0")
                            Step = 101;
                        break;
                    case 101://等待打开伺服使能-->TO-->6040
                        modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("06", 16).ToString(), numerical_format.Signed_16_Bit);
                        modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("07", 16).ToString(), numerical_format.Signed_16_Bit);
                        //判断伺服有无报警
                        Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                        if (Status[0])
                            Step = 102;
                        break;
                    case 102://等待伺服运行-->TO-->6040
                        modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("0F", 16).ToString(), numerical_format.Signed_16_Bit);
                        //判断伺服有无报警
                        Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                        if (Status[0])
                            Step = 103;
                        break;
                    case 103://切换伺服运行模式--位置模式-->TO-->6060
                        modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6060", 16).ToString(), Convert.ToInt32("06", 16).ToString(), numerical_format.Signed_16_Bit);
                        //判断伺服有无报警
                        Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                        if (Status[0] & Status[1] & Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6061", 16).ToString(), numerical_format.Signed_16_Bit)) == 1)
                            Step = 104;
                        break;
                    case 104://启动位置模式-->TO-->6040
                        modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("1F", 16).ToString(), numerical_format.Signed_16_Bit);
                        //判断伺服有无报警
                        Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
                        if (Status[0] & Status[1] & Status[2])
                            Step = 0;
                        break;

                }
            }
        }
        /// <summary>
        /// 伺服JOG 
        /// </summary>
        /// <param name="Direction">true 正向JOG false 方向JOG</param>
        /// <param name="control">需要传入 运动的控件</param>
        /// <returns></returns>
        public void Servo_JOG(bool Direction, Control control)
        {
            if (!this.Servo_ready)
            {
                MessageBox.Show("伺服未准备好");
            }
            //Task task;
            CancellationTokenSource _cancelSource = new CancellationTokenSource();
            //用户松开鼠标事件
            control.MouseUp += ((Send, e) =>
              {
                  //_cancelSource.Cancel();
                  modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("0F", 16).ToString(), numerical_format.Signed_16_Bit);
                  modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6060", 16).ToString(), Convert.ToInt32("01", 16).ToString(), numerical_format.Signed_16_Bit);
              });
            //task = new Task(() =>
            //{
            //切换模式--位置模式--TO--JOG模式
            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("0F", 16).ToString(), numerical_format.Signed_16_Bit);
            modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6060", 16).ToString(), Convert.ToInt32("03", 16).ToString(), numerical_format.Signed_16_Bit);
            this.JOG_Speed = this.JOG_Speed == 0 ? 500 : this.JOG_Speed;     
            //判断JOG旋转方向---0F--TO--800F--启动JOG
            if (Direction)
            {
                modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("800F", 16).ToString(), numerical_format.Unsigned_16_Bit);
               
            }
            else
            {
                this.JOG_Speed = this.JOG_Speed > 0 ? 0 - this.JOG_Speed : this.JOG_Speed;
                modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("800F", 16).ToString(), numerical_format.Unsigned_16_Bit);
            }
            //});
            //task.Start();
        }
        /// <summary>
        /// 处理伺服使能
        /// </summary>
        /// <param name="Enabled">TRUE 导通使能 FALSE 关闭使能</param>
        /// <returns></returns>
        //public bool Servo_Enabled(bool Enabled)
        //{
        //    if(Enabled)
        //    {
        //        this.modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("0F", 16).ToString(), numerical_format.Signed_16_Bit);
        //    }
        //    else
        //    {

        //        this.modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("07", 16).ToString(), numerical_format.Signed_16_Bit);
        //    }
        //    bool[] Status = new bool[16];
        //    Status = this.ConvertIntToBoolArray(Convert.ToInt32(modbus.IPLC_interface_PLC_read_D_register("D", Convert.ToInt32("6041", 16).ToString(), numerical_format.Signed_16_Bit)), 16);
        //    if (Status[1] & Status[2])
        //        return true;
        //    else
        //        return false;
        //}
        //public bool Servo_Parameter()
        //{
        //    this.modbus.IPLC_interface_PLC_write_D_register("D", Convert.ToInt32("6040", 16).ToString(), Convert.ToInt32("0F", 16).ToString(), numerical_format.Signed_16_Bit);
        //}
        /// <summary>
        /// 批量读取伺服状态
        /// </summary>
        /// <returns></returns>
        //public List<Tuple<string,int>> Servo_Status()
        //{
        //    List<Tuple<string, int>> Status = new List<Tuple<string, int>>();
        //    if(!modbus.Socket_ready)
        //    {
        //        MessageBox.Show("未链接伺服驱动器");
        //        return new List<Tuple<string, int>>();
        //    }
        //    Status.Add(new Tuple<string, int>("6061",Convert.ToInt32(modbus.Read_short(6061))));


        //}
        /// <summary>
        /// Err处理
        /// </summary>
        /// <param name="e"></param>
        //private void Err(Exception e)
        //{
        //    ready = false;
        //    code = 999;
        //    content = e.Message;
        //}
    }
}
