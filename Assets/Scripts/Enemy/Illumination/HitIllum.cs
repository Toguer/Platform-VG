using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class HitIllum : MonoBehaviour, IGameEventListener
{
    SpriteRenderer _spRenderer;
    EnemyLifeSystem _enemy;
    public GameEvent _event;
    

    [SerializeField] float _fadeIn, _fadeOut, _fadeDelay;
    
    [SerializeField] Color _idlecolor;
    [SerializeField] Color _hitcolor;

    ParticleSystem _ps;

    void Start()
    {
        _spRenderer = GetComponent<SpriteRenderer>();
        _enemy = GetComponent<EnemyLifeSystem>();
        _ps = GetComponent<ParticleSystem>();
        _ps.Stop();
    }

    public void IllumEffect()
    {
        StartCoroutine(HitState());
    }
    

    IEnumerator HitState()
    {
        for (float t = 0.01f; t < _fadeIn; t += 0.1f)
        {
            _spRenderer.color = Color.Lerp(_idlecolor, _hitcolor, t / _fadeIn);
            //Cambia el color de la Vignette
            //_vignette.color.Interp(Color.black, Color.red, t);
            _ps.Play();
            
           
            
            yield return null;            
        }
        yield return new WaitForSeconds(_fadeDelay);
        StartCoroutine(IdleState());
    }

    IEnumerator IdleState()
    {
        for (float t = 0.01f; t < _fadeOut; t += 0.1f)
        {
            _spRenderer.color = Color.Lerp(_hitcolor, _idlecolor, t / _fadeOut);
            //Resete el estado de la Vignette original
            //_vignette.color.Interp(Color.red, Color.black, t);
            yield return null;            
        }
    }
    
    public void InvokeEffect()
    {
        StartCoroutine(HitState());
    }
}
