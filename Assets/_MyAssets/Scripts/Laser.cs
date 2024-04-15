using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _vitesseLaser = 18f;

    private void Update()
    {
        MouvementLaser();
    }

    private void MouvementLaser()
    {
        transform.Translate(Vector2.up * Time.deltaTime * _vitesseLaser);
        if (transform.position.y > 7f)
        {
            Destroy(gameObject);
        }
    }
}
