using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Doors : MonoBehaviour
{
    
    [SerializeField] TextMeshPro doorText;
    [SerializeField] float value;
    [SerializeField] string doorOp;
    bool doorOpen = false;

    private void Awake() {
        doorText.text = doorOp + value.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag=="Player" && doorOpen==false )
        {
            if (doorOp == "+")
            {
                GameManager.Instance.plantValue = GameManager.Instance.plantValue+ value ;
            }
            else if (doorOp == "-")
            {
                GameManager.Instance.plantValue = GameManager.Instance.plantValue-value;
            }
            else if (doorOp == "/")
            {
                GameManager.Instance.plantValue = GameManager.Instance.plantValue/value;
            }
            else
            {
                GameManager.Instance.plantValue = GameManager.Instance.plantValue * value;
            }
        }
        Debug.Log(GameManager.Instance.plantValue);
        doorOpen = true;
    }
}


