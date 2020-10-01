using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjController : MonoBehaviour {

    public Transform target;
    public Transform myTransform;
    public GameObject popup;
    public Transform popupParent;
    public Animator anim;

    private readonly int moveSpeed = 4;
    private int questCount = 0;
    private bool canMove = true;

    private string npcName;
    private string npcWork;

    private IEnumerator coroutine;
    private bool canPopup = true;
    private bool justSpawn = true;
    private int sortingOrder = 10;

    public AudioSource mAudio;

    public void Awake()
    {
        myTransform = transform;
        popupParent = GameObject.Find("PopupParent").transform;
    }

    public void Start()
    {
        mAudio = GetComponent<AudioSource>();

        NameGenerator nameGenerator = new NameGenerator();
        npcName = nameGenerator.GenerateName();

        WorkGenerator workGenerator = new WorkGenerator();
        npcWork = workGenerator.GenerateWork();

        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    public void Update () {
        if (GameManager.onPause == false)
        {
            if (questCount == 0 && justSpawn == false)
            {
                Destroy(this.gameObject);
            }

            if (canMove)
            {
                int x = Mathf.RoundToInt(target.transform.position.x - transform.position.x);
                int y = Mathf.RoundToInt(target.transform.position.y - transform.position.y);

                if (x > 0 && y == 0)
                {
                    anim.SetInteger("Orientation", 1);
                    myTransform.position = Vector2.MoveTowards(myTransform.position, target.transform.position, moveSpeed * Time.deltaTime);
                }
                else if (x > 0 && y > 0)
                {
                    anim.SetInteger("Orientation", 2);
                    myTransform.position = Vector2.MoveTowards(myTransform.position, target.transform.position, moveSpeed * Time.deltaTime);
                }
                else if (x == 0 && y > 0)
                {
                    anim.SetInteger("Orientation", 2);
                    myTransform.position = Vector2.MoveTowards(myTransform.position, target.transform.position, moveSpeed * Time.deltaTime);
                }
                else if (x < 0 && y > 0)
                {
                    anim.SetInteger("Orientation", 2);
                    myTransform.position = Vector2.MoveTowards(myTransform.position, target.transform.position, moveSpeed * Time.deltaTime);
                }
                else if (x == 0 && y < 0)
                {
                    anim.SetInteger("Orientation", 0);
                    myTransform.position = Vector2.MoveTowards(myTransform.position, target.transform.position, moveSpeed * Time.deltaTime);
                }
                else if (x < 0 && y < 0)
                {
                    anim.SetInteger("Orientation", 0);
                    myTransform.position = Vector2.MoveTowards(myTransform.position, target.transform.position, moveSpeed * Time.deltaTime);
                }
                else if (x < 0 && y == 0)
                {
                    anim.SetInteger("Orientation", 3);
                    myTransform.position = Vector2.MoveTowards(myTransform.position, target.transform.position, moveSpeed * Time.deltaTime);
                }
                else if (x > 0 && y < 0)
                {
                    anim.SetInteger("Orientation", 0);
                    myTransform.position = Vector2.MoveTowards(myTransform.position, target.transform.position, moveSpeed * Time.deltaTime);
                }
                else
                {
                    myTransform.position = Vector2.MoveTowards(myTransform.position, target.transform.position, moveSpeed * Time.deltaTime);
                }
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (GameManager.onPause == false)
        {
            if (coll.gameObject.tag == "Player")
            {
                Vector3 position = new Vector3(Random.Range(-9, 9), Random.Range(-4, 4), 0);
                GameObject go = Instantiate(popup, position, Quaternion.identity, popupParent);
                go.GetComponent<PopupController>();
                go.SendMessage("SetNPCName", npcName);
                go.SendMessage("SetNPCWork", npcWork);
                go.SendMessage("SetSortingOrder", sortingOrder);
                go.SendMessage("SetNPC", this.gameObject);
                mAudio.Play();
                sortingOrder++;
                coroutine = WaitAndPopup(2.0f, coll);
                StartCoroutine(coroutine);
                canPopup = false;
                questCount++;
                justSpawn = false;
            }
        }
    }

    public void OnCollisionStay2D(Collision2D coll)
    {
        if (GameManager.onPause == false)
        {
            if (coll.gameObject.tag == "Player" && canPopup == true)
            {
                Vector3 position = new Vector3(Random.Range(-9, 9), Random.Range(-4, 4), 0);
                GameObject go = Instantiate(popup, position, Quaternion.identity, popupParent);
                go.GetComponent<PopupController>();
                go.SendMessage("SetNPCName", npcName);
                go.SendMessage("SetNPCWork", npcWork);
                go.SendMessage("SetSortingOrder", sortingOrder);
                go.SendMessage("SetNPC", this.gameObject);
                mAudio.Play();
                sortingOrder++;
                coroutine = WaitAndPopup(2.0f, coll);
                StartCoroutine(coroutine);
                canPopup = false;
                questCount++;
            }
        }
    }

    private IEnumerator WaitAndPopup(float waitTime, Collision2D coll)
    {   
        yield return new WaitForSeconds(waitTime);
        canPopup = true;
    }

    public void PopupDestroy(string msg)
    {
        questCount--;
    }

    public void SetCanMove(bool newCanMove)
    {
        canMove = newCanMove;
        StartCoroutine(WaitCanMove());
    }

    private IEnumerator WaitCanMove()
    {
        yield return new WaitForSeconds(2.0f);
        canMove = true;
    }
}