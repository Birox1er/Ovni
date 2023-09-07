using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private float speed;
    float moveinput;
    private void Start()
    {
       
    }
    void Update()
    {
        moveinput = Input.GetAxis("Wheel");
        if (Math.Abs(moveinput)>0.2)
         {
          transform.position += new Vector3(Math.Abs(moveinput) * speed * Time.deltaTime, 0, 0);
         } 
        

    }
    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
