using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _container = default(GameObject);
    [SerializeField] private GameObject _ennemiBase = default(GameObject);
    [SerializeField] private float _delaiApparitionEnnemis = 4f;
    [SerializeField] private float _delaiApparitionMinPU = 5f;
    [SerializeField] private float _delaiApparitionMaxPU = 10f;
    [SerializeField] private GameObject[] _PUPrefabs = default(GameObject[]);

    private void Start()
    {
        StartCoroutine(ApparitionEnnemis());
        StartCoroutine(ApparitionPU());
    }

    IEnumerator ApparitionEnnemis()
    {
        while (Player.Instance.ViesJoueur > 0)
        {
            Vector3 postionApparition = new Vector3(Random.Range(-8f, 8f), 6.5f, 0f);
            GameObject newGameobject = Instantiate(_ennemiBase, postionApparition, Quaternion.identity);
            newGameobject.transform.parent = _container.transform;
            yield return new WaitForSeconds(_delaiApparitionEnnemis);
        }
    }

    IEnumerator ApparitionPU()
    {
        while (Player.Instance.ViesJoueur > 0)
        {
            yield return new WaitForSeconds(3f);
            Vector3 postionApparition = new Vector3(Random.Range(-8f, 8f), 6.5f, 0f);
            int randomPos = Random.Range(0, _PUPrefabs.Length);
            GameObject newGameobject = Instantiate(_PUPrefabs[0], postionApparition, Quaternion.identity);
            newGameobject.transform.parent = _container.transform;
            yield return new WaitForSeconds(Random.Range(_delaiApparitionMinPU, _delaiApparitionMaxPU));
        }
    }
}
