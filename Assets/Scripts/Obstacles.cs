using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    Rigidbody _rigidbody;
    public float force ;
    public float forceup ;
    private void Start()
    {
        _rigidbody= GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ObstacleRight")
        {
            _rigidbody.AddForce(transform.right * force * -1);
        }
        if (other.tag == "ObstacleLeft")
        {
            _rigidbody.AddForce(transform.right * force);
        }
        if(other.tag == "Jump")
        {
            _rigidbody.AddForce(transform.up * forceup);
        }
    }
}
