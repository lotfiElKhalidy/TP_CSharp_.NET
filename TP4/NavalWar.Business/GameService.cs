using NavalWar.DTO;

namespace NavalWar.Business
{
    public class GameService
    {
        public GamingMapDto CreateGamingMap(int Width, int Height)
        {
            GamingMapDto map = new GamingMapDto();

            map.MapID = 1;
            map.Width = Width;
            map.Height = Height;

            map.ShipPositionsMap = new int[map.Width][];
            map.WarMap = new int[map.Width][];

            for (int i = 0; i < map.Width; i++)
            {
                map.ShipPositionsMap[i] = new int[map.Height];
                map.WarMap[i] = new int[map.Height];
            }

            map.ShipPositionsMap[1][3] = 1;
            map.ShipPositionsMap[3][5] = 1;
            map.ShipPositionsMap[2][6] = 1;
            map.ShipPositionsMap[5][3] = 1;
            map.ShipPositionsMap[1][0] = 1;
            map.ShipPositionsMap[1][2] = 1;

            for (int i = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Height; j++)
                {
                    map.WarMap[i][j] = 0;
                }
            }

            return map;
        }

        public bool AddShipToGamingMap(string infos)
        {
            bool status = true;
            string message = "Ship added successfully !";

            // Recover and parse the user's data
            string[] values = infos.Split(' ');
            int[] convertedValues = Array.ConvertAll<string, int>(values, int.Parse);

            int ShipLength = convertedValues[0];
            int ShipDirection = convertedValues[1];
            int StartingPointX = convertedValues[2];
            int StartingPointY = convertedValues[3];

            // Check the possibility of adding the ship
            if (StartingPointX > this.Width - 1 || StartingPointY > this.Height - 1 ||
                StartingPointX + ShipLength > this.Width - 1 || StartingPointY + ShipLength > this.Height - 1)
            {
                status = false;
                message = "ERROR: Cannot add this ship. You're outside the map";
            }
            else
            {
                if (ShipDirection == 0)  // <-->
                {
                    int i = 0;

                    // Check that another ship doesn't already exist in this position
                    while (i < ShipLength && this.ShipPositionsMap[StartingPointX + i][StartingPointY] == 0)
                    {
                        i++;
                        if (this.ShipPositionsMap[StartingPointX + i][StartingPointY] == 0)
                        {
                            status = false;
                            message = "ERROR: Cannot add this ship. Another one already exists in this position";
                        }
                    }

                    // At this point, everything should be working. We just have to change our map
                    if (status)
                    {
                        for (int j = 0; j < ShipLength; j++)
                        {
                            this.ShipPositionsMap[StartingPointX + j][StartingPointY] = 1;
                        }
                    }
                }
                else if (ShipDirection == 1) // <-->T
                {
                    int i = 0;

                    // Check that another ship doesn't already exist in this position
                    while (i < ShipLength && this.ShipPositionsMap[StartingPointX][StartingPointY + i] == 0)
                    {
                        i++;
                        if (this.ShipPositionsMap[StartingPointX][StartingPointY + i] == 1)
                        {
                            status = false;
                            message = "ERROR: Cannot add this ship. Another one already exists in this position";
                        }
                    }

                    // At this point, everything should be working. We just have to change our map
                    if (status)
                    {
                        for (int j = 0; j < ShipLength; j++)
                        {
                            this.ShipPositionsMap[StartingPointX][StartingPointY + j] = 1;
                        }
                    }
                }
                else
                {
                    status = false;
                    message = "ERROR: Cannot add this ship. This direction doesn't exist.";
                }
            }

            Console.WriteLine(message);

            return status;
        }

        public bool DeleteShipFromGamingMap(string infos)
        {
            bool status = true;
            string message = "Ship deleted successfully !";

            // Recover and parse the user's data
            string[] values = infos.Split(' ');
            int[] convertedValues = Array.ConvertAll<string, int>(values, int.Parse);

            int ShipLength = convertedValues[0];
            int ShipDirection = convertedValues[1];
            int StartingPointX = convertedValues[2];
            int StartingPointY = convertedValues[3];

            // Check the possibility of deleting the ship
            if (StartingPointX > this.Width - 1 || StartingPointY > this.Height - 1 ||
                StartingPointX + ShipLength > this.Width - 1 || StartingPointY + ShipLength > this.Height - 1)
            {
                status = false;
                message = "ERROR: Cannot delete this ship. You're outside the map";
            }
            else
            {
                if (ShipDirection == 0)  // <-->
                {
                    int i = 0;

                    // Check that a ship exists in the position given
                    while (i < ShipLength && this.ShipPositionsMap[StartingPointX + i][StartingPointY] == 1)
                    {
                        i++;
                        if (this.ShipPositionsMap[StartingPointX + i][StartingPointY] == 0)
                        {
                            status = false;
                            message = "ERROR: Cannot delete this ship. The infos given are wrong";
                        }
                    }

                    // At this point, everything should be working. We just have to change our map
                    if (status)
                    {
                        for (int j = 0; j < ShipLength; j++)
                        {
                            this.ShipPositionsMap[StartingPointX + j][StartingPointY] = 0;
                        }
                    }
                }
                else if (ShipDirection == 1) // <-->T
                {
                    int i = 0;

                    // Check that a ship exists in the position given
                    while (i < ShipLength && this.ShipPositionsMap[StartingPointX][StartingPointY + i] == 1)
                    {
                        i++;
                        if (this.ShipPositionsMap[StartingPointX][StartingPointY + i] == 0)
                        {
                            status = false;
                            message = "ERROR: Cannot delete this ship. The infos given are wrong";
                        }
                    }

                    // At this point, everything should be working. We just have to change our map
                    if (status)
                    {
                        for (int j = 0; j < ShipLength; j++)
                        {
                            this.ShipPositionsMap[StartingPointX][StartingPointY + j] = 0;
                        }
                    }
                }
                else
                {
                    status = false;
                    message = "ERROR: Cannot delete this ship. This direction doesn't exist.";
                }
            }

            Console.WriteLine(message);

            return status;
        }

        public bool ReplaceShipInGamingMap(string infos)
        {
            // ShipLength Horiz/Vert ActualStartPosX ActualStratPosY NewShipLength NewHoriz/Vert NewStartPosX NewStartPosY
            bool status = true;
            string message = "Ship replaced successfully !";

            // Recover and parse the user's data
            string[] values = infos.Split(' ');
            string[] actualValues = new string[4], newValues = new string[4];

            for (int i = 0; i < 4; i++)
            {
                actualValues[i] = values[i];
                newValues[i] = values[i + 4];

            }

            string actualShipInfos = String.Join(" ", actualValues);
            string newShipInfos = String.Join(" ", newValues);

            bool addStatus = this.AddShipToGamingMap(newShipInfos);
            bool deleteStatus = this.DeleteShipFromGamingMap(actualShipInfos);

            if (!addStatus || !deleteStatus)
            {
                status = false;
                message = "ERROR: Cannot replace this ship. Soething went wrong !";
            }

            Console.WriteLine(message);

            return status;
        }


        /*public void AttackPlayer(int position)
        {
            this.WarMap[position] = 1;

            if (this.ShipPositionsMap[position] == 1)
            {
                this.ShipPositionsMap[position] = 0;
            }
            else
            {
                this.ShipPositionsMap[position] = -1;
            }
        }*/
    }
}
