using System;

namespace AlienSpaceShooter.MovePatterns
{
   public class RotateAndMoveFIgure : MovePattern
   {
      private Random rand = new Random();

      public override void Move(Figure fig)
      {
            fig.Translate((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
            fig.Rotate((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
      }
   }
}