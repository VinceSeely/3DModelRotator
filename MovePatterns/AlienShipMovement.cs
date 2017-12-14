using System;

namespace AlienSpaceShooter.MovePatterns
{
   internal class AlienShipMovement : MovePattern
   {
      //private Random rand = new Random();
      private int numbMoves = 1000;
      private int currentMoves = 0;
      private bool posmove = true;

      public override void Move(Figure fig)
      {
         //fig.Translate((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
         if (posmove)
         {
            fig.Translate(0.1f, 0.1f, 0.0f);
            if (currentMoves++ == 1000)
               posmove = !posmove;
         }

         if (!posmove)
         {
            fig.Translate(-0.1f, -0.1f, 0.0f);
            if (currentMoves-- == 0)
               posmove = !posmove;
         }
      }
   }
}