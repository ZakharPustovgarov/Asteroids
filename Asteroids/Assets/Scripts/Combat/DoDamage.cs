using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    // Тип урона
    [SerializeField]
    protected string m_damageType = "";

    // Тэги объектов, которым будет нанесён урон
    public List<string> tagsToDamage;

    // Проверка тега при входе в триггер
    void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log(this.name + " is collided with " + other.name);

        if (TagCheck(other.tag))
        {
            UnityEngine.Debug.Log(this.name + " is damaging " + other.name);
            Damage(other);
        }
    }

    // Нанесение урона соответсвующим типом
    protected virtual void Damage(Collider2D enemy)
    {
        enemy.GetComponent<IDamagable>().TakeDamage(m_damageType);
    }

    // Функция на проверку тэга
    protected bool TagCheck(string otherTag)
    {
        foreach(string tag in tagsToDamage)
        {
            if (tag == otherTag) return true;
        }

        return false;
    }
}
