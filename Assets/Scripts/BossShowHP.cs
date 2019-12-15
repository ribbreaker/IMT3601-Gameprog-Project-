using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShowHP : MonoBehaviour
{
    [SerializeField] Texture2D healthTexture;
    float HP;

    private void Start()
    {
        HP = gameObject.GetComponent<EnemyController>().HP;
    }
    private void Update()
    {
        HP = gameObject.GetComponent<EnemyController>().HP;
    }
    void OnGUI()
    {
        GUI.Label(new Rect(400, 20, 50, 50), "Bandit king");
        for (int i = 1; i <= HP; i++)
        {
            GUI.DrawTexture(new Rect((400 + i * 50), 20, 50, 50), healthTexture);
        }
    }
   
}
