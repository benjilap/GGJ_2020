using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpriteDrag : MonoBehaviour
{
    float startPosX;
    float startPosY;
    Vector3 mousePos;

    private void OnMouseDown()
    {
        if (Vector2.Distance(this.transform.position, this.transform.parent.position) > 0.1f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                startPosX = mousePos.x - this.transform.localPosition.x;
                startPosY = mousePos.y - this.transform.localPosition.y;
            }
        }
    }

    public void OnMouseDrag()
    {
        if (Vector2.Distance(this.transform.position, this.transform.parent.position) > 0.1f)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }
}
