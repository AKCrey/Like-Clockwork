using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceScript : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Byebye());
    }

    IEnumerator Byebye()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
