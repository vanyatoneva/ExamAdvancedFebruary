namespace BlindManBuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimmension = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[][] playground = new char[dimmension[0]][];
            int touchedOpponents = 0;
            int movesMade = 0;
            int playerPositionRow = 0;
            int playerPositionCol = 0;
            for(int i = 0; i < playground.GetLength(0); i++)
            {
                char[] currentRowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                char[] currentRow = new char[dimmension[1]];
                for(int j = 0; j < dimmension[1]; j++)
                {
                    currentRow[j] = currentRowInput[j];
                }
                playground[i] = currentRow;
            }

            for (int i = 0; i < playground.GetLength(0); i++) 
            {
                bool isFound = false;
                for(int j = 0; j < playground[i].Length; j++)
                {
                    if (playground[i][j] == 'B')
                    {
                        playground[i][j] = '-';
                        playerPositionRow = i;
                        playerPositionCol = j;
                        isFound = true;
                        break;
                    }
                }
                if (isFound) break;
            }

            string command = Console.ReadLine();
            while(command != "Finish")
            {
                int[] moveResult = Play(command, playground, movesMade, touchedOpponents, playerPositionRow, playerPositionCol);
                if(moveResult != null && touchedOpponents < 3)
                {
                    playerPositionRow = moveResult[0];
                    playerPositionCol = moveResult[1];
                    movesMade = moveResult[2];
                    touchedOpponents = moveResult[3];
                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");
        }


        public static int[] Play(string move, char[][] playground, int movesMade, int touchedOpponents, int playerPositionRow, int playerPositionCol)
        {

            int newRow = playerPositionRow;
            int newCol = playerPositionCol; 
            switch (move) 
            {
                case "up":
                    newRow--;
                    break;
                case "down":
                    newRow++;
                    break;
                case "right":
                    newCol++;
                    break;
                case "left":
                    newCol--;
                    break;

            }
            if(newRow < 0 ||newRow >= playground.GetLength(0) ||
                newCol < 0 || newCol >= playground[playerPositionRow].Length)
            {
                return null;
            }
            if (playground[newRow][newCol] == 'O')
            {
                return null;
            }

            playerPositionRow = newRow;
            playerPositionCol = newCol;
            movesMade++;
            if (playground[playerPositionRow][playerPositionCol] == 'P')
            {
                touchedOpponents++;
                playground[playerPositionRow][playerPositionCol] = '-';
            }
            return new int[] { playerPositionRow, playerPositionCol, movesMade, touchedOpponents };
        }

    }

    
}

