using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _vitesseEnnemi = 7f;
    [SerializeField] private AudioClip _sonExplosion = default(AudioClip);

    private void Update()
    {
        MouvementEnnemy();
    }

    private void MouvementEnnemy()
    {
        transform.Translate(Vector2.down * Time.deltaTime * _vitesseEnnemi);
        if (transform.position.y < -6.5f)
        {
            float posX = Random.Range(-8.0f, 8.0f);
            transform.position = new Vector3(posX, 6.5f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            UIManager.Instance.AjouterScore(10);
        }
        else if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Player.Instance.DegatJoueur();
        }
        AudioSource.PlayClipAtPoint(_sonExplosion, Camera.main.transform.position, 0.5f);
    }
}
