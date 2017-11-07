namespace Prog2
{
   public class RotateAndMoveFIgure : MovePattern
   {
      public override void Move(Figure fig)
      {
         fig.Translate(1f, 0, 0);
         fig.Rotate(1f, 0, 0);
      }
   }
}