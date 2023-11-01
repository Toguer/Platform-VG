using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerDmgIllu : MonoBehaviour, IGameEventListener
{
    [SerializeField] private GameObject _volume;
    Vignette _vignette;
    [SerializeField] private GameEvent _event;
    
    [SerializeField] private float _fadeIn, _fadeOut, _fadeDelay;
    
    void Start()
    {
        _volume.GetComponent<Volume>().profile.TryGet(out _vignette);
    }

    public void PlayerDamaged()
    {
        StartCoroutine(DamagedState());
    }

    IEnumerator DamagedState()
    {
        for (float t = 0.01f; t < _fadeIn; t += 0.1f)
        {
            _vignette.color.Interp(Color.black, Color.red, t);

            yield return null;
        }

        yield return new WaitForSeconds(_fadeDelay);
        StartCoroutine(RecoverState());
    }

    IEnumerator RecoverState()
    {
        for (float t = 0.01f; t < _fadeOut; t += 0.1f)
        {
            _vignette.color.Interp(Color.red, Color.black, t);

            yield return null;
        }
    }

    public void InvokeEffect()
    {
        StartCoroutine(DamagedState());
    }

}
