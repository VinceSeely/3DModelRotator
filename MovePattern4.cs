using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
   public class MovePattern4 : MovePattern
   {
      private int totalMoves;
      private const int MAXMOVES = 1000;
      private bool moveOut;

      public MovePattern4()
      {
         totalMoves = 1;
         moveOut = true;
      }

      public override void Move(Figure fig)
      {
         if (totalMoves > MAXMOVES)
         {
            totalMoves = 1;
            moveOut = !moveOut;
         }

         if (moveOut)
         {
            fig.Translate(0.01f, 0.1f, 0);
            totalMoves++;
         }
         else
         {
            fig.Translate(-0.01f, -0.01f, 0);
            totalMoves++;
         }
      }
   }
}
