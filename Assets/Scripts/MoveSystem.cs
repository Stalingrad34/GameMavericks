using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveSystem : MonoBehaviour
{
    [SerializeField] private float minPosX = 0.0f;
    [SerializeField] private float maxPosX = 0.0f;
    [SerializeField] private float minPosZ = 0.0f;
    [SerializeField] private float maxPosZ = 0.0f;
    [SerializeField] private float speed = 0.0f;
    [SerializeField] private float tilt = 0.0f;
    private Rigidbody _rigidBody = null;
    private Vector3 startPosition = new Vector3();
    private Vector3 endPosition = new Vector3();

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
#if UNITY_EDITOR

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        _rigidBody.velocity = movement * speed;
        transform.position = new Vector3(Mathf.Clamp(_rigidBody.position.x, minPosX, maxPosX), 0, Mathf.Clamp(_rigidBody.position.z, minPosZ, maxPosZ));
        transform.rotation = Quaternion.Euler(0, 180, moveHorizontal * tilt);

#endif

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    break;

                case TouchPhase.Moved:
                    Vector3 dir = Camera.main.ScreenToWorldPoint(touch.position) - startPosition;
                    Vector3 pos = endPosition + dir;
                    transform.position = new Vector3(Mathf.Clamp(_rigidBody.position.x, minPosX, maxPosX), 0, Mathf.Clamp(_rigidBody.position.z, minPosZ, maxPosZ));
                    transform.rotation = Quaternion.Euler(0, 180, dir.x * tilt);
                    break;

                case TouchPhase.Ended:
                    endPosition = transform.position;
                    break;
            }
        }
#endif

        
    }

}
