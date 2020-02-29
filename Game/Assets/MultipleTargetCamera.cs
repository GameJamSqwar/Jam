using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
	public List<Transform> targets;

	public Vector3 offset;
	public float smoothTime = 0.5f;

	public float minZoom = 40f;
	public float maxZoom = 10f;
	public float zoomLimiter = 50f;

	private Vector3 velocity;
	private Camera cam;

	private void Start()
	{
		cam = GetComponent<Camera>();
	}

	private void LateUpdate()
	{
		if (targets.Count == 0)
		{
			return; // Escape the loop without running the code below in the case of no targets. (to prevent bugs)
		}
		Move();
		Zoom();
	}

	private void Move()
	{
		Vector3 centerPoint = GetCenterPoint();

		Vector3 newPosition = centerPoint + offset;

		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);

		Vector3 GetCenterPoint()
		{
			if (targets.Count == 1)
			{
				return targets[0].position;
			}

			var bounds = new Bounds(targets[0].position, Vector3.zero);
			{
				for (int i = 0; i < targets.Count; i++)
				{
					bounds.Encapsulate(targets[i].position);
				}
			}
			return bounds.center;
		}
	}

	private void Zoom()
	{
		float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
		cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
	}

	float GetGreatestDistance()
	{
		var bounds = new Bounds(targets[0].position, Vector3.zero);
		for (int i = 0; i < targets.Count; i++)
		{
			bounds.Encapsulate(targets[i].position);
		}
		Debug.Log("The largest distance between the players is:" + bounds.size.x);
		return bounds.size.x;
	}

	public void AddToTargets(Transform target)
	{
		targets.Add(target);
	}
}
