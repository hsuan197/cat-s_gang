using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Controllers : MonoBehaviour {
    public Vector3 direction;
    public float speed;
    Animator animator;
    void Awake()
    {
    }
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        animator.SetBool("move", false);
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += speed * Time.deltaTime * Vector3.forward;
            animator.SetBool("move", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += speed * Time.deltaTime * Vector3.left;
            animator.SetBool("move", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * Time.deltaTime * Vector3.right;
            animator.SetBool("move", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += speed * Time.deltaTime * Vector3.back;
            animator.SetBool("move", true);
        }
    }
}
