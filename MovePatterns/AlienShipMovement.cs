using System;

namespace AlienSpaceShooter.MovePatterns
{
   internal class AlienShipMovement : MovePattern
   {

      private Random rand = new Random();
      public override void Move(Figure fig)
      {
         fig.Translate((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble());
      }
   }
}