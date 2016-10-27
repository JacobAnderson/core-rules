using OpenLegendRPGLib;
using System;

namespace OpenLegendLib_TestApp
{
   class Program
   {
      static void Main( string[] args )
      {
         var d20 = new Die(20);
         var d8 = new Die(8);

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
