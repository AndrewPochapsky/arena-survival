using UnityEngine;
using System.Collections;

public class RotateToMouse : MonoBehaviour {

    public enum SpriteRotation
    {
        Up=-90,
        Down=90,
        Right=0,
        Left=180
    }

    public Camera camera;
    public SpriteRotation spriteRotation;
    private Vector2 direction;
    private Vector2 mousePosition;
    private Transform myTransform;

    private float angle;


	// Use this for initialization
	void Start () {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - (Vector2)transform.position).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + (int)spriteRotation;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
