using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Enums;
using RPG.GameBoard;
using RPG.Goods;
using RPG.Units.States;

namespace RPG.Units
{
    public abstract class Unit : IItem
    {
        public State State { get; set; }

        public IArmy Army { get; set; }

        public int Health
        {
            get; set;
        }

        public int Weapons { get; set; }

        public bool IsAlive
        {
            get { return Health > 0; }
        }

        public void Move(GameBoard.GameBoard gameBoard, Direction direction)
        {
            //TODO: попоробовать подобрать элемент 
            switch (direction)
            {
                case Direction.LEFT:
                    if (X-1 < 0) break;
                    var temp1 = gameBoard.GameBoardItems[Y][X - 1];
                    gameBoard.GameBoardItems[Y][X - 1] = this;
                    gameBoard.GameBoardItems[Y][X] = temp1;
                    X -= 1;
                    temp1.X += 1;
                    break;
                case Direction.UP:
                    if (Y - 1 < 0) break;
                    var temp2 = gameBoard.GameBoardItems[Y-1][X];
                    gameBoard.GameBoardItems[Y-1][X] = this;
                    gameBoard.GameBoardItems[Y][X] = temp2;
                    Y -= 1;
                    temp2.Y += 1;
                    break;
                case Direction.RIGHT:
                    if (X + 1 >= gameBoard.Width) break;
                    var temp3 = gameBoard.GameBoardItems[Y][X + 1];
                    gameBoard.GameBoardItems[Y][X + 1] = this;
                    gameBoard.GameBoardItems[Y][X] = temp3;
                    X += 1;
                    temp3.X -= 1;
                    break;
                case Direction.DOWN:
                    if (Y + 1 >= gameBoard.Height) break;
                    var temp4 = gameBoard.GameBoardItems[Y + 1][X];
                    gameBoard.GameBoardItems[Y + 1][X] = this;
                    gameBoard.GameBoardItems[Y][X] = temp4;
                    Y += 1;
                    temp4.Y -= 1;
                    break;
            }
        }

        public abstract void Attack(GameBoard.GameBoard gameBoard);

        public int X { get; set; }

        public int Y { get; set; }
        //Todo: выбрать экшн    
    }
}
