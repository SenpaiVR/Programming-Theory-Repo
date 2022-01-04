using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraRoot;
    [SerializeField] private int cameraSmoothSpeed;
    [SerializeField] private int cameraRotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = cameraRoot.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraRoot.transform.position, cameraSmoothSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, cameraRoot.transform.rotation, cameraRotateSpeed * Time.deltaTime);
    }
}
