using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public Slider progressSlider;
	public Text currentBalance;

	public int storeTimer;
	public int profit;

	public int balance;

	private bool startTimer;
	private float currentTimer;

	// Use this for initialization
	void Start () {
		currentBalance.text = "$" + balance.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (startTimer) {
			currentTimer = currentTimer + Time.deltaTime;
			progressSlider.value = currentTimer / storeTimer;
			if (currentTimer > storeTimer) {
				startTimer = false;
				currentBalance.text = "$" + balance.ToString ();
				progressSlider.value = 0;
			}
		}
	}

	public void clickme() {
		balance = balance + 1;
		currentTimer = 0;
		startTimer = true;
	}

}
