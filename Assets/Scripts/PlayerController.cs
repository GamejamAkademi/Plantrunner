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
    [SerializeField] GameObject[] roots;

    int currentIndex=0;
    int currentRootIndex=0;
    int rootIndex=0;

    void Update()
    {
        if(GameManager.Instance.isPlayable == true){
            Swipecheck();
            ChangeMesh();
        }
    }

    void ChangeMesh(){
        int index = (int) GameManager.Instance.plantValue / 1000 ;
        Debug.Log(rootIndex);
        Debug.Log(currentIndex);
        if(currentIndex < 4f ){
            rootIndex = 0;
        }else if(currentIndex >= 4f & currentIndex <8f){
            rootIndex = 1;
        }else if(currentIndex >= 8f & currentIndex <12f){
            rootIndex = 2;
        }else if(currentIndex >12f){
            rootIndex = 3;
        }
        //roots
        roots[currentRootIndex].gameObject.SetActive(false);
        roots[rootIndex].gameObject.SetActive(true);
        //flowers
        flowers[currentIndex].gameObject.SetActive(false);
        flowers[index].gameObject.SetActive(true);
        currentRootIndex = rootIndex;
        currentIndex = index;
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
