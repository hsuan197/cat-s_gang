using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCat : MonoBehaviour {

	public Material[] mat;
	public static AllCat catscon;

	void Awake(){
		catscon = this;
	}
}