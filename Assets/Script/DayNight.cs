using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {

	public Material[] skybox;
	Skybox sky;
	public int ChangePeriod;
	int nowTime;

    public GenFish genfish1;
    public GenFish genfish2;

	void Start () {
		sky = GetComponent<Skybox> ();
		nowTime = 0;
		sky.material = skybox [0];
		InvokeRepeating ("Change", ChangePeriod, ChangePeriod);
	}

	void Change(){
		if (++nowTime > 4) {
			nowTime = 0;
			foreach (OtherCats cat in ShareData.streetCats) {
				if (cat.job > -1) {
					cat.finishJob = true;
				}
			}

			ShareData.food -= ShareData.dailyConsume ();
			if (ShareData.food < 0) {
				Debug.Log ("QQ");
			}

            genfish1.gen();
            genfish2.gen();

            ShareData.energy = ShareData.max_energy();
			StatuBar.sb.UpdateStatu ();
		}
		sky.material = skybox [nowTime];
	}
		
	void Update () {
		if (Input.GetKeyUp(KeyCode.Z)) {
			Change ();
		}
	}
}
