using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntExtensions
{
    public static int RandomSign(this int toRandomize)
    {
        if (Random.Range(0, 2) > 0)
            return Mathf.Abs(toRandomize);
        else
            return Mathf.Abs(toRandomize) * -1;
    }
}