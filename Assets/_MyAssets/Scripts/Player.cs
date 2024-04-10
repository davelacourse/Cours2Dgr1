using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Propriétes Joueur")]
    [SerializeField] private float _vitesseJoueur = 10f;
    
    private void Update()
    {
        float mouvementX = Input.GetAxis("Horizontal");
        float mouvementY = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(mouvementX, mouvementY);
        direction.Normalize();

        transform.Translate(direction * Time.deltaTime * _vitesseJoueur);
        transform.position = 
            new Vector3(Mathf.Clamp(transform.position.x, -7.6f, 7.6f), Mathf.Clamp(transform.position.y, -4.5f, 0.5f), 0f);
    }
}
