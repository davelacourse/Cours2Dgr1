using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _ennemiBase = default(GameObject);
    [SerializeField] private float _delaiApparitionEnnemis = 4f;

    private void Start()
    {
        StartCoroutine(ApparitionEnnemis());
    }

    IEnumerator ApparitionEnnemis()
    {
        while (Player.Instance.ViesJoueur > 0)
        {
            Vector3 postionApparition = new Vector3(Random.Range(-8f, 8f), 6.5f, 0f);
            Instantiate(_ennemiBase, postionApparition, Quaternion.identity);
            yield return new WaitForSeconds(_delaiApparitionEnnemis);
        }
    }
}
