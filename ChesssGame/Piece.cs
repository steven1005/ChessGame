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
            Selected,
            aLive
        }
        
        public bool bFight = false;
        picPiece[] FightSeletedPiece = new picPiece[2]; //  0 第一個選擇 1 第一個選擇

        public static Size sPieceIcon = new Size(74, 76);
        public class picPiece
        {
            public PictureBox pic;
            public string sName; // 將 士 象 車 馬 炮 卒
                                 // 帥 仕 相 車 馬 炮 兵
            public int iLevel; // 0 將 1 士 1 士 2 象 2 象 3 車 3 車 4 馬 4 馬 5 炮 5 炮 6 卒 6 卒 6 卒 6 卒 6 卒 
                               // 0 帥 1 仕 1 仕 2 相 2 相 3 車 3 車 4 馬 4 馬 5 炮 5 炮 6 兵 6 兵 6 兵 6 兵 6 兵
            public SelectedType ePieceSatus;
        }

        public Piece()
        {
            InitPictureBox();
        }

        // 紅
        public List <picPiece> PlayOne = new List<picPiece> {
            new picPiece { pic = new PictureBox(), sName = "帥", iLevel = 0, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "仕", iLevel = 1, ePieceSatus = SelectedType.Dark},
            new picPiece { pic = new PictureBox(), sName = "仕", iLevel = 1, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "相", iLevel = 2, ePieceSatus = SelectedType.Dark},
            new picPiece { pic = new PictureBox(), sName = "相", iLevel = 2, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "車", iLevel = 3, ePieceSatus = SelectedType.Dark},
            new picPiece { pic = new PictureBox(), sName = "車", iLevel = 3, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "馬", iLevel = 4, ePieceSatus = SelectedType.Dark},
            new picPiece { pic = new PictureBox(), sName = "馬", iLevel = 4, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "炮", iLevel = 5, ePieceSatus = SelectedType.Dark},
            new picPiece { pic = new PictureBox(), sName = "炮", iLevel = 5, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "兵", iLevel = 6, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "兵", iLevel = 6, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "兵", iLevel = 6, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "兵", iLevel = 6, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "兵", iLevel = 6, ePieceSatus = SelectedType.Dark}
            };
        
        // 黑
        public List<picPiece> PlayTwo = new List<picPiece> {
            new picPiece { pic = new PictureBox(), sName = "將", iLevel = 0, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "士", iLevel = 1, ePieceSatus = SelectedType.Dark},
            new picPiece { pic = new PictureBox(), sName = "士", iLevel = 1, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "象", iLevel = 2, ePieceSatus = SelectedType.Dark},
            new picPiece { pic = new PictureBox(), sName = "象", iLevel = 2, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "車", iLevel = 3, ePieceSatus = SelectedType.Dark},
            new picPiece { pic = new PictureBox(), sName = "車", iLevel = 3, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "馬", iLevel = 4, ePieceSatus = SelectedType.Dark},
            new picPiece { pic = new PictureBox(), sName = "馬", iLevel = 4, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "炮", iLevel = 5, ePieceSatus = SelectedType.Dark},
            new picPiece { pic = new PictureBox(), sName = "炮", iLevel = 5, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "卒", iLevel = 6, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "卒", iLevel = 6, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "卒", iLevel = 6, ePieceSatus = SelectedType.Dark},
            new picPiece { pic = new PictureBox(), sName = "卒", iLevel = 6, ePieceSatus = SelectedType.Dark}, 
            new picPiece { pic = new PictureBox(), sName = "卒", iLevel = 6, ePieceSatus = SelectedType.Dark}
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
                if ((int)Pic.Tag < 16)
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
                                }
                                bFight = true;
                                Global.MsgStatusUpdate("選取 " + PlayOne[i].sName);
                                Console.WriteLine("PlayOne " + Pic.Name + " Tag " + (int)Pic.Tag + " Status " + PlayOne[i].ePieceSatus.ToString());
                                break;
                            }
                        }
                    }
                } // end PlayOne
                if ((int)Pic.Tag > 15)
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
                                }
                                bFight = true;
                                Global.MsgStatusUpdate("選取 " + PlayTwo[i].sName);
                                Console.WriteLine("PlayTwo " + Pic.Name + " Tag " + (int)Pic.Tag + " Status " + PlayTwo[i].ePieceSatus.ToString());
                            }
                        }
                    }
                } // end PlayTwo
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
