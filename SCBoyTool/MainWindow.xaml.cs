using System;
using System.Collections.Generic;
using System.Data;
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
    /// 测试值转换器
    /// </summary>
    public class TestValueConverter : IValueConverter
    {
        /// <summary>
        /// 转换函数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">参数</param>
        /// <param name="culture">本地化信息</param>
        /// <returns>转换结果</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        /// <summary>
        /// 反向转回函数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">参数</param>
        /// <param name="culture">本地化信息</param>
        /// <returns>转换结果</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    /// <summary>
    /// 自动序号Converter
    /// </summary>
    public class AutoNumberValueConverter : IValueConverter
    {
        /// <summary>
        /// 转换函数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">参数</param>
        /// <param name="culture">本地化信息</param>
        /// <returns>转换结果</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DataGridRow row)
            {
                return row.GetIndex() + 1;
            }
            return -1;
        }

        /// <summary>
        /// 反向转回函数
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="targetType">目标类型</param>
        /// <param name="parameter">参数</param>
        /// <param name="culture">本地化信息</param>
        /// <returns>转换结果</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
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

        /// <summary>
        /// 正则切换数据
        /// </summary>
        private bool IsChangeData { set; get; }

        /// <summary>
        /// 当前数据集依赖项
        /// </summary>
        public readonly DependencyProperty CurrentDataSetProperty = DependencyProperty.Register(nameof(CurrentDataSet), typeof(DataSet_PlayerInfo), typeof(MainWindow));

        /// <summary>
        /// 当前数据集依赖项属性
        /// </summary>
        public DataSet_PlayerInfo CurrentDataSet
        {
            set 
            {
                IsChangeData = true;
                DataSet_PlayerInfo info = value;
                if (info == null)
                {
                    info = DataSet_PlayerInfo.DefaultInfo();
                }
                SetValue(CurrentDataSetProperty, info); 
                DataGrid_PlayerLogo.ItemsSource = info.DataTable_PlayerInfo.DefaultView;
                TextBox_PrimaryLogo.Text = info.PrimaryLogo;
                CheckBox_PrimaryIsUsed.IsChecked = !info.IgnorePrimaryLogo;
                TextBox_SecondaryLogo.Text = info.SecondaryLogo;
                CheckBox_SecondaryIsUsed.IsChecked = !info.IgnoreSecondaryLogo;
                IsChangeData = false;
            }
            get 
            {
                return GetValue(CurrentDataSetProperty) as DataSet_PlayerInfo;
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
        public MainWindow()
        {
            InitializeComponent();
            CurrentDataSet = null;
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

        #endregion 打开保存窗口

        #region UI方法

        #endregion UI方法

        #endregion 通用方法

        #region 重写方法

        #endregion 重写方法

        #region 事件方法

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
                try
                {
                    XDocument doc = XDocument.Load(file.FullName);
                    CurrentDataSet = new DataSet_PlayerInfo(doc);
                }
                catch
                {
                    System.Windows.MessageBox.Show($"读取Xml文件（{file.FullName}）失败");
                }
            }
        }

        /// <summary>
        /// 清空按钮
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void Button_Clean_Click(object sender, RoutedEventArgs e)
        {
            CurrentDataSet = null;
            DataGrid_PlayerLogo.SelectedItem = null;
        }

        /// <summary>
        /// 导出按钮
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void Button_Export_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentDataSet == null)
            {
                return;
            }
            string filter = "XML文档|*.xml";
            string title = "保存配置文件"; 
            if (SaveFilePathDialog(BaseFolder, filter, title, out SaveFileDialog fileDialog) == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(fileDialog.FileName);
                BaseFolder = file.DirectoryName;
                try
                {
                    CurrentDataSet.RefreshDocument();
                    CurrentDataSet.Document.Save(file.FullName);
                }
                catch(Exception err)
                {
                    System.Windows.MessageBox.Show($"保存Xml文件（{file.FullName}）失败。\r\n{err.Message}");
                }
            }
        }

        /// <summary>
        /// 插入数据（前）
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void MenuItem_SelectBefore_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentDataSet == null) return;
            if (DataGrid_PlayerLogo.CurrentItem is DataRowView view)
            {
                DataRow row = view.Row;
                DataTable table = row.Table;
                DataRowCollection collection = table.Rows;
                int index = collection.IndexOf(row);
                collection.InsertAt(table.NewRow(), index);
                table.AcceptChanges();
            }
            else if (DataGrid_PlayerLogo.CurrentItem == null)
            {
                DataTable table = CurrentDataSet.DataTable_PlayerInfo;
                table.Rows.Add(table.NewRow());
            }
        }

        /// <summary>
        /// 插入数据（后）
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void MenuItem_SelectAfter_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentDataSet == null) return;
            if (DataGrid_PlayerLogo.CurrentItem is DataRowView view)
            {
                DataRow row = view.Row;
                DataTable table = row.Table;
                DataRowCollection collection = table.Rows;
                int index = collection.IndexOf(row);
                collection.InsertAt(table.NewRow(), index + 1);
                table.AcceptChanges();
            }
            else if (DataGrid_PlayerLogo.CurrentItem == null)
            {
                DataTable table = CurrentDataSet.DataTable_PlayerInfo;
                table.Rows.Add(table.NewRow());
            }
        }

        /// <summary>
        /// 删除数据（选择）
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentDataSet == null) return;
            if (DataGrid_PlayerLogo.CurrentItem is DataRowView view)
            {
                DataRow row = view.Row;
                DataTable table = row.Table;
                DataRowCollection collection = table.Rows;
                collection.Remove(row);
                table.AcceptChanges();
            }
        }

        /// <summary>
        /// 数据表完成编辑事件
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void DataGrid_PlayerLogo_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Row is DataGridRow row && row.Item is DataRowView rowView && rowView.Row is DataRow rowData)
            {
                rowData.Table.AcceptChanges();
            }
        }

        /// <summary>
        /// 主要Logo文件路径变化事件
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void TextBox_PrimaryFile_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CurrentDataSet == null || IsChangeData) return;
            CurrentDataSet.PrimaryLogo = TextBox_PrimaryLogo.Text;
        }

        /// <summary>
        /// 主要Logo文件忽略切换变化事件
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void CheckBox_PrimaryIsUsed_CheckChange(object sender, RoutedEventArgs e)
        {
            if (CurrentDataSet == null || IsChangeData) return;
            CurrentDataSet.IgnorePrimaryLogo = CheckBox_PrimaryIsUsed.IsChecked != true;
        }

        /// <summary>
        /// 主要Logo文件路径变化事件
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void TextBox_SecondaryFile_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CurrentDataSet == null || IsChangeData) return;
            CurrentDataSet.SecondaryLogo = TextBox_PrimaryLogo.Text;
        }

        /// <summary>
        /// 次要Logo文件忽略切换变化事件
        /// </summary>
        /// <param name="sender">响应控件</param>
        /// <param name="e">响应参数</param>
        private void CheckBox_SecondaryIsUsed_CheckChange(object sender, RoutedEventArgs e)
        {
            if (CurrentDataSet == null || IsChangeData) return;
            CurrentDataSet.IgnoreSecondaryLogo = CheckBox_PrimaryIsUsed.IsChecked != true;
        }

        #endregion 事件方法 

        #endregion 方法
    }
}
