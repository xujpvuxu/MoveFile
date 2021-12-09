using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveFiles
{
    /// <summary>
    /// 搬移檔案
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 重建子
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 開始搬檔
        /// </summary>
        /// <param name="sender">搬檔按鍵</param>
        /// <param name="e">搬檔事件</param>
        private void Run_Click(object sender, EventArgs e)
        {
            (bool isEfficient, string path)[] pathData = new (bool efficient, string path)[2];
            pathData[0] = GetPath(SourcePath.Text);
            pathData[1] = GetPath(TargetPath.Text);

            //檢查路徑
            if (pathData.All(data => data.isEfficient))
            {
                Move(pathData[0].path, pathData[1].path);
                MessageBox.Show("完成");
            }
        }

        /// <summary>
        /// 路徑是否有效
        /// </summary>
        /// <param name="path">路徑</param>
        /// <returns>(是否有效,路徑)</returns>
        private (bool isEfficient, string path) GetPath(string path)
        {
            return (Directory.Exists(path), path);
        }

        /// <summary>
        /// 搬檔
        /// </summary>
        /// <param name="sourcePath">來源路徑</param>
        /// <param name="targetPath">目標路徑</param>
        private void Move(string sourcePath, string targetPath)
        {
            //目標路徑是否有資料夾
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            //搬檔案
            foreach (string perData in Directory.GetFiles(sourcePath))
            {
                File.Move(perData, Path.Combine(targetPath, Path.Combine(targetPath, Path.GetFileName(perData))));
            }

            //進入資料夾
            foreach (string perPath in Directory.GetDirectories(sourcePath))
            {
                string fileName = Path.GetFileName(perPath);
                Move(Path.GetFullPath(perPath), Path.Combine(targetPath, fileName));
                Directory.Delete(perPath);
            }
        }

        /// <summary>
        /// 選擇來源路徑
        /// </summary>
        /// <param name="sender">來源路徑按鍵</param>
        /// <param name="e">來源路徑事件</param>
        private void SelectSourcePath_Click(object sender, EventArgs e)
        {
            SourcePath.Text = GetFilePath();
        }

        /// <summary>
        /// 選擇目標路徑
        /// </summary>
        /// <param name="sender">來源路徑按鍵</param>
        /// <param name="e">來源路徑事件</param>
        private void SelectTargetPath_Click(object sender, EventArgs e)
        {
            TargetPath.Text = GetFilePath();
        }

        /// <summary>
        /// 選擇的路徑
        /// </summary>
        /// <returns>輸出選擇的路徑</returns>
        private string GetFilePath()
        {
            string path = string.Empty;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "請選擇Txt所在資料夾";
            if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dialog.SelectedPath))
            {
                path = dialog.SelectedPath;
            }

            return path;
        }
    }
}