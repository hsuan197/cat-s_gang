using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityCatControl : MonoBehaviour {

	Renderer rend;
	private Animator animator;
	private Transform camaraT;
	private Vector3 direction;
	public int moving_speed;

	public float rotation_control;
	private float initial_r;
	private float final_r;

	public RectTransform talk;

	public GameObject workBar;
	public GameObject buyBar;
    static public CityCatControl player;

    public GameObject fightBar;
    fightingBar fightControl;

    [SerializeField] int fightStatu;
    OtherCats fightingCat;
    public GameObject fightParticle;

	void Start(){
		rend = GetComponentInChildren<Renderer> ();
		animator = GetComponent<Animator> ();
		rend.material = AllCat.catscon.mat [ShareData.material_id];
        player = this;
        fightControl = fightBar.GetComponentInChildren<fightingBar>();
        fightStatu = 0;
	}

	void Update () {

        if (fightStatu == 2) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fightControl.AddFillAmount(0.07f);
            }
            return;
        }

        animator.SetBool("move", false);
		direction.x = 0;
		direction.y = 0;
		direction.z = 0;

        if (transform.position.y < -2) {
            transform.position = new Vector3(145, 2.287412f, 180);
        }

		if (Input.GetKey(KeyCode.W))
		{
			direction.x += Mathf.Sin(transform.localRotation.eulerAngles.y * Mathf.Deg2Rad);
			direction.z += Mathf.Cos(transform.localRotation.eulerAngles.y * Mathf.Deg2Rad);
			animator.SetBool("move", true);
		}
		if (Input.GetKey(KeyCode.S))
		{
			direction.x += Mathf.Sin((transform.localRotation.eulerAngles.y + 180) * Mathf.Deg2Rad);
			direction.z += Mathf.Cos((transform.localRotation.eulerAngles.y + 180) * Mathf.Deg2Rad);
			animator.SetBool("move", true);
		}
		if (Input.GetKey(KeyCode.A))
		{
			direction.x += Mathf.Sin((transform.localRotation.eulerAngles.y - 90) * Mathf.Deg2Rad);
			direction.z += Mathf.Cos((transform.localRotation.eulerAngles.y - 90) * Mathf.Deg2Rad);
			animator.SetBool("move", true);
		}
		if (Input.GetKey(KeyCode.D))
		{
			direction.x += Mathf.Sin((transform.localRotation.eulerAngles.y + 90) * Mathf.Deg2Rad);
			direction.z += Mathf.Cos((transform.localRotation.eulerAngles.y + 90) * Mathf.Deg2Rad);
			animator.SetBool("move", true);
		}
        if (fightStatu == 1) {
            float distance = Vector3.Distance(fightingCat.transform.position, transform.position);
            if (distance > 3)
            {
                direction = Vector3.Normalize(fightingCat.transform.position - transform.position);
                animator.SetBool("Run", true);
            }
            else {
                animator.SetBool("Run", false);
                fightStatu = 2;
                fightParticle.SetActive(true);
                fightBar.SetActive(true);
                fightControl.ResetFill();
                if (fightingCat.rainbow)
                    fightControl.AddFillAmount(0.5f);
                Invoke("endFight", 2.5f);
                fightParticle.SetActive(true);
            }
        }

		if (animator.GetBool("move"))
		{
			transform.localPosition += moving_speed * Time.deltaTime * direction;
		}
        if (animator.GetBool("Run"))
        {
            transform.localPosition += moving_speed * Time.deltaTime * direction * 1.8f;
        }

        if (Input.GetMouseButtonDown(1))
		{
			initial_r = Input.mousePosition.x;
		}
		if (Input.GetMouseButton(1))
		{
			final_r = Input.mousePosition.x;
			Vector3 new_diraction = transform.localRotation.eulerAngles;
			new_diraction.y += (final_r - initial_r) * rotation_control;
			transform.localRotation = Quaternion.Euler(new_diraction);
		}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit raycasthit;
		if (Physics.Raycast(ray, out raycasthit))
		{
			if (string.Equals (raycasthit.collider.tag, "Cat")) {
				talk.gameObject.SetActive (true);
				talk.position = Input.mousePosition;
				if (Input.GetMouseButtonUp(0)) {
					TalkingBarControl.catTalkingBar.CatTalk (raycasthit.collider.GetComponent<OtherCats> ());
				}
			}
            else if (string.Equals(raycasthit.collider.tag, "Human")) {
                talk.gameObject.SetActive(true);
                talk.position = Input.mousePosition;
                if (Input.GetMouseButtonUp(0))
                {
                    TalkingBarControl.catTalkingBar.HumanTalk(raycasthit.collider.GetComponent<HumanControl>());
                }
            }
            else
            {
                talk.gameObject.SetActive(false);
            }
        }
        else {
			talk.gameObject.SetActive (false);
		}
	}

    public void fighting(OtherCats cat) {
        fightStatu = 1;
        fightingCat = cat;
    }

    void endFight() {
        fightStatu = 0;
        fightParticle.SetActive(false);
        fightBar.SetActive(false);
        if (fightControl.fillAm() == 1)
        {
            fightingCat.inMyGang = true;
            ShareData.streetCats.Add(fightingCat);
        }
    }
}
