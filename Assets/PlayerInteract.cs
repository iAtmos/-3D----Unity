using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerInteract : MonoBehaviour
{
    private InteractableObjectBehaviour onSightObject;
    
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, Mathf.Infinity);
        if (hit.collider == null || (onSightObject != null && onSightObject != hit.collider.GetComponent<InteractableObjectBehaviour>()))
            onSightObject.GetUnselected();
        onSightObject = hit.collider.GetComponent<InteractableObjectBehaviour>();
        onSightObject.GetSelected();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            onSightObject.Ation();
    }
}
