using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed;
    public float sideSpeed;
    void Start()
    {
        speed = 3f;
        sideSpeed = 1.5f;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveRight()
    {
        if (transform.position.x < 0.9f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * sideSpeed * (TouchManager.speedMultiplier/10));
        }
            
    }
    public void MoveLeft()
    {
        if (transform.position.x > -0.9f)
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed * (TouchManager.speedMultiplier/10));
    }
    public void CubeAdded()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y+0.30f,transform.position.z);
    }
    public void CubeRemoved()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y-(0.30f*5), transform.position.z);
}
}
