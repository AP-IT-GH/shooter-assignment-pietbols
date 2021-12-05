using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public AudioClip audioClip;
    public GameObject explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "projectile" || other.gameObject.tag == "Projectile")
        {
            print("hit");
            print(transform.position);
            Instantiate(explosionParticle, transform.position, transform.rotation); // explode on this position, with this rotation

            if (audioClip)
            {
                if (gameObject.GetComponent<AudioSource>())
                {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
                }
                else
                {
                    // add audiosource to gameobject: dynamically create object with audiosource, it will remove itself
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                }
            }

            Destroy(this.gameObject); // destroy enemy
        } 
    }
}
