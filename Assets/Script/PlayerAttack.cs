using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject prefab;
    public GameObject mag;
    public int amount;
    [HideInInspector]public float firerate;
    RightJoyStick rightJoyStick;
    private AudioSource shootingSound;
    void Start()
    {
        rightJoyStick = FindObjectOfType<RightJoyStick>();
        shootingSound = GetComponent<AudioSource>();
        firerate = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Firerate();
        if (rightJoyStick.OnFire && firerate >= 0.2f)
        {
            StartCoroutine(DelayShooting());
            GameObject bulletObject = Instantiate(prefab, transform.position, Quaternion.identity);
            bulletObject.transform.SetParent(mag.transform);
            firerate = 0;
        }
        if(!rightJoyStick.OnFire)
        {
            StartCoroutine(StopSound());
        }

    }
    public void Firerate()
    {
        firerate = firerate + Time.deltaTime;
    }
    public void SetParent(Transform parent)
    {
        transform.parent = parent;
    }
  
    IEnumerator StopSound()
    {
        yield return new WaitForSeconds(0.3f);

        shootingSound.Stop();
    }
    IEnumerator DelayShooting()
    {
        yield return new WaitForSeconds(0.3f);
        shootingSound.Play();
    }
}
