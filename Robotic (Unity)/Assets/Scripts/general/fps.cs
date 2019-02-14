using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps : MonoBehaviour
{
    public short framesPerSeconed;

    private void Start()
    {
        Application.targetFrameRate = framesPerSeconed;
    }
}
