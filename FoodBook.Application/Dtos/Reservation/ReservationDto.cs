public class ReservationDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FoodItemId { get; set; }
    public DateTime ReservationDateTime { get; set; }
    public int NumberOfPeople { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
    public DateTime CreatedDate { get; set; }

}