namespace pausetstate;

class PausetState
{
    private float time;
    public PausetState(float t)
    {
        time = t;
    }

    public string Update(float deltaTime)
    {
        time -= deltaTime;
        if (time <= 0)
        {
            return "game";
        }
        return "pause";
    }
}