using UnityEngine;
using System.Collections;

public class BumperScript : MonoBehaviour
{

    public int bumperForce = 25;
	private Animator animator;

	void Start(){
		animator = GetComponent<Animator>();
	}

    public void Bump()
    {
		animator.SetTrigger("Bump");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
