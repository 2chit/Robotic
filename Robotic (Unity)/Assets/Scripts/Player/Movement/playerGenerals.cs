﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGlibals : MonoBehaviour
{
    public static bool touchingWall;
    public static bool fasterDownfall;
    public static bool sliding;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
