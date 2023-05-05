using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{

    public GameObject _Enemy;
    private List<GameObject> _objects = new List<GameObject>();
    public float _ballSpeed = 2.5f;
    private bool _dirX;
    private bool _dirZ;
    private Vector3 rotate;

    public GameObject prefabRando;
    public GameObject prefabRando2;
    public GameObject prefabRando5;

    public static bool noLongerHuman = false;

    public Animator raquette_anim;
    public Animator Ui_Score;

    public ParticleSystem gainScore;

    public int myScore = 0;
    public TMP_Text score;



    void Start()
    {
        _dirX = true;
        _dirZ = true;
        rotate = new Vector3 (-10,0,0);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        transform.Rotate(rotate);
        score.SetText(""+myScore);
        if (myScore < 0)
        {
            myScore= 0;
        }
    }

    public void Move()
    {
        
            if (_dirX == true && _dirZ == true)
            {

                transform.position = new Vector3(transform.position.x - (_ballSpeed * Time.deltaTime), transform.position.y, transform.position.z - (_ballSpeed * Time.deltaTime));

            }

            if (_dirX == true && _dirZ == false)
            {

                transform.position = new Vector3(transform.position.x - (_ballSpeed * Time.deltaTime), transform.position.y, transform.position.z + (_ballSpeed * Time.deltaTime));

            }

            if (_dirX == false && _dirZ == true)
            {

                transform.position = new Vector3(transform.position.x + (_ballSpeed * Time.deltaTime), transform.position.y, transform.position.z - (_ballSpeed * Time.deltaTime));

            }

            if (_dirX == false && _dirZ == false)
            {

                transform.position = new Vector3(transform.position.x + (_ballSpeed * Time.deltaTime), transform.position.y, transform.position.z + (_ballSpeed * Time.deltaTime));

            }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.transform.parent = transform;
            _dirZ = !_dirZ;
            rotate = new Vector3(-10, 0, 0) * Time.deltaTime;
            rotate.x -= 2f;
            myScore += 10;
            ParticleSystem temp = Instantiate(gainScore, other.transform.position, other.transform.rotation);
            //gainScore.transform.position = other.transform.position;
            temp.Play();
            Ui_Score.SetTrigger("Points");
        }

        if(other.tag == "Rando")
        {
            //other.transform.parent = transform;
            //other.gameObject.SetActive(false);
            GameObject temp = Instantiate(prefabRando,other.transform.position,other.transform.rotation);
            other.gameObject.transform.position = new Vector3(-24.57f, 1.35f, Random.Range(9.45f, -6.6f));
            temp.transform.parent = gameObject.transform;
            myScore += 2;
            Ui_Score.SetTrigger("Points");
        }

        if (other.tag == "Rando2")
        {
            //other.transform.parent = transform;
            //other.gameObject.SetActive(false);
            GameObject temp = Instantiate(prefabRando2, other.transform.position, other.transform.rotation);
            other.gameObject.transform.position = new Vector3(-24.57f, 1.35f, Random.Range(9.45f, -6.6f));
            temp.transform.parent = gameObject.transform;
            myScore += 2;
            Ui_Score.SetTrigger("Points");
        }

        if (other.tag == "Rando3")
        {
            //other.transform.parent = transform;
            //other.gameObject.SetActive(false);
            GameObject temp = Instantiate(prefabRando, other.transform.position, other.transform.rotation);
            other.gameObject.transform.position = new Vector3(24.57f, 1.35f, Random.Range(9.45f, -6.6f));
            temp.transform.parent = gameObject.transform;
            myScore += 2;
            Ui_Score.SetTrigger("Points");
        }

        if (other.tag == "Rando4")
        {
            //other.transform.parent = transform;
            //other.gameObject.SetActive(false);
            GameObject temp = Instantiate(prefabRando2, other.transform.position, other.transform.rotation);
            other.gameObject.transform.position = new Vector3(24.57f, 1.35f, Random.Range(9.45f, -6.6f));
            temp.transform.parent = gameObject.transform;
            myScore += 2;
            Ui_Score.SetTrigger("Points");
        }

        if (other.tag == "Rando5")
        {
            //other.transform.parent = transform;
            //other.gameObject.SetActive(false);
            GameObject temp = Instantiate(prefabRando5, other.transform.position, other.transform.rotation);
            other.gameObject.transform.position = new Vector3(-24.57f, 1.35f, Random.Range(9.45f, -6.6f));
            temp.transform.parent = gameObject.transform;
            myScore += 2;
            Ui_Score.SetTrigger("Points");
        }

        if (other.tag == "Player")
        {
            raquette_anim.SetTrigger("Ball_touch");
            _dirZ = false;
            SoundManager.instance.PlaySound(Random.Range(0,3));
            rotate = new Vector3(10, 0, 0) * Time.deltaTime;
            rotate.x += 2f;
            if(_ballSpeed < 15f)
            {
                _ballSpeed += 1f;
            }
        }

        if(other.tag == "UpBorder")
        {
            _dirZ = true;
            rotate = new Vector3(-10, 0, 0) * Time.deltaTime;
            rotate.x += 2f;
        }

        if (other.tag == "LeftBorder")
        {
            _dirX = false;
        }

        if (other.tag == "RightBorder")
        {
            _dirX = true;
        }


        if (other.tag == "DownBorder")
        {
            transform.position = new Vector3(0, 1.29f, 0);
            rotate = new Vector3(-10, 0, 0) * Time.deltaTime;
            _dirX = true;
            _dirZ= true;
            myScore -= 10;
            _ballSpeed = 2.5f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       /* if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Oui je touche");
            collision.transform.parent = transform;
        }*/
    }

}
