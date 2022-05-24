namespace Rectangle
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics g;
        public Form1()
        {
            InitializeComponent();

            bitmap = new Bitmap(Width, Height);
            g = Graphics.FromImage(bitmap);
            BackgroundImage = bitmap;
        }

        int count = 0;
        bool startPaint = false;
        Point startPoint;
        int x = 0;
        int y = 0;
        Pen pen = new Pen(Color.DarkCyan, 5);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startPaint = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (x < 20 || y < 20)
                MessageBox.Show("Size can't be less than 20x20");
            else
            {
                Label label = new Label()
                {
                    AutoSize = false,
                    BackColor = Color.LightCyan,
                    ForeColor = Color.DarkBlue,
                    Location = new Point(startPoint.X, startPoint.Y),
                    Width = x,
                    Height = y,
                    Font = new Font("Georgia", 20),
                    Text = count.ToString()
                };

                label.MouseClick += label1_Click;
                label.MouseDoubleClick += label1_MouseDoubleClick;
                count += 1;
                Controls.Add(label);

            }

            startPaint = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPaint)
            {
                x = e.X - startPoint.X;
                y = e.Y - startPoint.Y;
                Refresh();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (startPaint)
                g.DrawRectangle(pen, startPoint.X, startPoint.Y, x, y);
            else
                g.Clear(Color.White);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            Text = $"W: {label.Location.X},H: {label.Location.Y}";
        }

        private void label1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            count -= 1;
            label.BringToFront();
            label.Dispose();
        }
    }
}