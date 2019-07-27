using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrassShop : MonoBehaviour {

    public GameObject window;
    public GrassNum grassNum;

    public void Click() {
        window.SetActive(true);
    }

    public void CancelClick() {
        window.SetActive(false);
    }

    public void BuyClick() {
        if (ShareData.money >= 1000) {
            ShareData.money -= 1000;
            ShareData.grass += 1;
            grassNum.UpdateNum();
            StatuBar.sb.UpdateStatu();
        }
    }
}
