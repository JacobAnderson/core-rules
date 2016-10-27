using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLegendRPGLib
{
   public static class DiceRoller
   {
      public static List<RolledDie> ActionRoll( DiceGroup baseDice, DiceGroup attributeDice, int advantageSum )
      {
         var rolledList = new List<RolledDie>();
         rolledList.AddRange( Roll( baseDice ) );
         rolledList.AddRange( Roll( attributeDice, advantageSum ) );
         ExplodeDice( ref rolledList );
         return rolledList;
      }

      public static List<RolledDie> Roll( DiceGroup diceToRoll )
      {
         return Roll( diceToRoll, 0 );
      }

      public static List<RolledDie> Roll( DiceGroup diceToRoll, int advantageSum )
      {
         var rolledList = new List<RolledDie>();

         return rolledList;
      }

      public static int Roll( Die dieToRoll )
      {
         var rolledList = new List<RolledDie>();

         return rolledList;
      }

      public static void ExplodeDice( ref List<RolledDie> currentPool )
      {
         var newDice = new List<Die>();
         newDice = currentPool.Where( x => x.rolledValue == x.rolledDie.Sides ).Select( rolled => rolled.rolledDie ).ToList();

         if ( newDice.Count > 0 )
         {
            var newRolledDice = Roll( newDice );
            ExplodeDice( ref newRolledDice );
            currentPool.AddRange( newRolledDice );
         }

      }
   }
}
