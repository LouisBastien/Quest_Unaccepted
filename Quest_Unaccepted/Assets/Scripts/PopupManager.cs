using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupManager : MonoBehaviour {

    private int nb_popup;
    public GameObject gameManager;

	public void Start () {
		
	}
	
	public void Update () {
        if (GameManager.onPause == false)
        {
            nb_popup = GameObject.FindGameObjectsWithTag("Popup").Length;

            if (nb_popup > 15)
            {
                gameManager.SendMessage("OnDefeat");
            }
        }
    }
}
