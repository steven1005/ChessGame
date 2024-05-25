using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChesssGame
{
    public class Board
    {
        public enum ClickType
        {
            None,
            Click
        }

        public class HalfBoardStatus
        {
            public Rectangle rect;
            public int iPlayer; // -1 None, 0 PlayOne, 1 PlayTwo
            public int iBoardIdx;
            public int iPieceIdx; // -1 None, 0 - 15 PlayOne,PlayTwo
            public ClickType eClick;
        }

        public List<HalfBoardStatus> rectHalfBoard = new List<HalfBoardStatus>() {
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(98, 55), Size =  new Size(75, 75)}, iPlayer = -1, iBoardIdx = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(178, 55), Size = new Size(75, 75)}, iPlayer = -1, iBoardIdx = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(258, 55), Size = new Size(75, 75)}, iPlayer = -1, iBoardIdx = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(338, 55), Size = new Size(75, 75)}, iPlayer = -1, iBoardIdx = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(418, 55), Size = new Size(75, 75)}, iPlayer = -1, iBoardIdx = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(498, 55), Size = new Size(75, 75)}, iPlayer = -1, iBoardIdx = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(578, 55), Size = new Size(75, 75)}, iPlayer = -1, iBoardIdx = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(658, 55), Size = new Size(75, 75)}, iPlayer = -1, iBoardIdx = -1, iPieceIdx = -1, eClick = ClickType.None},

            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(98, 135), Size =  new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(178, 135), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(258, 135), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(338, 135), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(418, 135), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(498, 135), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(578, 135), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(658, 135), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
        
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(98, 218), Size =  new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(178, 218), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(258, 218), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(338, 218), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(418, 218), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(498, 218), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(578, 218), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(658, 218), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
        
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(98, 300), Size =  new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(178, 300), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(258, 300), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(338, 300), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(418, 300), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(498, 300), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(578, 300), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
            new HalfBoardStatus{ rect = new Rectangle { Location = new Point(658, 300), Size = new Size(75, 75)}, iBoardIdx = -1, iPlayer = -1, iPieceIdx = -1, eClick = ClickType.None},
        };
    }
}
