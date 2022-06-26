using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class SawControl : MonoBehaviour
{
    public int Speed;
    public int LRSpeed;
    public float Max_X;
    public float Min_X;
    public DynamicJoystick joystick;

    void FixedUpdate()
    {
        float InputX = joystick.Horizontal;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Min_X, Max_X), transform.position.y, transform.position.z);
        transform.Translate(new Vector3(InputX * LRSpeed * Time.deltaTime, 0, Speed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Cuttable")
        {
            LRSpeed = 0;
            Speed = 2;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Cuttable")
        {
            Cutter(col);
            LRSpeed = 10;
            Speed = 10;
        }
    }

    public SlicedHull Slice(GameObject obj, Material mat = null)
    {
        return obj.Slice(transform.position, transform.right, mat);
    }

    public void Cutter(Collider col)
    {
        var cutMat = col.GetComponent<MeshRenderer>().materials[1];

        SlicedHull Cut = Slice(col.gameObject, cutMat);
        GameObject CutLeft = Cut.CreateUpperHull(col.gameObject, cutMat);
        CutLeft.AddComponent<BoxCollider>();
        CutLeft.AddComponent<Rigidbody>().AddForce(Vector3.right * 7, ForceMode.Impulse);
        GameObject CutRight = Cut.CreateLowerHull(col.gameObject, cutMat);
        CutRight.AddComponent<BoxCollider>();
        CutRight.AddComponent<Rigidbody>().AddForce(-Vector3.right * 7, ForceMode.Impulse);

        Destroy(CutLeft, 5);
        Destroy(CutRight, 5);
        Destroy(col.gameObject);
    }
}
