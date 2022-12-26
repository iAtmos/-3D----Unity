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
        // ����� 1 - ������
        // ����������� ��������� �������� ����� ������ 2
        yield return new WaitForSeconds(4);
        TrigerScript.IsTrigger = true;
        StartCoroutine(speedMove);

        // ���������� �� 2-�� ����� (�� 5 ���. �� ����������)
        // �������� ��������������� �������� �� �����
        yield return new WaitForSeconds(43);
        GenerationEnvironment.CountObjThisType["CapsuleObj"] = 0;
        GenerationEnvironment.CountObjThisType["CapsuleObj2"] = 0;
        GenerationEnvironment.CountObjThisType["RoofObj"] = 0;

        // ����� 2 - ������
        // �������� ������ � ������� �����
        yield return new WaitForSeconds(5);

        // ����� 3
        // ��������� ����� ����� �������
        yield return new WaitForSeconds(5);
        GenerationEnvironment.CountObjThisType["SceneObj"] = 1;
        generationEnvironment.GenerationDynamicFrontObj();
    }
}