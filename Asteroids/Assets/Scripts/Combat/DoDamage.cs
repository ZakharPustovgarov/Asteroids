using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    // ��� �����
    [SerializeField]
    protected string damageType = "";

    // ���� ��������, ������� ����� ������ ����
    public List<string> tagsToDamage;

    // ������ ��� ����������� �����������
    [SerializeField]
    public Sprite otherSprite;

    //[SerializeField]
    //GameObject polyPrefab;

    //[SerializeField]
    //GameObject spritePrefab;

    SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        UnityEngine.Debug.Log("Trying to get renderer");

        spriteRenderer = this.GetComponent<SpriteRenderer>();

        if(spriteRenderer != null) UnityEngine.Debug.Log(this.name + " has renderer");
        else UnityEngine.Debug.Log(this.name + " has NO renderer");
    }

    // �������� ���� ��� ����� � �������
    void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log(this.name + " is collided with " + other.name);

        if (TagCheck(other.tag))
        {
            UnityEngine.Debug.Log(this.name + " is damaging " + other.name);
            Damage(other);
        }
    }

    // ��������� ����� �������������� �����
    protected virtual void Damage(Collider2D enemy)
    {
        enemy.GetComponent<IDamagable>().TakeDamage(damageType);
    }

    // ������� �� �������� ����
    protected bool TagCheck(string otherTag)
    {
        foreach(string tag in tagsToDamage)
        {
            if (tag == otherTag) return true;
        }

        return false;
    }

    public virtual void ReplaceSprite()
    {
        Sprite buf = spriteRenderer.sprite;

        spriteRenderer.sprite = otherSprite;

        otherSprite = buf;
    }
}
