using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public GameManager gm;

	public int managerCost;
	public Text buyButtonText;

	// Use this for initialization
	void Start () {
		buyButtonText.text = "Hire ($" + managerCost.ToString () + ")";
	}
	
	public void hireManager(GameObject store) {
		if (gm.canBuy (managerCost)) {
			gm.addToBalance (-managerCost);
			store.GetComponent<Store> ().hasManager = true;
			GetComponent<Button> ().interactable = false;
		}
	}
}
