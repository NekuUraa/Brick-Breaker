using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    public GameObject Rando1;
    public GameObject Rando2;
    public GameObject Rando3;
    public GameObject Rando4;
    public GameObject Rando5;

    public static bool noLongerHuman = false;

    public Animator raquette_anim;
    public Animator Ui_Score;

    public ParticleSystem gainScore;

    public int myScore = 0;
    public TMP_Text score;

    public int nbrEnemy = 75;
    public TMP_Text myNbrEnemy;



    void Start()
    {
        _dirX = true;
        _dirZ = true;
        rotate = new Vector3 (-10,0,0);
        StartCoroutine(WaitForSpawnRando1());
        StartCoroutine(WaitForSpawnRando2());
        StartCoroutine(WaitForSpawnRando3());
        StartCoroutine(WaitForSpawnRando4());
        StartCoroutine(WaitForSpawnRando5());

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(nbrEnemy);
        Move();
        transform.Rotate(rotate);
        endScore();
        score.SetText(""+myScore);
        if (myScore < 0)
        {
            myScore= 0;
        }
        myNbrEnemy.SetText("Il vous reste "+ nbrEnemy +" briques a detruire");
        rememberNbrEnemy();

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

            StartCoroutine(AffichageNbrEnemy());
            other.transform.parent = transform;
            _dirZ = !_dirZ;
            rotate = new Vector3(-10, 0, 0) * Time.deltaTime;
            rotate.x -= 2f;
            myScore += 10;
            ParticleSystem temp = Instantiate(gainScore, other.transform.position, other.transform.rotation);
            //gainScore.transform.position = other.transform.position;
            temp.Play();
            Ui_Score.SetTrigger("Points");
            nbrEnemy -= 1;
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
            Debug.Log(_ballSpeed < 10f);
            if(_ballSpeed < 10f)
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

    public void endScore()
    {
        if(nbrEnemy == 0)
        {
            StartCoroutine(WaitForEndScreen());
        }
    }

    public void rememberNbrEnemy()
    {
        if (nbrEnemy == 50)
        {
            Debug.Log("Je marche");
        }
    }

    IEnumerator AffichageNbrEnemy()
    {

        myNbrEnemy.enabled = true;
        yield return new WaitForSeconds(2f);
        myNbrEnemy.enabled = false;
    }

    IEnumerator WaitForSpawnRando1()
    {
        yield return new WaitForSeconds(5f);
        Rando1.SetActive(true);
    }

    IEnumerator WaitForSpawnRando2()
    {
        yield return new WaitForSeconds(15f);
        Rando3.SetActive(true);
    }

    IEnumerator WaitForSpawnRando3()
    {
        yield return new WaitForSeconds(30f);
        Rando2.SetActive(true);
    }
    IEnumerator WaitForSpawnRando4()
    {
        yield return new WaitForSeconds(45f);
        Rando4.SetActive(true);
    }

    IEnumerator WaitForSpawnRando5()
    {
        yield return new WaitForSeconds(60f);
        Rando5.SetActive(true);
    }

    IEnumerator WaitForEndScreen()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Stage_1");
    }


}
