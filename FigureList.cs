using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
   class FigureList
   {
      private struct FigureMovementPair
      {
         public Figure fig;
         public MovePattern movement;
      }

      private List<FigureMovementPair> figlist = new List<FigureMovementPair>();

      public void LoadFigures(string folderName)
      {

      }
   }
}
