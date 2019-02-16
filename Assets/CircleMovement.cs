using UnityEngine;

public class CircleMovement : MonoBehaviour {

    public Transform currentRotation;
    public float rotationSpeed;

	void Update () {

        currentRotation.Rotate(new Vector3(0f, 0f, rotationSpeed));
	}
}
