using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairMusicBox : MonoBehaviour
{
    Object effectExplo;

    private void Start()
    {
        effectExplo = Resources.Load("Effect/Explo");
    }

    private void Update()
    {
        CheckPiece();
    }

    bool BodyInPlace()
    {
        Debug.Log(Vector2.Distance(this.transform.Find("Dress" + "Anchor").GetChild(0).position, this.transform.Find("Dress" + "Anchor").position));
        if (Vector2.Distance(this.transform.Find("Dress" + "Anchor").GetChild(0).position, this.transform.Find("Dress" + "Anchor").position) <= 0.1f)
        {
            Debug.Log("Dress");
            this.transform.Find("Dress" + "Anchor").GetChild(0).localPosition = Vector3.zero;
            if (this.transform.Find("Dress" + "Anchor").GetChild(0).GetComponent<SpriteDrag>().enabled)
            {
                GameObject newEffect = Instantiate(effectExplo, this.transform.Find("Dress" + "Anchor"), true) as GameObject;
                newEffect.transform.position = this.transform.Find("Dress" + "Anchor").position;
            }
            this.transform.Find("Dress" + "Anchor").GetChild(0).GetComponent<SpriteDrag>().enabled = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    bool ArmsInPlace()
    {
        Debug.Log(Vector2.Distance(this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").GetChild(0).position, this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").position));
        if (Vector2.Distance(this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").GetChild(0).position, this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").position) <= 0.1f)
        {
            Debug.Log("Arms");
            this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").GetChild(0).localPosition = Vector3.zero;
            if (this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").GetChild(0).GetComponent<SpriteDrag>().enabled)
            {
                GameObject newEffect = Instantiate(effectExplo, this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor"), true) as GameObject;
                newEffect.transform.position = this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").position;
            }
            this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").GetChild(0).GetComponent<SpriteDrag>().enabled = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    bool HeadInPlace()
    {
        Debug.Log(Vector2.Distance(this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").Find("Head" + "Anchor").GetChild(0).position, this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").Find("Head" + "Anchor").position));
        if (Vector2.Distance(this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").Find("Head" + "Anchor").GetChild(0).position, this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").Find("Head" + "Anchor").position) <= 0.1f)
        {

            this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").Find("Head" + "Anchor").GetChild(0).localPosition = Vector3.zero;
            if (this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").Find("Head" + "Anchor").GetChild(0).GetComponent<SpriteDrag>().enabled)
            {
                GameObject newEffect = Instantiate(effectExplo, this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").Find("Head" + "Anchor"), true) as GameObject;
                newEffect.transform.position = this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").Find("Head" + "Anchor").position;
            }
            this.transform.Find("Dress" + "Anchor").Find("Arms" + "Anchor").Find("Head" + "Anchor").GetChild(0).GetComponent<SpriteDrag>().enabled = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    void CheckPiece()
    {
        int counter = Increment(BodyInPlace()) + Increment(ArmsInPlace()) + Increment(HeadInPlace());
        if (counter == 3)
        {
            this.transform.parent.GetComponent<AnimManager>().sceneFinished = true;
        }
    }

    int Increment(bool piecePlaced)
    {
        if (piecePlaced)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
