using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public GameObject Player;
    public static bool follow=true;
    void FixedUpdate()
    {
        if (Player != null && follow)
        {
            transform.position = new Vector3(Player.transform.position.x,
                                         1.15f,
                                         transform.position.z);
        }

    }
}
