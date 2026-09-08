using System;

public interface IPayable
{
    bool ProcessPayment(decimal amount);
}


public interface IRefundable
{
    bool ProcessRefund(
        decimal amount,
        string reason);
}


public abstract class PaymentGateway
{
    public string TransactionId { get; init; }

    public DateTime CreationDate { get; init; }

    public string Status { get; protected set; }

    protected PaymentGateway(
        string transactionId)
    {
        TransactionId = transactionId;
        CreationDate = DateTime.Now;
        Status = "pending";
    }

    public abstract void ValidateConnection();

    public virtual void LogTransaction(
        string message)
    {
        string transactionText =
            $"ma giao dich {TransactionId}";

        Console.WriteLine(transactionText);

        Console.WriteLine(message);
    }
}


public class MomoPayment :
    PaymentGateway,
    IPayable,
    IRefundable
{
    public string PhoneNumber { get; set; }

    public MomoPayment(
        string transactionId,
        string phoneNumber)
        : base(transactionId)
    {
        PhoneNumber = phoneNumber;
    }

    public override void ValidateConnection()
    {
        string checkingText =
            "dang kiem tra ket noi api momo";

        Console.WriteLine(checkingText);

        string successText =
            "ket noi api momo thanh cong";

        Console.WriteLine(successText);
    }

    public bool ProcessPayment(
        decimal amount)
    {
        if (amount <= 0)
        {
            string errorText =
                "thanh toan that bai so tien khong hop le";

            LogTransaction(errorText);

            return false;
        }

        if (string.IsNullOrWhiteSpace(PhoneNumber))
        {
            string errorText =
                "thanh toan that bai so dien thoai khong hop le";

            LogTransaction(errorText);

            return false;
        }

        Status = "success";

        string successText =
            $"thanh toan thanh cong {amount:N0} vnd";

        LogTransaction(successText);

        return true;
    }

    public bool ProcessRefund(
        decimal amount,
        string reason)
    {
        if (amount <= 0)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(reason))
        {
            return false;
        }

        Status = "refunded";

        string refundText =
            $"hoan tien {amount:N0} vnd";

        LogTransaction(refundText);

        string reasonText =
            $"ly do {reason}";

        LogTransaction(reasonText);

        return true;
    }
}


class Program
{
    static void Main()
    {
        string title = "bai tap 4";
        Console.WriteLine(title);


        Console.WriteLine("nhap ma giao dich");
        string transactionId =
            Console.ReadLine() ?? "";


        Console.WriteLine("nhap so dien thoai");
        string phoneNumber =
            Console.ReadLine() ?? "";


        MomoPayment momo =
            new MomoPayment(
                transactionId,
                phoneNumber);


        string transactionText =
            $"ma giao dich {momo.TransactionId}";

        Console.WriteLine(transactionText);


        string statusText =
            $"trang thai {momo.Status}";

        Console.WriteLine(statusText);


        momo.ValidateConnection();


        Console.WriteLine("nhap so tien thanh toan");
        decimal paymentAmount =
            decimal.Parse(Console.ReadLine() ?? "0");


        IPayable payable = momo;

        bool paymentResult =
            payable.ProcessPayment(
                paymentAmount);


        string paymentResultText =
            $"ket qua thanh toan {paymentResult}";

        Console.WriteLine(paymentResultText);


        string paymentStatusText =
            $"trang thai {momo.Status}";

        Console.WriteLine(paymentStatusText);


        Console.WriteLine("nhap so tien hoan");
        decimal refundAmount =
            decimal.Parse(Console.ReadLine() ?? "0");


        Console.WriteLine("nhap ly do hoan tien");
        string refundReason =
            Console.ReadLine() ?? "";


        IRefundable refundable = momo;

        bool refundResult =
            refundable.ProcessRefund(
                refundAmount,
                refundReason);


        string refundResultText =
            $"ket qua hoan tien {refundResult}";

        Console.WriteLine(refundResultText);


        string refundStatusText =
            $"trang thai {momo.Status}";

        Console.WriteLine(refundStatusText);
    }
}
