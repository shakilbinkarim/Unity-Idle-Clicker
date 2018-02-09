using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Text currentBalance; // Total Balance Text
	public GameObject managerPanel; // Manager Panel Game Object

	public int balance; // Total Balance

	// Example of Observer Design Pattern
	// These events update all subscriber object that require it when the balance changes.
	public delegate void UpdateBalance ();
	public static event UpdateBalance OnUpdateBalance;


	// Use this for initialization
	void Start () {
		//Set Current Balance Text
		currentBalance.text = "$" + balance.ToString ();

		// Example of Observer pattern
		// Notify all observers that we have updated the game balance
		// This is how the interface knows to update without using updates
		if (OnUpdateBalance != null) {
			OnUpdateBalance ();
		}
	}

	// Add or Remove amount from total balance
	public void addToBalance(int amount) {
		balance += amount;
		currentBalance.text = "$" + balance.ToString ();
		// Example of Observer pattern
		// Notify all observers that we have updated the game balance
		// This is how the interface knows to update without using updates
		if (OnUpdateBalance != null) {
			OnUpdateBalance ();
		}
	}

	// Check if you have amount to buy from total balance
	public bool canBuy(int amount) {
		if (amount <= balance)
			return true;
		else
			return false;
	}

	// Show Manager Panel
	public void showManagers() {
		managerPanel.SetActive (!managerPanel.activeInHierarchy);
	}

	// Hide Manager Panel
	public void hideManagers() {
		managerPanel.SetActive (false);
	}
}
