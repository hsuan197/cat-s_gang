using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fightingBar : MonoBehaviour {

    Image img;
    void Awake() {
        img = GetComponent<Image>();
        img.fillAmount = 0;
    }

    public float fillAm() {
        return img.fillAmount;
    }

    public void ResetFill() {
        img.fillAmount = 0;
    }

    public void AddFillAmount(float val) {
        img.fillAmount += val;
    }
}
