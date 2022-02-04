class Weapon
{
    private const int _bulletsConsumption = 1;

    private int _bullets;

    public bool CanShoot() => _bullets >= _bulletsConsumption;

    public void Shoot() => _bullets -= _bulletsConsumption;
}