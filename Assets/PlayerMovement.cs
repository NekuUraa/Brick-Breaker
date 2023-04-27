using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _playerSpeed = 2.5f;
    public static bool _gameplay;
    void Start()
    {
        
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
        }
}
