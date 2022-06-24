using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

using TMPro;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public TextMeshProUGUI winTextObject;
	public GameObject resetButton;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private int count;

	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;

		// Run the SetCountText function to update the UI (see below)
		SetCountText();

		// Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winTextObject.text = "";

		resetButton.SetActive(false);
	}

	// Each physics step..
	void FixedUpdate ()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce (movement * speed);

		if(transform.position.y <= -50)
        {
			winTextObject.text = "Off Course!";
			resetButton.SetActive(true);
		}
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("PickUp"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive(false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText();
		}

		if (other.gameObject.CompareTag("CheckPlane"))
		{
			resetButton.SetActive(true);
			if (count >= 11)
			{
				// Set the text value of our 'winText'
				winTextObject.text = "Good job!";
			}
            else
            {
				winTextObject.text = "Good, But you haven't collected all the items yet!";
			}
		}
	}

	// Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
	void SetCountText()
	{
		// Update the text field of our 'countText' variable
		countText.text = "Remain Collectibles: " + (11 - count).ToString ();

		// Check if our 'count' is equal to or exceeded 12
		if (count >= 11) 
		{
			// Set the text value of our 'winText'
			//winText.text = "You Win!";
			countText.text = "Collection Complete!";
		}
	}
}