using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public GameObject[] cam1;
    public GameObject[] cam2;
    bool cam1Acti;


    void Start () {
        cam1Acti = true;
        foreach (GameObject obj in cam1) {
            obj.SetActive(true);
        }
        foreach (GameObject obj in cam2) {
            obj.SetActive(false);
        }
	}

    public void change() {
        bool cam2Acti = cam1Acti;
        cam1Acti = !cam1Acti;
        foreach (GameObject obj in cam1)
        {
            obj.SetActive(cam1Acti);
        }
        foreach (GameObject obj in cam2)
        {
            obj.SetActive(cam2Acti);
        }
    }
}
