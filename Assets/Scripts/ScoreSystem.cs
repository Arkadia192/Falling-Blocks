using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreSystem {

    static float score;

    public static float ppBlockMultiplier = 1;
    public static float ppCookieMultiplier = 10;

    public static void AddScore (int amount)
    {
        score += amount;
    }

    public static void AddScore (float amount)
    {
        score += amount;
    }

    public static float GetScore ()
    {
        return score;
    }

    public static void Reset()
    {
        score = 0f;
    }
}
