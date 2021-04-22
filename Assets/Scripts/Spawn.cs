using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject toSpawnHelper;

    private static GameObject toSpawn;

    private static GameObject obj;
    private static Transform cameraLoc;

    private void Start()
    {
        obj = this.gameObject;
        toSpawn = toSpawnHelper;
        cameraLoc = obj.transform.parent;
        
    }

    public void Respawn()
    {
        Instantiate(toSpawn, obj.transform.position, obj.transform.rotation);
        toSpawn.transform.SetParent(cameraLoc);
        
    }
}
