using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    [SerializeField] public AudioSource click;
    [SerializeField] public AudioClip clickButton;

    public void Click()
    {
        click.PlayOneShot(clickButton);
    }
}
