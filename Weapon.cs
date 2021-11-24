using System;

public class Weapon
{
    private readonly int _damage;
    private int _bullets;
    private bool _isCanFire;

    public Weapon(int damage, int bullets)
    {
        _bullets = bullets;
        _damage = damage;
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage));    
    }

    public void Fire(Player player)
    {
        if (_isCanFire)
        {
            _isCanFire = false;
            _bullets = ReduceCount(_bullets);
            player.TakeDamage(_damage);
        }
        else
            throw new InvalidOperationException(nameof(_isCanFire));
    }

    public bool CanFire(Player player)
    {
        _isCanFire = ReduceCount(_bullets) >= 0;
        _isCanFire &= player != null;
        return _isCanFire;
    }

    private int ReduceCount(int count)
    {
        return count - 1;
    }
}

public class Player
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