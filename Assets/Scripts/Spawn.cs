using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    private GameObject toSpawnHelper;

    private static GameObject toSpawn;

    private static GameObject obj;

    private void Start()
    {
        obj = this.gameObject;
        toSpawn = toSpawnHelper;
    }

    public static void Respawn()
    {
        Instantiate(toSpawn, obj.transform.position, obj.transform.rotation);
        
    }
}
