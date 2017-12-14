using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienSpaceShooter.MovePatterns;

namespace AlienSpaceShooter
{
   class FigureList
   {
      public List<MovePattern> movePattern;
      public int moveIndex;

      private struct FigureMovementPair
      {
         public Figure fig;
         public MovePattern movement;
      }

      private List<FigureMovementPair> figlist = new List<FigureMovementPair>();      

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
         for( int i = figlist.Count - 1; i > 0; i--)
         {
            for( int j = 0; j < i; j++ )
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
         foreach (var index in indexsToBeRemoved)
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
