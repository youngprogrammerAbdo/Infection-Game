using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FindTarget : MonoBehaviour
{

    [Header("FindTarget")]
    [SerializeField] private float range = 2f;
    [Range(1, 15)] public float blindArea = 7f;
    private float smoothRotateSpeed = 5f;
    public Transform partToRotate; //the part which will rotate 'Note' = this must but in all guns 

    [Header("Shooting")]
    public bool fireAuto;
    public bool multiShooting;
    public float Damage;
    public float fireRate;
    public int bulletCapacity = 10;
    public float reloadTime = 1.5f;
    public float BulletSpeed;
    public GameObject[] Bullet;
    public Transform[] FirePoint;
    public ParticleSystem[] particals;
    public float Angle = 60;
    [Header("Fire&&Laser")]
    public ParticleSystem particalStream;
    public bool FireStreamer = false;
    public bool laser = false;
    public ParticleSystem laserCharging;

    private float nextTimeToFire = 0f;
    private Animator anim;
    private int BulletsNumber;
    private bool reloading;
    private float CurrentWeaponSpeed;
    private int CurrentWeapon;
    private void Start()
    {
        anim = GetComponent<Animator>();
        BulletsNumber = bulletCapacity;
    }

    private void Update()
    {
        FindInClosestTarget();

    }
    public bool FireAuto(bool fireAuto)
    {
        fireAuto = this.fireAuto;
        return fireAuto;
    }
    private void FindInClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 vector = transform.forward;

        Dictionary<float, GameObject> enemiesInRange =
            new Dictionary<float, GameObject>();

        foreach (GameObject enemy in enemies)
        {
            Vector3 directionToTarget = enemy.transform.position - transform.position;
            float angle = Vector3.SignedAngle(directionToTarget, vector, -Vector3.up);

            if (angle > -Angle && angle < Angle)
                enemiesInRange.Add(directionToTarget.magnitude, enemy);
        }

        if (enemiesInRange.Count == 0)
        {
            partToRotate.rotation = Quaternion.Slerp(partToRotate.rotation, transform.rotation, Time.deltaTime * smoothRotateSpeed);
            return;
        }
        else
        {
            float key = enemiesInRange.Keys.Min();
            GameObject GO = enemiesInRange[key];
            float distanceToTarget = Vector3.Distance(partToRotate.transform.position, GO.transform.position);
            if (distanceToTarget <= range && distanceToTarget >= blindArea)
            {
                //	partToRotate.transform.LookAt (GO.transform);
                Vector3 directionToTarget = GO.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
                Vector3 rotation = Quaternion.Slerp(partToRotate.rotation, lookRotation, Time.deltaTime * smoothRotateSpeed).eulerAngles;
                partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
                if (!fireAuto)
                {
                    if (Input.GetKey(KeyCode.Space))
                    {
                        StartFire();
                    }
                }
                else
                {
                    StartFire();
                }

            }
        }

    }

    private void StartFire ()
    {
        if (Time.time >= nextTimeToFire)
        {

            if (laser || FireStreamer)
            {
                FireStreaming();
            }
            else
            {
                Fire();
            }
        }


        else
        {
            anim.SetBool("Fire", false);

        }
    }
    public void Fire()
    {
        int RandomBullet = Random.Range(0, Bullet.Length);

        if (Time.time >= nextTimeToFire && reloading == false)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            if (multiShooting)
            {
                BulletsNumber -= 2;

            }
            else
            {
                BulletsNumber--;

            }
            if (BulletsNumber <= 0)
            {
                reloading = true;
                StartCoroutine(Reload());
            }
            else
            {

                for (int i = 0; i < FirePoint.Length; i++)
                {

                    GameObject praticaleClone = Instantiate(Bullet[RandomBullet], FirePoint[i].position, FirePoint[i].rotation) as GameObject;
                    praticaleClone.GetComponent<Rigidbody>().AddForce(FirePoint[i].forward * BulletSpeed);

                    Bullet bullet = praticaleClone.GetComponent<Bullet>();
                    if (bullet != null)
                    {
                        bullet.seek(Damage);
                    }

                    for (int x = 0; x < particals.Length; x++)
                    {
                        particals[x].Play();

                    }
                }

                anim.SetBool("Fire", true);
            }
        }

    }

    public void FireStreaming()
    {
        //CurrentWeapon = WeaponSelection.ActiveWeaponNumber;
        //var power = "weapon" + (CurrentWeapon + 1) + "speed";
        //CurrentWeaponSpeed = PlayerPrefs.GetFloat(power);
        //Debug.Log("CurrentWeaponSpeed " + CurrentWeaponSpeed);
        nextTimeToFire = (Time.time + 1f / fireRate);
        RaycastHit hit;
        if (Physics.Raycast(partToRotate.position, partToRotate.forward, out hit, range))
        {
            particalStream.Play();
            anim.SetBool("Fire", true);
            ZombieHealth zombieHealth = hit.collider.GetComponent<ZombieHealth>();
            if (zombieHealth != null)
            {
                zombieHealth.DamageTaken(Damage);
            }
        }
        else
        {
            particalStream.Stop();
            anim.SetBool("Fire", false);

        }
    }
    private IEnumerator Reload()
    {

        for (int x = 0; x < particals.Length; x++)
        {
            particals[x].Stop();
        }
        yield return new WaitForSeconds(reloadTime);
        BulletsNumber = bulletCapacity;
        reloading = false;
        for (int x = 0; x < particals.Length; x++)
        {
            particals[x].Play();

        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, blindArea);
    }

}
