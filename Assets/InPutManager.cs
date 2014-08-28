using UnityEngine;
using System.Collections;

public class InPutManager : MonoBehaviour 
{
	Vector2 inputPosition;
	Transform button;
	RaycastHit2D hit;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		ButtonClick();
	
	}

	void ButtonClick()
	{
		if(Input.GetMouseButtonDown(0))
		{

			inputPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);

			hit = Physics2D.Raycast(inputPosition,new Vector2(0,0),0.1f);
			if(hit.collider!=null)
			{
				if(hit.collider.tag=="GUITag" )
				{
					Debug.Log("Down");
					button=hit.transform;
					ButtonDownEvent(button);

				}
//				else if(hit.collider.tag==null)
//				{
//					//button=null;
//					Debug.Log("Exception");
//				}

			}
			else
			{
				Debug.Log("Exception");
			}

		}
		else if(Input.GetMouseButtonUp(0))
		{
			if(button!=null)
			{
				Debug.Log("UP");
				ButtonUpEvent(button);
				button=null;
			}
		}
	}

	/***********************************************/
	//Scale Down the button Size while pressed
	public void ButtonDownEvent(Transform button)
	{
		Vector3 scale=button.transform.localScale;
		button.transform.localScale = scale * 0.8f;
	}
	//Scale Up the Button Size While Released
	public void ButtonUpEvent(Transform button)
	{
		Vector3 scale=button.transform.localScale;
		button.transform.localScale = scale*1.25f;
	}
	
}

