using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {
	public Vector3 direction;
    Vector3 startpt;
    Vector3 endpt;

    bool forward;
    Animator animator;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        startpt = transform.position;
        endpt = transform.position + direction * 5;
        forward = true;
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.z > endpt.z)
        {
            animator.SetBool("move", false);
            transform.Rotate(new Vector3(0, 180, 0));
            forward = false;
            animator.SetBool("move", true);
            transform.position += Time.deltaTime * -direction * 2;
        }
        else if (transform.position.z < startpt.z)
        {
            animator.SetBool("move", false);
            transform.Rotate(new Vector3(0, 180, 0));
            forward = true;
            animator.SetBool("move", true);
            transform.position += Time.deltaTime * direction * 2;
        }
        else
        {
            animator.SetBool("move", true);
            if (forward == true)
                transform.position += Time.deltaTime * direction;
            else
                transform.position += Time.deltaTime * -direction;
        }
    }
}
