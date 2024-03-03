using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed = 2.0f;

    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private float firingRate = 0.3f;

    private float setFiringRate;

    private Coroutine firingCoroutine;

    [SerializeField]
    private float fireCooldown = 0.5f; // The cooldown time in seconds

    private float timeSinceLastFire = 0f;

    public AudioSource audioSource;
    public AudioClip shot;

    void Start(){
        audioSource = GetComponent<AudioSource>();
        firingCoroutine = StartCoroutine(FireCoroutine());
    }
   


    private IEnumerator FireCoroutine(){
        while(true)
        {
            // instantiate bullet here, set velocity and then
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            // give it velocity and move right
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
            //rbb.velocity = new Vector2(1 * speed, 0);
            rbb.velocity = Vector2.right * bulletSpeed;
            PlayShotSound();
            Destroy(bullet.gameObject, 5.0f);
            // sleep for short time
            yield return new WaitForSeconds(firingRate); 
        }
    }

    public void IncreaseFireRate(){
        StopCoroutine(firingCoroutine);
        setFiringRate = firingRate;
        firingRate -= 0.2f;
        // call the SetFireRateBack method after 10 seconds
        Invoke("SetFireRateBack", 10f);
        firingCoroutine = StartCoroutine(FireCoroutine());
    }

    private void SetFireRateBack(){
        StopCoroutine(firingCoroutine);
        firingRate = setFiringRate;
        firingCoroutine = StartCoroutine(FireCoroutine());
    }

    void PlayShotSound() {
        audioSource.PlayOneShot(shot);
    }



}
