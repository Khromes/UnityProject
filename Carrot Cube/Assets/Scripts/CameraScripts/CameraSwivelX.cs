using UnityEngine;

public class CameraSwivelX : MonoBehaviour {

    private Vector3 _cameraOffset;
    public Transform PlayerTransform;

    [Range(.01f, 1f)]
    public float smoothFactor = 0.5f;

    public bool RotateAroundPlayer = true;

    public bool LookAtPlayer = false;

    public float RotateSpeed = 5.0f;

    // Use this for initialization
    void Start () {

        _cameraOffset = transform.position - PlayerTransform.position;
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotateSpeed, Vector3.up);

            _cameraOffset = camTurnAngle * _cameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (LookAtPlayer || RotateAroundPlayer)
         transform.LookAt(PlayerTransform);
        
	}
}
