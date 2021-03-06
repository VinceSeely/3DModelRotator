﻿using OpenTK;
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
            new RotateAndMoveFIgure(),
            new ScaleAndRotate(),
            new MovePattern4(),
            new MovePattern3()
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
         var numberShiny= 0f;
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
               numberShiny = numberShiny++ % 2;
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
   }
}
