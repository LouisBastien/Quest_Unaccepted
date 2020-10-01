using System.Collections;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    public Animator anim;

    public void Start()
    {
        anim.GetComponent<Animator>();
    }

    public void ActivateSpell(bool state)
    {
        GetComponent<BoxCollider2D>().enabled = true;
        anim.SetBool("Spell_activated", state);
        StartCoroutine(Wait(0.05f));
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("Spell_activated", false);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PNJ"))
        {
            other.gameObject.GetComponent<PnjController>().SetCanMove(false);
        }
    }
}
