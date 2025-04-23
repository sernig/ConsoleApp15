public class Money
{
    private int hryvnias;
    private int kopecks;

    public Money(int hryvnias, int kopecks)
    {
        if (hryvnias < 0 || kopecks < 0) throw new BankruptException("Отрицательная сумма не может быть создана.");
        this.hryvnias = hryvnias + kopecks / 100;
        this.kopecks = kopecks % 100;
    }

    public static Money operator +(Money a, Money b)
    {
        return new Money(a.hryvnias + b.hryvnias, a.kopecks + b.kopecks);
    }

    public static Money operator -(Money a, Money b)
    {
        int totalKopecksA = a.hryvnias * 100 + a.kopecks;
        int totalKopecksB = b.hryvnias * 100 + b.kopecks;
        if (totalKopecksA < totalKopecksB) throw new BankruptException("Результат отрицательный.");
        return new Money(0, totalKopecksA - totalKopecksB);
    }

    public static Money operator /(Money a, int b)
    {
        if (b <= 0) throw new ArgumentException("Деление на ноль или отрицательное число.");
        return new Money(0, (a.hryvnias * 100 + a.kopecks) / b);
    }

    public static Money operator *(Money a, int b)
    {
        return new Money(0, (a.hryvnias * 100 + a.kopecks) * b);
    }

    public static Money operator ++(Money a)
    {
        return new Money(a.hryvnias, a.kopecks + 1);
    }

    public static Money operator --(Money a)
    {
        if (a.hryvnias == 0 && a.kopecks == 0) throw new BankruptException("Результат отрицательный.");
        return new Money(a.hryvnias, a.kopecks - 1);
    }

    public static bool operator <(Money a, Money b)
    {
        return (a.hryvnias * 100 + a.kopecks) < (b.hryvnias * 100 + b.kopecks);
    }

    public static bool operator >(Money a, Money b)
    {
        return (a.hryvnias * 100 + a.kopecks) > (b.hryvnias * 100 + b.kopecks);
    }

    public static bool operator ==(Money a, Money b)
    {
        return a.hryvnias == b.hryvnias && a.kopecks == b.kopecks;
    }

    public static bool operator !=(Money a, Money b)
    {
        return !(a == b);
    }

    public override string ToString()
    {
        return $"{hryvnias} грн {kopecks} коп";
    }

    public override bool Equals(object obj)
    {
        return obj is Money money && this == money;
    }

    public override int GetHashCode()
    {
        return (hryvnias, kopecks).GetHashCode();
    }
}

