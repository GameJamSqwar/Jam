using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int seekingCount;
    private Rigidbody rb;

    public int GetSeekerCount() { return seekingCount; }
    public void SetSeekerCount(int newCount) { seekingCount = newCount; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        seekingCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            rb.AddForce(Vector3.forward * 5);
        if (Input.GetKey(KeyCode.DownArrow))
            rb.AddForce(Vector3.back * 5);
        if (Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(Vector3.left * 5);
        if (Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(Vector3.right * 5);
    }


}