using UnityEngine;
using System.Collections;

public class FreeCamMouseLook : MonoBehaviour 
{
	public enum RotationAxes 
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 5f;
	public float sensitivityY = 5f;
	public float minimumX = -360f;
	public float maximumX = 360f;
	public float minimumY = -60F;
	public float maximumY = 60F;
	public bool active = false;

	private float xInput = 0f;
	private float yInput = 0f;
	private float xInputOld = 0f;
	private float yInputOld = 0f;
	private float averageXInput = 0f;
	private float averageYInput = 0f;
	private float rotationX = 0f;
	private float rotationY = 0f;
	private Quaternion originalRotation;

	void Start() 
	{
		originalRotation = Quaternion.identity;
	}

	void Update() 
	{
		if(active)
		{
			if (axes == RotationAxes.MouseXAndY) 
			{

				// Pass inputs to inputOlds first... 
				xInputOld = xInput; 
				yInputOld = yInput; 

				// Read the mouse input axis 
				xInput = Input.GetAxis ("Mouse X") * sensitivityX; 
				yInput = Input.GetAxis ("Mouse Y") * sensitivityY; 

				//Average new inputs with old 
				averageXInput = xInput + xInputOld; 
				averageYInput = yInput + yInputOld; 
				averageXInput *= 0.5f; 
				averageYInput *= 0.5f; 

				rotationX += averageXInput; 
				rotationY += averageYInput; 

				rotationX = ClampAngle (rotationX, minimumX, maximumX); 
				rotationY = ClampAngle (rotationY, minimumY, maximumY); 

				Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up); 
				Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.left); 

				transform.localRotation = originalRotation * xQuaternion * yQuaternion; 

			} else if (axes == RotationAxes.MouseX) 
			{

				// Pass inputs to inputOlds first... 
				xInputOld = xInput; 

				// Read the mouse input axis 
				xInput = Input.GetAxis ("Mouse X") * sensitivityX; 

				//Average new inputs with old 
				averageXInput = xInput + xInputOld; 
				averageXInput *= 0.5f; 

				rotationX += averageXInput; 
				rotationX = ClampAngle (rotationX, minimumX, maximumX); 

				Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up); 
				transform.localRotation = originalRotation * xQuaternion; 

			} else 
			{

				// Pass inputs to inputOlds first... 
				yInputOld = yInput; 

				// Read the mouse input axis 
				yInput = Input.GetAxis ("Mouse Y") * sensitivityY; 

				//Average new inputs with old 
				averageYInput = yInput + yInputOld; 
				averageYInput *= 0.5f; 

				rotationY += averageYInput; 

				rotationY += Input.GetAxis ("Mouse Y") * sensitivityY; 
				rotationY = ClampAngle (rotationY, minimumY, maximumY); 

				Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.left); 
				transform.localRotation = originalRotation * yQuaternion; 
			} 
		}
	}

	public static float ClampAngle(float angle, float min, float max) 
	{
		if (angle < -360F) angle += 360F; 
		if (angle > 360F) angle -= 360F; 
		return Mathf.Clamp (angle, min, max); 
	}
}
