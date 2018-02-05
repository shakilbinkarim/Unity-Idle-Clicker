using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text currentBalance;
	public int balance;

	public GameObject managerPanel;


	// Use this for initialization
	void Start () {
		currentBalance.text = "$" + balance.ToString ();
	}
	
	public void addToBalance(int amount) {
		balance += amount;
		currentBalance.text = "$" + balance.ToString ();
	}

	public bool canBuy(int amount) {
		if (amount <= balance)
			return true;
		else
			return false;
	}

	public void showManagers() {
		managerPanel.SetActive (true);
	}

	public void hideManagers() {
		managerPanel.SetActive (false);
	}
}
