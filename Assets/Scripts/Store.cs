using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour {

	public GameManager gm;
	public Slider progressSlider;
	public Text storeCountText;
	public Text buyButtonText;

	public int storeTimer;
	public int profit;

	private bool startTimer;
	private float currentTimer;

	public int baseStorePrice;
	public int storeMultiplier;
	public int storeCount;

	// Use this for initialization
	void Start () {
		storeCountText.text = storeCount.ToString ();
		buyButtonText.text = "Buy ($" + baseStorePrice.ToString () + ")";
	}
	
	// Update is called once per frame
	void Update () {
		if (startTimer) {
			currentTimer = currentTimer + Time.deltaTime;
			progressSlider.value = currentTimer / storeTimer;
			if (currentTimer > storeTimer) {
				startTimer = false;
				gm.addToBalance (profit * storeCount);
				progressSlider.value = 0;
			}
		}
	}

	public void clickme() {
		if (storeCount > 0) {
			currentTimer = 0;
			startTimer = true;
		}
	}

	public void buyStore() {
		if (gm.canBuy (baseStorePrice)) {
			gm.addToBalance (-baseStorePrice);
			storeCount++;
			storeCountText.text = storeCount.ToString ();

			baseStorePrice = baseStorePrice + (storeCount * storeMultiplier);
			buyButtonText.text = "Buy ($" + baseStorePrice.ToString () + ")";
		} 
	}

}
