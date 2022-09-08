using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analogic : MonoBehaviour
{
    Touch touchDevice;
    Vector2 startPosition;
    public Transform background;
    public float radius = 60f;
    public Transform player;
    public float speedPlayer = 0.2f;
    void Start()
    {
        touchDevice = new Touch{fingerId = -1};
    }

    // Update is called once per frame
    void Update()
    {
        startPosition = background.position;
        if(Input.touchCount > 0){
            for(int i = 0; i < Input.touchCount; i++){
                if(touchDevice.fingerId == -1){
                    if(Input.GetTouch(i).position.x < Screen.width / 2 && Input.GetTouch(i).position.x < Screen.height / 2 ){
                        touchDevice = Input.GetTouch(i);
                        startPosition = touchDevice.position;
                        background.position = startPosition;
                    }
                }
                else{
                    if(Input.GetTouch(i).fingerId == touchDevice.fingerId)
                    {
                        touchDevice = Input.GetTouch(i);
                    }
                }
            }
            if(touchDevice.fingerId != -1)
            {
                if(touchDevice.phase == TouchPhase.Canceled || touchDevice.phase == TouchPhase.Ended)
                {
                    touchDevice = new Touch{fingerId = -1};
                }
                else
                {
                    Vector2 distance = touchDevice.position - startPosition;
                    transform.position = startPosition + Vector2.ClampMagnitude(distance, radius);
                    player.position += (Vector3)distance * speedPlayer * Time.deltaTime;
                }
            }
        }
        if(touchDevice.fingerId == -1)
        {
            touchDevice.position = Vector2.MoveTowards(transform.position, startPosition, 70);
        }
    }
}
