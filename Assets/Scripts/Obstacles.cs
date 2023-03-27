using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    Rigidbody _rigidbody;
    public float force ;
    private void Start()
    {
        _rigidbody= GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Debug.Log("engele çarptý");
            _rigidbody.AddForce(transform.right * force);
        }
    }
}
