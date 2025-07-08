﻿using FoodBook.Domain;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public List<MenuItem> MenuItems { get; set; } = new();
    public List<Reservation> Reservations { get; set; } = new();
}