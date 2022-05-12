
using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    public enum Target {
        Player,
        Enemy
    }
    public Target targetType;
    //bools 
    public bool shooting, readyToShoot, reloading;

    //Reference
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        //SetText
        if(text && !reloading)
            text.SetText(bulletsLeft + " / " + magazineSize);
    }
    public void MyInput(bool auto = false)
    {
        //if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        if (auto) shooting = true;
        //else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        if (auto && bulletsLeft == 0 && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0){
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = attackPoint.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(attackPoint.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag(targetType.ToString()))
            {
                if (targetType == Target.Enemy)
                    rayHit.collider.GetComponent<Turret>().GetDamage(damage);
                if (targetType == Target.Player)
                    rayHit.collider.GetComponent<Player>().GetDamage(damage);
            }
        }

        //Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
        Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    public void Reload()
    {
        if (bulletsLeft >= magazineSize || reloading) return;
        reloading = true;
        if(text)
        text.text = "Reloading";
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
