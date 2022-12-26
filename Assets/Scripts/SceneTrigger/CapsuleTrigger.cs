using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTrigger : MonoBehaviour
{
    private CharacterController playerController;
    public GameObject pos;
    private void OnTriggerStay (Collider other)
    {
        if (other.tag == "Player")
        {
            if (pos.transform.position.y > 0 && pos.transform.position.y <9)
            {
                pos.transform.position += pos.transform.up * 0.05f;
            }
        }
    }

    void Update()
    {

    }

    void Start()
    {

    }
}