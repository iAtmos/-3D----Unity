using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectBehaviour : MonoBehaviour
{
    public Material unselected;
    public Material selected;
    void Start()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(new Vector3(0, 0.2f, 0));
            yield return new WaitForSeconds(0.005f);
        }
    }

    public IEnumerator FloatUp()
    {
        while (true)
        {
            transform.position = transform.position + new Vector3(0, 0.1f, 0);
            yield return new WaitForSeconds(0.005f);
        }
    }

    public void Ation()
    {
        StartCoroutine(FloatUp());
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public void GetSelected()
    {
        GetComponent<MeshRenderer>().material = selected;
    }
    
    public void GetUnselected()
    {
        GetComponent<MeshRenderer>().material = unselected;
    }
}
