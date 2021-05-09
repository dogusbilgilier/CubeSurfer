using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    PlayerControls _playerControls;
    CubeManager _cubeManager;
    public float cubeSpeed;
    public bool isAdded=false;
    void Start()
    {
        _cubeManager = FindObjectOfType<CubeManager>();
        _playerControls = FindObjectOfType<PlayerControls>();

        cubeSpeed = _playerControls.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAdded)
            transform.Translate(Vector3.back * Time.deltaTime * cubeSpeed);

        if (transform.position.z<-3)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            isAdded = true;
            _cubeManager.CubeAdded(gameObject);
        }
        
    }
}
