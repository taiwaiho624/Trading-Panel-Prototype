using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Floating
{
    public const double Epsilon = 0.000000001;
    public static bool IsEqual(double a, double b)
    {
        if (Math.Abs(b - a) < Epsilon)
            return true;
        else
            return false;
    }

    public static bool LargeT(double a, double b)
    {
        if ((a - b) > Epsilon)
            return true;
        else
            return false;
    }

    public static bool LessT(double a, double b)
    {
        if ((b - a) > Epsilon)
            return true;
        else
            return false;
    }

    public static bool LargeET(double a, double b)
    {
        if (IsEqual(a, b))
            return true;
        else
        {
            if ((a - b) > Epsilon)
                return true;
            else
                return false;
        }
    }

    public static bool LessET(double a, double b)
    {
        if (IsEqual(a, b))
            return true;
        else
        {
            if ((b - a) > Epsilon)
                return true;
            else
                return false;

        }
    }
}

public class SpreadTable
{
    public static bool IsTightSpread(double bid, double ask)
    {
        if (bid.Equals(double.NaN) || ask.Equals(double.NaN))
            return false;
        double nextDownPrice = ReturnNextDownPrice(ask);
        return Floating.IsEqual(nextDownPrice, bid);
    }

    public static bool IsSecTightSpread(double bid, double ask)
    {
        if (bid.Equals(double.NaN) || ask.Equals(double.NaN))
            return false;
        double nextDownPrice = ReturnNextDownPrice(ask);
        return (Floating.IsEqual(nextDownPrice, bid) || Floating.IsEqual(nextDownPrice, ReturnNextDownPrice(ask)));
    }
    //diff=b-a
    public static int ReturnSpreadDiff(double a, double b)
    {
        if (Floating.LargeT(a, b))
        {
            int spreadCounter = 0;
            double adjVal = b;
            for (int i = 0; i < 50; ++i)
            {
                adjVal = ReturnNextUpPrice(adjVal);
                ++spreadCounter;
                if (!Floating.LargeT(a, adjVal))
                    return -spreadCounter;
            }
        }
        else if (Floating.LessT(a, b))
        {
            int spreadCounter = 0;
            double adjVal = a;
            for (int i = 0; i < 50; ++i)
            {
                adjVal = ReturnNextUpPrice(adjVal);
                ++spreadCounter;
                if (!Floating.LessT(adjVal, b))
                    return spreadCounter;
            }
        }
        else
            return 0;
        return 100;
    }

    public static double ReturnUpSpread(double price)
    {
        double spread = double.NaN;
        spread = 0d;
        if (0.01 <= price && price < 0.25)
            spread = 0.001;
        else if (0.25 <= price && price < 0.50)
            spread = 0.005;
        else if (0.50 <= price && price < 10.00)
            spread = 0.010;
        else if (10.00 <= price && price < 20.00)
            spread = 0.020;
        else if (20.00 <= price && price < 100.00)
            spread = 0.050;
        else if (100.00 <= price && price < 200.00)
            spread = 0.100;
        else if (200.00 <= price && price < 500.00)
            spread = 0.200;
        else if (500.00 <= price && price < 1000.00)
            spread = 0.500;
        else
            spread = 1; // assume HSI or HSCE
        spread = Math.Round(spread, 3);
        return spread;
    }

    public static double ReturnDownSpread(double price)
    {
        double spread = double.NaN;
        spread = 0d;
        if (0.01 <= price && price <= 0.25)
            spread = 0.001;
        else if (0.25 < price && price <= 0.50)
            spread = 0.005;
        else if (0.50 < price && price <= 10.00)
            spread = 0.010;
        else if (10.00 < price && price <= 20.00)
            spread = 0.020;
        else if (20.00 < price && price <= 100.00)
            spread = 0.050;
        else if (100.00 <= price && price <= 200.00)
            spread = 0.100;
        else if (200.00 < price && price <= 500.00)
            spread = 0.200;
        else if (500.00 < price && price <= 1000.00)
            spread = 0.500;
        else
            spread = 1; // assume HSI or HSCE
        spread = Math.Round(spread, 3);
        return spread;
    }

    public static double ReturnNextUpPrice(double price)
    {
        return Math.Round(price + ReturnUpSpread(price), 4);
    }
    public static double ReturnNextDownPrice(double price)
    {
        return Math.Round(price - ReturnDownSpread(price), 4);
    }
    public static double ReturnNextUpPrice(double price, double pent)
    {
        pent = Math.Round(pent, 2);
        return Math.Round(price + pent * ReturnUpSpread(price), 4);
    }
    public static double ReturnNextDownPrice(double price, double pent)
    {
        pent = Math.Round(pent, 2);
        return Math.Round(price - pent * ReturnDownSpread(price), 4);
    }
    public static double ReturnNextUpPrice(double price, int n)
    {
        for (int i = 0; i < n; i++)
        {
            price = Math.Round(SpreadTable.ReturnNextUpPrice(price), 4);
        }
        return price;
    }
    public static double ReturnNextDownPrice(double price, int n)
    {
        for (int i = 0; i < n; i++)
        {
            price = Math.Round(SpreadTable.ReturnNextDownPrice(price), 4);
        }
        return price;
    }
}