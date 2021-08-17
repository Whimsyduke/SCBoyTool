using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Xml.Linq;

namespace SCBoyTool
{
    /// <summary>
	/// 玩家信息数据集
	/// </summary>
	partial class DataSet_PlayerInfo
    {
        #region 内部声明

        #region 常量

        private const string Const_Element_LogoConfig = "LogoConfig";
        private const string Const_Element_LeagueLogoEntry = "LeagueLogoEntry";
        private const string Const_Element_PlayerLogoEntry = "PlayerLogoEntry";
        private const string Const_Element_FrameLogoText = "FrameLogoText";
        private const string Const_Element_FrameLogoImage = "FrameLogoImage";
        private const string Const_Attribute_IgnorePlayerPrimaryLogo = "IgnorePlayerPrimaryLogo";
        private const string Const_Attribute_IgnorePlayerSecondaryLogo = "IgnorePlayerSecondaryLogo";
        private const string Const_Attribute_TeamName = "TeamName";
        private const string Const_Attribute_PrimaryLogo = "PrimaryLogo";
        private const string Const_Attribute_SecondaryLogo = "SecondaryLogo";
        private const string Const_Attribute_Text = "Text";
        private const string Const_Attribute_Alias = "Alias";
        private const string Const_Attribute_FilePath = "FilePath";
        private const string Const_Value_PlayerName = "PlayerName";
        private const string Const_Value_Logo = "Logo";
        private const string Const_Value_LogoSmall = "LogoSmall";
        private const string Const_Column_Logo = "Logo";
        private const string Const_Column_IsUse = "IsUse";
        private const string Const_Column_TeamName = "TeamName";
        private const string Const_Column_PrimaryLogo = "PrimaryLogo";
        private const string Const_Column_SecondaryLogo = "SecondLogo";
        private const string Const_Column_PlayerName = "PlayerName";
        private const int Const_Index_Primary = 0;
        private const int Const_Index_Secondary = 1;

        #endregion 常量

        #region 枚举

        #endregion 枚举

        #region 定义

        /// <summary>
        /// 比赛数据
        /// </summary>
        partial class DataTable_LeagueDataTable
        {
            #region 内部声明

            #region 常量

            #endregion 常量

            #region 枚举

            #endregion 枚举

            #region 定义

            #endregion 定义

            #region 委托

            #endregion 委托

            #endregion 内部声明

            #region 属性字段

            #region 静态属性

            #endregion 静态属性

            #region 属性

            #endregion 属性

            #region 字段

            #endregion 字段

            #region 事件

            #endregion 事件

            #endregion 属性字段

            #region 构造函数

            #endregion 构造函数

            #region 方法

            #region 通用方法

            /// <summary>
            /// 初始化联赛数据
            /// </summary>
            /// <param name="dataSet">数据集</param>
            /// <param name="root">根元素</param>
            public void Init(XElement root)
            {
                Clear();
                XElement leagueInfo = root.Element(Const_Element_LeagueLogoEntry);
                Rows.Add(leagueInfo?.Attribute(Const_Attribute_PrimaryLogo)?.Value, root.Attribute(Const_Attribute_IgnorePlayerPrimaryLogo)?.Value);
                Rows.Add(leagueInfo?.Attribute(Const_Attribute_SecondaryLogo)?.Value, root.Attribute(Const_Attribute_IgnorePlayerSecondaryLogo)?.Value);
            }

            #endregion 通用方法

            #region 重写方法

            #endregion 重写方法

            #region 事件方法

            #endregion 事件方法 

            #endregion 方法

        }

        /// <summary>
        /// 玩家数据
        /// </summary>
        partial class DataTable_PlayerInfoDataTable
        {
            #region 内部声明

            #region 常量

            #endregion 常量

            #region 枚举

            #endregion 枚举

            #region 定义

            #endregion 定义

            #region 委托

            #endregion 委托

            #endregion 内部声明

            #region 属性字段

            #region 静态属性

            #endregion 静态属性

            #region 属性

            #endregion 属性

            #region 字段

            #endregion 字段

            #region 事件

            #endregion 事件

            #endregion 属性字段

            #region 构造函数

            #endregion 构造函数

            #region 方法

            #region 通用方法

            /// <summary>
            /// 初始化联赛数据
            /// </summary>
            /// <param name="dataSet">数据集</param>
            /// <param name="root">根元素</param>
            public void Init(XElement root)
            {
                Clear();
                IEnumerable<XElement> playerInfos = root.Elements(Const_Element_PlayerLogoEntry);
                foreach (XElement element in playerInfos)
                {
                    XElement text = element.Element(Const_Element_FrameLogoText);
                    Rows.Add(element.Attribute(Const_Attribute_TeamName)?.Value, element.Attribute(Const_Attribute_PrimaryLogo)?.Value, element.Attribute(Const_Attribute_SecondaryLogo)?.Value, text.Attribute(Const_Attribute_Text)?.Value);
                }
            }

            #endregion 通用方法

            #region 重写方法

            #endregion 重写方法

            #region 事件方法

            #endregion 事件方法 

            #endregion 方法

        }

        #endregion 定义

        #region 委托

        #endregion 委托

        #endregion 内部声明

        #region 属性字段

        #region 静态属性

        #endregion 静态属性

        #region 属性

        /// <summary>
        /// Xml文档
        /// </summary>
        public XDocument Document { private set; get; }

        /// <summary>
        /// 主要Logo
        /// </summary>
        public string PrimaryLogo
        {
            set
            {
                DataTable_League.Rows[Const_Index_Primary].SetField(Const_Column_Logo, value);
            }
            get
            {
                return (string)DataTable_League.Rows[Const_Index_Primary][Const_Column_Logo];
            }
        }

        /// <summary>
        /// 忽略主要Logo
        /// </summary>
        public bool IgnorePrimaryLogo
        {
            set
            {
                DataTable_League.Rows[Const_Index_Primary].SetField(Const_Column_IsUse, value);
            }
            get
            {
                return (bool)DataTable_League.Rows[Const_Index_Primary][Const_Column_IsUse];
            }
        }

        /// <summary>
        /// 次要Logo
        /// </summary>
        public string SecondaryLogo
        {
            set
            {
                DataTable_League.Rows[Const_Index_Secondary].SetField(Const_Column_Logo, value);
            }
            get
            {
                return (string)DataTable_League.Rows[Const_Index_Secondary][Const_Column_Logo];
            }
        }

        /// <summary>
        /// 忽略次要Logo
        /// </summary>
        public bool IgnoreSecondaryLogo
        {
            set
            {
                DataTable_League.Rows[Const_Index_Secondary].SetField(Const_Column_IsUse, value);
            }
            get
            {
                return (bool)DataTable_League.Rows[Const_Index_Secondary][Const_Column_IsUse];
            }
        }

        #endregion 属性

        #region 字段

        #endregion 字段

        #region 事件

        #endregion 事件

        #endregion 属性字段

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public DataSet_PlayerInfo(XDocument doc) : this()
        {
            Document = doc;
            Init();
        }

        #endregion 构造函数

        #region 方法

        #region 通用方法

        /// <summary>
        /// 默认数据集
        /// </summary>
        /// <returns></returns>
        public static DataSet_PlayerInfo DefaultInfo()
        {
            return new DataSet_PlayerInfo(null);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            if (Document == null)
            {
                Clean();
                return;
            }
            XElement root = Document.Element(Const_Element_LogoConfig);
            if (root == null)
            {
                MessageBox.Show($"Xml文件的根元素{Const_Element_LogoConfig}不存在。");
                Clean();
                return;
            }
            (DataTable_League as DataTable_LeagueDataTable).Init(root);
            (DataTable_PlayerInfo as DataTable_PlayerInfoDataTable).Init(root);
        }

        /// <summary>
        /// 清理数据集
        /// </summary>
        private void Clean()
        {
            DataTable_League.Clear();
            DataTable_PlayerInfo.Clear();
            DataTable_League.Rows.Add(DataTable_League.NewRow());
            DataTable_League.Rows.Add(DataTable_League.NewRow());
        }

        /// <summary>
        /// 刷新XML文档
        /// </summary>
        public void RefreshDocument()
        {
            XElement root = new XElement(Const_Element_LogoConfig,
                new XAttribute(Const_Attribute_IgnorePlayerPrimaryLogo, IgnorePrimaryLogo),
                new XAttribute(Const_Attribute_IgnorePlayerSecondaryLogo, IgnoreSecondaryLogo),
                new XElement(Const_Element_LeagueLogoEntry,
                    new XAttribute(Const_Attribute_PrimaryLogo, PrimaryLogo),
                    new XAttribute(Const_Attribute_SecondaryLogo, SecondaryLogo)
                    )
                );
            foreach (DataRow row in DataTable_PlayerInfo.Rows)
            {
                XElement playerInfo = new XElement(Const_Element_PlayerLogoEntry,
                    new XAttribute(Const_Attribute_TeamName, row[Const_Column_TeamName]),
                    new XAttribute(Const_Attribute_PrimaryLogo, row[Const_Column_PrimaryLogo]),
                    new XAttribute(Const_Attribute_SecondaryLogo, row[Const_Column_SecondaryLogo]),
                    new XElement(Const_Element_FrameLogoText,
                        new XAttribute(Const_Attribute_Alias, Const_Value_PlayerName),
                        new XAttribute(Const_Attribute_Text, row[Const_Column_PlayerName])
                        ),
                    new XElement(Const_Element_FrameLogoImage,
                        new XAttribute(Const_Attribute_Alias, Const_Value_Logo),
                        new XAttribute(Const_Attribute_FilePath, row[Const_Column_PrimaryLogo])
                        ),
                    new XElement(Const_Element_FrameLogoImage,
                        new XAttribute(Const_Attribute_Alias, Const_Value_LogoSmall),
                        new XAttribute(Const_Attribute_FilePath, row[Const_Column_PrimaryLogo])
                        )
                    );
                root.Add(playerInfo);
            }
            Document.RemoveNodes();
            Document.Add(root);
        }

        #endregion 通用方法

        #region 重写方法

        #endregion 重写方法

        #region 事件方法

        #endregion 事件方法 

        #endregion 方法

    }
}
