using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienSpaceShooter.MovePatterns
{
   public class ScaleAndRotate : MovePattern
   {

      private int totalMoves;
      private const int MAXMOVES = 1000;
      private bool moveOpposite;

      public ScaleAndRotate()
      {
         totalMoves = 1;
         moveOpposite = true;
      }
      public override void Move(Figure fig)
      {
         if (totalMoves > MAXMOVES)
         {
            moveOpposite = !moveOpposite;
            totalMoves = 1;
         }
         if (moveOpposite)
         {
            fig.Rotate(-0.01f, -0.01f, 0.0f);
            fig.Scale(1.001f, 1.001f, 1.001f);
         }
         else
         {
            fig.Rotate(0.01f, 0.01f, 0.0f);
            fig.Scale(0.999f, 0.999f, 0.999f);
         }

         totalMoves++;
      }
   }
}
