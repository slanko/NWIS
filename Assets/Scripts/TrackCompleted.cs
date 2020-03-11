using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrackCompleted
{
    public delegate void someEvent();

    public static someEvent complete;
}
