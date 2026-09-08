using System;
using System.Collections.Generic;

public class DiscountCalculator
{
    public decimal ApplyDiscount(
        decimal totalAmount)
    {
        decimal defaultPercentage = 5;

        decimal discount =
            totalAmount * defaultPercentage / 100;

        return totalAmount - discount;
    }

    public decimal ApplyDiscount(
        decimal totalAmount,
        double percentage)
    {
        double minimumPercentage = 0;
        double maximumPercentage = 100;

        if (percentage < minimumPercentage ||
            percentage > maximumPercentage)
        {
            string errorMessage =
                "phan tram giam phai tu 0 den 100";

            throw new ArgumentException(errorMessage);
        }

        decimal discount =
            totalAmount * (decimal)percentage / 100;

        return totalAmount - discount;
    }

    public decimal ApplyDiscount(
        decimal totalAmount,
        decimal fixedVoucher,
        decimal minimumOrder)
    {
        if (totalAmount >= minimumOrder)
        {
            decimal result =
                totalAmount - fixedVoucher;

            if (result < 0)
            {
                result = 0;
            }

            return result;
        }

        return totalAmount;
    }
}


public class DeliveryService
{
    public string OrderId { get; set; }

    public double DistanceKm { get; set; }

    public DeliveryService(
        string orderId,
        double distanceKm)
    {
        OrderId = orderId;
        DistanceKm = distanceKm;
    }

    public virtual decimal CalculateShippingFee()
    {
        decimal pricePerKm = 5000;

        return (decimal)DistanceKm * pricePerKm;
    }
}


public class ExpressDelivery : DeliveryService
{
    public ExpressDelivery(
        string orderId,
        double distanceKm)
        : base(orderId, distanceKm)
    {
    }

    public override decimal CalculateShippingFee()
    {
        decimal basicFee =
            base.CalculateShippingFee();

        decimal expressMultiplier = 1.5m;
        decimal expressSurcharge = 20000;

        return basicFee * expressMultiplier
            + expressSurcharge;
    }
}


public class EcoDelivery : DeliveryService
{
    public EcoDelivery(
        string orderId,
        double distanceKm)
        : base(orderId, distanceKm)
    {
    }

    public override decimal CalculateShippingFee()
    {
        decimal basicFee =
            base.CalculateShippingFee();

        double maximumEcoDistance = 10;
        decimal ecoDiscount = 0.9m;

        if (DistanceKm > maximumEcoDistance)
        {
            return basicFee * ecoDiscount;
        }

        return basicFee;
    }
}


class Program
{
    static void Main()
    {
        string title = "bai tap 3";
        Console.WriteLine(title);


        DiscountCalculator calculator =
            new DiscountCalculator();


        Console.WriteLine("nhap tong tien don hang");
        decimal orderAmount =
            decimal.Parse(Console.ReadLine() ?? "0");


        decimal defaultDiscount =
            calculator.ApplyDiscount(orderAmount);

        string defaultResult =
            $"ket qua giam mac dinh {defaultDiscount:N0} vnd";

        Console.WriteLine(defaultResult);


        Console.WriteLine("nhap phan tram giam");
        double discountPercentage =
            double.Parse(Console.ReadLine() ?? "0");

        decimal percentageDiscount =
            calculator.ApplyDiscount(
                orderAmount,
                discountPercentage);

        string percentageResult =
            $"ket qua giam theo phan tram {percentageDiscount:N0} vnd";

        Console.WriteLine(percentageResult);


        Console.WriteLine("nhap gia tri voucher");
        decimal voucher =
            decimal.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("nhap gia tri don hang toi thieu");
        decimal minimumOrder =
            decimal.Parse(Console.ReadLine() ?? "0");

        decimal voucherDiscount =
            calculator.ApplyDiscount(
                orderAmount,
                voucher,
                minimumOrder);

        string voucherResult =
            $"ket qua giam bang voucher {voucherDiscount:N0} vnd";

        Console.WriteLine(voucherResult);


        List<DeliveryService> deliveries =
            new List<DeliveryService>();


        Console.WriteLine("nhap ma don hang thu nhat");
        string orderId1 =
            Console.ReadLine() ?? "";

        Console.WriteLine("nhap khoang cach don hang thu nhat");
        double distance1 =
            double.Parse(Console.ReadLine() ?? "0");

        DeliveryService delivery1 =
            new DeliveryService(
                orderId1,
                distance1);

        deliveries.Add(delivery1);


        Console.WriteLine("nhap ma don hang thu hai");
        string orderId2 =
            Console.ReadLine() ?? "";

        Console.WriteLine("nhap khoang cach don hang thu hai");
        double distance2 =
            double.Parse(Console.ReadLine() ?? "0");

        ExpressDelivery delivery2 =
            new ExpressDelivery(
                orderId2,
                distance2);

        deliveries.Add(delivery2);


        Console.WriteLine("nhap ma don hang thu ba");
        string orderId3 =
            Console.ReadLine() ?? "";

        Console.WriteLine("nhap khoang cach don hang thu ba");
        double distance3 =
            double.Parse(Console.ReadLine() ?? "0");

        EcoDelivery delivery3 =
            new EcoDelivery(
                orderId3,
                distance3);

        deliveries.Add(delivery3);


        string shippingTitle =
            "phi van chuyen";

        Console.WriteLine(shippingTitle);


        foreach (DeliveryService delivery in deliveries)
        {
            string orderText =
                $"ma don hang {delivery.OrderId}";

            Console.WriteLine(orderText);

            string typeText =
                $"loai giao hang {delivery.GetType().Name}";

            Console.WriteLine(typeText);

            decimal shippingFee =
                delivery.CalculateShippingFee();

            string feeText =
                $"phi van chuyen {shippingFee:N0} vnd";

            Console.WriteLine(feeText);
        }
    }
}
