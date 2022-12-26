using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject effect;
    
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
