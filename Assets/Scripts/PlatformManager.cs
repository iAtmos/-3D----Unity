using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static List<(int, int)> Coordinates = new List<(int, int)> { (0, 0) };
    public (int, int) Coordinate = (0, 0);
}
