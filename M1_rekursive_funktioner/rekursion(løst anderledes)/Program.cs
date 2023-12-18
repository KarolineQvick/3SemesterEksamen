

    int Faculty(int n)
    {

        // Termineringsregel: 0! = 1

        if (n == 0)
        {
            return 1;
        }

        // Rekurrensregel: n! = n * (n - 1)! hvor n > 0

        return n * Faculty(n - 1);

    }

Console.WriteLine("Faculty(5): " + Faculty(5));

int Euclid(int a, int b)
    {
        // Termineringsregel: b hvis b <= a og b går op i a.
        if (b <= a && a % b == 0)
        {
            return b;
        }

        // Rekurrensregel: sfd(b, a) hvis a<b, ellers sfd(b, a % b)
        if (a < b) {
            return Euclid(b, a);
        }
        else
        {
            return Euclid(b, a % b);
        }

    }

Console.WriteLine("Euclid(50, 45: " + Euclid(50, 45));

// PowerOf()-metoden tager udgangspunkt i positive heltal.
int PowerOf(int n, int p)
{

    // Termineringsregel: n⁰ = 1
    if (p == 0)
    {
        return 1;
    }

    // Rekurrensregel: np = n(p - 1) * n, hvor p > 0.
    return n * PowerOf(n, p-1);

}
Console.WriteLine("PowerOf(5, 6): " + PowerOf(5, 6));


int Multiplication(int a, int b)
{

    // Termineringsregel:
    // 0 * b = 0
    if (a == 0)
    {
        return 0;
    }
    // Rekurrensregel: a* b = (a - 1) * b + b hvor a > 1
    else if (a > 1)
    {
        return b + Multiplication(a - 1, b);
    }
    // Termineringsregel:
    // 1 * b = b
    else return b;

}

Console.WriteLine("Multiplication(5, 30): " + Multiplication(5, 30));

string ReverseString(string s)
{
    Console.WriteLine(s);

    if (s.Length == 1)
    {
        return s;
    }
    return ReverseString(s.Substring(1)) + s[0];
}

Console.WriteLine("ReverseString(BANANKAGE): " + ReverseString("BANANKAGE"));

