using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShareData {

	public struct Cat
	{
		public string name;
		public int level;
		public int fame;
		public int makeMoneyRate;
		public int getFoodRate;
		public int colorid;
	}
	public static List<Cat> catlist = new List<Cat> ();
	public static List<OtherCats> streetCats = new List<OtherCats>();

	public static int material_id = 0;

	public static string name;
	public static int food = 300;
	public static int money = 1000;
	public static int level = 1;
	public static int fame = 100;
    public static int grass = 0;
    public static int energy = 5;
    public static int[] itemcost = {20, 50, 200, 500, 100, 100};

    public static int[] buildingNum = new int[6];

    public static int max_energy() {
        return 5 + buildingNum[4];
    }

	public static int max_money(){
        return 10000;
        //return level * 100 + fame;
	}

	public static int max_food(){
		return 5000;
	}

	public static int dailyConsume(){
		return streetCats.Count - buildingNum[5] * 1000;
	}

	public static void add_catlist(Cat newcat){
		catlist.Add (newcat);
	}

    public static int robHuman(int humanLevel, int humanMoney) {
        return humanMoney;
    }
}