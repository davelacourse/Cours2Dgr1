using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    [Header("Propriétes Joueur")]
    [SerializeField] private float _vitesseJoueur = 10f;
    [SerializeField] private GameObject _laserJoueur = default(GameObject);
    [SerializeField] private float _cadenceTir = 0.5f;
    [SerializeField] private int _viesJoueur = 3;
    [SerializeField] private GameObject _shield = default(GameObject);
    [SerializeField] private AudioClip _sonLaserJoueur = default;
    public int ViesJoueur => _viesJoueur;

    private float _tempsTir = -1f;
    private Animator _animator;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MouvementsJoueur();
        Tir();
        
    }

    private void GestionAnims(Vector2 direction)
    {
        if (direction.x < 0f)
        {
            _animator.SetBool("TurnLeft", true);
            _animator.SetBool("TurnRight", false);
        }
        else if (direction.x > 0f)
        {
            _animator.SetBool("TurnRight", true);
            _animator.SetBool("TurnLeft", false);
        }
        else
        {
            _animator.SetBool("TurnRight", false);
            _animator.SetBool("TurnLeft", false);
        }
    }

    private void Tir()
    {
        if (Input.GetAxis("Fire1") == 1 && Time.time > _tempsTir)
        {
            _tempsTir = Time.time + _cadenceTir;
            Instantiate(_laserJoueur, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
            AudioSource.PlayClipAtPoint(_sonLaserJoueur, Camera.main.transform.position, 0.25f);
        }
    }

    private void MouvementsJoueur()
    {
        float mouvementX = Input.GetAxis("Horizontal");
        float mouvementY = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(mouvementX, mouvementY);
        direction.Normalize();

        transform.Translate(direction * Time.deltaTime * _vitesseJoueur);
        transform.position =
            new Vector3(Mathf.Clamp(transform.position.x, -8.14f, 8.14f), Mathf.Clamp(transform.position.y, -4.09f, 0.5f), 0f);

        GestionAnims(direction);
    }

    public void DegatJoueur()
    {
        if(!_shield.activeSelf)
        {
            _viesJoueur--;
            UIManager.Instance.ChangeLivesDisplayImage(_viesJoueur);
        }
        else
        {
            _shield.SetActive(false);
        }
        
        if(_viesJoueur < 1)
        {
            Destroy(gameObject);
        }
    }

    public void ActiverShield()
    {
        _shield.SetActive(true);
    }
}
