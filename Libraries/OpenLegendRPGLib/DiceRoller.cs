﻿using System.Collections.Generic;

namespace OpenLegendRPGLib
{
   public class DiceRoller
   {
      public List<RolledDie> ActionRoll( DiceGroup baseDice, DiceGroup attributeDice, int advantageSum )
      {
         var rolledList = new List<RolledDie>();
         rolledList.AddRange( Roll( baseDice ) );
         rolledList.AddRange( Roll( attributeDice, advantageSum ) );
         ExplodeDice( ref rolledList );
         return rolledList;
      }

      public List<RolledDie> Roll( DiceGroup diceToRoll )
      {
         return Roll( diceToRoll, 0 );
      }

      public List<RolledDie> Roll( DiceGroup diceToRoll, int advantageSum )
      {
         var rolledList = new List<RolledDie>();

         return rolledList;
      }

      public List<RolledDie> Roll( List<Die> diceToRoll )
      {
         var rolledList = new List<RolledDie>();

         return rolledList;
      }
      }
   }
}
