using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
   public class ScaleAndRotate : MovePattern
   {
      public override void Move(Figure fig)
      {
         fig.Rotate(1.0f, 1.0f, 0.0f);
         fig.Scale(-1.0f, -1.0f, 0.0f);
      }
   }
}
