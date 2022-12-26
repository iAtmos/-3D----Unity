using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUp : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float floatHeight;
    [SerializeField]
    private MeshRenderer platform;
    [SerializeField] 
    private ParticleSystem particles;

    public bool IsFloated;

    private Material particlesMaterial;
    private Material trailsMaterial;

    public Vector3 originalPos;
    
    private float originalHeight;
    
    private void Awake()
    {
        originalHeight = transform.position.y;
        particlesMaterial = particles.GetComponent<Renderer>().materials[0];
        trailsMaterial = particles.GetComponent<Renderer>().materials[1];
        originalPos = transform.position + new Vector3(0, floatHeight, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        StopAllCoroutines();
        StartCoroutine(FloatUpward());
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
        StartCoroutine(FloatDown());
    }

    private IEnumerator FloatUpward()
    {
        while (originalHeight + floatHeight > transform.position.y)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            yield return new WaitForSeconds(0.005f);
        }
        
        IsFloated = true;
    }
    
    private IEnumerator FloatDown()
    {
        while (transform.position.y > originalHeight)
        {
            IsFloated = false;
            transform.position -= Vector3.up * speed * Time.deltaTime;
            yield return new WaitForSeconds(0.005f);
        }
    }
}