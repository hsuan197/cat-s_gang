using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCats : MonoBehaviour {

	public ShareData.Cat cat_id;
	public bool inMyGang = false;
    public bool rainbow = false;

	public string name;
	public int level, fame, makeMoneyRate, getFoodRate, colorid;
	public int job = -1;

	public bool finishJob = false;

	public Renderer rend;

	void Start(){
		rend = GetComponentInChildren<Renderer> ();
		tag = "Cat";
		rend.material = AllCat.catscon.mat [colorid];
	}

    public void Grass() {
        rend.material = AllCat.catscon.mat[5];
        Invoke("GrassEnd", 10);
        rainbow = true;
    }
    public void GrassEnd() {
        rend.material = AllCat.catscon.mat[colorid];
        rainbow = false;
    }

}
