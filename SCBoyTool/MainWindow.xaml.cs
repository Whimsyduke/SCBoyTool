using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace SCBoyTool
{
    /// <summary>
    /// 自动序号Converter
    /// </summary>
    public class AutoNumberValueConverter : IMultiValueConverter
    {
        /// <summary>
        /// 转换函数
        /// </summary>
        /// <param name="values">值数组</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">参数</param>
        /// <param name="culture">本地化</param>
        /// <returns>转换结果</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null || values[1] == null) return 0;
            if (values[1] is ItemCollection items)
            {
                int index = items.IndexOf(values[0]);
                return (index + 1).ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 逆向转换函数
        /// </summary>
        /// <param name="value">值数组</param>
        /// <param name="targetTypes">目标类型</param>
        /// <param name="parameter">参数</param>
        /// <param name="culture">本地化</param>
        /// <returns>转换结果</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }

    }

    /// <summary>
	/// 主窗口
	/// </summary>
	public partial class MainWindow : Window
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

        /// <summary>
        /// 基本目录
        /// </summary>
        private string BaseFolder { set; get; } = Environment.CurrentDirectory;

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
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion 构造函数

        #region 方法

        #region 通用方法

        #region 打开保存窗口

        /// <summary>
        /// 打开文件路径窗口
        /// </summary>
        /// <param name="baseFolder">默认打开目录</param>
        /// <param name="filter">文件类型验证</param>
        /// <param name="title">标题</param>
        /// <param name="fileDialog">对话框</param>
        /// <returns>打开结果</returns>
        public static System.Windows.Forms.DialogResult OpenFilePathDialog(string baseFolder, string filter, string title, out System.Windows.Forms.OpenFileDialog fileDialog)
        {
            fileDialog = new System.Windows.Forms.OpenFileDialog();
            if (Directory.Exists(baseFolder))
            {
                fileDialog.InitialDirectory = baseFolder;
            }
            else
            {
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            fileDialog.Filter = filter;
            fileDialog.Title = title;
            fileDialog.Multiselect = false;
            fileDialog.RestoreDirectory = true;
            return fileDialog.ShowDialog();
        }

        /// <summary>
        /// 保存文件路径窗口
        /// </summary>
        /// <param name="baseFolder">默认保存目录</param>
        /// <param name="filter">文件类型验证</param>
        /// <param name="title">标题</param>
        /// <param name="fileDialog">对话框</param>
        /// <returns>打开结果</returns>
        public static System.Windows.Forms.DialogResult SaveFilePathDialog(string baseFolder, string filter, string title, out System.Windows.Forms.SaveFileDialog fileDialog)
        {
            fileDialog = new System.Windows.Forms.SaveFileDialog();
            if (Directory.Exists(baseFolder))
            {
                fileDialog.InitialDirectory = baseFolder;
            }
            else
            {
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            fileDialog.Filter = filter;
            fileDialog.Title = title;
            fileDialog.RestoreDirectory = true;
            return fileDialog.ShowDialog();
        }

        #endregion

        #endregion 通用方法

        #region 重写方法

        #endregion 重写方法

        #region 事件方法

        /// <summary>
        /// 加载行事件
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void DataGrid_PlayerLogo_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        /// <summary>
        /// 加载按钮
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            string filter = "XML文档|*.xml";
            string title = "读取配置文件";
            if (OpenFilePathDialog(BaseFolder, filter, title, out OpenFileDialog fileDialog) == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(fileDialog.FileName);
                BaseFolder = file.DirectoryName;
                XmlDocument doc = new XmlDocument();
                doc.Load(file.FullName);

                XmlDataProvider xdp = new XmlDataProvider
                {
                    Document = doc,
                    XPath = @"LogoConfig/PlayerLogoEntry"
                };
                DataGrid_PlayerLogo.DataContext = xdp;
            }
        }

        /// <summary>
        /// 清空按钮
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void Button_Clean_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_PlayerLogo.DataContext = null;
        }

        #endregion 事件方法 

        #endregion 方法

    }
}
