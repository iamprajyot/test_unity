using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Rigidbody rigidbody;

	void start(){
		rigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {

				if (SystemInfo.deviceType == DeviceType.Desktop) {
						//get input by keyboard
						float movehorizontal = Input.GetAxis ("Horizontal");
						float movevertical = Input.GetAxis ("Vertical");
			
						Vector3 movement = new Vector3 (movehorizontal, 0.0f, movevertical);
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				} else {
						// Player movement in mobile devices
						// Building of force vector 
			speed = 600;
						Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
						// Adding force to rigidbody
						rigidbody.AddForce (movement * speed * Time.deltaTime);
				}
		}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Hole")) {
			gameObject.SetActive(false);
			//yield WaitForSeconds(2);
			Invoke("closeApp", 1);
		}
	}

	void closeApp(){
		Application.Quit();
		}

	void OnCollisionEnter(Collision collision) {
		ContactPoint contact = collision.contacts[0];

		if (contact.otherCollider.gameObject.tag == "Hole") {
			Destroy(collision.gameObject);
		}

	}
}
