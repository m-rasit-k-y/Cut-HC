using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class PlayerControl : MonoBehaviour
{
    public int Speed;
    public int LRSpeed;

    public float Max_X;
    public float Min_X;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Movement();
    }





    private void OnTriggerEnter(Collider col)
    {
        Cutter(col.gameObject);
    }
    public SlicedHull Slice(GameObject obj, Material mat = null)
    {
        return obj.Slice(transform.position, transform.right, mat);
    }
    public void Cutter(GameObject obj)
    {
        var cutMat = obj.GetComponent<MeshRenderer>().materials[1];

        SlicedHull Cut = Slice(obj, cutMat);
        GameObject CutLeft = Cut.CreateUpperHull(obj, cutMat);
        CutLeft.AddComponent<BoxCollider>();
        CutLeft.AddComponent<Rigidbody>().AddForce(Vector3.right * 7, ForceMode.Impulse);
        GameObject CutRight = Cut.CreateLowerHull(obj, cutMat);
        CutRight.AddComponent<BoxCollider>();
        CutRight.AddComponent<Rigidbody>().AddForce(-Vector3.right * 7, ForceMode.Impulse);

        Destroy(CutLeft, 5);
        Destroy(CutRight, 5);
        Destroy(obj);
    }

    private void Movement()
    {
        // Movement
        float InputX = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(InputX * LRSpeed * Time.deltaTime, 0, Speed * Time.deltaTime), Space.World);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, Min_X, Max_X), transform.position.y, transform.position.z);
    }
}
