using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSysteme : MonoBehaviour
{

    int actualSceneIndex = 0;
    List<AnimManager> SceneList = new List<AnimManager>();
    public AnimManager actualSceneManager;

    public bool fadeState;
    public bool inFade;
    Animator UIAtor;

    // Start is called before the first frame update
    void Start()
    {
        UIAtor = this.GetComponent<Animator>();
        actualSceneManager = GetAnimManager(actualSceneIndex);

    }

    // Update is called once per frame
    void Update()
    {
        SceneManager();
        //ValidScene();
    }

    void SceneManager()
    {
        if (!actualSceneManager.sceneFinished)
        {
            actualSceneManager.ExecuteScene();
        }
        else
        {
            ChangeScene();
            UIAtor.SetBool("Fade", inFade);

        }
    }

    void ValidScene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            actualSceneManager.sceneFinished = true;
        }
    }

    void ChangeScene()
    {

        if (!inFade && !fadeState)
        {
            inFade = true;
            StartCoroutine(GoInFade());
        }

        if (fadeState && GetAnimManager(actualSceneIndex + 1)!=null)
        {
            if (Vector3.Distance(Camera.main.transform.position, GetAnimManager(actualSceneIndex + 1).transform.position + new Vector3(0, 0, Camera.main.transform.position.z)) > 0.01f)
            {
                Camera.main.transform.position = GetAnimManager(actualSceneIndex + 1).transform.position + new Vector3(0, 0, Camera.main.transform.position.z);
                StartCoroutine(GoOutFade());
                inFade = false;

            }
        }
    }

    IEnumerator GoInFade()
    {
        yield return new WaitForSeconds(1);
        fadeState = true;
    }

    IEnumerator GoOutFade()
    {
        yield return new WaitForSeconds(1);
        actualSceneManager = GetAnimManager(actualSceneIndex + 1);
        actualSceneIndex++;
        fadeState = false;
    }

    AnimManager GetAnimManager(int index)
    {

        foreach (AnimManager animMng in GameObject.FindObjectsOfType<AnimManager>())
        {
            if (animMng.sceneIndex == index)
            {
                return animMng;

            }
        }
        return null;
    }
}
