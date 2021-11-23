using System;

class Weapon
{
    private readonly int _damage, _maxBullets;
    public int Bullets { get; private set; }

    public Weapon(int damage, int bullets)
    {
        _maxBullets = Bullets = bullets;
        _damage = damage;
        if (CheckLoad() == false)
            throw new ArgumentOutOfRangeException(nameof(bullets));
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage));    
    }

    public bool CheckLoad()
    {
        return Bullets > 0;
    }

    public void Fire(Player player)
    {
        if (CheckLoad() == false)
            throw new InvalidOperationException();
        player?.TakeDamage(_damage):throw new NullReferenceException(nameof(player));
        Bullets -= 1;          
    }

    public void Reload()
    {
        Bullets = _maxBullets;
    }
}

class Player
{
    public int Health { get; private set; }
    public bool IsDead { get; private set; }

    public Player(int health)
    {
        if (health <= 0)
            throw new ArgumentOutOfRangeException(nameof(health));
        Health = health;      
    }

    public void TakeDamage(int damage)
    {
        if (IsDead)
            throw new InvalidOperationException();
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage));
        Health -= damage;
        if (Health < 0)
        {
            Health = 0;
            Dying();
        }
    }

    private void Dying()
    {    
        IsDead = true;
    }
}

class Bot
{
    public Weapon Weapon;

    public void OnSeePlayer(Player player)
    {
        if (Weapon = null)
            throw new NullReferenceException(nameof(Weapon));
        if (Weapon.CheckLoad() == false)
            Weapon.Reload();
        Weapon.Fire(player);
    }
}