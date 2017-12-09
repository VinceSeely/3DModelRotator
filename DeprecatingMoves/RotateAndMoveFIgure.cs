namespace Prog2
{
   public class RotateAndMoveFIgure : MovePattern
   {
      private int totalMoves;
      private const int MAXMOVES = 1000;
      private bool moveOut;

      public RotateAndMoveFIgure()
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
            fig.Translate(0.01f, 0, 0);
            fig.Rotate(0.01f, 0, 0);
            totalMoves++;
         }
         else
         {
            fig.Translate(-0.01f, 0, 0);
            fig.Rotate(-0.01f, 0, 0);
            totalMoves++;
         }
      }
   }
}