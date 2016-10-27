namespace OpenLegendRPGLib
{
   public class DiceGroup
   {
      public DiceGroup( int amount, Die die )
      {
         AmountOfDice = amount;
         dieType = die;
      }
      public int AmountOfDice;
      public Die dieType;
   }
}
