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
      private Vector3 loc;

      /// <summary>
      /// Instantiates the "shot" and starts it at the player location
      /// </summary>
      /// <param name="fig"></param>
      /// <param name="direction"></param>
      /// <param name="moveAmount"></param>
      /// <param name="location"></param>
      public PlayerShot(Figure fig, Vector3 direction, double moveAmount, Vector3 location)
      {
         v = direction;
         m = moveAmount;
         loc = location;

         fig.Translate(loc.X, loc.Y, loc.Z);
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
