using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject objectToFollow;
    public int[] spaceBetween = new int[2];

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(this.objectToFollow.transform.position.x - this.spaceBetween[0], this.objectToFollow.transform.position.y - this.spaceBetween[1]);
    }
}
