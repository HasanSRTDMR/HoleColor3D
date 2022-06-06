using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed=1.0f;
    [SerializeField] Vector2 moveLimit;
    float x, y;
    Vector3 touch,targetPos;

    // Start is called before the first frame update
    void Start()
    {
        Game.isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        
        Game.isMoving = Input.GetMouseButton(0);

        if (!Game.isGameOver && Game.isMoving)
        {           
            MoveHole();           
        }

#else
		
		Game.isMoving = Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved;

		if (!Game.isGameOver && Game.isMoving)
        {
		MoveHole ();
		}
#endif
    }

    void MoveHole()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        touch = Vector3.Lerp(transform.position, transform.position + new Vector3(x, 0.0f, y),moveSpeed*Time.deltaTime);

        targetPos = new Vector3(Mathf.Clamp(touch.x, -moveLimit.x, moveLimit.x), touch.y, Mathf.Clamp(touch.z, -moveLimit.y, moveLimit.y));

        transform.position = targetPos;
    }
}
