using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour
{

  public Vector3 currPosition;
  public float moveSpeed = 1.0f;
  public float camLimit = 50000.0f;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    currPosition = GameObject.Find("Main Camera").transform.position;

    //Debug.Log(currPosition);

    //		if ( Input.GetKey(KeyCode.UpArrow) && currPosition.y < camLimit )
    //			transform.Translate(Vector3.up * Time.deltaTime * 20);
    //
    //		if ( Input.GetKey(KeyCode.DownArrow) && currPosition.y > -camLimit )
    //			transform.Translate(Vector3.down * Time.deltaTime * 20);
    //
    //		if ( Input.GetKey(KeyCode.RightArrow) && currPosition.x < camLimit )  
    //			transform.Translate(Vector3.right * Time.deltaTime * 20);
    //		
    //		if ( Input.GetKey(KeyCode.LeftArrow) && currPosition.x > -camLimit )	
    //			transform.Translate(Vector3.left * Time.deltaTime * 20);	

    if (Input.GetKey(KeyCode.UpArrow))
      transform.Translate(Vector3.up * Time.deltaTime * 20);

    if (Input.GetKey(KeyCode.DownArrow))
      transform.Translate(Vector3.down * Time.deltaTime * 20);

    if (Input.GetKey(KeyCode.RightArrow))
      transform.Translate(Vector3.right * Time.deltaTime * 20);

    if (Input.GetKey(KeyCode.LeftArrow))
      transform.Translate(Vector3.left * Time.deltaTime * 20);
  }


}


