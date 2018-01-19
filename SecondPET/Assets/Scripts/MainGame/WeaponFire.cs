using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponFire : MonoBehaviour {
    public Text coinT;
    public float fireRate = 0;
    public float damage = 10;
    public LayerMask ToHit;
    public GameObject laserEffect, damageEffect;
    public AudioSource shootAudio;
    public AudioClip shootClip;

    float timeToFire = 0;
    Transform firePoint;

    [SerializeField] GameObject recoil;

	// Use this for initialization
	void Start () {
        firePoint = transform.Find("Fire");
        if(firePoint == null)
        {
            Debug.LogError("Hello, no object guys!");
        }
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && timeToFire <= 0)
        {
            timeToFire = 2;
            Shoot();
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        shootAudio.PlayOneShot(shootClip);
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        Instantiate(recoil, new Vector3(mousePosition.x, mousePosition.y,-2),Quaternion.identity);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, ToHit);
        bullet(firePointPosition, mousePosition);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100, Color.cyan);
        if(hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            FindObjectOfType<GameManager>().Coin += 100;
            PlayerPrefs.SetInt("Coin", FindObjectOfType<GameManager>().Coin);
            Destroy(hit.collider.gameObject);

            if (hit.collider.name == "Civil")
            {
                FindObjectOfType<PlayerBehav>().GameOver();
            }
        }
    }

    void bullet(Vector3 firePosition, Vector3 mousePosition)
    {
        Instantiate(laserEffect, firePosition, Quaternion.EulerAngles(0,0, (Vector3.Angle(firePosition, mousePosition))) );
        Debug.Log(Vector3.Angle(firePosition, mousePosition));
    }
}
