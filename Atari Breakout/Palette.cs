using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace palette;

class Palette
{
    private Dictionary<string, Color> classic;
    private Dictionary<string, Color> sunset;
    private Dictionary<string, Color> neon;
    private Dictionary<string, Color> chromatic;
    public Dictionary<string, Color> palette { get; set; }
    public Palette()
    {
        //classic palette
        classic = new Dictionary<string, Color>(){{"row1", new Color(152, 51, 51)},
                                                  {"row2", new Color(204, 85, 51)},
                                                  {"row3", new Color(204, 136, 51)},
                                                  {"row4", new Color(204, 153, 51)},
                                                  {"row5", new Color(85, 153, 85)},
                                                  {"row6", new Color(51, 85, 136)},
                                                  {"paddle", new Color(51, 85, 136)},
                                                  {"ball", new Color(238, 238, 238)},
                                                  {"background", new Color(0, 0, 0)},
                                                  {"text", new Color(238, 238, 238)}};

        //sunset palette
        sunset = new Dictionary<string, Color>(){{"row1", new Color(255, 87, 51)},
                                                  {"row2", new Color(255, 195, 0)},
                                                  {"row3", new Color(218, 247, 166)},
                                                  {"row4", new Color(199, 0, 57)},
                                                  {"row5", new Color(144, 12, 63)},
                                                  {"row6", new Color(88, 24, 69)},
                                                  {"paddle", new Color(255, 195, 0)},
                                                  {"ball", new Color(255, 255, 255)},
                                                  {"background", new Color(0, 0, 0)},
                                                  {"text", new Color(255, 255, 255)}};

        //neon palette
        neon = new Dictionary<string, Color>(){{"row1", new Color(255, 0, 255)},
                                                  {"row2", new Color(0, 255, 255)},
                                                  {"row3", new Color(0, 255, 0)},
                                                  {"row4", new Color(255, 255, 0)},
                                                  {"row5", new Color(255, 69, 0)},
                                                  {"row6", new Color(255, 20, 147)},
                                                  {"paddle", new Color(0, 255, 255)},
                                                  {"ball", new Color(255, 255, 255)},
                                                  {"background", new Color(0, 0, 0)},
                                                  {"text", new Color(255, 255, 255)}};

        //chromatic palette
        chromatic = new Dictionary<string, Color>(){{"row1", new Color(224, 224, 224)},
                                                  {"row2", new Color(192, 192, 192)},
                                                  {"row3", new Color(150, 160, 160)},
                                                  {"row4", new Color(128, 128, 128)},
                                                  {"row5", new Color(96, 96, 96)},
                                                  {"row6", new Color(64, 64, 64)},
                                                  {"paddle", new Color(128, 128, 128)},
                                                  {"ball", new Color(255, 255, 255)},
                                                  {"background", new Color(0, 0, 0)},
                                                  {"text", new Color(255, 255, 255)}};
    }

    public void SetPalette(string choice)
    {
        switch (choice)
        {
            case "sunset":
                palette = sunset;
                break;
            case "neon":
                palette = neon;
                break;
            case "chromatic":
                palette = chromatic;
                break;
            default:
                palette = classic;
                break;
        }
    }
}