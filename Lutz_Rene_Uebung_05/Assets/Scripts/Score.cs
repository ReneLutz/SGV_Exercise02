public static class Score
{
    private static int _score = 0;

    public static void AddScore(int value)
    {
        _score += value;
    }

    public static void LowerScore(int value)
    {
        _score -= value;
    }

    public static int GetScore()
    {
        return _score;
    }

    public static void Reset()
    {
        _score = 0;
    }
}
