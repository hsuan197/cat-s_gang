using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlane : MonoBehaviour {

    Renderer rend;
    int nowBuildingID;

    void Awake() {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
    }

    void OnMouseEnter() {
        if (BaseBuild.building)
            rend.material.color = Color.green;
        else
            rend.material.color = Color.yellow;
    }
    void OnMouseExit() {
        rend.material.color = Color.white;
    }

    void OnMouseUp() {
        if (BaseBuild.building) {
            if (transform.childCount > 0)
            {
                Destroy(transform.GetChild(0).gameObject);
                ShareData.buildingNum[nowBuildingID] -= 1;
            }

            Transform newItem = Instantiate (BaseBuild.selectItem) ;
            newItem.parent = transform;
            newItem.localPosition = Vector3.zero;

            BaseBuild.building = false;
            ShareData.buildingNum[BaseBuild.buildingID] += 1;
            nowBuildingID = BaseBuild.buildingID;

            StatuBar.sb.UpdateStatu();
        }
    }
}