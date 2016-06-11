using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour
{


    public void Move(Vector3 velocity)
    {
        transform.Translate(velocity);

    }
}
