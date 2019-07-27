using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class CreateMyCat : MonoBehaviour {

	Renderer rend;
	public Material[] material;
	public InputField inputF;
	int colorid;

	void Awake(){
		rend = GetComponentInChildren<Renderer> ();
	}

	public void ChangeColor(int id){
		rend.material = material[id];
		colorid = id;
	}

	public void OkClick(){
		if (inputF.text != null) {
			ShareData.material_id = colorid;
			ShareData.name = inputF.text;
		}
		SceneManager.LoadScene (1);
	}
}
