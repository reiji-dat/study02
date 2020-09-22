using System;
using System.Drawing;       //文字を描画させるシステム
using System.Windows.Forms; //ウィンドウを表示させるシステム

namespace study02
{
    class Program : Form
    {
        const int FWidth = 800;
        const int FHeight = 500;

        int px = 100;
        int py = 100;

        Graphics g;                        //これを使えば省略できる
        SolidBrush black = new SolidBrush(Color.Black); //これでも省略できる
        Bitmap img = new Bitmap(@"image\image.png");
        Bitmap player = new Bitmap(@"image\image_2.png");
        void init()
        {
            Text = "study02";                       //ウィンドウの名前を変更
            ClientSize = new Size(FWidth, FHeight); //画面のサイズ変更
            Location = new Point(300, 100);         //ウィンドウの表示する場所を変える
            //今まではランダムの場所に表示していた
        }

        void draw()
        {
            for (int x = 0; x * img.Width < FWidth; x++)
            {
                for (int y = 0; y * img.Height < FHeight; y++)
                {
                    //指定した画像を表示
                    g.DrawImage(img, x * img.Width, y * img.Height);
                    //e.Graphics.DrawImage(new Bitmap(@"実行ファイルからの相対パス"), x座標, y座標);
                }
            }

            g.DrawImage(player, px, py);

            //四角形の枠組みを表示
            g.DrawRectangle(new Pen(Color.LightBlue), 400, 200, 100, 50);

            //四角形を表示
            g.FillRectangle(black, 20, ClientSize.Height * 0.666f, ClientSize.Width -20 - 20, ClientSize.Height * 0.333f - 20);
            //e.Graphics.FillRectangle(new SolidBrush(色の種類), x座標, y座標, 幅, 高さ);

            /*
            g.DrawString("ドイツ国旗", Font, black, 0, 0);
            g.DrawString("■■■■■", Font, black, 0, 12);
            g.DrawString("■■■■■", Font, new SolidBrush(Color.Red), 0, 24);
            g.DrawString("■■■■■", Font, new SolidBrush(Color.Yellow), 0, 36);
            //e.Graphics.DrawString("文字列", フォントの種類, new SolidBrush(色の種類), x座標, y座標);
            
            g.DrawString("ＭＳ 明朝", new Font("ＭＳ 明朝", 32), black, 0, 100);
            //フォントの変更 : new Font("フォント名", 大きさ)
            */
            DString('A', 0);
            DString("こんにちは！", 1);
            DString("こんにちは！", 2, 16);
            DString("こんにちは！", 3, 20);
            DString("X:" + px + "Y:" + py, 4, 24);
        }


        //関数名が同じでも引数の数、種類が異なれば作れる。
        void DString(string str,float line, float size)
        {
            g.DrawString(str, new Font("ＭＳ 明朝", size), new SolidBrush(Color.White), 20, ClientSize.Height * 0.666f + line * size);
        }
        /// <summary>
        /// sizeの引数がなければ12にする。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="line"></param>
        void DString(string str, float line)
        {
            g.DrawString(str, new Font("ＭＳ 明朝", 12), new SolidBrush(Color.White), 20, ClientSize.Height * 0.666f + line * 12);
        }
        void DString(char chr, float line)
        {
            g.DrawString(chr.ToString(), new Font("ＭＳ 明朝", 12), new SolidBrush(Color.White), 20, ClientSize.Height * 0.666f + line * 12);
        }


        /// <summary>
        /// Windowに表示する関数
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Console.WriteLine("OnPaint開始");
            g = e.Graphics;
            init(); //画面設定
            draw(); //描画
            Console.WriteLine("OnPaint完了");
        }
        /// <summary>
        /// キーが押されたら実行する関数
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
            if(e.KeyCode == Keys.D)
            {
                px += 20;
            }
            if (e.KeyCode == Keys.A)
            {
                px -= 20;
            }
            if (e.KeyCode == Keys.S)
            {
                py += 20;
            }
            if (e.KeyCode == Keys.W)
            {
                py -= 20;
            }
            //OnPaintではなくInvalidateを使うと再描画できる
            Invalidate();
        }

        static void Main()
        {
            Console.WriteLine("Main");
            Application.Run(new Program());
        }
    }
}
