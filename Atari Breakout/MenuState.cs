using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using palette;

namespace menustate;

class MenuState
{
    private int screenWidth;
    private int screenHeight;
    public MenuState(int sw, int sh)
    {
        screenWidth = sw;
        screenHeight = sh;
    }

    public string Update(string gamestate, Palette colourPalette)
    {
        //getting player inputs
        //space - classic theme
        //s - sunset theme
        //n - neon theme
        //c - chromatic theme
        var keystate = Keyboard.GetState();
        if (keystate.IsKeyDown(Keys.Space))
        {
            colourPalette.SetPalette("");
            gamestate = "game";
        }
        else if (keystate.IsKeyDown(Keys.S))
        {
            colourPalette.SetPalette("sunset");
            gamestate = "game";
        }
        else if (keystate.IsKeyDown(Keys.N))
        {
            colourPalette.SetPalette("neon");
            gamestate = "game";
        }
        else if (keystate.IsKeyDown(Keys.C))
        {
            colourPalette.SetPalette("chromatic");
            gamestate = "game";
        }
        return gamestate;
    }

    public void DrawMainMenu(SpriteBatch _spriteBatch, SpriteFont font)
    {
        //displaying menu text
        var text = "PRESS SPACE";
        var textWidth = font.MeasureString(text).X;
        var textHeight = font.MeasureString(text).Y;
        _spriteBatch.DrawString(font, text, new Vector2(screenWidth / 2 - textWidth / 2, screenHeight / 2 - textHeight / 2), Color.White);
    }

    public void DrawLoseMenu(SpriteBatch _spriteBatch, SpriteFont font, SpriteFont smallFont, int score)
    {
        //displaying score
        _spriteBatch.DrawString(smallFont, $"SCORE: {score}", new Vector2(0, 0), Color.White);
        
        //displaying lose menu text
        var text = "GAME OVER";
        var textWidth = font.MeasureString(text).X;
        var textHeight = font.MeasureString(text).Y;
        _spriteBatch.DrawString(font, text, new Vector2(screenWidth / 2 - textWidth / 2, screenHeight / 2 - textHeight / 2), Color.Red);
        var text2 = "PRESS SPACE";
        var text2Width = font.MeasureString(text2).X;
        _spriteBatch.DrawString(font, text2, new Vector2(screenWidth / 2 - text2Width / 2, screenHeight / 2 + textHeight / 2), Color.Red);
    }
}