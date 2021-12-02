using System.Text;
using System.Security.Cryptography;
using System;

class Programm
{
    static void Main(string[] args)
    {
        //Выведите платёжные ссылки для трёх разных систем платежа: 
        //pay.system1.ru/order?amount=12000RUB&hash={MD5 хеш ID заказа}
        //order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
        //system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}
        var order = new Order(54, 12000);
        string secretKey = "F8A965";
        string currency = "RUB";

        var ps = new PaymentSystem1(currency);
        Console.WriteLine(ps.GetPayingLink(order));
        var ps2 = new PaymentSystem2();
        Console.WriteLine(ps2.GetPayingLink(order));
        var ps3 = new PaymentSystem3(currency, secretKey);
        Console.WriteLine(ps3.GetPayingLink(order));
    }
}

public class Order
{
    public readonly int Id;
    public readonly int Amount;

    public Order(int id, int amount) => (Id, Amount) = (id, amount);
}

public class PaymentSystem1 : IPaymentSystem
{
    private readonly string _curency;

    public PaymentSystem1(string curency)
    {
        _curency = curency;
    }

    public string GetPayingLink(Order order)
    {
        var link = "//pay.system1.ru/order?";
        var amount = order?.Amount.ToString();
        var id = order?.Id.ToString();
        var linkParameters = new LinkParameter(amount + _curency, "amount")
            .AddLinkParameter(new LinkParameter(new HashSystem(new MD5Hash()).GetHash(id), "hash"));
        return link + linkParameters.GetLinkParameter();
    }
}

public class PaymentSystem2 : IPaymentSystem
{
    public string GetPayingLink(Order order)
    {
        var link = "//order.system2.ru/pay?";
        var amount = order?.Amount.ToString();
        var id = order?.Id.ToString();
        var linkParameters = new LinkParameter(new HashSystem(new MD5Hash()).GetHash(amount + id), "hash");
        return link + linkParameters.GetLinkParameter();
    }
}

public class PaymentSystem3 : IPaymentSystem
{
    private readonly string _curency, _key;

    public PaymentSystem3(string curency, string key)
    {
        _curency = curency;
        _key = key;
    }

    public string GetPayingLink(Order order)
    {
        var link = "//system3.com/pay?";
        var amount = order?.Amount.ToString();
        var id = order?.Id.ToString();
        var linkParameters = new LinkParameter(amount, "amount").AddLinkParameter(new LinkParameter(_curency, "curency")
            .AddLinkParameter(new LinkParameter(new HashSystem(new SHA1Hash()).GetHash(amount + id + _key), "hash")));
        return link + linkParameters.GetLinkParameter();
    }
}

public class HashSystem
{
    private readonly iHashSystem _hashProvider;

    public HashSystem (iHashSystem hashProvider)
    {
        if(hashProvider == null)
            throw new ArgumentNullException(nameof(hashProvider));
        _hashProvider = hashProvider;
    }

    public string GetHash(string value)
    { 
        return ByteToString(_hashProvider.GetHash(value));
    }

    private string ByteToString(byte[] hash)
    {
        var sb = new StringBuilder(hash.Length * 2);
        foreach (byte b in hash)
            sb.Append(b.ToString("X2"));
        return sb.ToString();
    }
}

public class MD5Hash : iHashSystem
{
    public byte[] GetHash(string value)
    {
        var cryptoProvider = new MD5CryptoServiceProvider();
        var hash = cryptoProvider.ComputeHash(Encoding.UTF8.GetBytes(value));
        return hash;
    }
}

public class SHA1Hash : iHashSystem
{
    public byte[] GetHash(string value)
    {
        var cryptoProvider = new SHA1Managed();
        var hash = cryptoProvider.ComputeHash(Encoding.UTF8.GetBytes(value));
        return hash;
    }
}

public class LinkParameter : ILinkParameter
{
    private string _parameter;

    public LinkParameter(string value, string name)
    {
        _parameter = name + "=" + value;
    }

    public ILinkParameter AddLinkParameter(ILinkParameter newLinkParameter)
    {
        if (newLinkParameter == null)
            throw new ArgumentNullException(nameof(newLinkParameter));
        _parameter += "&" + newLinkParameter.GetLinkParameter();
        return this;
    }

    public string GetLinkParameter()
    {
        return _parameter;
    }
}

public interface IPaymentSystem
{
    public string GetPayingLink(Order order);
}

public interface ILinkParameter
{
    public string GetLinkParameter();
    public ILinkParameter AddLinkParameter(ILinkParameter newLinkParameter);
}

public interface iHashSystem
{
    public byte[] GetHash(string value);
}