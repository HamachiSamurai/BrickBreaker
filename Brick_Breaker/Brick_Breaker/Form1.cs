using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Brick_Breaker
{
    public partial class Form1 : Form
    {
        // ボールの位置
        Vector ballPos;

        // ボールの移動ベクトル
        Vector ballSpeed;

        // ボールの半径
        int ballRadius;
        public Form1()
        {
            InitializeComponent();

            this.ballPos = new Vector(200, 200);
            this.ballSpeed = new Vector(-2, -4);
            this.ballRadius = 10;

            Timer timer = new Timer();
            // 約30fps
            timer.Interval = 33;
            timer.Tick += new EventHandler(Update);
            timer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            // ボールの移動
            ballPos += ballSpeed;

            // 左右の壁でのバウンド 移動ベクトルXを反転
            // 壁と当たり判定するときには、ボールの半径を考慮
            if (ballPos.X + ballRadius > this.Bounds.Width || ballPos.X - ballRadius < 0)
            {
                ballSpeed.X *= -1;
            }

            // 上の壁でのバウンド　移動ベクトルYを反転
            // 壁と当たり判定するときには、ボールの半径を考慮
            if (ballPos.Y - ballRadius < 0)
            {
                ballSpeed.Y *= -1;
            }

            // 再描画
            Invalidate();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            // ボールを描画するためのブラシ（SolidBrush）
            SolidBrush pinkBrush = new SolidBrush(Color.HotPink);

            float px = (float)this.ballPos.X - ballRadius;
            float py = (float)this.ballPos.Y - ballRadius;

            e.Graphics.FillEllipse(pinkBrush, px, py, this.ballRadius * 2, this.ballRadius * 2);
        }
    }
}
