using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCharacterToCameraTargets : MonoBehaviour
{
	GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
		mainCamera = Camera.main.gameObject;
		mainCamera.GetComponent<MultipleTargetCamera>().AddToTargets(gameObject.transform);

    }
}
