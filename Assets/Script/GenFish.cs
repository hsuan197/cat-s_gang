using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenFish : MonoBehaviour {


    public Transform fish;

    public void gen() {
        for (int i = 0; i < 3; i++)
        {
            Transform T = Instantiate(fish);
            T.parent = transform;
            Vector3 pos = Vector3.zero;
            pos.y = 0.5f;
            T.localPosition = pos;
        }
    }
}
