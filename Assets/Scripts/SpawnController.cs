using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static SpawnController instance;
    public GameObject[] junkPrefabs;

    private float pastTime;
    public static float waitTime = 4f;

    private void Awake()
    {
        if (junkPrefabs.Length == 0)
        {
            Debug.LogError("NEED JUNK");
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - pastTime >= waitTime && GameController.active){
            Spawn();
        }
    }

    public void Spawn()
    {
        int index = Random.Range(0, junkPrefabs.Length);
        Instantiate(junkPrefabs[index], transform.position, Quaternion.identity);
        pastTime = Time.time;
    }

}
