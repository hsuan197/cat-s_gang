using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuild : MonoBehaviour {

    public Transform[] item;
    public static Transform selectItem;
    public static bool building = false;
    public static int buildingID;
    public int[] money;

    public void SelectItem(int id) {
        if (ShareData.money >= money[id])
        {
            ShareData.money -= money[id];
            StatuBar.sb.UpdateStatu();

            selectItem = item[id];
            building = true;
            buildingID = id;
        }
        else
            buildingID = -1;
    }
}