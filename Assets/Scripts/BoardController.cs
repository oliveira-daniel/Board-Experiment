using UnityEngine;
using System.Collections;

public class BoardController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        // GameObject[] casas = transform.chil
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).name = "casa" + i;
        }
    }

}
