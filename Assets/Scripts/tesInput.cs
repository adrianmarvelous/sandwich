using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tesInput : MonoBehaviour
{
    // If the touch is longer than MAX_SWIPE_TIME, we dont consider it a swipe
	public const float MAX_SWIPE_TIME = 5.0f; 
	
	// Factor of the screen width that we consider a swipe
	// 0.17 works well for portrait mode 16:9 phone
	public const float MIN_SWIPE_DISTANCE = 0.01f;

	public static bool swipedRight = false;
	public static bool swipedLeft = false;
	public static bool swipedUp = false;
	public static bool swipedDown = false;
	
	
	public bool debugWithArrowKeys = true;

	Vector2 startPos;
	float startTime;

    public string active;
    public string direction;

    // Update is called once per frame
    void Update()
    {
        swipedRight = false;
		swipedLeft = false;
		swipedUp = false;
		swipedDown = false;
                    if(Input.touches.Length > 0)
                    {
                        Touch t = Input.GetTouch(0);
                        if(t.phase == TouchPhase.Began)
                        {
                            
                            startPos = new Vector2(t.position.x/(float)Screen.width, t.position.y/(float)Screen.width);
                            startTime = Time.time;
                            Debug.Log(startPos);

                        }
                        if(t.phase == TouchPhase.Ended)
                        {
                            Debug.Log("ended");

                            
                            if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
                                return;

                            Vector2 endPos = new Vector2(t.position.x/(float)Screen.width, t.position.y/(float)Screen.width);

                            Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

                            if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
                                return;
                            
                            if (Mathf.Abs (swipe.x) > Mathf.Abs (swipe.y)) { // Horizontal swipe
                                if (swipe.x > 0) {
                                    swipedRight = true;
                                    direction = "right";
                                }
                                else {
                                    swipedLeft = true;
                                    direction = "left";
                                }
                            }
                            else { // Vertical swipe
                                if (swipe.y > 0) {
                                    swipedUp = true;
                                    direction = "up";
                                }
                                else {
                                    swipedDown = true;
                                    direction = "down";
                                }
                            }
                            Debug.Log(endPos);
                        }
                    }

                    if (debugWithArrowKeys) {
                        swipedDown = swipedDown || Input.GetKeyDown (KeyCode.DownArrow);
                        swipedUp = swipedUp|| Input.GetKeyDown (KeyCode.UpArrow);
                        swipedRight = swipedRight || Input.GetKeyDown (KeyCode.RightArrow);
                        swipedLeft = swipedLeft || Input.GetKeyDown (KeyCode.LeftArrow);
                    }
        
        if (Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "box")
                {
                    active = hit.transform.name;
                    /*
                    Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                    hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                    Debug.Log("tes");
                    hit.collider.GetComponent<RotateBox>().ChangeBool();
                    */
                }
            }
        }
    }

}
