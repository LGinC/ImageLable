using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageLable
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 指示当前模式 Click=false    Drag=true
        /// </summary>
        bool ClickOrDrag = true;
        /// <summary>
        /// 是否按下鼠标左键
        /// </summary>
        bool IsDown = false;
        /// <summary>
        /// 是否正在处于点击画框中
        /// </summary>
        bool Clicking = false;
        /// <summary>
        /// 矩形的左上角点
        /// </summary>
        List<Point> Points_start;
        /// <summary>
        /// 矩形的右下角点
        /// </summary>
        List<Point> Points_end;
        /// <summary>
        /// 图形
        /// </summary>
        Graphics g;
        /// <summary>
        /// 画笔，用于画矩形
        /// </summary>
        Pen[] p;
        Pen p_line;
        /// <summary>
        /// 矩形
        /// </summary>
        List<Rectangle> rects;
        /// <summary>
        /// 输入的图片文件列表
        /// </summary>
        List<FileInfo> imagesPath;
        /// <summary>
        /// 输出文件夹路径
        /// </summary>
        string outputPath;
        /// <summary>
        /// 当前图片索引
        /// </summary>
        int picIndex;
        /// <summary>
        /// 当前矩形索引
        /// </summary>
        int rectIndex;
        /// <summary>
        /// 输出文件夹
        /// </summary>
        DirectoryInfo outtxt;
        /// <summary>
        /// 是否已经选择输出文件夹
        /// </summary>
        bool isFoundOut;
        /// <summary>
        /// 边框大小
        /// </summary>
        int p_size  = 1;
        Point down;
        public Form1()
        {
            InitializeComponent();
            folderBrowserDialog1.SelectedPath = System.Windows.Forms.Application.StartupPath;
            g = this.CreateGraphics();
            p = new Pen[5]{new Pen(Brushes.Red, p_size), new Pen(Brushes.Blue, p_size), new Pen(Brushes.Orange, p_size), new Pen(Brushes.SpringGreen, p_size), new Pen(Brushes.Purple, p_size) };
            p_line = new Pen(Brushes.Gray, 1);
            Points_start = new List<Point>();
            Points_end = new List<Point>();
            rects = new List<Rectangle>();
            rectIndex = 0;
        }

        /// <summary>
        /// 鼠标在pictureBox中按下左键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (Clicking)
                {
                    AddRect(e);
                    Clicking = false;
                    return;
                }

                IsDown = true;
                if (Points_start.Count > rectIndex)
                {
                    Points_start[rectIndex] = e.Location;
                }
                else
                {
                    Points_start.Add(e.Location);
                    rects.Add(new Rectangle());
                }
                down = e.Location;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                MessageBox.Show(ex.Message);
            }
            
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //this.g.DrawLines(p_line, new Point[] { new Point(e.Y, 0), new Point(e.Y, pictureBox1.Width) , new Point(e.X, 0), new Point(e.Y, pictureBox1.Height)});
            try
            {
                if (Clicking || IsDown)
                {
                    Rectangle tem = rects[rectIndex];
                    tem.Location = new Point(Math.Min(Points_start[rectIndex].X, e.Location.X), Math.Min(Points_start[rectIndex].Y, e.Location.Y));
                    tem.Location = new Point(Math.Min(Points_start[rectIndex].X, e.Location.X), Math.Min(Points_start[rectIndex].Y, e.Location.Y));
                    tem.Width = Math.Abs(Points_start[rectIndex].X - e.Location.X);
                    tem.Height = Math.Abs(Points_start[rectIndex].Y - e.Location.Y);
                    rects[rectIndex] = tem;
                    pictureBox1.Invalidate();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                MessageBox.Show(ex.Message);
            }
            
            //pictureBox1.Invalidate();
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (ClickOrDrag)//Drag模式
                {
                    if (IsDown)
                    {
                        AddRect(e);
                    }
                }
                IsDown = false;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                MessageBox.Show(ex.Message);
            }
            
        }

        private void AddRect(MouseEventArgs e)
        {
            int x = 0, y = 0;
            Point location;
            x = e.X;
            y = e.Y;
            if (x > pictureBox1.Width)
            {
                x = pictureBox1.Width;
            }
            if (y > pictureBox1.Height)
            {
                y = pictureBox1.Width;
            }

            location = new Point(x, y);


                if (Points_end.Count <= rectIndex)
                    Points_end.Add(location);
                else
                    Points_end[rectIndex] = location;//获取当前鼠标坐标，放入end
                x = Math.Min(Points_start[rectIndex].X, Points_end[rectIndex].X);//start存入坐标值小的点
                y = Math.Min(Points_start[rectIndex].Y, Points_end[rectIndex].Y);//end存入坐标值大的点

                Point tem = Points_end[rectIndex];
                tem.X = Math.Max(Points_start[rectIndex].X, Points_end[rectIndex].X);
                tem.Y = Math.Max(Points_start[rectIndex].Y, Points_end[rectIndex].Y);
                Points_end[rectIndex] = tem;

                tem = Points_start[rectIndex];
                tem.X = x;
                tem.Y = y;
                Points_start[rectIndex] = tem;

                rectIndex++;//矩形索引+1
            
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                int i = 0;
                foreach (var item in rects)//遍历矩形数组
                {
                    if (item != null && item.Width > 0 && item.Height > 0)//矩形
                    {
                        e.Graphics.DrawRectangle(p[i], item);
                    }
                    if (i < p.Length - 1)
                        i++;
                }

            }

        }

        private void B_Load_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                LoadImages(folderBrowserDialog1.SelectedPath);
            }

        }

        private void B_output_Click(object sender, EventArgs e)
        {           
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                outputPath = folderBrowserDialog1.SelectedPath;
                textBox2.Text = outputPath;
                outtxt = new DirectoryInfo(outputPath);
                isFoundOut = true;
                if (imagesPath != null && imagesPath.Count != 0)
                {
                    ChangedImage();
                }
            }

            

            
        }
        private void LoadImages(string selectedPath)
        {
            DirectoryInfo d = new DirectoryInfo(selectedPath);
            IEnumerable<FileInfo> f = (d.GetFiles().Where(s => s.Extension.EndsWith("jpg") || s.Extension.EndsWith("JPG")));//获取输入文件夹中所有jpg和JPG为扩展名的文件
            imagesPath = f.ToList<FileInfo>();//文件列表放入imagesPath中
            picIndex = 0;//索引置为0
            label_total.Text = imagesPath.Count.ToString();//显示总数
            ChangedImage();                      
        }

        /// <summary>
        /// 改变当前显示的图片
        /// </summary>
        private void ChangedImage()
        {
            try
            {
                Points_start.Clear();
                Points_end.Clear();
                rects.Clear();
                rectIndex = 0;
                pictureBox1.Invalidate();//重绘
                if (imagesPath != null && imagesPath.Count != 0)//如果图片列表不为空
                {
                    if (isFoundOut)//若已经打开输出文件夹，则会读取对应文件，画出矩形
                    {
                        int x_l, y_l, x_r, y_r, i = 0;
                        IEnumerable<FileInfo> outtxts = (outtxt.GetFiles().Where(s => s.Extension.EndsWith("txt") || s.Extension.EndsWith("TXT")));//获取输出文件夹里的所有扩展名为txt或TXT的文件放入列表
                        foreach (var item in outtxts)//遍历列表
                        {
                            if (item.Name.Replace(item.Extension, "").Equals(imagesPath[picIndex].Name.Replace(imagesPath[picIndex].Extension, "")))//如果txt文件名和图片文件名一致(去掉扩展名)
                            {
                                string[] contents = File.ReadAllLines(item.FullName);//读取txt文件内容
                                foreach (var s in contents)
                                {
                                    string[] con = s.Split(' ');//每一行内容按空格分开
                                    if (con.Length >= 4)
                                    {
                                        x_l = int.Parse(con[0]);//第一个是左上角x坐标
                                        y_l = int.Parse(con[1]);//第二个是左上角y坐标
                                        x_r = int.Parse(con[2]);//第三个是右下角x坐标
                                        y_r = int.Parse(con[3]);//第四个是右下角y坐标\
                                        Rectangle tem = new Rectangle(x_l, y_l, x_r - x_l, y_r - y_l);
                                        rects.Add(tem);
                                        Points_start.Add(rects[i].Location);
                                        Points_end.Add(new Point(x_r, y_r));
                                        i++;
                                    }
                                }
                                pictureBox1.Invalidate();//重绘
                                break;//跳出foreach
                            }
                        }
                    }
                }
                else//如果图片列表为空则返回
                    return;
                label_current.Text = (picIndex + 1).ToString();
                label_file.Text = imagesPath[picIndex].Name;
                pictureBox1.Image = Image.FromFile(imagesPath[picIndex].FullName);//改变显示的图片
                pictureBox1.Height = pictureBox1.Image.Height;//将picturBox高度改为图片高度
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                MessageBox.Show(e.Message);
            }
            

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 键盘按下事件处理函数
        /// </summary>
        /// <param name="sender">事件发送者，此处为Form</param>
        /// <param name="e">键盘事件参数</param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Focused || textBox2.Focused || tb_index.Focused)//如果是在输入框有焦点的情况下输入则不做处理
            {
                return;
            }
            if (textBox1.Text.Equals(""))//如果输入文件夹(图片文件夹)未打开,则警告返回
            {
                MessageBox.Show("未打开目标文件夹", "警告");
                return;
            }
            else if (imagesPath.Count == 0)//如果打开的文件夹里没有图片，则警告返回
            {
                MessageBox.Show("目标文件夹里未发现jpg文件", "警告");
                return;
            }
            e.Handled = true;//事件标记为已处理
            switch (e.KeyCode)//根据键值做出处理
            {
                case Keys.A://如果按下的是A
                    if (picIndex > 0 && picIndex <= imagesPath.Count)//且当前图片索引在范围内
                    {
                        if (isFoundOut)//若输出文件夹已经打开
                        {
                            SaveLable();//保存标注                       
                        }
                        if (picIndex == 0)//如果当前是第一张则跳出
                            break;
                        picIndex--;//如果不是第一张则索引减一
                        ChangedImage();//改变显示的图片
                    }
                    break;

                case Keys.D://如果按下的是D
                    if (picIndex >= 0 && picIndex <= imagesPath.Count - 1)//若索引在范围内
                    {
                        if (isFoundOut)//若输出文件夹已经打开
                        {
                            SaveLable();//保存标注        
                        }
                        if (picIndex == imagesPath.Count - 1)//如果当前是最后一张则跳出
                        {
                            break;
                        }
                        picIndex++;//如果不是最后一张则索引加一
                        ChangedImage();//改变显示的图片
                    }
                    break;
                default:
                    break;
            }
        }

        private void SaveLable()
        {
            try
            {
                //BUG记录：若未放开左键 进入保存，会导致乱掉
                if (isFoundOut == false)//如果没有打开输出文件夹，则警告返回
                {
                    MessageBox.Show("请先打开输出文件夹");
                    return;
                }
                string outtxt = outputPath + "\\" + imagesPath[picIndex].Name.Replace(imagesPath[picIndex].Extension, "") + ".txt";
                //if ((Points_start[0].X == 0 && Points_start[0].Y == 0) || (Points_end[0].X == 0 && Points_end[0].Y == 0))//如果没有画矩形框，则返回
                //{
                //    if (File.Exists(outtxt))
                //    {
                //        File.Delete(outtxt);
                //    }
                //    return;
                //}
                string[] writecontent = new string[rects.Count + 1];

                for (int i = 0; i < rects.Count; i++)
                {
                    if (rects[i].Width > 0 && rects[i].Height > 0)
                    {
                        writecontent[i + 1] = Points_start[i].X + " " + Points_start[i].Y + " " + Points_end[i].X + " " + Points_end[i].Y;
                    }
                }
                writecontent[0] = rects.Count.ToString();
                File.WriteAllLines(outtxt, writecontent);//输出到和照片同名的txt文件中，有则覆盖，无则创建
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                MessageBox.Show(e.Message);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Cross;
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void ContextMenu_click(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text.Equals("清除矩形"))//右键菜单点击的是清除矩形
            {
                Points_start.Clear();
                Points_end.Clear();
                rects.Clear();
                rectIndex = 0;
                pictureBox1.Invalidate();//重绘
            }
        }

        private void B_skip_Click(object sender, EventArgs e)
        {
            if (imagesPath == null || imagesPath.Count == 0)
            {
                return;
            }
            string index = tb_index.Text;
            if (index != null && !index.Equals(""))
            {
                int n = int.Parse(index) - 1;
                if (n < 0 || n >= imagesPath.Count)
                {
                    MessageBox.Show("请输入范围内的数字");
                    return;
                }
                picIndex = n;
                ChangedImage();
            }
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            p_size = trackBar1.Value;
            this.BeginInvoke((Action)(() =>
            {
                foreach (var item in p)
                {
                    item.Width = p_size;
                }
            }));           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs arges = e as MouseEventArgs;
            if (arges.Location != down)
            {
                ClickOrDrag = true;
                return;
            }
            ClickOrDrag = false;
            Clicking = true;

            Points_start[rectIndex] = arges.Location;
        }
    }
}
