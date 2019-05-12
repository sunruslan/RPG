using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Enums;
using RPG.GameBoard;
using RPG.Goods;
using RPG.Action;

namespace RPG.Units
{
    public abstract class Unit : IItem
    {
        public IArmy Army { get; set; }

        public int Health { get; set; }

        public int Weapons { get; set; }

        public int Hit { get; set; }

        public Direction direction { get; set; } = Direction.LEFT;

        public bool IsAlive
        {
            get { return Health > 0; }
        }
        
        public void SetNewStuff(IItem temp, IItem stuff, GameBoard.GameBoard gameBoard)
        {
            if (temp.X + 1 < gameBoard.Width && gameBoard.GameBoardItems[temp.Y][temp.X + 1] is Ground)
            {
                stuff.X = temp.X + 1;
                stuff.Y = temp.Y;
                gameBoard.GameBoardItems[temp.Y][temp.X + 1] = stuff;
                return;
            }
            if (temp.Y + 1 < gameBoard.Height && gameBoard.GameBoardItems[temp.Y + 1][temp.X] is Ground)
            {
                stuff.X = temp.X;
                stuff.Y = temp.Y + 1;
                gameBoard.GameBoardItems[temp.Y + 1][temp.X] = stuff;
                return;
            }
            if (temp.X - 1 >= 0 && gameBoard.GameBoardItems[temp.Y][temp.X - 1] is Ground)
            {
                stuff.X = temp.X - 1;
                stuff.Y = temp.Y;
                gameBoard.GameBoardItems[temp.Y][temp.X - 1] = stuff;
                return;
            }
            if (temp.Y - 1 >= 0 && gameBoard.GameBoardItems[temp.Y - 1][temp.X] is Ground)
            {
                stuff.X = temp.X;
                stuff.Y = temp.Y - 1;
                gameBoard.GameBoardItems[temp.Y - 1][temp.X] = stuff;
                return;
            }
        }

        // подбираем элемент
        public void PickUp(IItem temp, GameBoard.GameBoard gameBoard)
        {
            if (temp is Weapon)
            {
                Weapons += 1;
                temp = new Ground { X = temp.X, Y = temp.Y };
                var newWeapon = new Weapon { X = 0, Y = 0 };
                SetNewStuff(temp, newWeapon, gameBoard);
                return;
            }
            if (temp is Life)
            {
                Health += 10;
                temp = new Ground { X = temp.X, Y = temp.Y };
                var newLife = new Life { X = 0, Y = 0 };
                SetNewStuff(temp, newLife, gameBoard);
                return;
            }
        }

        
        public void Move(GameBoard.GameBoard gameBoard)
        {
            //ChangeDirection(this);
            switch (direction)
            {
                case Direction.LEFT:
                    if (X - 1 < 0) break;
                    var temp1 = gameBoard.GameBoardItems[Y][X - 1];
                    PickUp(temp1, gameBoard);

                    gameBoard.GameBoardItems[Y][X - 1] = this;
                    gameBoard.GameBoardItems[Y][X] = temp1;
                    X -= 1;
                    temp1.X += 1;
                    break;
                case Direction.UP:
                    if (Y - 1 < 0) break;
                    var temp2 = gameBoard.GameBoardItems[Y - 1][X];
                    PickUp(temp2, gameBoard);
                    gameBoard.GameBoardItems[Y - 1][X] = this;
                    gameBoard.GameBoardItems[Y][X] = temp2;
                    Y -= 1;
                    temp2.Y += 1;
                    break;
                case Direction.RIGHT:
                    if (X + 1 >= gameBoard.Width) break;
                    var temp3 = gameBoard.GameBoardItems[Y][X + 1];
                    PickUp(temp3, gameBoard);
                    gameBoard.GameBoardItems[Y][X + 1] = this;
                    gameBoard.GameBoardItems[Y][X] = temp3;
                    X += 1;
                    temp3.X -= 1;
                    break;
                case Direction.DOWN:
                    if (Y + 1 >= gameBoard.Height) break;
                    var temp4 = gameBoard.GameBoardItems[Y + 1][X];
                    PickUp(temp4, gameBoard);
                    gameBoard.GameBoardItems[Y + 1][X] = this;
                    gameBoard.GameBoardItems[Y][X] = temp4;
                    Y += 1;
                    temp4.Y -= 1;
                    break;
            }
        }

        public bool Attack(GameBoard.GameBoard gameBoard)
        {
            if (Weapons == 0) return false;
            if (X - 1 >= 0 && gameBoard.GameBoardItems[Y][X - 1] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y][X - 1]).Army != Army)
            {
                ((Unit)gameBoard.GameBoardItems[Y][X - 1]).Health -= Hit;
                return true;
            }
            if (Y - 1 >= 0 && gameBoard.GameBoardItems[Y - 1][X] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y - 1][X]).Army != Army)
            {
                ((Unit)gameBoard.GameBoardItems[Y - 1][X]).Health -= Hit;
                return true;
            }
            if (X + 1 < gameBoard.Width && gameBoard.GameBoardItems[Y][X + 1] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y][X + 1]).Army != Army)
            {
                ((Unit)gameBoard.GameBoardItems[Y][X + 1]).Health -= Hit;
                return true;
            }
            if (Y + 1 < gameBoard.Height && gameBoard.GameBoardItems[Y + 1][X] is Unit &&
                ((Unit)gameBoard.GameBoardItems[Y + 1][X]).Army != Army)
            {
                ((Unit)gameBoard.GameBoardItems[Y + 1][X]).Health -= Hit;
                return true;
            }
            return false;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public void ChangeDirection(IItem fighter)
        {
            Random rnd = new Random(fighter.GetHashCode());
            direction = (Direction)(rnd.Next(0, 4));
        }

        public IItem FindEnemy(IItem fighter, GameBoard.GameBoard gameBoard)
        {
            for (int i = -1; i <= 1; ++i)
            {
                for (int j = -1; j <= 1; ++j)
                {
                    if (i == 0 && j == 0)
                        continue;
                    if (fighter.Y + i < 0 || fighter.Y + i >= gameBoard.Height ||
                    fighter.X + j < 0 || fighter.X + j >= gameBoard.Width)
                        continue;

                    if (gameBoard.GameBoardItems[fighter.Y + i][fighter.X + j] is Unit &&
                     ((Unit)gameBoard.GameBoardItems[fighter.Y = i][fighter.X + j]).Army != Army)
                    {
                        return gameBoard.GameBoardItems[fighter.Y + i][fighter.X + j];
                    }
                }
                return null;
            }
        }

        public IItem FindUnit(Unit fighter, GameBoard.GameBoard gameBoard)
        {
            bool[ , ] visited = new bool[gameBoard.Height, gameBoard.Width];
            for (int i = 0; i < gameBoard.Height; ++i)
                for (int j = 0; j < gameBoard.Width; ++j)
                    visited[i, j] = false;
            visited[fighter.Y, fighter.X] = true;
            IItem item = null;
            while (!(item is Unit))
            {
                for (int i = -1; i <= 1; ++i)
                {
                    for (int j = -1; j <= 1; ++j)
                    {
                        if (i == 0 && j == 0)
                            continue;
                        if (fighter.Y + i < 0 || fighter.Y + i >= gameBoard.Height ||
                        fighter.X + j < 0 || fighter.X + j >= gameBoard.Width)
                            continue;

                        if (!visited[fighter.Y + i, fighter.X + j])
                        {
                            if (gameBoard.GameBoardItems[fighter.Y + i][fighter.X + j] is Unit &&
                            ((Unit)gameBoard.GameBoardItems[fighter.Y = i][fighter.X + j]).Army != Army)
                            {
                                return gameBoard.GameBoardItems[fighter.Y + i][fighter.X + j];
                            }
                        } 
                            gameBoard.GameBoardItems[fighter.Y + i][fighter.X + j] is Unit &&
                         ((Unit)gameBoard.GameBoardItems[fighter.Y = i][fighter.X + j]).Army != Army)
                        {
                            return gameBoard.GameBoardItems[fighter.Y + i][fighter.X + j];
                        } else
                        {

                        }
                    }
                    return null;
                }
            }
            return item;
        }

        public void Act(GameBoard.GameBoard gameBoard)
        {
            var context = new Context();
            var enemy = FindEnemy(this, gameBoard);
            if (enemy == null)
            {
                context.SetAction(new Move());
            } else
            {
                context.SetAction(new Attack());
            }
            context.DoAction(this, element, gameBoard);
            switch (direction)
            {
                case Direction.LEFT:
                    if (X - 1 < 0 || gameBoard.GameBoardItems[Y][X - 1] is Wall)
                    {
                        ChangeDirection(this);
                        break;
                    }
                    if (!Attack(gameBoard))
                    {
                        Move(gameBoard);
                    }
                    break;
                case Direction.UP:
                    if (Y - 1 < 0 || gameBoard.GameBoardItems[Y - 1][X] is Wall)
                    {
                        ChangeDirection(this);
                        break;
                    }
                    if (!Attack(gameBoard))
                    {
                        Move(gameBoard);
                    }
                    break;
                case Direction.RIGHT:
                    if (X + 1 >= gameBoard.Width || gameBoard.GameBoardItems[Y][X + 1] is Wall)
                    {
                        ChangeDirection(this);
                        break;
                    }
                    if (!Attack(gameBoard))
                    {
                        Move(gameBoard);
                    }
                    break;
                case Direction.DOWN:
                    if (Y + 1 >= gameBoard.Height || gameBoard.GameBoardItems[Y + 1][X] is Wall)
                    {
                        ChangeDirection(this);
                        break;
                    }
                    if (!Attack(gameBoard))
                    {
                        Move(gameBoard);
                    }
                    break;
            }
        }
    }
}
