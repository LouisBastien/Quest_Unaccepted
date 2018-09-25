using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjController : MonoBehaviour {

    public Transform target;
    public Transform myTransform;
    public GameObject popup;
    public Animator anim;

    private int moveSpeed = 4;
    private int questCount = 0;

    private string mName;
    private string mWork;

    private IEnumerator coroutine;
    private bool canPopup = true;
    private bool justSpawn = true;
    private int mSortingOrder = 10;

    public AudioSource mAudio;

    private List<GameObject> listePopup;

    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        mAudio = GetComponent<AudioSource>();

        NameGenerator nameGenerator = new NameGenerator();
        mName = nameGenerator.generateName();

        WorkGenerator workGenerator = new WorkGenerator();
        mWork = workGenerator.generateWork();

        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

	void Update () {
        if (GameManager.onPause == false)
        {

/*            if (Input.GetKey(KeyCode.KeypadEnter))
            {
                destroyMe();
            } */

            if (questCount == 0 && justSpawn == false)
            {
                Destroy(this.gameObject);
            }

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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (GameManager.onPause == false)
        {
            if (coll.gameObject.tag == "Player")
            {
                Vector3 position = new Vector3(Random.Range(-9, 9), Random.Range(-4, 4), 0);
                GameObject go = Instantiate(popup, position, Quaternion.identity);
                go.GetComponent<PopupController>();
                go.SendMessage("setPnjName", mName);
                go.SendMessage("setPnjWork", mWork);
                go.SendMessage("setSortingOrder", mSortingOrder);
                go.SendMessage("setNPC", this.gameObject);
                //                listePopup.Add(go);
                mAudio.Play();
                mSortingOrder++;
                coroutine = WaitAndPopup(2.0f, coll);
                StartCoroutine(coroutine);
                canPopup = false;
                questCount++;
                justSpawn = false;
            }
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (GameManager.onPause == false)
        {
            if (coll.gameObject.tag == "Player" && canPopup == true)
            {
                Vector3 position = new Vector3(Random.Range(-9, 9), Random.Range(-4, 4), 0);
                GameObject go = Instantiate(popup, position, Quaternion.identity);
                go.GetComponent<PopupController>();
                go.SendMessage("setPnjName", mName);
                go.SendMessage("setPnjWork", mWork);
                go.SendMessage("setSortingOrder", mSortingOrder);
                go.SendMessage("setNPC", this.gameObject);
                //                listePopup.Add(go);
                mAudio.Play();
                mSortingOrder++;
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

    public void popupDestroy(string msg)
    {
        questCount--;
    }

    private void destroyMe()
    {
/*        int x = 0;

        while (listePopup[x])
        {
            x++;
        }
        print(x);
*/
        Destroy(this.gameObject);
    }
}