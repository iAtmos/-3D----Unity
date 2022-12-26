using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class points : MonoBehaviour
{
    private string text;

    public void OnEnable()
    {
        text = GetComponent<Text>().text;
        GetComponent<Text>().text = " ";
        StartCoroutine(TextCoroutine());
    }

    IEnumerator TextCoroutine()
    {
        foreach(char abc in text)
        {
            for (var i = 0; i <= 4; i++)
            {
                GetComponent<Text>().text += abc;
                yield return new WaitForSeconds(0.8f);
            }
            GetComponent<Text>().text = " ";
        }
    }
}