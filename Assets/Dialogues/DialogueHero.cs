using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueHero : MonoBehaviour
{
    //DialogMeneger dialogMeneger;
    public List<string> GetArray(int number, int numberPhrases)
    {
        var countPhrases = 0;
        var secondsAndLines = new List<string>();
        string[] PlayerArray = File.ReadAllLines("Assets\\Dialogues\\Player.txt");
        string[] ObjectArray = File.ReadAllLines("Assets\\Dialogues\\Object.txt");
        //var PlayerArrayDialogues = new List<string>();
        //var ObjectArrayDialogues = new List<string>();
        if (number == 0)
        {
            foreach (var str in PlayerArray)
            {
                if (str == ":::")
                    countPhrases++;
                if (countPhrases > numberPhrases)
                    break;
                if (countPhrases == numberPhrases)
                {
                    if (str != "" && str != ":::")
                    {
                        //var dialogue = str.Split(";")[1];
                        secondsAndLines.Add(str);
                    }
                } 
            }     
        }
        else
        {
            foreach (var str in ObjectArray)
            {
                if (str == ":::")
                    countPhrases++;
                if (countPhrases > numberPhrases)
                    break;
                if (countPhrases == numberPhrases)
                {
                    if (str != "" && str != ":::")
                    {
                        //var dialogue = str.Split(";")[1];
                        secondsAndLines.Add(str);
                    }
                }
            }
        }
        return secondsAndLines;
    }

    public int GetDialoguesCount(int number, int numberPhrases)
    {
        return GetArray(number, numberPhrases).Count;
    }

    public string GetDialoguesStringIndex(int index, int number, int numberPhrases)
    {
        return GetArray(number, numberPhrases)[index];
    }

}
