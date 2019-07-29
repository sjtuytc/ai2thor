using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public string objectTypeToScreenshot;
    public Transform spawnPositionA;
    public Transform spawnPositionB;
    GameObject[] allObjects;
    GameObject[] comparedObjects = new GameObject[40];
    int comparedObjectsSize;
    GameObject spawneeA;
    GameObject spawneeB;
    float spawnHeightA;
    float spawnHeightB;
    GameObject sceneSpawnedA;
    GameObject sceneSpawnedB;
    bool cont = true;
    int aNum = 0;
    int bNum = 1;
    string spawneeAMat;
    string spawneeBMat;

    private void Awake()
    {
        //Debug.Log("Hello World 1");


        //private int f = 0;

        allObjects = Resources.LoadAll("SimObjsPhysics", typeof(GameObject)).Cast<GameObject>().ToArray();

        //Debug.Log(allObjects.Length);

        int n = 0;

        for (int i = 0; i < allObjects.Length; i++)
        {
            if (allObjects[i].GetComponent<SimObjPhysics>() != null)
            {
                if (allObjects[i].GetComponent<SimObjPhysics>().Type.ToString() == objectTypeToScreenshot)
                {
                    comparedObjects[n] = allObjects[i];
                    n++;
                }
            }
        }

        comparedObjectsSize = n;
        //Debug.Log("Size: " + comparedObjectsSize);
    }

    void Update()
    {
        if (cont == true)
        {
            spawneeA = comparedObjects[aNum];

            sceneSpawnedA = Instantiate(spawneeA, spawnPositionA.position, spawnPositionA.rotation);
            spawnHeightA = sceneSpawnedA.transform.Find("BoundingBox").GetComponent<BoxCollider>().size.y / 2;
            sceneSpawnedA.transform.position = new Vector3(spawnPositionA.position.x, spawnPositionA.position.y + spawnHeightA, spawnPositionA.position.z);

            spawneeB = comparedObjects[bNum];

            sceneSpawnedB = Instantiate(spawneeB, spawnPositionB.position, spawnPositionB.rotation);
            spawnHeightB = sceneSpawnedB.transform.Find("BoundingBox").GetComponent<BoxCollider>().size.y / 2;
            sceneSpawnedB.transform.position = new Vector3(spawnPositionB.position.x, spawnPositionB.position.y + spawnHeightB, spawnPositionB.position.z);

            spawneeAMat = spawneeA.GetComponent<SimObjPhysics>().salientMaterials[0].ToString();
            spawneeBMat = spawneeB.GetComponent<SimObjPhysics>().salientMaterials[0].ToString();

            //Debug.Log(spawneeAMat);
            //Debug.Log(spawneeBMat);

            StartCoroutine(Screenshot());
            cont = false;
        }
    }

    IEnumerator Screenshot()
    {
        yield return new WaitForSeconds(0.1f);
        ScreenCapture.CaptureScreenshot("Assets/Mechanical_Turk_Test/Screenshots/" + objectTypeToScreenshot + "/A_" + spawneeA.name + "_" + spawneeAMat + "-B_" + spawneeB.name + "_" + spawneeBMat + ".jpg", 1);
        yield return new WaitForSeconds(0.01f);
        Destroy(sceneSpawnedA);
        Destroy(sceneSpawnedB);

        if (aNum != comparedObjectsSize - 2)
        {
            if (bNum == comparedObjectsSize - 1)
            {
                aNum++;
                bNum = aNum + 1;
            }

            else
            {
                bNum++;
            }

            cont = true;
        }
    }
}