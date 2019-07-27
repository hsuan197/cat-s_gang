using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFood : MonoBehaviour {

    public int increse_num = 10;
    
    void OnMouseUp() {
        ShareData.food += increse_num;
        if (ShareData.food > ShareData.max_food())
            ShareData.food = ShareData.max_food();

        StatuBar.sb.UpdateStatu();
        Destroy(this.gameObject);
    }
}
