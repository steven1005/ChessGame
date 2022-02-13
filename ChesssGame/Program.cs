using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChesssGame
{
    enum GameBoard
    {
        HalfBoard = 0,
        WholeBoard
    }

    public class Global
    {
        public static Board board = new Board();
        public static Piece piece = new Piece();

        public static bool bPieceStep = false; // true     紅 PlayOne rdoRed
        // false    黑 PlayTow rdoBlack

        public static int iBordType = 0; // 0 半板 1 全板
        public static void TurnPlayPiece() // 換手
        {
            bPieceStep = !bPieceStep;
            // Accessing Form's Controls from another class
            Form1.ChangePieceRadioValue();
        }

        public static void MsgStatusUpdate(string sMsg)
        {
            Form1.ChangeStatusMessage(sMsg);
        }

        //private string _x = "test";

        //public string X
        //{
        //    get //用來回傳給用戶讀取
        //    {
        //        return this._x;
        //    }
        //    set //開放給用戶修改
        //    {
        //        this._x = value;
        //    }
        //}

        //public string X { get; set; } //.Net 3.0 可以這樣寫
    }

    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
