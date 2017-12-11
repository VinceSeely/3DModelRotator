using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace AlienSpaceShooter.MovePatterns
{
   public class PlayerShot: MovePattern 
   {
      private Vector3 v;
      private double m;

      public PlayerShot(Vector3 direction, double moveAmount)
      {
         v = direction;
         m = moveAmount;
      }

      public override void Move(Figure fig)
      {
         double x = m * v.X;
         double y = m * v.Y;
         double z = m * v.Z;

         fig.Translate((float)x, (float)y, (float)z);
      }
   }
}
