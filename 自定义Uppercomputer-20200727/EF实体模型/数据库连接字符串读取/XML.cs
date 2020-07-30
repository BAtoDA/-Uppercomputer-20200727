using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
namespace 自定义Uppercomputer_20200727.EF实体模型.XML
{
    /// <summary>
    /// 本类用于对XML文件增删改查
    /// </summary>
    public class XML
    {
        /// <summary>
        /// xml对象
        /// </summary>
        private XmlDocument Xml;
        /// <summary>
        /// 地址
        /// </summary>
        private string address;
        /// <summary>
        /// 构造函数
        /// 进行实例化对象
        /// </summary>
        /// <param name="address">地址</param>
        public XML(string address)
        {
            this.address = address+ "\\configuration.xml";
            Xml = new XmlDocument();
        }
        /// <summary>
        /// 对XML文件进行新增操作
        /// 
        /// </summary>
        /// <param name="Name">数据库实例名</param>
        /// <param name="database">数据库名</param>
        /// <param name="user">登录名</param>
        /// <param name="password">登录密码</param>
        public void Add_XMl(string Name,string database,string user,string password)
        {
            //创建xml的根节点
            XmlElement rootElement =Xml.CreateElement("Computers");
            //将根节点加入到xml文件中（AppendChild）
            Xml.AppendChild(rootElement);

            //初始化第一层的第一个子节点
            XmlElement firstLevelElement1 = Xml.CreateElement("Computer");
            //填充第一层的第一个子节点的属性值（SetAttribute）
            firstLevelElement1.SetAttribute("Name", Name ?? @"DESKTOP - E3JO5HA\WINCC");
            firstLevelElement1.SetAttribute("Description", "SQL Server 2014 Management Studio");
            //将第一层的第一个子节点加入到根节点下
            rootElement.AppendChild(firstLevelElement1);

            //初始化第二层的第一个子节点
            XmlElement firstLevelElement2 = Xml.CreateElement("Computer");
            //填充第二层的第一个子节点的属性值（SetAttribute）
            firstLevelElement2.SetAttribute("Database", database ?? "Uppercomputer");
            firstLevelElement2.SetAttribute("Description", "SQL Server 2014 Management Studio");
            //将第二层的第一个子节点加入到根节点下
            rootElement.AppendChild(firstLevelElement2);

            //初始化第三层的第一个子节点
            XmlElement firstLevelElement3 = Xml.CreateElement("Computer");
            //填充第三层的第一个子节点的属性值（SetAttribute）
            firstLevelElement3.SetAttribute("user", user ?? "sa");
            firstLevelElement3.SetAttribute("Description", "SQL Server 2014 Management Studio");
            //将第三层的第一个子节点加入到根节点下
            rootElement.AppendChild(firstLevelElement3);

            //初始化第四层的第一个子节点
            XmlElement firstLevelElement4 = Xml.CreateElement("Computer");
            //填充第四层的第一个子节点的属性值（SetAttribute）
            firstLevelElement4.SetAttribute("password", password ?? "3131458");
            firstLevelElement4.SetAttribute("Description", "SQL Server 2014 Management Studio");
            //将第四层的第一个子节点加入到根节点下
            rootElement.AppendChild(firstLevelElement4);

            //将xml文件保存到指定的路径下
            Xml.Save(@address);
        }
        /// <summary>
        /// 对XML文件进行读取
        /// 返回泛型集合元组表
        /// </summary>
        /// <returns></returns>
        public List<Tuple<string, string, string, string>> Read_XML()
        {
            try
            {
                //加载xml文件（参数为xml文件的路径）
                Xml.Load(address);
                //获得第一个匹配的节点（SelectSingleNode）：此xml文件的根节点
                XmlNode rootNode = Xml.SelectSingleNode("Computers");
                //分别获得该节点的InnerXml和OuterXml信息
                string innerXmlInfo = rootNode.InnerXml.ToString();
                string outerXmlInfo = rootNode.OuterXml.ToString();
                //获得该节点的子节点（即：该节点的第一层子节点）
                XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
                //实例化泛型集合
                List<string> Data = new List<string>();
                foreach (XmlNode node in firstLevelNodeList)
                {
                    //获得该节点的属性集合
                    XmlAttributeCollection attributeCol = node.Attributes;
                    foreach (XmlAttribute attri in attributeCol)
                    {
                        Data.Add(attri.Value);
                    }
                }
                return new List<Tuple<string, string, string, string>>() { new Tuple<string, string, string, string>(Data[0], Data[2], Data[4], Data[6]) };
            }
            catch
            {
                return new List<Tuple<string, string, string, string>>();
            }
        }
        /// <summary>
        /// 对XML文件进行删除
        /// </summary>
        public void Delete_XML()
        {
            FileInfo fileInfo = new FileInfo(@address);
            if (fileInfo.Exists)
                fileInfo.Delete();
        }
    }
}
