public enum NodeType
{
    Collectable,
    PowerUp,
    Wall,
    Empty
}

public class LevelGeneration
{
    public static NodeType[,] Generate(int sizeX, int sizeY)
    {
        NodeType[,] level = new NodeType[sizeX, sizeY];

        // fill with walls
        for (int curX=0; curX<sizeX; ++curX)
        {
            for (int curY=0; curY<sizeY; ++curY)
            {
                level[curX,curY] = NodeType.Wall;
            }
        }

        // place PowerUp every 10 placed collectables
        int numPlaced = 0;
        for (int curY=1; curY <sizeY-1; curY+=2)
        {
            for (int curX=1; curX<sizeX-1; ++curX)
            {
                ++numPlaced;
                if (numPlaced % 10 == 0)
                {
                    level[curX, curY] = NodeType.PowerUp;
                }
                else
                {
                    level[curX, curY] = NodeType.Collectable;
                }
            }
        }
        for (int curX = 1; curX < sizeX - 1; curX += 2)
        {
            for (int curY = 1; curY < sizeY - 1; ++curY)
            {
                if (level[curX,curY] != NodeType.Wall)
                {
                    continue;
                }
                ++numPlaced;
                if (numPlaced % 10 == 0)
                {
                    level[curX, curY] = NodeType.PowerUp;
                }
                else
                {
                    level[curX, curY] = NodeType.Collectable;
                }
            }
        }

        // place monster box at the center

        NodeType[,] monsterBox = new NodeType[4,5] { {NodeType.Wall, NodeType.Wall, NodeType.Empty, NodeType.Wall, NodeType.Wall},
                                                   {NodeType.Wall, NodeType.Empty, NodeType.Empty, NodeType.Empty, NodeType.Wall},
                                                   {NodeType.Wall, NodeType.Empty, NodeType.Empty, NodeType.Empty, NodeType.Wall},
                                                   {NodeType.Wall, NodeType.Wall, NodeType.Wall, NodeType.Wall, NodeType.Wall}};

        int startBoxX = (sizeX - 5) / 2;
        int startBoxY = (sizeY - 4) / 2;
        for (int curX=0; curX<5; ++curX)
        {
            for (int curY=0; curY<4; ++curY)
            {
                level[curX+startBoxX, curY+startBoxY] = monsterBox[curY, curX];
            }
        }

        return level;
    }
}
