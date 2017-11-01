namespace Prog2
{
   public class RotateAndMoveFIgure : MovePattern
   {
      public override void Move(Figure fig)
      {
         fig.Translate(0, 0, 0);
         fig.Rotate(0, 0, 0);
         fig.Translate(0, 0, 0);
         throw new System.NotImplementedException();
      }
   }
}