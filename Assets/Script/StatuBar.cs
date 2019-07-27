using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatuBar : MonoBehaviour {

	public Text energyT, moneyT, foodT;
	public Image energyF, moneyF, foodF;
	public static StatuBar sb;

	void Awake(){
		sb = this;
		UpdateStatu ();
	}

	public void UpdateStatu(){
		energyT.text = ShareData.energy.ToString() + " / " + ShareData.max_energy();
		moneyT.text = ShareData.money.ToString();
		foodT.text = ShareData.food.ToString();

        energyF.fillAmount = (float)ShareData.energy / ShareData.max_energy();
        moneyF.fillAmount = (float)ShareData.money / ShareData.max_money ();
		foodF.fillAmount = (float)ShareData.food / ShareData.max_food ();
	}
}
