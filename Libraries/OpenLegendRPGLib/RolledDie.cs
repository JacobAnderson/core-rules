namespace OpenLegendRPGLib
{
   public class RolledDie
   {
      public RolledDie( Die dieToRoll )
      {
         rolledDie = dieToRoll;
         rolledValue = DiceRoller.Roll( rolledDie );
      }
      public Die rolledDie;
      public int rolledValue;
   }
}
