using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public float smoothSpeed = 0.04f;


    // Start is called before the first frame update
    void Start()
    {
        //Get the distance of camera from player
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Set position of camera as a total of player position and distance from it.
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        transform.position = newPosition;

    }
}
