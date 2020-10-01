using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Animator anim;
    public GameObject spell;
    public GameObject spellActivatedImage;
    public GameObject spellUnactivatedImage;

    private bool canUseSpell = false;

    // Use this for initialization
    public void Start()
    {
        anim = GetComponent<Animator>();
        spell.GetComponent<SpellController>();
        StartCoroutine(Wait(5f));
    }

    // Update is called once per frame
    public void Update()
    {
        if (GameManager.onPause == false)
        {
            anim.SetBool("Barbare_isMoving", false);
            anim.SetInteger("Barbare_Orientation", 4);

            var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            if (canUseSpell)
            {
                spellActivatedImage.SetActive(true);
                spellUnactivatedImage.SetActive(false);
            }
            else
            {
                spellActivatedImage.SetActive(false);
                spellUnactivatedImage.SetActive(true);
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
                if (canUseSpell)
                {
                    spell.SendMessage("ActivateSpell", true);
                    canUseSpell = false;
                    StartCoroutine(Wait(5));
                }
            }
        }
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canUseSpell = true;
    }
}
