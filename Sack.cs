using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    public class Sack : ICreature
    {

        private int lastMoveValue = 0;
        private int fallTimeCounter = 0;

        private int CalculateMoveValue(int x, int y, int lastMoveValue)
        {
            if(y + 1 < Game.MapHeight && Game.Map[x, y + 1] is null)
            {
                fallTimeCounter += 1;
                return 1;
            }
            else if (y + 1 < Game.MapHeight && Game.Map[x, y + 1] is Player && lastMoveValue == 1)
            {
                fallTimeCounter += 1;
                return 1;
            }
            else
            {   
                return 0;
            }
        }

        private ICreature GetNewForm(int moveValue)
        {
            if(fallTimeCounter >= 2 && moveValue == 0)
            {
                return new Gold();
            }
            else if(moveValue == 0)
            {
                fallTimeCounter = 0;
                return null;
            }
            else
            {
                return null;
            }
        }

        public CreatureCommand Act(int x, int y)
        {
            int moveValue = CalculateMoveValue(x, y, lastMoveValue);
            lastMoveValue = moveValue;
            
            ICreature newForm = GetNewForm(moveValue);

            return new CreatureCommand
            {
                DeltaX = 0,
                DeltaY = moveValue,
                TransformTo = newForm
            };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Sack.png";
        }
    }
}
