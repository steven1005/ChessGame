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
        public List<int> listRandomLoc = new List<int>();
        public enum PieceType
        { 
            None = -1,
            PlayRed = 0,
            PlayBlack = 1
        }
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
            public Image Image;
            public string sName; // 將 士 象 車 馬 炮 卒
            // 帥 仕 相 車 馬 炮 兵
            public int iLevel; // 0 將 1 士 1 士 2 象 2 象 3 車 3 車 4 馬 4 馬 5 炮 5 炮 6 卒 6 卒 6 卒 6 卒 6 卒 
            // 0 帥 1 仕 1 仕 2 相 2 相 3 車 3 車 4 馬 4 馬 5 炮 5 炮 6 兵 6 兵 6 兵 6 兵 6 兵
            public int iPlayer; // -1 None, 0 PlayRed, 1 PlayBlack
            public int iPieceIdx; // -1, 0 - 15
            public bool bAlive = true; // false Dead, true Alive
            public int iBoardIdx;
            public SelectedType ePieceSatus;
        }

        public Piece()
        {
            listRandomLoc.Clear();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            listRandomLoc = new List<int>(Enumerable.Range(1, 32));
            listRandomLoc = listRandomLoc.OrderBy(num => rand.Next()).ToList<int>();

            for (int i = 0; i < 16; i++)
            {
                PlayRed[i].iBoardIdx = listRandomLoc[i];
            }
            for (int i = 16; i < 32; i++)
            {
                PlayBlack[i - 16].iBoardIdx = listRandomLoc[i];
            }
        }

        public PictureBox BlackMask = new PictureBox(){Image = Properties.Resources.Dark};

        // 紅
        public List<picPiece> PlayRed = new List<picPiece> {
            new picPiece {Image = Properties.Resources.紅帥,  sName = "帥",  iLevel = 0, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 0}, 
            new picPiece {Image = Properties.Resources.紅仕1, sName = "仕1", iLevel = 1, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 1},
            new picPiece {Image = Properties.Resources.紅仕2, sName = "仕2", iLevel = 1, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 2}, 
            new picPiece {Image = Properties.Resources.紅相1, sName = "相1", iLevel = 2, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 3},
            new picPiece {Image = Properties.Resources.紅相2, sName = "相2", iLevel = 2, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 4}, 
            new picPiece {Image = Properties.Resources.紅俥1, sName = "俥1", iLevel = 3, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 5},
            new picPiece {Image = Properties.Resources.紅俥2, sName = "俥2", iLevel = 3, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 6}, 
            new picPiece {Image = Properties.Resources.紅傌1, sName = "傌1", iLevel = 4, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 7},
            new picPiece {Image = Properties.Resources.紅傌2, sName = "傌2", iLevel = 4, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 8}, 
            new picPiece {Image = Properties.Resources.紅炮1, sName = "炮1", iLevel = 5, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 9},
            new picPiece {Image = Properties.Resources.紅炮2, sName = "炮2", iLevel = 5, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 10}, 
            new picPiece {Image = Properties.Resources.紅兵1, sName = "兵1", iLevel = 6, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 11}, 
            new picPiece {Image = Properties.Resources.紅兵2, sName = "兵2", iLevel = 6, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 12}, 
            new picPiece {Image = Properties.Resources.紅兵3, sName = "兵3", iLevel = 6, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 13}, 
            new picPiece {Image = Properties.Resources.紅兵4, sName = "兵4", iLevel = 6, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 14}, 
            new picPiece {Image = Properties.Resources.紅兵5, sName = "兵5", iLevel = 6, iPlayer = 0, ePieceSatus = SelectedType.Dark, iPieceIdx = 15}
            };

        // 黑
        public List<picPiece> PlayBlack = new List<picPiece> {
            new picPiece { Image = Properties.Resources.黑將,  sName = "將",  iLevel = 0, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 0}, 
            new picPiece { Image = Properties.Resources.黑士1, sName = "士1", iLevel = 1, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 1},
            new picPiece { Image = Properties.Resources.黑士2, sName = "士2", iLevel = 1, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 2}, 
            new picPiece { Image = Properties.Resources.黑象1, sName = "象1", iLevel = 2, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 3},
            new picPiece { Image = Properties.Resources.黑象2, sName = "象2", iLevel = 2, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 4}, 
            new picPiece { Image = Properties.Resources.黑車1, sName = "車1", iLevel = 3, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 5},
            new picPiece { Image = Properties.Resources.黑車2, sName = "車2", iLevel = 3, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 6}, 
            new picPiece { Image = Properties.Resources.黑馬1, sName = "馬1", iLevel = 4, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 7},
            new picPiece { Image = Properties.Resources.黑馬2, sName = "馬2", iLevel = 4, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 8}, 
            new picPiece { Image = Properties.Resources.黑包1, sName = "包1", iLevel = 5, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 9},
            new picPiece { Image = Properties.Resources.黑包2, sName = "包2", iLevel = 5, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 10}, 
            new picPiece { Image = Properties.Resources.黑卒1, sName = "卒1", iLevel = 6, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 11}, 
            new picPiece { Image = Properties.Resources.黑卒2, sName = "卒2", iLevel = 6, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 12}, 
            new picPiece { Image = Properties.Resources.黑卒3, sName = "卒3", iLevel = 6, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 13},
            new picPiece { Image = Properties.Resources.黑卒4, sName = "卒4", iLevel = 6, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 14}, 
            new picPiece { Image = Properties.Resources.黑卒5, sName = "卒5", iLevel = 6, iPlayer = 1, ePieceSatus = SelectedType.Dark, iPieceIdx = 15}
            };

    }
}
