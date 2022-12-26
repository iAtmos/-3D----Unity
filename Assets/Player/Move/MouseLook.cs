using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    float yRotation = 0f;
    public Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
    float mouseSensivity = 800f;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        slider.onValueChanged.AddListener((v) =>
        {
            sliderText.text=v.ToString("0.0");
        });
    }

    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * slider.value * Time.deltaTime * mouseSensivity;
        var mouseY = Input.GetAxis("Mouse Y") * slider.value * Time.deltaTime * mouseSensivity;

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
