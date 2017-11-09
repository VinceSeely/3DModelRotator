namespace Prog2
{
   public class RotateAndMoveFIgure : MovePattern
   {
      private int totalMoves;
      private const int MAXMOVES = 20;
      private bool moveOut;

      public RotateAndMoveFIgure()
      {
         totalMoves = 0;
         moveOut = true;
      }

      public override void Move(Figure fig)
      {
         if (totalMoves > MAXMOVES)
         {
            totalMoves = 0;
            moveOut = !moveOut;
         }

         if (moveOut)
         {
            fig.Translate(1f, 0, 0);
            fig.Rotate(1f, 0, 0);
            totalMoves++;
         }
         else
         {
            fig.Translate(-1, 0, 0);
            fig.Rotate(-1, 0, 0);
            totalMoves++;
         }
      }
   }
}