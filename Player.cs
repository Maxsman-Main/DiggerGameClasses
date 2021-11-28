using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digger
{
    public class Player : ICreature
    {
        private int CalculatPositiveMoveValue(int cooridinatePosition, int x, int y, int bound)
        {
            if (cooridinatePosition + 1 < bound)
            {
                if(Game.Map[x, y] is Sack)
                {
                    return 0;
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private int CalculatNegativeMoveValue(int cooridinatePosition, int x, int y)
        {
            if (cooridinatePosition - 1 >= 0)
            {
                if (Game.Map[x, y] is Sack)
                {
                    return 0;
                }
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public CreatureCommand Act(int x, int y)
        {
            int deltaX = 0;
            int deltaY = 0;

            if (Game.KeyPressed == System.Windows.Forms.Keys.Left)
            {
                deltaX = CalculatNegativeMoveValue(x, x - 1, y);
            }
            if (Game.KeyPressed == System.Windows.Forms.Keys.Right)
            {
                deltaX = CalculatPositiveMoveValue(x, x + 1, y, Game.MapWidth);
            }
            if (Game.KeyPressed == System.Windows.Forms.Keys.Up)
            {
                deltaY = CalculatNegativeMoveValue(y, x, y - 1);
            }
            if (Game.KeyPressed == System.Windows.Forms.Keys.Down)
            {
                deltaY = CalculatPositiveMoveValue(y, x, y + 1, Game.MapHeight);
            }

            return new CreatureCommand
            {
                DeltaX = deltaX,
                DeltaY = deltaY,
                TransformTo = null
            };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if(conflictedObject is Sack)
            {
                return true;
            }
            return false;
        }

        public int GetDrawingPriority()
        {
            return -3;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }
    }
}
