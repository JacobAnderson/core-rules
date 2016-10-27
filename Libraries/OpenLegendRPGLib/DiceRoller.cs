using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenLegendRPGLib
{
   public static class DiceRoller
   {
      static Random _random = new Random();

      public static List<RolledDie> ActionRoll( DiceGroup baseDice, DiceGroup attributeDice, int advantageValue, int disadvantageValue )
      {
         return ActionRoll( baseDice, attributeDice, advantageValue - disadvantageValue );
      }

      public static List<RolledDie> ActionRoll( DiceGroup baseDice, DiceGroup attributeDice )
      {
         return ActionRoll( baseDice, attributeDice, 0 );
      }

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
         int baseDiceToRoll = diceToRoll.AmountOfDice;
         int advDiceToRoll = Math.Abs(advantageSum);
         int TotalDiceToRoll = baseDiceToRoll + advDiceToRoll;
         for ( int x = 0; x < TotalDiceToRoll; x++ )
         {
            rolledList.Add( new RolledDie( diceToRoll.dieType ) );
         }

         rolledList = rolledList.OrderByDescending( x => x.rolledValue ).ToList();
         if ( advantageSum > 0 )
         {
            rolledList.Take( baseDiceToRoll );
         }
         else if ( advantageSum < 0 )
         {
            rolledList.Skip( advDiceToRoll );
         }
         return rolledList;
      }

      public static int Roll( Die dieToRoll )
      {
         return _random.Next( dieToRoll.Sides ) + 1; //1 to sides inclusive
      }

      public static List<RolledDie> Roll( List<Die> diceToRoll )
      {
         var rolledList = new List<RolledDie>();
         foreach ( var singleDie in diceToRoll )
         {
            rolledList.Add( new RolledDie( singleDie ) );
         }
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
