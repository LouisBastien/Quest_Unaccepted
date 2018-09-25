using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Animator anim;
    public GameObject Spell;
    public GameObject Spell_image_activated;
    public GameObject Spell_image_unactivated;

    private bool inBoundary;
    private bool Spell_canUse = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Spell.GetComponent<SpellController>();
        StartCoroutine(Wait(5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.onPause == false)
        {
            anim.SetBool("Barbare_isMoving", false);
            anim.SetInteger("Barbare_Orientation", 4);

            var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            if (Spell_canUse)
            {
                Spell_image_activated.SetActive(true);
                Spell_image_unactivated.SetActive(false);
            }
            else
            {
                Spell_image_activated.SetActive(false);
                Spell_image_unactivated.SetActive(true);
            }

            if (x > 0 && y == 0)
            {
                anim.SetBool("Barbare_isMoving", true);
                anim.SetInteger("Barbare_Orientation", 1);
                transform.Translate(x, y, 0);
            }
            else if (x > 0 && y > 0)
            {
                anim.SetBool("Barbare_isMoving", true);
                anim.SetInteger("Barbare_Orientation", 2);
                transform.Translate(x, y, 0);
            }
            else if (x == 0 && y > 0)
            {
                anim.SetBool("Barbare_isMoving", true);
                anim.SetInteger("Barbare_Orientation", 2);
                transform.Translate(x, y, 0);
            }
            else if (x < 0 && y > 0)
            {
                anim.SetBool("Barbare_isMoving", true);
                anim.SetInteger("Barbare_Orientation", 2);
                transform.Translate(x, y, 0);
            }
            else if (x == 0 && y < 0)
            {
                anim.SetBool("Barbare_isMoving", true);
                anim.SetInteger("Barbare_Orientation", 0);
                transform.Translate(x, y, 0);
            }
            else if (x < 0 && y < 0)
            {
                anim.SetBool("Barbare_isMoving", true);
                anim.SetInteger("Barbare_Orientation", 0);
                transform.Translate(x, y, 0);
            }
            else if (x < 0 && y == 0)
            {
                anim.SetBool("Barbare_isMoving", true);
                anim.SetInteger("Barbare_Orientation", 3);
                transform.Translate(x, y, 0);
            }
            else if (x > 0 && y < 0)
            {
                anim.SetBool("Barbare_isMoving", true);
                anim.SetInteger("Barbare_Orientation", 0);
                transform.Translate(x, y, 0);
            }
            else
            {
                transform.Translate(x, y, 0);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (Spell_canUse)
                {
                    Spell.SendMessage("spell_activated", true);
                    Spell_canUse = false;
                    StartCoroutine(Wait(5));
                }
            }
        }
    }

    private IEnumerator Wait(float waitTime)
    {
            yield return new WaitForSeconds(waitTime);
            Spell_canUse = true;
    }
}
