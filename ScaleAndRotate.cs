using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
   public class ScaleAndRotate : MovePattern
   {

      private int totalMoves;
      private const int MAXMOVES = 20;
      private bool moveOpposite;

      public ScaleAndRotate()
      {
         totalMoves = 0;
         moveOpposite = true;
      }
      public override void Move(Figure fig)
      {
         if (totalMoves > MAXMOVES)
         {
            moveOpposite = !moveOpposite;
         }
         if (moveOpposite)
         {
            fig.Rotate(-1.0f, -1.0f, 0.0f);
            fig.Scale(1.0f, 1.0f, 1.0f);
         }
         else
         {
            fig.Rotate(1.0f, 1.0f, 0.0f);
            fig.Scale(-1.0f, -1.0f, -1.0f);
         }
         totalMoves++;
      }
   }
}
