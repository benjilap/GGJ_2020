using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestruction : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 3);
    }

}
