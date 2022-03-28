using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtensions
{
    public static float SignedValueTo1(this float testedFloat)
    {
        if (testedFloat < 0)
            testedFloat = -1;
        else if (testedFloat > 0)
            testedFloat = 1;

        return testedFloat;
    }

    public static bool IsInRange(this float testedFloat, float min, float max)
    {
        if (min > max)
        {
            float tmp = min;
            min = max;
            max = tmp;
        }
        if (testedFloat >= min && testedFloat <= max)
            return true;
        return false;
    }

    public static float GetFloatInRange(this float testedFloat, float min, float max)
    {
        if (min > max)
        {
            float tmp = min;
            min = max;
            max = tmp;
        }
        if (testedFloat < min)
            return min;
        if (testedFloat > max)
            return max;
        return testedFloat;
    }
}