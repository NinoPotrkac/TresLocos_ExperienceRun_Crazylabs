using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0)); // Script that is put on the coin wich will rotate the coin
    }
}
