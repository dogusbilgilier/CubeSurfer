using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public int addedCubes = 0;
    GameObject player;
    PlayerControls _playerControls;
    float ypos;
    List<GameObject> cubess;
    int colorMatch=0;
    string[] colorarr = { "Yellow", "Green", "Blue", "Red", "Purple" };
    void Start()
    {
        cubess = new List<GameObject>();
        ypos = 0.15f;
        player = GameObject.FindGameObjectWithTag("Player");
        _playerControls = player.GetComponent<PlayerControls>();
    }
    void Update()
    {
        for (int i = 0; i < cubess.Count; i++)
            if (cubess[i]!=null)
                cubess[i].transform.position = new Vector3(player.transform.position.x, cubess[i].transform.position.y ,0);
    }
    public void CubeAdded(GameObject cube)
    {
        Destroy(cube.GetComponent<BoxCollider>());
        Destroy(cube.GetComponent<Rigidbody>());

        cubess.Add(cube);

        ColorMatch();

        addedCubes++;

        for (int i = 0; i < addedCubes; i++)
            cubess[addedCubes - 1 - i].transform.position = (new Vector3(cube.transform.position.x, ypos + 0.30f * i, 0));

        _playerControls.CubeAdded();
    }

    void ColorMatch()
    {
        List<string> tempList = new List<string>();

        for (int i = 0; i < cubess.Count; i++)
            tempList.Add(cubess[i].name);

        var res = tempList.GroupBy(item => item);

        colorMatch = res.Count();

        if (colorMatch == 5)
            DestroyFive();
    }

    void DestroyFive()
    {
        int index;

        for (int i = 0; i < colorarr.Length; i++)
        {
            index = cubess.FindIndex(cube => cube.name.Contains(colorarr[i]));
            Destroy(cubess[index]);
            cubess.RemoveAt(index);
        }
       
        cubess.RemoveAll(empty => empty== null);

        addedCubes -= 5;
        ColorMatch();

        _playerControls.CubeRemoved();

    }
    
}
