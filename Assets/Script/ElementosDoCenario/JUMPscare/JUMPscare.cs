using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class JUMPscare : MonoBehaviour
{


    private Collider[] Colisores;
    private AudioSource emissorSom;
    public float TempoDaImagem = 1;
    public AudioClip AudioImagem;
    public Image _Imagem;
    void Start()
    {
        _Imagem.enabled = false;
        emissorSom = GetComponent<AudioSource>();
        emissorSom.clip = AudioImagem;
        Colisores = transform.GetComponentsInChildren<Collider>();
    }

    void OnTriggerEnter()
    {
        StartCoroutine(EsperarTempo(TempoDaImagem));
    }

    IEnumerator EsperarTempo(float tempo)
    {
        _Imagem.enabled = true;
        emissorSom.PlayOneShot(emissorSom.clip);
        foreach (Collider coll in Colisores)
        {
            coll.enabled = false;
        }
        yield return new WaitForSeconds(tempo);
        _Imagem.enabled = false;
        Destroy(gameObject, (emissorSom.clip.length - tempo));
    }
}

