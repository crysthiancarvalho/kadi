using UnityEngine;
using System.Collections;

public class MoveFrontButton : MonoBehaviour {

	public GameObject kadi;
	public Player player;
	// Use this for initialization
	void Start () {
		player =  kadi.GetComponent<Player>();
		var recognizer = new TKTapRecognizer();
		
		// we can limit recognition to a specific Rect, in this case the bottom-left corner of the screen
		//recognizer.boundaryFrame = new TKRect( transform.position.x, transform.position.y,.bounds.size.x, collider.bounds.size.y );
		
		// we can also set the number of touches required for the gesture
		if( Application.platform == RuntimePlatform.IPhonePlayer )
			recognizer.numberOfTouchesRequired = 2;
		
		recognizer.gestureRecognizedEvent += ( r ) =>
		{
			Debug.Log( "tap recognizer fired: " + r );
			player.moveKadi(1f);
		};
		TouchKit.addGestureRecognizer( recognizer );

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		
		//player.moveKadi (1f);
	}
}
