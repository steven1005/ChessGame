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
        public Piece p = new Piece();

        struct structFightPiece
        {
            public int iNowSelected;
            public Piece.picPiece pPlayRed;
            public Piece.picPiece pPlayBlack;
        };
        structFightPiece stFightPiece;

        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            ChnangeMainFormBoard(Global.iBordType);
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
                return;
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

                bi.iPieceIdx = bi.iBoardIdx % 16;
                bi.iPlayer = (bi.iBoardIdx < 16) ? 0:1;

                //Console.WriteLine(bi.iPieceIdx);
            } // end for i
            //for (int i = 0; i < 32; i++)
            //{
            //    Console.WriteLine(Global.board.rectHalfBoard[i].iBoardIdx);
            //}
        }

        private void StartGame(int iType)
        {
            if (iType == (int)GameBoard.HalfBoard)
            {
                stFightPiece.iNowSelected = (int)Piece.PieceType.None;
                stFightPiece.pPlayRed = null;
                stFightPiece.pPlayBlack = null;
                // 亂數放棋子
                //RandomPiece();
                //GenerateNumber1();

            }
        }

        private void 開始ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame(Global.iBordType);
        }

        //public bool FightPiece()
        //{
        //    if (stFightPiece.iNowSelected == (int)Piece.PieceType.PlayBlack)
        //    {
        //        if (stFightPiece.pPlayBlack.iLevel <= stFightPiece.pPlayRed.iLevel)
        //        {
        //            stFightPiece.pPlayRed.bAlive = false;
        //            stFightPiece.pPlayRed.ePieceSatus = Piece.SelectedType.None;
        //            stFightPiece.pPlayBlack.iPieceIdx = stFightPiece.pPlayRed.iPieceIdx;

        //            UpdateStatusMessage(stFightPiece.pPlayBlack.sName + " 殺 " + stFightPiece.pPlayRed.sName);
        //            return true;
        //        }
        //    }
        //    if (stFightPiece.iNowSelected == (int)Piece.PieceType.PlayRed)
        //    {
        //        if (stFightPiece.pPlayRed.iLevel <= stFightPiece.pPlayBlack.iLevel)
        //        {
        //            stFightPiece.pPlayBlack.bAlive = false;
        //            stFightPiece.pPlayBlack.ePieceSatus = Piece.SelectedType.None;
        //            stFightPiece.pPlayRed.iPieceIdx = stFightPiece.pPlayBlack.iPieceIdx;

        //            UpdateStatusMessage(stFightPiece.pPlayRed.sName + " 殺 " + stFightPiece.pPlayBlack.sName);
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            //if (Global.iBordType == (int)GameBoard.HalfBoard)
            //{
            //    int iRedCount = 0;
            //    int iBlackCount = 0;
            //    for(int i = 0; i < 32 ; i++)
            //    {
            //        if (Global.board.rectHalfBoard[i].iPlayer != -1)
            //        {
            //            // Create image.
            //            //Image newImage = Properties.Resources.Dark;
            //            Image newImage = null;
            //            Piece.SelectedType PieceStatus = Piece.SelectedType.Dark;

            //            // 紅棋
            //            if(Global.board.rectHalfBoard[i].iPlayer == 0)
            //            {
            //                iRedCount++;
            //                newImage = p.PlayRed[Global.board.rectHalfBoard[i].iPieceIdx].Image; // 棋圖像
            //                if (Global.board.rectHalfBoard[i].eClick == Board.ClickType.Click)
            //                {
            //                    // 已開啟的
            //                    if (p.PlayRed[Global.board.rectHalfBoard[i].iPieceIdx].ePieceSatus == Piece.SelectedType.Selected)
            //                    {
            //                        Global.TurnPlayPiece();

            //                        stFightPiece.iNowSelected = (int)Piece.PieceType.PlayRed;
            //                        stFightPiece.pPlayRed = p.PlayRed[Global.board.rectHalfBoard[i].iPieceIdx];

            //                        PieceStatus = p.PlayRed[Global.board.rectHalfBoard[i].iPieceIdx].ePieceSatus;
            //                    }
            //                    // 未開啟的
            //                    if (p.PlayRed[Global.board.rectHalfBoard[i].iPieceIdx].ePieceSatus == Piece.SelectedType.Dark)
            //                    {
            //                        Global.TurnPlayPiece();

            //                        PieceStatus = Piece.SelectedType.Selected;
            //                        p.PlayRed[Global.board.rectHalfBoard[i].iPieceIdx].ePieceSatus = PieceStatus;

            //                        stFightPiece.iNowSelected = (int)Piece.PieceType.None;
            //                        stFightPiece.pPlayRed = null;
            //                    }
            //                    UpdateStatusMessage(p.PlayRed[Global.board.rectHalfBoard[i].iPieceIdx].sName + "(" + Global.board.rectHalfBoard[i].iBoardIdx + ") Level " + p.PlayRed[Global.board.rectHalfBoard[i].iPieceIdx].iLevel);
            //                }
            //                else
            //                {
            //                    PieceStatus = p.PlayRed[Global.board.rectHalfBoard[i].iPieceIdx].ePieceSatus;
            //                }
            //            }

            //            // 黑棋
            //            if (Global.board.rectHalfBoard[i].iPlayer == 1)
            //            {
            //                iBlackCount++;
            //                newImage = p.PlayBlack[Global.board.rectHalfBoard[i].iPieceIdx].Image; // 棋圖像
            //                if (Global.board.rectHalfBoard[i].eClick == Board.ClickType.Click)
            //                {
            //                    // 已開啟的
            //                    if (p.PlayBlack[Global.board.rectHalfBoard[i].iPieceIdx].ePieceSatus == Piece.SelectedType.Selected)
            //                    {
            //                        Global.TurnPlayPiece();

            //                        stFightPiece.iNowSelected = (int)Piece.PieceType.PlayRed;
            //                        stFightPiece.pPlayBlack = p.PlayBlack[Global.board.rectHalfBoard[i].iPieceIdx];

            //                        PieceStatus = p.PlayBlack[Global.board.rectHalfBoard[i].iPieceIdx].ePieceSatus;
            //                    }
            //                    // 未開啟的
            //                    if (p.PlayBlack[Global.board.rectHalfBoard[i].iPieceIdx].ePieceSatus == Piece.SelectedType.Dark)
            //                    {
            //                        Global.TurnPlayPiece();

            //                        PieceStatus = Piece.SelectedType.Selected;
            //                        p.PlayBlack[Global.board.rectHalfBoard[i].iPieceIdx].ePieceSatus = PieceStatus;

            //                        stFightPiece.iNowSelected = (int)Piece.PieceType.None;
            //                        stFightPiece.pPlayBlack = null;
            //                    }
            //                    UpdateStatusMessage(p.PlayBlack[Global.board.rectHalfBoard[i].iPieceIdx].sName + "(" + Global.board.rectHalfBoard[i].iBoardIdx + ") Level " + p.PlayBlack[Global.board.rectHalfBoard[i].iPieceIdx].iLevel);
            //                }
            //                else
            //                {
            //                    PieceStatus = p.PlayBlack[Global.board.rectHalfBoard[i].iPieceIdx].ePieceSatus;
            //                }
            //            }

            //            //bool bWin = false;
            //            //if (stFightPiece.pPlayRed != null && stFightPiece.pPlayBlack != null)
            //            //{
            //            //    bWin = FightPiece();
            //            //    //if(bWin)
            //            //    //{

            //            //    //    newImage = 
            //            //    //}
            //            //}

            //            // Create point for upper-left corner of image.
            //            PointF ulCorner = Global.board.rectHalfBoard[i].rect.Location;

            //            if (PieceStatus == Piece.SelectedType.Dark)
            //                newImage = Properties.Resources.Dark;

            //            if (PieceStatus == Piece.SelectedType.None)
            //                newImage = null;

            //            // Draw image to screen.
            //            if (newImage != null)
            //            {
            //                e.Graphics.DrawImage(newImage, ulCorner);

            //                StringFormat drawFormat = new StringFormat();
            //                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            //                e.Graphics.DrawString(Global.board.rectHalfBoard[i].iPieceIdx.ToString(), 
            //                    new Font("Arial", 32), 
            //                    new SolidBrush(Color.Yellow),
            //                    Location.X, Location.Y,
            //                    drawFormat);
            //            }

            //            Global.board.rectHalfBoard[i].eClick = Board.ClickType.None;
            //        } // end iPlay
            //    } // end loop 32
            //    //Console.WriteLine("Red " + iRedCount);
            //    //Console.WriteLine("Black " + iBlackCount);
            //} // end HalfBoard


            #region 顯示所有棋子
            //Image newImage = null;
            //newImage = Properties.Resources.Dark;

            //for (int i = 0; i < 32; i++)
            //{
            //    PointF ulCorner = Global.board.rectHalfBoard[i].rect.Location;
            //    if (newImage != null)
            //    {
            //        // 紅棋
            //        if (Global.board.rectHalfBoard[i].iPlayer == 0)
            //        {
            //            newImage = p.PlayRed[Global.board.rectHalfBoard[i].iPieceIdx].Image; // 棋圖像
            //        }
            //        //  黑棋
            //        if (Global.board.rectHalfBoard[i].iPlayer == 1)
            //        {
            //            newImage = p.PlayBlack[Global.board.rectHalfBoard[i].iPieceIdx].Image; // 棋圖像
            //        }
            //        e.Graphics.DrawImage(newImage, ulCorner);

            //        StringFormat drawFormat = new StringFormat();
            //        drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            //        e.Graphics.DrawString(Global.board.rectHalfBoard[i].iPieceIdx.ToString(),
            //            new Font("Arial", 32),
            //            new SolidBrush(Color.Yellow),
            //            Location.X, Location.Y,
            //            drawFormat);
            //    }
            //}
            #endregion

            Image newImage = null;
            newImage = Properties.Resources.Dark;

            foreach (Piece.picPiece pRed in p.PlayRed)
            {
                int iBoardLoc = pRed.iBoardIdx;
                newImage = pRed.Image; // 棋圖像
                PaintImagePiece(e, newImage, iBoardLoc);
            }

            foreach (Piece.picPiece pBlack in p.PlayBlack)
            {
                int iBoardLoc = pBlack.iBoardIdx;
                newImage = pBlack.Image; // 棋圖像
                newImage = Properties.Resources.Dark;
                PaintImagePiece(e, newImage, iBoardLoc);
            }
        }

        private void PaintImagePiece(PaintEventArgs ep, Image img, int iLoc)
        {
            PointF ulCorner = Global.board.rectHalfBoard[iLoc - 1].rect.Location;
            ep.Graphics.DrawImage(img, ulCorner);
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            ep.Graphics.DrawString(Global.board.rectHalfBoard[iLoc - 1].iPieceIdx.ToString(),
                new Font("Arial", 32),
                new SolidBrush(Color.Yellow),
                Location.X, Location.Y,
                drawFormat);
        }

        private void MainPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (Global.iBordType == (int)GameBoard.HalfBoard)
            {
                for(int i = 0; i < 32; i++)
                {
                    if (Global.board.rectHalfBoard[i].rect.Contains(e.Location))
                    {
                        Global.board.rectHalfBoard[i].eClick = Board.ClickType.Click;
                    }
                }
            } // end HalfBoard
            MainPanel.Invalidate();
        }
    }
}
