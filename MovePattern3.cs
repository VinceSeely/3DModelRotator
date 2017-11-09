using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
   public class MovePattern3 : MovePattern 
   {
      private int totalMoves;
      private const int MAXMOVES = 1000;
      private bool goBack;

      public MovePattern3()
      {
         totalMoves = 1;
         goBack = false;
      }

      public override void Move(Figure fig)
      {
         if(totalMoves > MAXMOVES)
         {
            totalMoves = 1;
            goBack = !goBack;
         }

         if(!goBack)
         {
            fig.Scale(1.001f, 1f, 1.001f);
         }
         else
         {
            fig.Scale(.999f, 1f, .999f);
         }
         totalMoves++;
      }
   }
}
