using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{

    [SerializeField]
    protected float HP;
    protected bool immune;

    protected float maxHP;

    protected float healthLost;
    protected CameraPerspectiveZoom mainCamera;

    protected void Start()
    {
        mainCamera = Camera.main.GetComponent<CameraPerspectiveZoom>();
    }

    public float getHP()
    {
        return HP;
    }

    public float getMaxHP()
    {
        return maxHP;
    }

    public void setHP(float newHP)
    {
        HP = newHP;
    }

    public void takeDamage(float damage)
    {
        HP = HP - damage;
        healthLost += damage;
    }

    public bool isImmune()
    {
        return immune;
    }

    public static void ShuffleArray<T>(T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i + 1);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }
}
