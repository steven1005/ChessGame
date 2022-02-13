using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChesssGame
{
    public partial class Form1 : Form
    {

        // Accessing Form's Controls from another class
        // Static form. Null if no form created yet.
        private static Form1 form = null;

        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            ChnangeMainFormBoard(Global.iBordType);
            Global.piece.PaintPieceIcon();
            StartGame(Global.iBordType);
            form = this;
            Global.TurnPlayPiece();
        }

        // Accessing Form's Controls from another class
        private delegate void ChangePieceDelegate();
        private delegate void StatusMsgDelegate(string sMsg);
        // Accessing Form's Controls from another class
        // Static method, call the non-static version if the form exist.
        public static void ChangePieceRadioValue()
        {
            if (form != null)
                form.ChangePiecePlayer();
        }

        public static void ChangeStatusMessage(string sMsg)
        {
            if (form != null)
                form.UpdateStatusMessage(sMsg);
        }

        // Accessing Form's Controls from another class
        private void ChangePiecePlayer()
        {
            // If this returns true, it means it was called from an external thread.
            if (InvokeRequired)
            {
                // Create a delegate of this method and let the form run it.
                this.Invoke(new ChangePieceDelegate(ChangePiecePlayer), new object[] { });
                return; // Important
            }
            // Set textBox
            //textBox1.Enabled = enable;
            statusPiecelb.Text = (Global.bPieceStep) ? "紅棋下     " : "黑棋下     ";
        }

        private void UpdateStatusMessage(string sMsg)
        {
            if (InvokeRequired)
            {
                // Create a delegate of this method and let the form run it.
                this.Invoke(new StatusMsgDelegate(UpdateStatusMessage), new object[] { sMsg });
                return; // Important
            }
            statusDesplb.Text = sMsg;
        }

        private void ChnangeMainFormBoard(int iType)
        {
            int iWidth = Properties.Resources.HalfBoard.Width;
            int iHeight = Properties.Resources.HalfBoard.Height;
            // 暗棋 半板
            if (iType == (int)GameBoard.HalfBoard)
            {
                this.MainPanel.BackgroundImage = Properties.Resources.HalfBoard;
            }
            // 象棋 全板
            if (iType == (int)GameBoard.WholeBoard)
            {
                this.MainPanel.BackgroundImage = Properties.Resources.FullBoard;
                iWidth = Properties.Resources.FullBoard.Width;
                iHeight = Properties.Resources.FullBoard.Height - 60;
            }
            this.Width = iWidth + 150;
            this.Height = iHeight + 80;
            this.MainPanel.Width = iWidth;
            this.MainPanel.Height = iHeight;
        }

        private void 暗棋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.iBordType = 0;
            ChnangeMainFormBoard(Global.iBordType);
            StartGame(Global.iBordType);
        }

        private void 象棋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.iBordType = 1;
            ChnangeMainFormBoard(Global.iBordType);
            StartGame(Global.iBordType);
        }

        public void GenerateNumber1()  
        {
            //用於保存返回的結果   
            List<int> result = new List<int>(32);  
            Random random = new Random();  
            int temp = 0;  
            //如果返回的結果集合中實際的元素個數小於6個   
            while (result.Count < 32)  
            {  
                //在[1,34)區間任意取一個隨機整數   
                temp = random.Next(0, 32);  
                if (!result.Contains(temp))  
                {  
                    //如果在結果集合中不存在這個數，則添加這個數   
                    result.Add(temp);  
                }  
            }  
            //result.Sort();//對返回結果進行排序   
            //return result; 

            for (int i = 0; i < 32; i++)    
            {
                Board.HalfBoardStatus bi = Global.board.rectHalfBoard[i];
                bi.iBoardIdx = result[i];
                Console.WriteLine(result[i]);
            }
        }

        // 暗棋 亂數放棋子
        public void RandomPiece()
        {
            Random rnd = new Random();  //產生亂數初始值
            for (int i = 0; i < 32; i++)    
            {
                //board.rectHalfBoard[i].iPieceIdx = (int)(rnd.Next(1, 32));   //亂數產生，亂數產生的範圍是1~9
                Board.HalfBoardStatus bi = Global.board.rectHalfBoard[i];
                bi.iBoardIdx = (int)(rnd.Next(0, 32));
                //Console.WriteLine(bi.iPieceIdx);
                for (int j = 0; j < i; j++)
                {
                    while (Global.board.rectHalfBoard[j].iBoardIdx == Global.board.rectHalfBoard[i].iBoardIdx)    //檢查是否與前面產生的數值發生重複，如果有就重新產生
                    {
                        j = 0;  //如有重複，將變數j設為0，再次檢查 (因為還是有重複的可能)
                        //board.rectHalfBoard[i].iPieceIdx = (int)(rnd.Next(1, 32));   //亂數產生，亂數產生的範圍是1~9
                        Board.HalfBoardStatus bj = Global.board.rectHalfBoard[i];
                        bj.iBoardIdx = (int)(rnd.Next(0, 32));
                    }
                } // end for j
                //Console.WriteLine(bi.iPieceIdx);
            } // end for i
        }

        private void StartGame(int iType)
        {
            if (iType == (int)GameBoard.HalfBoard)
            {
                // 亂數放棋子
                RandomPiece();
                //GenerateNumber1();

                for (int i = 0; i < 16; i++)
                {
                    //Global.piece.PlayOne[i].pic.Location = Global.board.rectHalfBoard[i].rect.Location;
                    //this.MainPanel.Controls.Add(Global.piece.PlayOne[i].pic);
                    Board.HalfBoardStatus iboard = Global.board.rectHalfBoard[i];
                    Global.piece.PlayOne[i].pic.Location = Global.board.rectHalfBoard[iboard.iBoardIdx].rect.Location;
                    Global.piece.PlayOne[i].iBoardIdx = iboard.iBoardIdx;
                    Global.board.rectHalfBoard[iboard.iBoardIdx].iPlayer = 0;
                    Global.board.rectHalfBoard[iboard.iBoardIdx].iPieceIdx = i;
                    // 改蓋牌
                    Global.piece.PlayOne[i].pic.Visible = false;
                    this.MainPanel.Controls.Add(Global.piece.PlayOne[i].pic);
                }

                for (int i = 16; i < 32; i++)
                {
                    //Global.piece.PlayTwo[i - 16].pic.Location = Global.board.rectHalfBoard[i].rect.Location;
                    //this.MainPanel.Controls.Add(Global.piece.PlayTwo[i - 16].pic);
                    Board.HalfBoardStatus iboard = Global.board.rectHalfBoard[i];
                    Global.piece.PlayTwo[i - 16].pic.Location = Global.board.rectHalfBoard[iboard.iBoardIdx].rect.Location;
                    Global.piece.PlayTwo[i - 16].iBoardIdx = iboard.iBoardIdx;
                    Global.board.rectHalfBoard[iboard.iBoardIdx].iPlayer = 1;
                    Global.board.rectHalfBoard[iboard.iBoardIdx].iPieceIdx = i - 16;
                    // 改蓋牌
                    Global.piece.PlayTwo[i - 16].pic.Visible = false;
                    this.MainPanel.Controls.Add(Global.piece.PlayTwo[i - 16].pic);
                }
            }
        }

        private void 開始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame(Global.iBordType);
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            if (Global.iBordType == (int)GameBoard.HalfBoard)
            {
                for(int i = 0; i < 32 ; i++)
                {
                    if (Global.board.rectHalfBoard[i].iPlayer != -1)
                    {
                        // Create image.
                        Image newImage = Properties.Resources.Dark;

                        // Create point for upper-left corner of image.
                        PointF ulCorner = Global.board.rectHalfBoard[i].rect.Location;

                        // Draw image to screen.
                        e.Graphics.DrawImage(newImage, ulCorner);
                    }
                }
            } // end HalfBoard
        }

        private void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (Global.iBordType == (int)GameBoard.HalfBoard)
            {
                for (int i = 0; i < 32; i++)
                {
                    Board.HalfBoardStatus iboard = Global.board.rectHalfBoard[i];
                    if (iboard.rect.Contains(e.X, e.Y))
                    {
                        if (Global.board.rectHalfBoard[i].iPlayer == 0)
                        {
                            for(int i1 = 0; i1 < 16; i1++)
                            {
                                if (iboard.rect.Contains(Global.piece.PlayOne[i1].pic.Location.X, Global.piece.PlayOne[i1].pic.Location.Y))
                                {
                                    Global.piece.PlayOne[i1].pic.Visible = true;
                                    Global.piece.PlayOne[i1].ePieceSatus = Piece.SelectedType.None;
                                    Global.TurnPlayPiece();
                                    Global.MsgStatusUpdate("翻棋 紅 " + Global.piece.PlayOne[i1].sName);
                                }
                            }
                        }

                        if (Global.board.rectHalfBoard[i].iPlayer == 1)
                        {
                            for (int i1 = 0; i1 < 16; i1++)
                            {
                                if (iboard.rect.Contains(Global.piece.PlayTwo[i1].pic.Location.X, Global.piece.PlayTwo[i1].pic.Location.Y))
                                {
                                    Global.piece.PlayTwo[i1].pic.Visible = true;
                                    Global.piece.PlayTwo[i1].ePieceSatus = Piece.SelectedType.None;
                                    Global.TurnPlayPiece();
                                    Global.MsgStatusUpdate("翻棋 黑 " + Global.piece.PlayTwo[i1].sName);
                                }
                            }
                        }
                    } // Contain Rect
                } // end for

                //for(int iOne = 0; iOne < 16; iOne++)
                //{
                //    Rectangle rect = new Rectangle(Global.piece.PlayOne[iOne].pic.Location, Global.piece.PlayOne[iOne].pic.Size);
                //    if (rect.Contains(e.X, e.Y))
                //    {
                //        Console.WriteLine("Two " + Global.piece.PlayOne[iOne].sName);
                //    }
                //}
            } // end HalfBoard
            MainPanel.Invalidate();
        }
    }
}
