using OpenLegendRPGLib;
using System;
using static OpenLegendRPGLib.DiceConstants;

namespace OpenLegendLib_TestApp
{
   class Program
   {
      static void Main( string[] args )
      {
         var baseDiceGroup = new DiceGroup( 1, d20 );
         var abilityDiceGroup = new DiceGroup( 1, d8 );

         var rolledDice = DiceRoller.ActionRoll( baseDiceGroup, abilityDiceGroup );

         foreach ( var die in rolledDice )
         {
            string explodeText = die.rolledDie.Sides == die.rolledValue ? " Explode!" : "";
            Console.WriteLine( "Rolled a d" + die.rolledDie.Sides + " Got " + die.rolledValue + explodeText );
         }
      }
   }
}
