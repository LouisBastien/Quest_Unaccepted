using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {
        anim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spell_activated(bool state)
    {
        anim.SetBool("Spell_activated", state);
        StartCoroutine(Wait(0.05f));
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("Spell_activated", false);
    }
}
