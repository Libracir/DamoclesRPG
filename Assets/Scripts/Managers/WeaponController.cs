using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public List<GameObject> Weapons;
    public List<GameObject> Projectiles;

    [System.Obsolete]

    public float cooldown = 0.5f;
    private float lastSwing;


    public void SpawnProjectile(GameObject obj)
    {
        GameObject missile = Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, this.transform);
        Projectile projectile = missile.GetComponent<Projectile>();
        missile.transform.rotation = Utils.AngleToMouse(missile.transform);
        projectile.transform.parent = null;
    }

    public void SwapWeapon(GameObject obj)
    {
        DestroyWeapon();
        CreateWeapon(obj);
    }
    private void CreateWeapon(GameObject obj)
    {
        GameObject weapon = Instantiate(obj, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, this.transform);
        weapon.name = "Weapon";
        weapon.transform.localPosition = new Vector3(0, 1, 0);
        weapon.transform.parent = this.transform;
    }
    private void DestroyWeapon()
    {
        Destroy(GameObject.Find("Weapon"));
    }
    public void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                SpawnProjectile(Projectiles[0]);
            }
        }
    }
}
