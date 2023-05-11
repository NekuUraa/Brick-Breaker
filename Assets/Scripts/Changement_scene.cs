using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changement_scene : MonoBehaviour
{

    public string change_scene;

    

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(sceneChange());
    }

    IEnumerator sceneChange()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(change_scene);
    }
}
