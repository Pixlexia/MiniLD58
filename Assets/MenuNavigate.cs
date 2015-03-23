using UnityEngine;
using System.Collections;

public class MenuNavigate : MonoBehaviour {

	//public GameObject playButton, quitButton;
	public GameObject[] Options;
	public GameObject menuArrow;

	public float x;
	public float arrowX;
	private float playY, helpY, aboutY;
	public int select, maxOption;

	void Awake(){
		//arrowX = 217f;
		playY = Options[0].transform.localPosition.y;
		helpY = Options[1].transform.localPosition.y;
		aboutY = Options[2].transform.localPosition.y;


		select = 1; //1 is play, 2 is quit
		menuArrow.transform.localPosition = new Vector2 (arrowX,playY);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		SelectScene ();
		EnterScene ();
	}

	void SelectScene(){
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if(select < maxOption)
				select++;
			else if(select > maxOption || (maxOption >= 3))
				select = 1; 
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if(select > 1)
				select--;
			else if(select < 1 || (maxOption >= 3))
				select = maxOption;
		}

		if (select == 1 && (menuArrow.transform.localPosition.y != playY)) {
			menuArrow.transform.localPosition = Vector2.Lerp(new Vector2(arrowX,menuArrow.transform.localPosition.y),
			                                                 new Vector2(arrowX,playY),.3f);
		} else if (select == 2 && (menuArrow.transform.localPosition.y != helpY)) {
			menuArrow.transform.localPosition = Vector2.Lerp(new Vector2(arrowX,menuArrow.transform.localPosition.y),
			                                                 new Vector2(arrowX,helpY),.3f);
		}else if (select == 3 && (menuArrow.transform.localPosition.y != aboutY)) {
			menuArrow.transform.localPosition = Vector2.Lerp(new Vector2(arrowX,menuArrow.transform.localPosition.y),
			                                                 new Vector2(arrowX,aboutY),.3f);
		}
	}

	void EnterScene(){
		if (Input.GetKeyDown ("space")) {
			if(select == 1){
				Application.LoadLevel("main");
			}
			else if(select == 2){
				//HELP
			}
			else if(select == 3){
				//ABOUT
			}
		}
	}
}
