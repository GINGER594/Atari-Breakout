using System;
using Microsoft.Xna.Framework;

namespace breakoutpaddle;

class Paddle
{
    private const int paddleSpeed = 500;
    private Vector2 paddlePos;
    public Rectangle paddle { get; set; }
    public Paddle(int screenWidth, int screenHeight)
    {
        var paddleWidth = 100;
        var paddleHeight = 20;
        paddlePos = new Vector2(screenWidth / 2 - paddleWidth / 2, screenHeight - paddleHeight);
        paddle = new Rectangle(Convert.ToInt32(paddlePos.X), Convert.ToInt32(paddlePos.Y), paddleWidth, paddleHeight);
    }

    public void Move(char direction, int screenWidth, float deltaTime)
    {
        //left paddle movement
        if (direction == 'l' && paddlePos.X - paddleSpeed * deltaTime >= 0)
        {
            paddlePos.X -= paddleSpeed * deltaTime;
        }

        //right paddle movement
        if (direction == 'r' &&  paddlePos.X + paddle.Width + paddleSpeed * deltaTime <= screenWidth)
        {
            paddlePos.X += paddleSpeed * deltaTime;
        }

        //updating the paddle
        paddle = new Rectangle(Convert.ToInt32(paddlePos.X), Convert.ToInt32(paddlePos.Y), paddle.Width, paddle.Height);
    }
}