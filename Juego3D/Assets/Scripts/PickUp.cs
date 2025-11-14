using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject objectToPickUp;
    public GameObject pickedObject;
    public Transform interectionZone;
    void Update()
    {
        if (objectToPickUp != null && objectToPickUp.GetComponent<PickableObject>().isPickable == true && pickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                pickedObject = objectToPickUp;
                pickedObject.GetComponent<PickableObject>().isPickable = false;
                pickedObject.transform.SetParent(interectionZone);
                pickedObject.transform.position = interectionZone.position;
                pickedObject.GetComponent<Rigidbody>().useGravity = false;
                pickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }else if (pickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                pickedObject.GetComponent<PickableObject>().isPickable = true;
                pickedObject.transform.SetParent(null);
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject = null;
            }
        }
    }
}
