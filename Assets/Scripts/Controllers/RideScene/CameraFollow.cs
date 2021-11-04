using UnityEngine;

namespace SergeyPchelintsev.Expedito.Controllers.RideScene
{
	public class CameraFollow : MonoBehaviour
	{
		[SerializeField] private Transform target;
		[SerializeField] private float height = 5.0f;
		[SerializeField] private float distance = 10.0f;
		[SerializeField] private float rotationDamping;
		[SerializeField] private float heightDamping;

		public Transform Target
		{
			get => target;
			set => target = value;
		}

		private void LateUpdate()
		{
			if (!Target) return;

			var wantedRotationAngle = Target.eulerAngles.y;
			var targetPosition = Target.position;
			var wantedHeight = targetPosition.y + height;

			var currentRotationAngle = transform.eulerAngles.y;
			var currentHeight = transform.position.y;

			currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, 
				wantedRotationAngle, rotationDamping * Time.deltaTime);

			currentHeight = Mathf.Lerp(currentHeight, 
				wantedHeight, heightDamping * Time.deltaTime);

			var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
			var cameraPosition = targetPosition - currentRotation * Vector3.forward * distance;
			transform.position = new Vector3(cameraPosition.x, currentHeight, cameraPosition.z);
			transform.rotation = Quaternion.Lerp(transform.rotation, Target.rotation, rotationDamping * Time.deltaTime);
		}
	}
}