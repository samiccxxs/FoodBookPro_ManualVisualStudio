﻿public class Payment
{
    public int Id { get; set; }
    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; }
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; }
    public DateTime PaymentDate { get; set; }
    public Transaction Transaction { get; set; }
}