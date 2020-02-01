using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public int sceneIndex;
    public bool sceneFinished;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExecuteScene()
    {
        if (this.GetComponent<Animator>())
        {
            this.GetComponent<Animator>().SetTrigger("StartAnim");
        }
    }
}
