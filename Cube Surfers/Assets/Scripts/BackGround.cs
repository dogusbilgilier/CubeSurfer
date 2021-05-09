using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField]GameObject backGround;
    void Start()
    {
        InvokeRepeating("InstantiateBackground", 45, 45);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate ( Vector3.back * Time.deltaTime*2);

           

    }
    void InstantiateBackground()
    {
        backGround = Instantiate(backGround, new Vector3(-8, -16, 190), Quaternion.identity, transform);
       
        Destroy(transform.GetChild(0).gameObject);
    }
}
