using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logic : MonoBehaviour
{
    private IEnumerator speedMove = PlayerMovement.SpeedChangeCoroutine(6f, 47);
    private GenerationEnvironment generationEnvironment;

    private void Awake()
    {
        generationEnvironment = this.GetComponent<GenerationEnvironment>();
    }

    private void Start()
    {
        StartCoroutine(LogicSceans());
    }

    private IEnumerator LogicSceans()
    {
        // Сцена 1 - Диалог
        // Постепенное повышение скорости перед Сценой 2
        yield return new WaitForSeconds(4);
        TrigerScript.IsTrigger = true;
        StartCoroutine(speedMove);

        // Подготовка ко 2-ой сцене (за 5 сек. до завершения)
        // Удаление сгенерированных обьектов со сцены
        yield return new WaitForSeconds(43);
        GenerationEnvironment.CountObjThisType["CapsuleObj"] = 0;
        GenerationEnvironment.CountObjThisType["CapsuleObj2"] = 0;
        GenerationEnvironment.CountObjThisType["RoofObj"] = 0;

        // Сцена 2 - Боевка
        // Введение врагов в игровую сцену
        yield return new WaitForSeconds(5);

        // Сцена 3
        // Генерация сцены перед игроком
        yield return new WaitForSeconds(5);
        GenerationEnvironment.CountObjThisType["SceneObj"] = 1;
        generationEnvironment.GenerationDynamicFrontObj();
    }
}