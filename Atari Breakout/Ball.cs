using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace breakoutball;

class Ball
{
    private const int ballSize = 10;
    private Vector2 ballSpeed;
    private int ballAngle = 0;
    public Rectangle ball { get; set; }
    public Ball(int screenWidth, int screenHeight, int speed)
    {
        ball = new Rectangle(screenWidth / 2 - ballSize / 2, screenHeight / 2 - ballSize / 2, ballSize, ballSize);
        ballSpeed = new Vector2(0, speed);
    }

    public void Move(int screenWidth, float deltaTime)
    {
        //creating a variable for where the ball will be when its moved
        Matrix ballRotation = Matrix.CreateRotationZ(MathHelper.ToRadians(ballAngle));
        Vector2 movedBallPos = new Vector2(ball.X, ball.Y) + Vector2.Transform(new Vector2(ballSpeed.X, ballSpeed.Y * deltaTime), ballRotation);
        Rectangle movedBall = new Rectangle(Convert.ToInt32(movedBallPos.X), Convert.ToInt32(movedBallPos.Y), ballSize, ballSize);

        //checking if the ball hits the sides
        if (movedBall.X <= 0)
        {
            ReflectHorizontal();
            movedBall.X = 0;
        }
        if (movedBall.X >= screenWidth - ballSize)
        {
            ReflectHorizontal();
            movedBall.X = screenWidth - ballSize;
        }

        //checking if the ball hits the ceiling
        if (movedBall.Y <= 0)
        {
            ReflectVertical();
        }

        //updating the ball
        ball = movedBall;
    }

    public void ReflectHorizontal()
    {
        //reflecting the ball horizontally
        ballAngle *= -1;
    }

    public void ReflectVertical()
    {
        //reflecting the ball vertically
        ballAngle = 180 - ballAngle;
    }

    public void ReflectPaddle(Rectangle paddle)
    {
        //reflecting the ball based on how close to the centre of the paddle it is
        var paddleCentre = paddle.X + (paddle.Width / 2);
        var ballCentre = ball.X + (ballSize / 2);
        var distance = paddleCentre - ballCentre;
        ballAngle = Convert.ToInt32(180 - (distance / 0.9));
    }
}