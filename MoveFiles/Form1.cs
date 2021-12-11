using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        /// 檔案數量
        /// </summary>
        private int DataCount;

        /// <summary>
        /// 資料夾數量
        /// </summary>
        private int FileCount;

        private Stopwatch Watch;

        /// <summary>
        /// 檔案鎖定
        /// </summary>
        private object LockDataObject = new object();

        /// <summary>
        /// 資料夾鎖定
        /// </summary>
        private object LockFileObject = new object();

        /// <summary>
        /// 開始搬檔
        /// </summary>
        /// <param name="sender">搬檔按鍵</param>
        /// <param name="e">搬檔事件</param>
        private async void Run_Click(object sender, EventArgs e)
        {
            DataCount = 0;
            FileCount = 0;
            Watch = new Stopwatch();
            (bool isEfficient, string path)[] pathData = new (bool efficient, string path)[2];
            pathData[0] = GetPath(SourcePath.Text);
            pathData[1] = GetPath(TargetPath.Text);

            //檢查路徑
            if (pathData.All(data => data.isEfficient))
            {
                Watch.Restart();
                await Task.Run(() => Move(pathData[0].path, pathData[1].path));
                Watch.Stop();
                //MessageBox.Show($"耗時：{watch.Elapsed.TotalSeconds}");
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
            Parallel.ForEach(Directory.GetFiles(sourcePath), perData =>
            {
                File.Move(perData, Path.Combine(targetPath, Path.Combine(targetPath, Path.GetFileName(perData))));
                lock (LockDataObject)
                {
                    DataCount++;
                }
                Invoke(new Action(() => ShowData.Text = DataCount.ToString()));
            });

            //進入資料夾
            Parallel.ForEach(Directory.GetDirectories(sourcePath), perPath =>
            {
                string fileName = Path.GetFileName(perPath);
                lock (LockFileObject)
                {
                    FileCount++;
                }
                Invoke(new Action(() => ShowFile.Text = FileCount.ToString()));
                Move(Path.GetFullPath(perPath), Path.Combine(targetPath, fileName));
                Directory.Delete(perPath);
            });
            Invoke(new Action(() => ShowTime.Text = Watch.Elapsed.Seconds.ToString()));
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