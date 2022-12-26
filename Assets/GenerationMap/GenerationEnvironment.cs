using System.Collections.Generic;
using UnityEngine;

public class GenerationEnvironment : MonoBehaviour
{
    public List<GameObject> PrefabsObject = new List<GameObject>();
    private Dictionary<int, string> layerObj = new Dictionary<int, string>()
    {
        [30] = "CapsuleObj",
        [29] = "CapsuleObj2",
        [28] = "RoofObj",
        [27] = "SceneObj"
    };
    private Dictionary<string, List<GameObject>> currentObjiect = new Dictionary<string, List<GameObject>>()
    {
        ["CapsuleObj"] = new List<GameObject>(),
        ["CapsuleObj2"] = new List<GameObject>(),
        ["RoofObj"] = new List<GameObject>(),
        ["SceneObj"] = new List<GameObject>()
    };

    public static Dictionary<string, int> CountObjThisType = new Dictionary<string, int>()
    {
        ["CapsuleObj"] = 0,
        ["CapsuleObj2"] = 0,
        ["RoofObj"] = 2,
        ["SceneObj"] = 0
    };

    private Vector3 playerPosition;
    private Vector3 playerDirection;

    private Vector3 positionObj;
    private Vector3 newPositionObj;

    private float sizePartExternalAreaX = 25;
    private float sizePartInternalAreaX = 7;
    private float sizePartArea = 11;
    private float borderChangesPosition;

    private float rangeX;
    private float rangeY;
    private float rangeZ;

    private enum ErrorÑoefficient
    {
        IncreasingRadius = 5,
        BorderChangesPosition = 2
    }

    //Çàìåíèòü íà Awake
    private void Start()
    {
        PositionDetermination();
        GenerationDynamicObj();

        CountObjThisType["CapsuleObj"] = 1;
        CountObjThisType["CapsuleObj2"] = 1;
        CountObjThisType["RoofObj"] = 8;

        sizePartExternalAreaX = GameObject.Find("ExternalArea").GetComponent<BoxCollider>().size.x / 2;
        sizePartInternalAreaX = GameObject.Find("InternalArea").GetComponent<BoxCollider>().size.x / 2;
        sizePartArea = (sizePartExternalAreaX - sizePartInternalAreaX) * 2 - sizePartExternalAreaX;
        borderChangesPosition = sizePartExternalAreaX - (float)ErrorÑoefficient.BorderChangesPosition;
        BorderChangesPosition();

        GenerationDynamicObj();
    }

    private void PositionDetermination()
    {
        playerPosition = this.transform.position;
        playerDirection = this.transform.forward;
    }

    private void BorderChangesPosition()
    {
        var colliderSphere = GameObject.Find("BorderArea").GetComponent<CapsuleCollider>();
        var radius = Mathf.Sqrt((sizePartExternalAreaX * sizePartExternalAreaX) * 2);
        var height = radius * 4;
        colliderSphere.radius = radius + (float)ErrorÑoefficient.IncreasingRadius;
        colliderSphere.height = height;
    }

    /// <summary>
    /// Óâåëè÷åíèå êîëè÷åñòâåííîé ãåíåðàöèè îáüåêòîâ. 
    /// Ðàáîòàåò â ñâÿçêå ñî çíà÷åíèÿìè CountObjThisType[...]
    /// </summary>
    public void GenerationDynamicObj()
    {
        for (var i = 0; i < CountObjThisType["CapsuleObj"]; i++)
            InitializingDynamicObj(PrefabsObject[0], "CapsuleObj");
        for (var i = 0; i < CountObjThisType["CapsuleObj2"]; i++)
            InitializingDynamicObj(PrefabsObject[1], "CapsuleObj2");
        for (var i = 0; i < CountObjThisType["RoofObj"]; i++)
            InitializingDynamicObj(PrefabsObject[2], "RoofObj");
    }

    public void GenerationDynamicFrontObj()
    {
        InitializingDynamicObj(PrefabsObject[3], "SceneObj", true);
    }

    private void InitializingDynamicObj(GameObject prefab, string typeObj, bool pointwise = false)
    {
        PositionDetermination();

        if (!pointwise)
        {
            positionObj = GeneratioPositionObjAround(playerPosition.x, playerPosition.z, typeObj);
            currentObjiect[typeObj].Add(Instantiate(prefab, new Vector3(positionObj.x, positionObj.y, positionObj.z), Quaternion.Euler(0f, Random.Range(0, 360f), 0f)));
        }
        else
        {
            positionObj = GeneratioPositionObjFront(playerPosition.x, playerPosition.z, typeObj);
            currentObjiect[typeObj].Add(Instantiate(prefab, new Vector3(positionObj.x, positionObj.y, positionObj.z), Quaternion.Euler(0f, 90f + this.transform.rotation.eulerAngles.y, 0f)));
        }
    }

    private Vector3 GeneratioPositionObjAround(float playerPositionX, float playerPositionZ, string typeObj)
    {
        rangeX = Random.Range(playerPositionX - sizePartExternalAreaX, playerPositionX + sizePartExternalAreaX);

        if (playerPositionX - sizePartInternalAreaX < rangeX && rangeX < playerPositionX + sizePartInternalAreaX)
        {
            rangeZ = Random.Range(playerPositionZ - sizePartExternalAreaX, playerPositionZ + sizePartArea);
            if (rangeZ > playerPositionZ - sizePartInternalAreaX)
                rangeZ = Random.Range(playerPositionZ + sizePartInternalAreaX, playerPositionZ + sizePartExternalAreaX);
        }
        else
        {
            rangeZ = Random.Range(playerPositionZ - sizePartExternalAreaX, playerPositionZ + sizePartExternalAreaX);
        }

        rangeY = typeObj == "RoofObj" ? 0f : 1f;

        return new Vector3(rangeX, rangeY, rangeZ);
    }

    private Vector3 GeneratioPositionObjFront(float playerPositionX, float playerPositionZ, string typeObj)
    {
        rangeX = playerPositionX + (30.4f + 7.3f) * playerDirection.x;
        rangeZ = playerPositionZ + (30.4f + 7.3f) * playerDirection.z;
        rangeY = 2.5f;
        return new Vector3(rangeX, rangeY, rangeZ);
    }

    private void OnTriggerExit(Collider triger)
    {
        PositionDetermination();

        if (DeterminingDistance(triger.transform.position, playerPosition.x, playerPosition.z))
        {
            switch (triger.tag)
            {
                case "EnvironmentObject":
                    ÑhangingEnvironment(triger, GeneratioPositionObjAround);
                    break;
                case "FacialEnvironmentObject":
                    triger.gameObject.transform.rotation = Quaternion.Euler(0f, 90f + this.transform.rotation.eulerAngles.y, 0f);
                    ÑhangingEnvironment(triger, GeneratioPositionObjFront);
                    break;
            }
        }
    }

    private void ÑhangingEnvironment(Collider triger, System.Func<float, float, string, Vector3> position)
    {
        if (currentObjiect[layerObj[triger.gameObject.layer]].Count <= CountObjThisType[layerObj[triger.gameObject.layer]]
            && currentObjiect[layerObj[triger.gameObject.layer]].Contains(triger.gameObject))
        {
            newPositionObj = position(playerPosition.x, playerPosition.z, layerObj[triger.gameObject.layer]);
            triger.gameObject.transform.position = new Vector3(newPositionObj.x, newPositionObj.y, newPositionObj.z);
        }
        else
        {
            currentObjiect[layerObj[triger.gameObject.layer]].Remove(triger.gameObject);
            Destroy(triger.gameObject);
        }
    }

    private bool DeterminingDistance(Vector3 posObj, float playerPositionX, float playerPositionZ)
    {
        if (Mathf.Sqrt((posObj.x - playerPositionX) * (posObj.x - playerPositionX)
            + (posObj.z - playerPositionZ) * (posObj.z - playerPositionZ)) > borderChangesPosition)
        {
            return true;
        }
        return false;
    }
}