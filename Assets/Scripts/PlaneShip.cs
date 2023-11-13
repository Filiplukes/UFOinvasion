using UnityEngine;

public class PlaneShip : EnemyShip
{

    public GameObject backMenu;
    private GameObject ad;
    public GameObject shieldBuff;

    protected override void Start()
    {
        hpBar = GameObject.Find("Main Camera/HpCanvas/HpBar").GetComponent<HeatlhBar>();
        base.Start();
        ad = GameObject.Find("AdIns");
        
    }


    protected override void DestoyShip() { 
          
        base.DestoyShip();
        Destroy(transform.parent.gameObject);
        FindAnyObjectByType<AudioManager>().Play("PlayerExplosion"); 
        if(ad != null) { ad.GetComponent<AdIns>().ShowInterstitialAd(); }
        
        Instantiate(backMenu);       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
   
        if (collision.CompareTag("SpeedBuff"))
        {
            GameObject buff = collision.gameObject;
            try { 
            gameObject.GetComponent<Attack>().buffSpeed(buff.GetComponent<BuffScript>().getStat());     
            buff.GetComponent<BuffScript>().DestroyBuff();
            }
            catch
            {
                Debug.Log("Buff nots here ");
            }

        }


        if (collision.CompareTag("DmgBuff"))
        {
            GameObject buff = collision.gameObject;
            try { 
            gameObject.GetComponent<Attack>().buffDmg(buff.GetComponent<DMGBuff>().getStatDMG());
            buff.GetComponent<BuffScript>().DestroyBuff();
                 }
            catch
                {
            Debug.Log("Buff nots here ");
                 }

    }


        if (collision.CompareTag("HealBuff"))
        {
            GameObject buff = collision.gameObject;
            try
            {
                Heal(buff.GetComponent<HealBuf>().getStatHeal());
                buff.GetComponent<BuffScript>().DestroyBuff();
            }
            catch {
                Debug.Log("Buff nots here ");
                }

        }

        if (collision.CompareTag("HealBuff1"))
        {
            GameObject buff = collision.gameObject;
            Heal(buff.GetComponent<HealBuf1>().getStatHeal());
            buff.GetComponent<BuffScript>().DestroyBuff();

        }

        if (collision.CompareTag("ShieldBuff"))
        {
            shieldBuff.SetActive(true);
            shieldBuff.GetComponent<Shield>().SetActiveTime();
            GameObject buff = collision.gameObject;
            try { 
            buff.GetComponent<BuffScript>().DestroyBuff();
            }
            catch
            {
                Debug.Log("Buff nots here ");
            }


        }

        if (collision.CompareTag("Coin"))
        {
            GameObject buff = collision.gameObject;
            try {buff.GetComponent<BuffScript>().DestroyBuff();

            string coins = PlayerPrefs.GetString("Coins");
            if (coins == "") { coins = "0"; }
            coins = (1 + long.Parse(coins)).ToString();
            PlayerPrefs.SetString("Coins", coins);
            }
                catch
            {
                Debug.Log("Buff nots here ");
            }
    }

    }


    private void Heal(int heal) {

        hp += heal;
        if (hp > 100) hp = 100; 
        hpBar.setHealth(hp);
        checkHP(hp);

    }


    public new void TakeDamage(int Damage)
    {
        if (!shieldBuff.activeSelf) { 
            base.TakeDamage(Damage);
        } 

    }

}
