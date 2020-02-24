using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    private void FixedUpdate()
    {
        _direction.Set(0, 0, 0);

        if (UpdateDirection(ref _direction))
            GetComponent<Rigidbody>().AddForce((_direction * speed));

        
        // Debug.Log(string.Format("Direction = {0}", _direction));
    }

    private static bool UpdateDirection(ref Vector3 dir)
    {
        if (!Input.anyKey) return false;
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            dir.x += 1;
        }


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            dir.x -= 1;
        }


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            dir.z += 1;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            dir.z -= 1;
        }

        return true;

    }

}