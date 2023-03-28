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



    [SerializeField] GameObject[] flowers;
 
    [SerializeField] int currentLevelIndex=0;
    [SerializeField] int lowLevel=1000;
    [SerializeField] int midLevel=2000;
    [SerializeField] int highLevel=3000;

    void Update()
    {
        if(GameManager.Instance.isPlayable == true){
            Swipecheck();
            ChangeMesh();
        }
        
    }

    void ChangeMesh(){

        if(GameManager.Instance.plantValue<lowLevel){
            flowers[currentLevelIndex].gameObject.SetActive(false);
            currentLevelIndex=0;
            flowers[currentLevelIndex].gameObject.SetActive(true);
        }else if(GameManager.Instance.plantValue>=lowLevel && GameManager.Instance.plantValue<midLevel){
            flowers[currentLevelIndex].gameObject.SetActive(false);
            currentLevelIndex=1;
            flowers[currentLevelIndex].gameObject.SetActive(true);
        }else if(GameManager.Instance.plantValue>=midLevel && GameManager.Instance.plantValue<highLevel){
            flowers[currentLevelIndex].gameObject.SetActive(false);
            currentLevelIndex=2;
            flowers[currentLevelIndex].gameObject.SetActive(true);
        }else if(GameManager.Instance.plantValue>highLevel){
            flowers[currentLevelIndex].gameObject.SetActive(false);
            currentLevelIndex=3;
            flowers[currentLevelIndex].gameObject.SetActive(true);
        }
    }

    private void Swipecheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Debug.Log("finger is moved");
            Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width);
            //parmaginin ekranda nerde oldugunun hassas degeri
            touchxDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchxDelta = Input.GetAxis("Mouse X");
            //mouse ile de kontrol edebilmek icin ekledik
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
