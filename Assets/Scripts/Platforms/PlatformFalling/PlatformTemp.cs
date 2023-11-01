using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlatformTemp : MonoBehaviour
{
    private float respawnTime = 5f;
    [SerializeField]
    private CapsuleCollider2D _cC;

    PlatformTempAnim _anim;

    ParticleSystem _ps;
    void Start()
    {
        _cC = GetComponent<CapsuleCollider2D>();
        _anim = GetComponent<PlatformTempAnim>();
        _ps = GetComponent<ParticleSystem>();
        _ps.Stop();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(BreakState());
            _ps.Play();
        }
    }

    

    IEnumerator BreakState()
    {
        Break();
        Debug.Log("Break");
        yield return new WaitForSeconds(3f);
        Destroy();
        Debug.Log("Destroy");
        yield return new WaitForSeconds(respawnTime);
        Respawn();
        Debug.Log("Respawn");
    }
    
    
    void Break()
    {
        _anim.BreakingAnim();
    }
    void Destroy()
    {
        _cC.enabled = false;
        _anim.DestroyAnim();
    }
    
    void Respawn()
    {
        _cC.enabled = true;
        _anim.EntryAnim();
    }

}
