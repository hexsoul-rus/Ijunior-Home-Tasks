using System;

public class Weapon
{
    private readonly int _damage;
    private int _bulletsCount;
    private int _bulletsPerShot;

    public Weapon(int damage, int bulletsCount, int bulletsPerShot)
    {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _bulletsCount = bulletsCount;
        _damage = damage;
        _bulletsPerShot = bulletsPerShot;
    }

    public void Fire(Player player)
    {
        if (CanFire(player) == false)
            throw new InvalidOperationException();

        _bulletsCount -= _bulletsPerShot;
        player.TakeDamage(_damage);    
    }

    public bool CanFire(Player player)
    {
        return _bulletsCount - _bulletsPerShot >= 0 && player != null;
    }
}

public class Player
{
    public int Health { get; private set; }
    private bool IsDead;

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

public class Bot
{
    private readonly Weapon _weapon;

    public Bot(Weapon weapon)
    {
        if (weapon == null)
            throw new NullReferenceException(nameof(weapon));

        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        if (_weapon.CanFire(player))
            _weapon.Fire(player);
        else
            throw new InvalidOperationException();
    }
}