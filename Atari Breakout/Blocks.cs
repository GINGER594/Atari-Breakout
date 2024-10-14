using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace breakoutblocks;

class Blocks
{
    private const int blockWidth = 40;
    private const int blockHeight = 20;
    public List<Rectangle> blockList { get; set; }
    public Blocks(int screenWidth)
    {
        //adding blocks to the blocklist
        blockList = new List<Rectangle>();
        for (int i = 1; i < 7; i++)
        {
            for (int j = 0; j < screenWidth / blockWidth; j++)
            {
                blockList.Add(new Rectangle(j * blockWidth, i * blockHeight, blockWidth, blockHeight));
            }
        }
    }
}