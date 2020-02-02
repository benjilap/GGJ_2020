using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairFamilyPict : MonoBehaviour
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

    bool PieceInPlace(string bodyPart)
    {
        Debug.Log(Vector2.Distance(this.transform.Find(bodyPart + "Anchor").GetChild(0).position, this.transform.Find(bodyPart + "Anchor").position));
        if (Vector2.Distance(this.transform.Find(bodyPart + "Anchor").GetChild(0).position, this.transform.Find(bodyPart + "Anchor").position) <= 0.1f)
        {
            Debug.Log(bodyPart);
            this.transform.Find(bodyPart + "Anchor").GetChild(0).localPosition = Vector3.zero;
            if (this.transform.Find(bodyPart + "Anchor").GetChild(0).GetComponent<SpriteDrag>().enabled)
            {
                GameObject newEffect = Instantiate(effectExplo, this.transform.Find(bodyPart + "Anchor"), true) as GameObject;
                newEffect.transform.position = this.transform.Find(bodyPart + "Anchor").position;
            }
            this.transform.Find(bodyPart + "Anchor").GetChild(0).GetComponent<SpriteDrag>().enabled = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    void CheckPiece()
    {
        int counter = Increment(PieceInPlace("PictPart1")) + Increment(PieceInPlace("PictPart2")) + Increment(PieceInPlace("PictPart3")) + Increment(PieceInPlace("PictPart4"));
        if (counter == 4)
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
