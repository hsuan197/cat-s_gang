using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingBarControl : MonoBehaviour {

	public static TalkingBarControl catTalkingBar;
	public GameObject workBar;
	public GameObject buyBar;
	private OtherCats nowCat;

	public Text buyCatUIContant;
	public GameObject buyCatOK;
    public GameObject buyCatCha;
	public GameObject buyCatUI;

	public GameObject selectJobUI;
	public GameObject getBtn;

    public GameObject humanPop;
    private HumanControl nowHuman;

	void Awake(){
		catTalkingBar = this;
	}

	public void CatTalk(OtherCats cat){
		nowCat = cat;
		if (cat.inMyGang) {
			CleanBars ();
			Text text = workBar.GetComponentInChildren<Text> ();
			text.text = "Name:\t\t" + cat.name + "\n\nLevel:\t\t" + cat.level.ToString ();
			text.text += "\n\nFood:\t\t" + cat.getFoodRate + "/day\n";
			text.text += "Money:\t\t" + cat.makeMoneyRate + "/day\n";
			text.text += "Fame:\t\t" + cat.fame;
			text.text += "\nWork:\t\t";
			switch (nowCat.job) {
			case -1:
				text.text += "未指派";
				break;
			case 0:
				text.text += "找食物";
				break;
			case 1:
				text.text += "賺錢";
				break;
			case 2:
				text.text += "巡邏";
				break;
			}
			if (cat.finishJob) {
				getBtn.SetActive (true);
			} else {
				getBtn.SetActive (false);
			}

			workBar.SetActive (true);
		} else {
			CleanBars ();
			Text text = buyBar.GetComponentInChildren<Text> ();
			text.text = "Name:\t\t" + cat.name + "\n\nLevel:\t\t" + cat.level.ToString ();
			buyBar.SetActive (true);
		}		
	}

	public void CleanBars(){
		workBar.SetActive (false);
		buyBar.SetActive (false);
		buyCatUI.SetActive (false);
		selectJobUI.SetActive (false);
        humanPop.SetActive(false);
	}

	public void BuyTheCat(){
		int needFood, needMoney, needFame;
		needFood = nowCat.getFoodRate * 5;
		needMoney = nowCat.makeMoneyRate * 5;
		needFame = nowCat.fame * 2;

        buyCatCha.SetActive((ShareData.energy > 0)?true:false);
		if (ShareData.food < needFood || ShareData.money < needMoney || ShareData.fame < needFame) {
			buyCatUIContant.text = "目前無法收買此貓貓\n\n";
			buyCatUI.SetActive (true);
			buyCatOK.SetActive (false);
		} else {
			buyCatUIContant.text = "收買貓貓需要下列道具:\n\n";
			buyCatUIContant.text += "食物:\t\t" + needFood.ToString ();
			buyCatUIContant.text += "\n金錢:\t\t" + needMoney.ToString ();
			buyCatUI.SetActive (true);
			buyCatOK.SetActive (true);
		}
	}

	public void BuyTheCatOK(){
		ShareData.food -= nowCat.getFoodRate * 5;
		ShareData.money -= nowCat.makeMoneyRate * 5;
		nowCat.inMyGang = true;
		ShareData.streetCats.Add (nowCat);

		StatuBar.sb.UpdateStatu ();
		CleanBars ();
	}

    public void ChallengeCat() {
         ShareData.energy -= 1;
         CityCatControl.player.fighting(nowCat);
         CleanBars();
         StatuBar.sb.UpdateStatu();
    }

	public void SelectJobShow(){
		selectJobUI.SetActive (true);
	}

	public void SelectJobOK(int num){
		CleanBars ();
		nowCat.job = num;
	}
	public void GetBtnClick(){
		nowCat.finishJob = false;
		getBtn.SetActive (false);
        switch (nowCat.job) {
            case 0:
                ShareData.food += nowCat.getFoodRate + ShareData.buildingNum[0] * 2 + ShareData.buildingNum[2] * 20;
                if (ShareData.food > ShareData.max_food())
                    ShareData.food = ShareData.max_food();
                break;
            case 1:
                ShareData.money += nowCat.makeMoneyRate + ShareData.buildingNum[1] * 2 + ShareData.buildingNum[3] * 20;
                if (ShareData.money > ShareData.max_money())
                    ShareData.money = ShareData.max_money();
			break;
		}
		StatuBar.sb.UpdateStatu ();
	}
    public void HumanTalk(HumanControl human)
    {
        humanPop.SetActive(true);
        nowHuman = human;
    }
    public void HumanTalkBtn(int num) {
        if (num == 0 && ShareData.energy > 0)
        {
            --ShareData.energy;
            int getMoney = ShareData.robHuman(nowHuman.level, nowHuman.money);
            ShareData.money += getMoney;
            nowHuman.money -= getMoney;
            StatuBar.sb.UpdateStatu();
        }
        else if(ShareData.energy > 1)
        {
            ShareData.energy -= 2;
            StatuBar.sb.UpdateStatu();
        }
        CleanBars();
    }

    public void Item() {
        if (ShareData.grass > 0)
        {
            nowCat.Grass();
            ShareData.grass -= 1;
            GrassNum.graNum.UpdateNum();
        }
    }
}