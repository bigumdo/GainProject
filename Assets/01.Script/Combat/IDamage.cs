using UnityEngine;
public enum DamageTypeEnum
{
    None
}


public interface IDamage
{

    public void ApplyDamage(int damage);

}
