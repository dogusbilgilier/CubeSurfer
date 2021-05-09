using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    float touchPosX;
    Touch touch;
    PlayerControls _playerControls;
    float timer=0;
    float period=0.1f;
    public static float speedMultiplier=0f;
    void Start()
    {
        _playerControls = FindObjectOfType<PlayerControls>();
    }

    void FixedUpdate()
    {
        TouchInputs();
    }

    void TouchInputs() {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (Time.time > timer)
            {
                touchPosX = touch.position.x;
                timer += Time.deltaTime + period;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.position.x < touchPosX)
                {
                    speedMultiplier = (touchPosX - touch.position.x);
                    _playerControls.MoveLeft();
                }
                else if (touch.position.x > touchPosX)
                {
                    speedMultiplier = (touch.position.x - touchPosX);
                    _playerControls.MoveRight();
                }
            }
        }
        else
            timer = Time.time;
    }

}
