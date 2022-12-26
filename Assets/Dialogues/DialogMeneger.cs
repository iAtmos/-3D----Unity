using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogMeneger : MonoBehaviour
{
    public List<GameObject> Hero = new List<GameObject>();
    public TextMeshProUGUI Text;
    public int IndexHero = 0;
    public int IndexText = 0;
    public float PauseSeconds = 2f;
    public int numberPhrases = 0;

    public void WriteDialog()
    {
        if (Hero.Count > IndexHero)
        {
            if (Hero[IndexHero].GetComponent<DialogueHero>() != null)
            {
                var dialogueHero = Hero[IndexHero].GetComponent<DialogueHero>();
                if (IndexText >= dialogueHero.GetDialoguesCount(IndexHero, numberPhrases))
                {
                    TrigerScript.IsTrigger = false;
                    IndexText = 0;
                    IndexHero = -1;
                    numberPhrases++;
                    StopAllCoroutines();
                    Debug.Log("Диалог закончен");
                    TextDialog("");// чтобы пропадал текст после финальной фразы
                }
                else
                {
                    var text = dialogueHero.GetDialoguesStringIndex(IndexText, IndexHero, numberPhrases).Split(";")[1];
                    PauseSeconds = float.Parse(dialogueHero.GetDialoguesStringIndex(IndexText, IndexHero, numberPhrases).Split(";")[0]);
                    TextDialog(text);
                    Debug.Log(text);
                }
            }
        }
        else StopAllCoroutines();
    }

    private void TextDialog(string text)
    {
        Text.text = text;
    }

    public void NextIndex()
    {
        for (var i = IndexHero; i < Hero.Count; i++)
        {
            WriteDialog();
            IndexHero++;
            return;
        }
        if (IndexHero >= Hero.Count)
        {
            IndexHero = 0;
            IndexText++;
            //WriteDialog();
        }
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    NextIndex();
        //}

        if (TrigerScript.IsTrigger == true)
        {
            TrigerScript.IsTrigger = false;
            StartCoroutine(StartDialogue());
        }

    }

    public IEnumerator StartDialogue()
    {
        while (true)
        {
            NextIndex();
            yield return new WaitForSeconds(PauseSeconds); 
            Debug.Log("seconds - " + PauseSeconds);
            //NextIndex(); даёт правильный временный интервал
        }
    }
}
