using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    float touchxDelta = 0;
    float newDeltax;
    public float xSpeed;
    public float limitx;
    // Update is called once per frame
    void Update()
    {
        Swipecheck();
    }

    private void Swipecheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Debug.Log("finger is moved");
            Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width);
            //parmaðýnýn ekranda nerde olduðunun hassas deðeri
            touchxDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchxDelta = Input.GetAxis("Mouse X");
            //mouse ile de kontrol edebilmek için ekledik
        }
        else
        {
            touchxDelta= 0;
        }
        newDeltax = transform.position.x + xSpeed * touchxDelta * Time.deltaTime;
        newDeltax = Mathf.Clamp(newDeltax, -limitx, +limitx);
        Vector3 newPosition = new Vector3(newDeltax, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
