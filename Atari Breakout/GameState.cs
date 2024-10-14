using System.Collections.Generic;
using breakoutpaddle;
using breakoutball;
using breakoutblocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gamestate;

class GameState
{
    private int screenWidth;
    private int screenHeight;
    private Paddle player;
    private const int defaultLives = 3;
    private int lives = defaultLives;
    private const int defaultBallSpeed = 300;
    private int ballSpeed = defaultBallSpeed;
    private Ball gameBall;
    private Blocks gameBlocks;
    public int score { get; set; }
    public GameState(int sw, int sh)
    {
        screenWidth = sw;
        screenHeight = sh;
        player = new Paddle(screenWidth, screenHeight);
        gameBall = new Ball(screenWidth, screenHeight, ballSpeed);
        gameBlocks = new Blocks(screenWidth);
        score = 0;
    }

    public void Reset()
    {
        //resetting ball speed and score and refreshing
        lives = defaultLives;
        ballSpeed = defaultBallSpeed;
        score = 0;
        Refresh();
    }

    public void Refresh()
    {
        //setting player and ball positions to default and generating blocks
        player = new Paddle(screenWidth, screenHeight);
        gameBall = new Ball(screenWidth, screenHeight, ballSpeed);
        gameBlocks = new Blocks(screenWidth);
    }

    public string Update(string gamestate, float deltaTime)
    {
        //player inputs
        var keystate = Keyboard.GetState();
        if (keystate.IsKeyDown(Keys.Left))
        {
            player.Move('l', screenWidth, deltaTime);
        }
        if (keystate.IsKeyDown(Keys.Right))
        {
            player.Move('r', screenWidth, deltaTime);
        }

        //moving the ball
        gameBall.Move(screenWidth, deltaTime);

        //checking if the ball has gone below the screen
        if (gameBall.ball.Y - 10 >= screenHeight)
        {
            gamestate = "pause";
            lives -= 1;
            player = new Paddle(screenWidth, screenHeight);
            gameBall = new Ball(screenWidth, screenHeight, ballSpeed);
            if (lives == 0)
            {
                gamestate = "lose";
            }
        }

        //checking if the ball collides with the paddle
        if (gameBall.ball.Intersects(player.paddle))
        {
            gameBall.ReflectPaddle(player.paddle);
        }

        //checking if there are any blocks left, if not: refresh game (add 1 to ball speed and reset paddle, ball and blocks)
        if (gameBlocks.blockList.Count > 0)
        {
            //checking if the ball collides with a block
            foreach (Rectangle block in gameBlocks.blockList)
            {
                if (gameBall.ball.Intersects(block))
                {
                    gameBall.ReflectVertical();
                    gameBlocks.blockList.Remove(block);
                    score += 1;
                    break;
                }
            }
        }
        else
        {
            gamestate = "pause";
            ballSpeed += 50;
            Refresh();
        }

        return gamestate;
    }

    public void Draw(SpriteBatch _spriteBatch, Dictionary<string, Color> palette, SpriteFont smallFont, Texture2D blankTexture, Texture2D heartSprite)
    {
        //displaying score
        _spriteBatch.DrawString(smallFont, $"SCORE: {score}", new Vector2(0, 0), palette["text"]);

        //displaying hearts
        for (int i = 0; i < lives + 1; i++)
        {
            Rectangle drawLocation = new Rectangle(screenWidth - i * 20, 0, 20, 20);
            _spriteBatch.Draw(heartSprite, drawLocation, Color.White);
        }

        //drawing blocks
        foreach (Rectangle block in gameBlocks.blockList)
        {
            Color colour = palette[$"row{block.Y / block.Height}"];
            _spriteBatch.Draw(blankTexture, new Vector2(block.X, block.Y), block, colour, 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
        }

        //drawing ball
        _spriteBatch.Draw(blankTexture, new Vector2(gameBall.ball.X, gameBall.ball.Y), gameBall.ball, palette["ball"], 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);

        //drawing player
        _spriteBatch.Draw(blankTexture, new Vector2(player.paddle.X, player.paddle.Y), player.paddle, palette["paddle"], 0, new Vector2(0, 0), 1, SpriteEffects.None, 0);
    }
}