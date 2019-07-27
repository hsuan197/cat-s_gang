using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrassNum : MonoBehaviour {

    Text text;
    public static GrassNum graNum;

	void Start () {
        graNum = this;
        text = GetComponent<Text>();
        text.text = "x" + ShareData.grass.ToString();
	}

    public void UpdateNum() {
        text.text = "x" + ShareData.grass.ToString();
    }
}
