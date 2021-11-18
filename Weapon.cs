using System;

class Weapon
{
    private int _damage, _maxBullets;
    public int Bullets { get; private set; }

    public Weapon(int damage, int bullets)
    {
        if (bullets > 0 && damage > 0)
        {
            _maxBullets = Bullets = bullets;
            _damage = damage;
        }
        else
            throw new ArgumentOutOfRangeException();
    }

    public void Fire(Player player)
    {
        if( Bullets > 0)
        {
            player?.TakeDamage(_damage):throw new NullReferenceException();
            Bullets -= 1;
        }
        else
            throw new InvalidOperationException();           
    }

    public void Reload()
    {
            Bullets = _maxBullets;
    }
}

class Player
{
    public int Health { get; private set; }
    public bool IsAlive { get; private set; }

    public Player(int health)
    {
        if (health > 0)
        {
            Health = health;
            IsAlive = true;
        }
        else
            throw new ArgumentOutOfRangeException();
    }

    public void TakeDamage(int damage)
    {
        if (IsAlive && damage > 0)
        {
            Health -= damage;
            if (Health < 0)
                PlayerDeath();
        }
        else
            throw new InvalidOperationException();
    }

    private void PlayerDeath()
    {
        Health = 0;
        IsAlive = false;
    }
}

class Bot
{
    public Weapon Weapon;

    public void OnSeePlayer(Player player)
    {
        if (Weapon != null)
            if (Weapon.Bullets > 0)
                Weapon.Fire(player);
            else
                Weapon.Reload();
        else
            throw new NullReferenceException();
    }
}