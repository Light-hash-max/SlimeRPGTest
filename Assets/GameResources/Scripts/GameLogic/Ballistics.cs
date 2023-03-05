using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Управление полетом пули
/// </summary>
public class Ballistics : MonoBehaviour {

    [SerializeField]
    private Transform _spawnTransform = default;
    [SerializeField]
    private GameObject _bullet = default;

    private List<GameObject> _pool = new List<GameObject>();
    private Vector3 fromToXZ = default;
    private GameObject newBullet = default;

    private void GetBullet()
    {
        foreach (GameObject bullet in _pool)
        {
            if(!bullet.activeSelf)
            {
                bullet.SetActive(true);
                bullet.transform.position = _spawnTransform.position;
                bullet.transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);
                newBullet = bullet;
                return;
            }
        }

        newBullet = Instantiate(_bullet, _spawnTransform.position, Quaternion.LookRotation(fromToXZ, Vector3.up));
        _pool.Add(newBullet);
    }

    /// <summary>
    /// Выстрелить
    /// </summary>
    /// <param name="target"></param>
    /// <param name="speed"></param>
    public void Shot(Transform target, float speed) 
    {
        Vector3 fromTo = target.position - transform.position;
        fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

        GetBullet();
        newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * speed;
    }

}
