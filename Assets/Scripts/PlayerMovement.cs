using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float _playerSpeed = 4f;
    public static bool _gameplay;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Screen.fullScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = new Vector3(transform.position.x - (_playerSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + (_playerSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _playerSpeed= 10f;
        }
        else
        {
            _playerSpeed = 4f;
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Stage_1");
        }
    }
}
