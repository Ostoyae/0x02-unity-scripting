using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    private Vector3 _direction;

    public Canvas hud;

    private int score = 0;
    private Text _scoreText;
    private Text _healthText;


    // Start is called before the first frame update
    void Start()
    {
        _healthText = hud.transform.Find("Health").GetComponent<UnityEngine.UI.Text>();
        _scoreText = hud.transform.Find("Score").GetComponent<UnityEngine.UI.Text>();
        
        _scoreText.text = "Score: 0";
        _healthText.text = "Health: 5";
   
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

    void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Coin")) {
            score += 1;
            _scoreText.text = "Score: " + score;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
    }

}