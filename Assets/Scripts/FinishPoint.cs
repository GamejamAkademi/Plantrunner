using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] ParticleSystem con1;
    [SerializeField] ParticleSystem con2;

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Player"){

            GameManager.Instance.isPlayable = false;
            con1.Play();
            con2.Play();

            Vector3 dest = transform.position + new Vector3(0,0,GameManager.Instance.plantValue / 1000);
            Debug.Log(dest);
           //other.transform.DOMove(dest,3);
            other.transform.DOMoveZ(transform.position.z  + (GameManager.Instance.plantValue) / 500,3);
        }
    }
}
