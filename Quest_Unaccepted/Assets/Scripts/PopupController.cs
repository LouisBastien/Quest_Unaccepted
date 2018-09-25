using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour {

    private static int TEXT_NAME = 0;
    private static int TEXT_WORK = 1;
    private static int TEXT_QUEST = 2;
    private Text[] mTextTab;

    private string PnjName;
    private string PnjWork;
    private int mSortingOrder;

    private GameObject npc;

    public GameObject obj;
    public Renderer mRenderer;
    public Canvas mCanvas;
        
    void Start()
    {
        QuestGenerator questGenerator = new QuestGenerator();

        mTextTab = GetComponentsInChildren<Text>();
        mTextTab[TEXT_NAME].text = PnjName;
        mTextTab[TEXT_WORK].text = PnjWork;
        mTextTab[TEXT_QUEST].text = questGenerator.generateQuest();
        mRenderer.sortingOrder = mSortingOrder;
        mCanvas.sortingOrder = mSortingOrder;
    }

    public void setPnjName(string name)
    {
        PnjName = name;
    }

    public void setPnjWork(string work)
    {
        PnjWork = work;
    }

    public void setSortingOrder(int order)
    {
        mSortingOrder = order;
    }

    public void setNPC(GameObject NPC)
    {
        npc = NPC;
    }

    public void acceptQuest()
    {
        if (GameManager.onPause == false)
        {
            GameManager.Instance.SendMessage("OnDefeat");
        }
    }

    public void declineQuest()
    {
        if (GameManager.onPause == false)
        {
            GameObject.Destroy(obj);
            npc.SendMessage("popupDestroy", "Done");
            GameManager.Instance.SendMessage("addScore", 10);
        }
    }
}
