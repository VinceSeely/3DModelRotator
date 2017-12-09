using System;

namespace Prog2
{
   public class RotateAndMoveFIgure : MovePattern
   {
      private int totalMoves;
      private const int MAXMOVES = 1000;
      private bool moveOut;
      private Random rand = new Random();

      public RotateAndMoveFIgure()
      {
         totalMoves = 1;
         moveOut = true;
      }

      public override void Move(Figure fig)
      {
            fig.Translate((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
            fig.Rotate((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
      }
   }
}