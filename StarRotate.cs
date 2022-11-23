using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 0.5f)); // rotating star on the Z axis
    }
}
