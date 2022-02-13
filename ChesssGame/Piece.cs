using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChesssGame
{
    public class Piece
    {
        public enum SelectedType
        {
            Dark = 0,
            None,
            Selected
        }
        
        public bool bFight = false;
        picPiece[] FightSeletedPiece = new picPiece[2]; //  0 第一個選擇 1 第二個選擇

        public static Size sPieceIcon = new Size(74, 76);
        public class picPiece
        {
            public PictureBox pic;
            public string sName; // 將 士 象 車 馬 炮 卒
                                 // 帥 仕 相 車 馬 炮 兵
            public int iLevel; // 0 將 1 士 1 士 2 象 2 象 3 車 3 車 4 馬 4 馬 5 炮 5 炮 6 卒 6 卒 6 卒 6 卒 6 卒 
                               // 0 帥 1 仕 1 仕 2 相 2 相 3 車 3 車 4 馬 4 馬 5 炮 5 炮 6 兵 6 兵 6 兵 6 兵 6 兵
            public int iPlayer; // -1 None, 0 PlayOne, 1 PlayTwo
            public int iPieceIdx; // -1, 0 - 15
            public int iBoardIdx; // -1, 0 - 31
            public bool bAlive = true; // false Dead, true Alive
            public SelectedType ePieceSatus;
        }

        public Piece()
        {
            InitPictureBox();
        }

        // 紅
        public List <picPiece> PlayOne = new List<picPiece> {
            new picPiece { pic = new PictureBox(), sName = "帥", iLevel = 0, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 0}, 
            new picPiece { pic = new PictureBox(), sName = "仕1", iLevel = 1, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 1},
            new picPiece { pic = new PictureBox(), sName = "仕2", iLevel = 1, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 2}, 
            new picPiece { pic = new PictureBox(), sName = "相1", iLevel = 2, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 3},
            new picPiece { pic = new PictureBox(), sName = "相2", iLevel = 2, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 4}, 
            new picPiece { pic = new PictureBox(), sName = "俥1", iLevel = 3, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 5},
            new picPiece { pic = new PictureBox(), sName = "俥2", iLevel = 3, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 6}, 
            new picPiece { pic = new PictureBox(), sName = "傌1", iLevel = 4, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 7},
            new picPiece { pic = new PictureBox(), sName = "傌2", iLevel = 4, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 8}, 
            new picPiece { pic = new PictureBox(), sName = "炮1", iLevel = 5, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 9},
            new picPiece { pic = new PictureBox(), sName = "炮2", iLevel = 5, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 10}, 
            new picPiece { pic = new PictureBox(), sName = "兵1", iLevel = 6, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 11}, 
            new picPiece { pic = new PictureBox(), sName = "兵2", iLevel = 6, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 12}, 
            new picPiece { pic = new PictureBox(), sName = "兵3", iLevel = 6, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 13}, 
            new picPiece { pic = new PictureBox(), sName = "兵4", iLevel = 6, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 14}, 
            new picPiece { pic = new PictureBox(), sName = "兵5", iLevel = 6, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 15}
            };
        
        // 黑
        public List<picPiece> PlayTwo = new List<picPiece> {
            new picPiece { pic = new PictureBox(), sName = "將", iLevel = 0, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 0}, 
            new picPiece { pic = new PictureBox(), sName = "士1", iLevel = 1, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 1},
            new picPiece { pic = new PictureBox(), sName = "士2", iLevel = 1, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 2}, 
            new picPiece { pic = new PictureBox(), sName = "象1", iLevel = 2, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 3},
            new picPiece { pic = new PictureBox(), sName = "象2", iLevel = 2, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 4}, 
            new picPiece { pic = new PictureBox(), sName = "車1", iLevel = 3, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 5},
            new picPiece { pic = new PictureBox(), sName = "車2", iLevel = 3, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 6}, 
            new picPiece { pic = new PictureBox(), sName = "馬1", iLevel = 4, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 7},
            new picPiece { pic = new PictureBox(), sName = "馬2", iLevel = 4, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 8}, 
            new picPiece { pic = new PictureBox(), sName = "包1", iLevel = 5, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 9},
            new picPiece { pic = new PictureBox(), sName = "包2", iLevel = 5, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 10}, 
            new picPiece { pic = new PictureBox(), sName = "卒1", iLevel = 6, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 11}, 
            new picPiece { pic = new PictureBox(), sName = "卒2", iLevel = 6, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 12}, 
            new picPiece { pic = new PictureBox(), sName = "卒3", iLevel = 6, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 13},
            new picPiece { pic = new PictureBox(), sName = "卒4", iLevel = 6, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 14}, 
            new picPiece { pic = new PictureBox(), sName = "卒5", iLevel = 6, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 15}
            };

        public void InitPictureBox()
        {
            for(int i = 0; i < 16; i++)
            {
                if (PlayOne[i].pic != null)
                {
                    PlayOne[i].pic.Click += new EventHandler(PicClickEvent_Click);
                    PlayOne[i].pic.Name = PlayOne[i].sName;
                    PlayOne[i].pic.Tag = i;
                }
                if (PlayTwo[i].pic != null)
                {
                    PlayTwo[i].pic.Click += new EventHandler(PicClickEvent_Click);
                    PlayTwo[i].pic.Name = PlayTwo[i].sName;
                    PlayTwo[i].pic.Tag = i + 16;
                }
            }
        }

        public void PicClickEvent_Click(object sender, EventArgs e)
        {
            PictureBox Pic = sender as PictureBox;

            if (null == Pic) 
                return;

            if (Global.iBordType == (int)GameBoard.HalfBoard)
            {
                //Console.WriteLine(Pic.Tag);
                if ((int)Pic.Tag < 16 && (Global.bPieceStep || bFight == true))
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if ((int)PlayOne[i].pic.Tag == (int)Pic.Tag)
                        {
                            // 選棋
                            // 同一支棋
                            if (PlayOne[i].ePieceSatus == SelectedType.Selected)
                            {
                                PlayOne[i].ePieceSatus = SelectedType.None;

                                FightSeletedPiece[0] = null;
                                FightSeletedPiece[1] = null;
                                Global.MsgStatusUpdate("不選取 " + PlayOne[i].sName);
                                Console.WriteLine("PlayOne " + Pic.Name + " Tag " + (int)Pic.Tag + " Status " + PlayOne[i].ePieceSatus.ToString());
                                break;
                            }

                            // 點擊棋後改狀態
                            if (PlayOne[i].ePieceSatus == SelectedType.None && PlayOne[i].ePieceSatus != SelectedType.Selected)
                            {
                                PlayOne[i].ePieceSatus = SelectedType.Selected;
                                
                                if(bFight == false)
                                {
                                    FightSeletedPiece[0] = PlayOne[i];
                                    FightSeletedPiece[1] = null;
                                    Console.WriteLine("Fight PlayOne 0 " + PlayOne[i].sName);
                                }
                                else
                                {
                                    FightSeletedPiece[1] = PlayOne[i];
                                    Console.WriteLine("Fight PlayOne 1 " + PlayOne[i].sName);
                                }
                                bFight = true;
                                Global.MsgStatusUpdate("選取 " + PlayOne[i].sName);
                                Console.WriteLine("PlayOne " + Pic.Name + " Tag " + (int)Pic.Tag + " Status " + PlayOne[i].ePieceSatus.ToString());
                                break;
                            }
                        }
                    }
                } // end PlayOne

                if ((int)Pic.Tag > 15 && (!Global.bPieceStep || bFight == true))
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if ((int)PlayTwo[i].pic.Tag == (int)Pic.Tag)
                        {
                            // 選棋
                            // 同一支棋
                            if (PlayTwo[i].ePieceSatus == SelectedType.Selected)
                            {
                                PlayTwo[i].ePieceSatus = SelectedType.None;

                                FightSeletedPiece[0] = null;
                                FightSeletedPiece[1] = null;
                                bFight = false;
                                Global.MsgStatusUpdate("不選取 " + PlayTwo[i].sName);
                                Console.WriteLine("PlayTwo " + Pic.Name + " Tag " + (int)Pic.Tag + " Status " + PlayOne[i].ePieceSatus.ToString());
                            }
                            // 點擊棋後改狀態
                            if (PlayTwo[i].ePieceSatus == SelectedType.None && PlayTwo[i].ePieceSatus != SelectedType.Selected)
                            {
                                PlayTwo[i].ePieceSatus = SelectedType.Selected;
                                
                                if(bFight == false)
                                {
                                    FightSeletedPiece[0] = PlayTwo[i];
                                    FightSeletedPiece[1] = null;
                                    Console.WriteLine("Fight PlayTwo 0 " + PlayTwo[i].sName);
                                }
                                else
                                {
                                    FightSeletedPiece[1] = PlayTwo[i];
                                    Console.WriteLine("Fight PlayTwo 1 " + PlayTwo[i].sName);
                                }
                                bFight = true;
                                Global.MsgStatusUpdate("選取 " + PlayTwo[i].sName);
                                Console.WriteLine("PlayTwo " + Pic.Name + " Tag " + (int)Pic.Tag + " Status " + PlayTwo[i].ePieceSatus.ToString());
                            }
                        }
                    }
                } // end PlayTwo

                if (bFight && 
                    FightSeletedPiece[0] != null && FightSeletedPiece[1] != null &&
                    FightSeletedPiece[0].iPlayer != FightSeletedPiece[1].iPlayer)
                {
                    Console.WriteLine(FightSeletedPiece[0].sName);
                    Console.WriteLine(FightSeletedPiece[1].sName);

                    // 吃子
                    if (FightSeletedPiece[0].iLevel <= FightSeletedPiece[1].iLevel ||
                        FightSeletedPiece[0].iLevel - FightSeletedPiece[1].iLevel == 6) // 卒吃帥，兵吃將
                    {
                        if(FightSeletedPiece[1].iPlayer == 0)
                        {
                            int iNewIdx = FightSeletedPiece[1].iPieceIdx;
                            int iNewBoardIdx0 = FightSeletedPiece[0].iBoardIdx;

                            int iIdx = FightSeletedPiece[0].iPieceIdx;
                            int iNewBoardIdx1 = FightSeletedPiece[1].iBoardIdx;

                            PlayOne[iNewIdx].bAlive = false; // Dead
                            PlayOne[iNewIdx].pic.Location = new Point(0, 55);
                            Console.WriteLine(PlayOne[iNewIdx].sName + " Dead");

                            // 將版面贏棋位置變更為-1，才不會畫上黑格
                            Global.board.rectHalfBoard[iNewBoardIdx0].iPlayer = -1;
                            Global.board.rectHalfBoard[iNewBoardIdx1].iPlayer = -1;

                            // 將贏棋的位置移到輪棋位置
                            PlayTwo[iIdx].pic.Location = PlayOne[iNewIdx].pic.Location;
                            PlayOne[iIdx].ePieceSatus = SelectedType.None;
                        }
                        if (FightSeletedPiece[1].iPlayer == 1)
                        {
                            int iNewIdx = FightSeletedPiece[1].iPieceIdx;
                            int iNewBoardIdx0 = FightSeletedPiece[0].iBoardIdx;

                            int iIdx = FightSeletedPiece[0].iPieceIdx;
                            int iNewBoardIdx1 = FightSeletedPiece[1].iBoardIdx;

                            PlayTwo[iNewIdx].bAlive = false; // Dead
                            PlayTwo[iNewIdx].pic.Location = new Point(770, 55);
                            Console.WriteLine(PlayTwo[iNewIdx].sName + " Dead");

                            // 將版面贏棋位置變更為-1，才不會畫上黑格
                            Global.board.rectHalfBoard[iNewBoardIdx0].iPlayer = -1;
                            Global.board.rectHalfBoard[iNewBoardIdx1].iPlayer = -1;

                            // 將贏棋移到輪棋
                            PlayOne[iIdx].pic.Location = PlayTwo[iNewIdx].pic.Location;
                            PlayTwo[iIdx].ePieceSatus = SelectedType.None;
                        }

                        // 換棋
                        Global.TurnPlayPiece();
                    }

                    bFight = false;
                    FightSeletedPiece[0] = null;
                    FightSeletedPiece[1] = null;
                }
            } // end HalfBoard


        }

        // 切割大圖到PlayOne PlayTwo
        public void PaintPieceIcon()
        {
            /*
            pictureBox1.Image = originalImage.Clone(rect, originalImage.PixelFormat);
             */
            Bitmap originalImage = new Bitmap(Properties.Resources.Piece);
            for (int i = 0; i < 16; i++)
            {
                Rectangle rect = new Rectangle(i * sPieceIcon.Width, 0, sPieceIcon.Width, sPieceIcon.Height);
                PlayOne[i].pic.Image = originalImage.Clone(rect, originalImage.PixelFormat);
                PlayOne[i].pic.Size = sPieceIcon;

                Rectangle rect1 = new Rectangle(i * sPieceIcon.Width, sPieceIcon.Height, sPieceIcon.Width, sPieceIcon.Height);
                PlayTwo[i].pic.Image = originalImage.Clone(rect1, originalImage.PixelFormat);
                PlayTwo[i].pic.Size = sPieceIcon;
            }
        }
    }
}
