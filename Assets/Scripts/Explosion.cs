using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField]
    private AudioClip _explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(this._explosionSound, this.transform.position);

        Destroy(this.gameObject, 2.3f);
    }
}
