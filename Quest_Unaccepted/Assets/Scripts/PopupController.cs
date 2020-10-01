using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour {

    private static readonly int TEXT_NAME = 0;
    private static readonly int TEXT_WORK = 1;
    private static readonly int TEXT_QUEST = 2;
    private Text[] mTextTab;

    private GameObject npc;
    private string npcName;
    private string npcWork;
    private int sortingOrder;

    public GameObject obj;
    public Renderer rendererPopup;
    public Canvas canvasPopup;
        
    public void Start()
    {
        QuestGenerator questGenerator = new QuestGenerator();

        mTextTab = GetComponentsInChildren<Text>();
        mTextTab[TEXT_NAME].text = npcName;
        mTextTab[TEXT_WORK].text = npcWork;
        mTextTab[TEXT_QUEST].text = questGenerator.GenerateQuest();
        rendererPopup.sortingOrder = sortingOrder;
        canvasPopup.sortingOrder = sortingOrder;
    }

    public void SetNPCName(string name)
    {
        npcName = name;
    }

    public void SetNPCWork(string work)
    {
        npcWork = work;
    }

    public void SetSortingOrder(int order)
    {
        sortingOrder = order;
    }

    public void SetNPC(GameObject NPC)
    {
        npc = NPC;
    }
 
    public void AcceptQuest()
    {
        if (GameManager.onPause == false)
        {
            GameManager.Instance.SendMessage("OnDefeat");
        }
    }

    public void DeclineQuest()
    {
        if (GameManager.onPause == false)
        {
            GameObject.Destroy(obj);
            npc.SendMessage("PopupDestroy", "Done");
            GameManager.Instance.SendMessage("AddScore", 10);
        }
    }
}
