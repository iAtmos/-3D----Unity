using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] private Transform original;
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Vector3 spawnPos;
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private int xOffset;
    [SerializeField] private int yOffset;

    private void OnTriggerEnter(Collider other)
    {
        var coord = (platformManager.Coordinate.Item1 + xOffset,
            platformManager.Coordinate.Item2 + yOffset);
        if (other.gameObject.CompareTag("Player") && !PlatformManager.Coordinates.Contains(coord))
        {
            var newPlatform = Instantiate(platformPrefab, original.GetComponent<FloatUp>().originalPos + spawnPos, Quaternion.identity).GetComponent<PlatformManager>();
            newPlatform.Coordinate = coord;
            PlatformManager.Coordinates.Add(newPlatform.Coordinate);
        }
    }
}
