using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Parallax : MonoBehaviour
{
    float _lenght, _startpos;
    [SerializeField]
    GameObject _camera;
    [SerializeField]
    float _parallaxEffect;
    
    void Start()
    {
        _startpos = transform.position.x;
        _lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void FixedUpdate()
    {
        float temp = (_camera.transform.position.x * (1 - _parallaxEffect));
        float dist = (_camera.transform.position.x * _parallaxEffect);

        transform.position = new Vector3(_startpos + dist, transform.position.y, transform.position.z);

        if (temp > _startpos + _lenght) _startpos += _lenght;
        else if (temp < _startpos - _lenght) _startpos -= _lenght;

    }
}