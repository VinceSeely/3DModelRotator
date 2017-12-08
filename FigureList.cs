using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog2
{
   class FigureList
   {
      public List<MovePattern> movePattern;
      public int moveIndex;
      public FigureList()
      {
         moveIndex = 0;
         movePattern = new List<MovePattern>
         {
            
         };
      }
      private struct FigureMovementPair
      {
         public Figure fig;
         public MovePattern movement;
      }

      private List<FigureMovementPair> figlist = new List<FigureMovementPair>();

      public void LoadFigures(string folderName)
      {
         var files = Directory.GetFiles(folderName);
         var numberShiny= 1000f;
         foreach (var file in files)
         {
            if (file.EndsWith(".wrl"))
            {
               var verts = new VertexDataList();
               verts.LoadDataFromVRML(file);
               figlist.Add(new FigureMovementPair
               {
                  fig = new Figure(verts, numberShiny),
                  movement = getNextMove()
               });
               numberShiny = 1.0f;// numberShiny++ % 2;
            }
         }
      }

      private MovePattern getNextMove()
      {
         var patternForFigure = movePattern.ElementAt(moveIndex++);
         moveIndex = moveIndex % movePattern.Count;
         return patternForFigure;
      }

      internal void Show(Matrix4 lookAt)
      {
         foreach (var figure in figlist ?? Enumerable.Empty<FigureMovementPair>())
         {
            figure.fig.Show(lookAt);
         }
      }

      internal void Move()
      {
         foreach (var figure in figlist ?? Enumerable.Empty<FigureMovementPair>())
         {
            figure.movement.Move(figure.fig);
         }
      }

      internal void Reset()
      {
         foreach(var figure in figlist)
         {
            figure.fig.Reset();
         }
      }

      public void CheckCollisionsKillIfDetected (FigureList list)
      {
         var indexsToBeRemoved = new HashSet<int>(); 
         for( int i = figlist.Count; i > figlist.Count / 2; i--)
         {
            for( int j = 0; j <= figlist.Count; j++ )
            {
               var collisionFigure = figlist[j].fig;
               var collision = figlist[i].fig.detectCollision(collisionFigure.Max + collisionFigure.TranlateAmount, collisionFigure.Min + collisionFigure.TranlateAmount);
               if (collision && i != j)
               {
                  indexsToBeRemoved.Add(i);
                  indexsToBeRemoved.Add(j);
               }
            }
         }
         var remove = indexsToBeRemoved.ToArray();
         Array.Sort(remove);
         remove.Reverse();
         foreach (var index in remove)
         {
            figlist.RemoveAt(index);
         }
      }

      public void Add(Figure fig, MovePattern movement)
      {
         figlist.Add(new FigureMovementPair { fig = fig, movement = movement });
      }
   }
}
