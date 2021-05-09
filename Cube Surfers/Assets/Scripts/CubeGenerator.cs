using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    float randomTimer=1f;
    float timer=0;
    public float distance;
    [SerializeField] GameObject[] cubes;
    [Header("Lower to More!")]
    public float cubeDensityZ;
    private void Start()
    {
        distance = 40;
        cubeDensityZ = 0.6f;
    }
    void Update()
    {
        if (Time.time > timer)
        {
            InstantiateCubes();
            //cubeDensityZ = (float)Random.Range(0.5f, 1f);
            timer += cubeDensityZ;
        }
    }
    void InstantiateCubes()
    {
        GameObject cube= Instantiate(cubes[Random.Range(0,5)]);
        cube.transform.position = new Vector3((float)Random.Range(1f, -1f), 0.15f, distance);
        cube.transform.parent = gameObject.transform;
    }
}
